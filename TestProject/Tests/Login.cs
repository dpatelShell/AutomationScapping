using WebAutomation.Default;
using WebAutomation.Pages;

namespace WebAutomation.Tests
{
    [TestClass]
    public class Login : TestController
    {
        MenuPage _menuPage;
        AdminPage _adminPage;
        LoginPage _loginPage;
 
        [TestInitialize]
        public void Setup()
        {
            LaunchApp();
            _menuPage = new MenuPage(_driverController);
            _adminPage = new AdminPage(_driverController);
            _loginPage = new LoginPage(_driverController);
        }

        [TestCleanup]
        public void TearDown()
        {
            ShutDownApp();
        }

        [TestMethod]
        public void GetDetailsFromWIDI()
        {
            _adminPage.SetUserName()
                .SetPassword()
                .ClickLogOnButton().
                NagivateCrossFeildSummary().GetTableData();
        }
       
    }
}
