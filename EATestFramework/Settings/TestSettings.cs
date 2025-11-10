using System;
using EATestFramework.Driver;

namespace EATestFramework.Settings;

public class TestSettings
{
    public BrowserType BrowserType { get; set; }
    public string ApplicationUri { get; set; }
    public int TimeoutInterval { get; set; }
}
