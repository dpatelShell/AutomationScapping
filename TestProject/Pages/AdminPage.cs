using System.Data;
using OpenQA.Selenium;
using TestProject.Default;

namespace TestProject.Pages
{
    public class AdminPage : PageObject
    {
        #region default values
        public string DefaultUserName = "A.Clucas";
        public string DefaultPassword = "Welcome549#";
        #endregion

        #region page elements
        public string UserNameInput = "Id==UserName";
        public string PasswordInput = "Id==Password";
        public string UserNameValidationErrorLabel = "XPath==//span[@htmlfor='UserName']";
        public string PasswordValidationErrorLabel = "XPath==//span[@htmlfor='Password']";
        public string LogOnFailErrorLabel = "XPath==//div[@class='validation-summary-errors']/span";
        public string WrongCrediantialsErrorLabel = "XPath=//div[@class='validation-summary-errors']/ul/li";
        public string LogOnButton = "XPath==//button[.='Log in']";
        public string FieldSummaryButton = "XPath==//ul[@class='nav navbar-nav']/li[3]/div[@id='Align1']/button";
        public string CrossFieldSummaryButton = "XPath==//a[.='Cross Field Summary']";
        public string CrossFieldSummaryTable = "XPath==//span[@class='lead']/following::table";
        #endregion

        #region constructor
        public AdminPage(DriverController driver)
            : base(driver)
        {

        }
        #endregion

        #region public api
        public AdminPage SetUserName()
        {
            SetUserName(DefaultUserName);
            return this;
        }
        public AdminPage SetUserName(string userName)
        {
            _driverController.SendKeys(UserNameInput, userName);
            return this;
        }

        public AdminPage SetPassword()
        {
            SetPassword(DefaultPassword);
            return this;
        }

        public AdminPage SetPassword(string password)
        {
            _driverController.SendKeys(PasswordInput, password);
            return this;
        }

        public AdminPage ClickLogOnButton()
        {
            _driverController.Click(LogOnButton);
            return this;
        }

        public AdminPage NagivateCrossFeildSummary()
        {
            _driverController.Click(FieldSummaryButton);
            _driverController.Click(CrossFieldSummaryButton);
            return this;
        }

        public AdminPage GetTableData()
        {
            DataTable dt =
                new DataTable();
            try
            {
              
                var getElements = _driverController.FindElement(CrossFieldSummaryTable);
                foreach (var trElement in getElements.FindElements(By.TagName("tr")).ToList())
                {
                    DataRow? dataRow = null;
                    foreach (var thElement in trElement.FindElements(By.TagName("th")).ToList().Where(thElement => thElement.TagName == "th"))
                    {
                        dt.Columns.Add(new DataColumn(thElement.Text));
                    }

                    if (trElement.FindElements(By.TagName("th")).Count > 0)
                    {
                        continue;
                    }

                    dataRow = dt.NewRow();

                    var i = 0;
                    foreach (var tdElement in trElement.FindElements(By.TagName("td")).ToList().Where(tdElement => true))
                    {
                        dataRow[i] = tdElement.Text;
                        i++;
                    }

                    dt.Rows.Add(dataRow);
                }
                var lines = new List<string>();

                string[] columnNames = dt.Columns
                    .Cast<DataColumn>()
                    .Select(column => column.ColumnName)
                    .ToArray();

                var header = string.Join(",", columnNames.Select(name => $"\"{name}\""));
                lines.Add(header);

                var valueLines = dt.AsEnumerable()
                    .Select(row => string.Join(",", row.ItemArray.Select(val => $"\"{val}\"")));

                lines.AddRange(valueLines);

                File.WriteAllLines("excel.csv", lines);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                throw;
            }
           
            return this;

        }
        #endregion

        #region get values
        public string GetSetUserName()
        {
            return _driverController.GetAttribute(UserNameInput, "value");
        }

        public string GetSetPassword()
        {
            return _driverController.GetAttribute(PasswordInput, "textContent");
        }

        public string GetUserNameValidationErrorLabel()
        {
            return _driverController.GetAttribute(UserNameValidationErrorLabel, "textContent");
        }

        public string GetPasswordNameValidationErrorLabel()
        {
            return _driverController.GetAttribute(PasswordValidationErrorLabel, "textContent");
        }
        #endregion 
    }
}
