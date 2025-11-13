namespace EAIntegrationTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:8001/");
        var response = client.Send(new HttpRequestMessage(HttpMethod.Get, "Product/GetProducts"));
        response.EnsureSuccessStatusCode();
    }
}
