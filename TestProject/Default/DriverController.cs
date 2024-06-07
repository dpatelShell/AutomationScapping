using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject
{
    public enum Browsers
    {
        IE = 0,
        Chrome = 1,
        Firefox = 2,
        Edge = 3
    }
}

namespace TestProject.Default
{
    public class DriverController
    {
        public IWebDriver _driver;
        private const int _timeout = 10;

        public int Browser { get; private set; }

        public DriverController(IWebDriver driver, Browsers browser)
        {
            _driver = driver;
            if (browser.Equals(Browsers.IE))
            {
                Browser = 0;
            }
            else if (browser.Equals(Browsers.Chrome))
            {
                Browser = 1;
            }
            else if (browser.Equals(Browsers.Firefox))
            {
                Browser = 3;
            }
            else if (browser.Equals(Browsers.Edge))
            {
                Browser = 4;
            }
        }

        #region driver methods

        /*
         * Close Browser Window
         * 
         * */
        public void Close()
        {
            _driver.Close();
        }

        /*
         * Manage Driver Settings
         * 
         * */
        public IOptions Manage()
        {
            return _driver.Manage();
        }

        /*
         * Navigate Driver to location
         * 
         * */
        public INavigation Navigate()
        {
            return _driver.Navigate();
        }

        /*
         * Quit driver and close every window
         * 
         * */
        public void Quit()
        {
            _driver.Quit();
        }

        public IReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_timeout));
            wait.Until(ExpectedConditions.ElementExists(by));

            return _driver.FindElements(by);
        }
        public IReadOnlyCollection<IWebElement> FindElements(string by)
        {
            try
            {
                return FindElements(GetBy(by));
            }
            catch (Exception)
            {
                Assert.Fail("Cannot find element: {0}", by);
                return null;
            }
            // return FindElements(GetBy(by));
        }
        public IEnumerable<IWebElement> FindElements(IEnumerable<string> selectors)
        {
            return selectors.Select(FindElement);
        }

        /*
         * Find web elements By
         * 
         * */
        public IWebElement FindElement(By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_timeout));
            wait.Until(ExpectedConditions.ElementExists(by));

            return _driver.FindElement(by);
        }
        /*
         * Find web elements string using pattern: "ID==the_element_id"
         * for Css: "CssSelector==.css_class #css_id"
         * for XPath: "xpath==//div//p/span[1]"
         * for Class: "class==my_class"
         * for Tag Name: "tag==tag_name"
         * 
         * If identifier befor the "==" can not be read the value behind the "=="
         * will be used to get the element by name.
         * 
         * */
        public IWebElement FindElement(string by)
        {
            try
            {
                return FindElement(GetBy(by));
            }
            catch (Exception)
            {
                Assert.Fail("Cannot find element: {0}", by);
                return null;
            }
        }
        #endregion

        #region Input Field Methods
        /* 
         * Clear input field
         * 
         * */
        public void Clear(IWebElement elem)
        {
            elem.Clear();
        }
        public void Clear(string elem)
        {
            Clear(FindElement(elem));
        }

        /* 
         * Send keys to input field
         * 
         * */
        public void SendKeys(IWebElement elem, string text)
        {
            elem.Clear();
            elem.SendKeys(text);
            //_driver.Keyboard.SendKeys(text);
        }
        public void SendKeys(string elem, string text, int t = _timeout)
        {
            try
            {
                SendKeys(FindElement(elem), text);
            }
            catch (Exception)
            {
                Assert.Fail("Cannot send keys to elment: '{0}'", elem);
            }
        }

        /* 
         * Send keys to input field without clear
         * 
         * */
        public void SendKeysWithoutClear(IWebElement elem, string text)
        {
            elem.SendKeys(text);
        }
        public void SendKeysWithoutClear(string elem, string text, int t = _timeout)
        {
            try
            {
                SendKeysWithoutClear(FindElement(elem), text);
            }
            catch (Exception)
            {
                Assert.Fail("Cannot send keys to elment: '{0}'", elem);
            }
        }

        /*
         * Click at button
         *
         * */
        public void Click(IWebElement elem)
        {
            elem.Click();
        }
        public void Click(string elem, int t = _timeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(t));
                IWebElement element = (IWebElement)wait.Until(ExpectedConditions.ElementIsVisible(GetBy(elem)));
                element.Click();
            }
            catch (Exception)
            {
                Assert.Fail("Cannot click at Element located with: '{0}'", elem);
            }
        }

        public void CloseModal()
        {
            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();
        }

        #endregion

        #region Element Status
        /*
         * Compare checkbox status to given value
         * true: check if checkbox is checked
         * false: check if checkbox is unchecked
         * 
         * */
        public bool CheckboxIs(IWebElement checkbox, bool value)
        {
                return Boolean.Parse(checkbox.GetAttribute("checked")).Equals(value);
        }

        public bool CheckboxIs(string elem, bool value)
        {
            var checkbox = FindElement(elem);
            return CheckboxIs(checkbox, value);
        }

        /*
         * Compare radio status to given value
         * true: check if radio is checked
         * false: check if radio is unchecked
         * 
         * */
        public bool RadioIs(string elem, bool value)
        {
            return CheckboxIs(elem, value);
        }

        /*
         * Wait for timeout if element exists
         * 
         * */
        public bool Exists(string elem, int t = 1)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(t));
                wait.Until(ExpectedConditions.ElementExists(GetBy(elem)));
                return true;
            }
            //catch (NoSuchElementException)
            catch (Exception)
            {
                return false;
            }
        }

        public bool Exists(string elem, string value)
        {
            try
            {
                IReadOnlyCollection<IWebElement> elements = FindElements(elem);
                return elements.Any(e => e.Text.Equals(value));
            }
            //catch (NoSuchElementException)
            catch (Exception)
            {
                return false;
            }
        }
        public bool DoesNotExist(string elem, int t = 1)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(t));
                wait.Until(ExpectedConditions.ElementExists(GetBy(elem)));
                return false;
            }
            //catch (NoSuchElementException)
            catch (Exception)
            {
                return true;
            }
        }

        /*
         * Wait for timeout if element is visible
         * 
         * */
        public bool IsVisible(string elem, int t = 1)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(t));
                IWebElement element = (IWebElement)wait.Until(ExpectedConditions.ElementIsVisible(GetBy(elem)));
                return element.Displayed && element.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*
         * Wait for timeout if element is not visible
         * 
         * */
        public bool IsNotVisible(string elem, int t = _timeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(t));
                return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(GetBy(elem)));
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*
         * Wait for timeout if element is disabled
         * 
         * */
        public bool IsEnabled(string elem, int t = 1)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(t));
                IWebElement element = (IWebElement)wait.Until(ExpectedConditions.ElementExists(GetBy(elem)));
                return element.Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WaitForValueToBePresent(string elem, string value, int t = _timeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(t));
                return wait.Until(ExpectedConditions.TextToBePresentInElementValue(GetBy(elem), value));

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WaitForElementToBeSelected(string elem, int t = _timeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(t));
                return wait.Until(ExpectedConditions.ElementToBeSelected(GetBy(elem)));
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*
         * Check if input has Value
         * 
         * */
        public bool FieldHasValue(string elem, string value, int t = _timeout)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(t));
                IWebElement myElement = (IWebElement)wait.Until(ExpectedConditions.ElementIsVisible(GetBy(elem)));
                return (myElement.GetAttribute("value").Equals(value));
            }
            catch (Exception)
            {
                return false;
            }
        }

        /* 
         * get attribute of web element
         * 
         * */
        public string GetAttribute(IWebElement elem, string attributeName)
        {
            return elem.GetAttribute(attributeName);
        }
        public string GetAttribute(string elem, string attributeName)
        {
            return GetAttribute(FindElement(elem), attributeName);
        }

        public string GetValueOf(string elem)
        {
            return GetAttribute(FindElement(elem), "text");
        }
        public bool GetValueOfCheckbox(string checkbox)
        {
            return FindElement(checkbox).Selected;
        }

        #endregion

        #region helper methods
        /*
         * Get By using string pattern
         * 
         * for Css: "CssSelector==.css_class #css_id"
         * for XPath: "xpath==//div//p/span[1]"
         * for Class: "class==my_class"
         * for Tag Name: "tag==tag_name"
         * 
         * If identifier befor the "==" can not be read the value behind the "=="
         * will be used to get the element by name.
         * 
         * */
        public By GetBy(string by)
        {
            string[] split_by = by.Split(new string[] { "==" }, StringSplitOptions.None);
            switch (split_by[0])
            {
                case "Id":
                    {
                        return By.Id(split_by[1]);
                    }
                case "class":
                    {
                        return By.ClassName(split_by[1]);
                    }
                case "CssSelector":
                    {
                        return By.CssSelector(split_by[1]);
                    }
                case "tag":
                    {
                        return By.TagName(split_by[1]);
                    }
                case "XPath":
                    {
                        return By.XPath(split_by[1]);
                    }
                case "Name":
                    {
                        return By.Name(split_by[1]);
                    }
                case "PartialLinkText":
                    {
                        return By.PartialLinkText(split_by[1]);
                    }
                case "LinkText":
                    {
                        return By.LinkText(split_by[1]);
                    }
                default:
                    {
                        return By.Name(split_by[1]);
                    }
            }
        }

        public void Scroll(string element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", FindElement(element));
        }

        /// <summary>
        /// select item in list using text from drop down list
        /// </summary>
        /// <param name="element">string element</param>
        /// <param name="itemText">string item</param>
        public void SelectItemInListUsingText(string element,string itemText)
        {
            new SelectElement(FindElement(element)).SelectByText(itemText); 
        }

        /// <summary>
        /// select item in list using value from drop down list
        /// </summary>
        /// <param name="element">string element</param>
        /// <param name="itemValue">string item</param>
        public void SelectItemInListUsingValue(string element, string itemValue)
        {
            new SelectElement(FindElement(element)).SelectByValue(itemValue);
        }

        /// <summary>
        /// select item in list using index from drop down list
        /// </summary>
        /// <param name="element">string element</param>
        /// <param name="itemIndex">string item</param>
        public void SelectItemInListUsingIndex(string element, int itemIndex)
        {
            new SelectElement(FindElement(element)).SelectByIndex(itemIndex);
        }
        #endregion
    }

}
