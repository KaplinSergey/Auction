using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Auction.e2e.Steps
{
    [Binding]
    public sealed class Hooks: TechTalk.SpecFlow.Steps
    {
        private readonly int iisPort;
        private readonly string _applicationName;
        private Process _iisProcess;

        public Hooks()
        {
            int.TryParse(ConfigurationManager.AppSettings["iisPort"], out iisPort);
            _applicationName = "MvcPL";
        }

        [BeforeScenario]
        public void BeforScenario()
        {
            StartIIS();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var browser = this.ScenarioContext.Get<IWebDriver>("browser");
            if (_iisProcess.HasExited == false)
            {
                _iisProcess.Kill();
            }
            browser.Quit();
        }

        private void StartIIS()
        {
            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            _iisProcess = new Process();
            _iisProcess.StartInfo.FileName = programFiles + @"\IIS Express\iisexpress.exe";
            _iisProcess.StartInfo.Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationPath, iisPort);
            _iisProcess.Start();
        }


        private string GetApplicationPath(string applicationName)
        {
            var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            return Path.Combine(solutionFolder, applicationName);
        }
    }
}
