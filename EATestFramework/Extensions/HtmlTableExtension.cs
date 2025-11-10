using OpenQA.Selenium;
using System.Collections;
using System.Collections.ObjectModel;

namespace EATestFramework.Extensions
{
  public static class HtmlTableExtension
  {
    private static List<TableDataCollection> ReadTable(IWebElement table)
    {
      List<TableDataCollection> tableDataCollections = new();
      ReadOnlyCollection<IWebElement>? columns = table.FindElements(By.TagName("th"));
      ReadOnlyCollection<IWebElement>? rows = table.FindElements(By.TagName("tr"));

      int rowIndex = 0;
      foreach (var row in rows)
      {
        int colIndex = 0;
        var colDatas = row.FindElements(By.TagName("td"));

        if (colDatas.Count != 0)
        {
          foreach (var colValue in colDatas)
          {
            tableDataCollections.Add(new()
            {
              RowNumber = rowIndex,
              ColumnName = columns[colIndex].Text != "" ?
                           columns[colIndex].Text : colIndex.ToString(),
              ColumnValue = colValue.Text,
              ColumnSpecialValue = GetControl(colValue)
            });

            colIndex++;
          }
        }

        rowIndex++;
      }

      return tableDataCollections;
    }

    private static ColumnSpecialValue GetControl(IWebElement columnValue)
    {
      ColumnSpecialValue? columnSpecialValue = null;

      if (columnValue.FindElements(By.TagName("a")).Count > 0)
      {
        columnSpecialValue = new()
        {
          ElementCollections = columnValue.FindElements(By.TagName("a")),
          ControlType = ControlTypeEnum.hyperlink
        };
      }

      if (columnValue.FindElements(By.TagName("input")).Count > 0)
      {
        columnSpecialValue = new()
        {
          ElementCollections = columnValue.FindElements(By.TagName("input")),
          ControlType = ControlTypeEnum.input
        };
      }

      return columnSpecialValue;
    }

    public static void PerformActionOnCell(
        this IWebElement element,
        string targetColumnIndex,
        string refColumnName,
        string refColumnValue,
        string controlToOperate = null
    ){
      var table = ReadTable(element);

      foreach (int rowNumber in GetDynamicRowNumber(table, refColumnName, refColumnValue))
      {
        ColumnSpecialValue? cell = (from e in table
                                    where e.ColumnName == targetColumnIndex && e.RowNumber == rowNumber
                                    select e.ColumnSpecialValue).SingleOrDefault();

        if (controlToOperate != null && cell != null)
        {
          IWebElement? elementToClick = null;

          if (cell.ControlType == ControlTypeEnum.hyperlink)
          {
            elementToClick = (from c in cell.ElementCollections
                              where c.Text.ToLower() == controlToOperate.ToLower()
                              select c).SingleOrDefault();
          }

          if (cell.ControlType == ControlTypeEnum.input)
          {
            elementToClick = (from c in cell.ElementCollections
                              where c.GetAttribute("value") == controlToOperate.ToLower()
                              select c).SingleOrDefault();
          }

          elementToClick?.Click();
        }
        else
        {
          cell.ElementCollections?.First().Click();
        }
      }
    }

    private static IEnumerable GetDynamicRowNumber(List<TableDataCollection> tableCollection, string columnName, string columnValue)
    {
      foreach (var table in tableCollection)
      {
       if (table.ColumnName == columnName && table.ColumnValue == columnValue)
         yield return table.RowNumber;
      }
    }
  }

  public class TableDataCollection
  {
    public int RowNumber { get; set; }
    public string? ColumnName { get; set; }
    public string? ColumnValue { get; set; }
    public ColumnSpecialValue? ColumnSpecialValue { get; set; }
  }

  public class ColumnSpecialValue
  {
    public IEnumerable<IWebElement>? ElementCollections { get; set; }
    public ControlTypeEnum? ControlType { get; set; }
  }

  public enum ControlTypeEnum
  {
    hyperlink,
    input,
    option,
    select
  }
}