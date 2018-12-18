﻿using System.Collections.Generic;
using TMNAdapter_Demo_SpecFlow.Common;

namespace TMNAdapter_Demo_SpecFlow.BaseObject
{
    public class BrowserContainer
    {
        public static Dictionary<string, Browser> _testBrowsers = new Dictionary<string, Browser>();

        public static Browser GetBrowser(string keyName) => _testBrowsers[keyName];

        public static Browser InitDriver(string keyName)
        {
            _testBrowsers.Add(keyName, new Browser());
            return GetBrowser(keyName);
        }

        public static void DeleteBrowser(string keyName)
        {
            _testBrowsers[keyName].Quit();
            _testBrowsers.Remove(keyName);
        }
    }
}
