using System;
using EATestFramework.Driver;

namespace EATestFramework.Settings;

public class TestSettings
{
    public BrowserType BrowserType { get; set; }
    public Uri ApplicationUri { get; set; }
    public int TimeoutInterval { get; set; }
    public Uri SeleniumGridUrl { get; set; }
}
