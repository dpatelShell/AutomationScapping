using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace TestProject.Default
{
    public class TestController
    {
        public DriverController _driverController;
        
        /// <summary>
        /// Launch the browser during the running the test case
        /// </summary>
        public void LaunchApp()
        {
            var browser = "Edge";
            IWebDriver driver;
            string url;

            switch (browser)
            {
                case "IE":
                    // url = "http://localhost:26641/";
                    url = "http://www.epaylaundry.com/index.aspx?sid=1";
                    driver = new InternetExplorerDriver(@"..\..\DriverExE");
                    driver.Navigate().GoToUrl(url);
                    _driverController = new DriverController(driver,Browsers.IE);
                    break;

                case "Chrome":
                    url = "https://widi-prod.shell.com/Account/Login";
                    driver = new ChromeDriver(@"..\..\..\DriverExE");
                    driver.Navigate().GoToUrl(url);
                    _driverController = new DriverController(driver, Browsers.Chrome);
                    break;
                
                case "Firefox":
                    url = "http://www.epaylaundry.com/index.aspx?sid=1";

                    driver = new FirefoxDriver();
                    driver.Navigate().GoToUrl(url);
                    _driverController = new DriverController(driver, Browsers.Firefox);
                   break;
                case "Edge":
                    url = "https://widi-prod.shell.com/Account/Login";

                    driver = new EdgeDriver(EdgeDriverService.CreateDefaultService());
                    driver.Navigate().GoToUrl(url);
                    _driverController = new DriverController(driver, Browsers.Edge);
                    break;
            }
        }

        public void ShutDownApp()
        {
            try
            {
                 _driverController.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown: {0}\n", e.ToString());
            }
        }
    }
}
