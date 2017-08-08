using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using System.Diagnostics;
using System.Configuration;

namespace Auction.e2e.Steps.Common
{
    [Binding]
    class CommonSteps: TechTalk.SpecFlow.Steps
    {
        private readonly string _applicationName;
        private readonly int iisPort;

        public CommonSteps()
        {
            int.TryParse(ConfigurationManager.AppSettings["iisPort"], out iisPort);
            _applicationName = "MvcPL";
        }

        public string GetAbsoluteUrl(string relativeUrl)
        {
            if (!relativeUrl.StartsWith("/"))
            {
                relativeUrl = "/" + relativeUrl;
            }
            return String.Format("http://localhost:{0}{1}", iisPort, relativeUrl);
        }

    }
}
