using TestProject.Default;

namespace TestProject.Pages
{
    public class LoginPage : PageObject
    {
        #region page elements
        public string machineDDL = "Id==ContentPlaceHolder1_ddlMachines";
        public string amountDDL = "Name==ctl00$ContentPlaceHolder1$drpAmount";
        public string textTransactionFee = "Id==txtTransactionFee";
        public string textDiscount = "Id==txtDiscount";
        public string textTotalAmount = "Id==txtTotalAmount";
        public string payPalButton = "Id==ContentPlaceHolder1_btnPaypal";

        #endregion

        #region constructor
        public LoginPage(DriverController driver)
            : base(driver)
        {
        }
        #endregion

        #region selection event

        public LoginPage SelectMachineUsingText(string machine)
        {
            _driverController.SelectItemInListUsingText(machineDDL,machine);
            return this;
        } 

        public LoginPage SelectAmount(string amount)
        {
            _driverController.SelectItemInListUsingText(amountDDL, amount);
            return this;
        }
        #endregion

        #region get values
        public string GetTransactionFee()
        {
            return _driverController.GetValueOf(textTransactionFee);
        }

        public string GetDiscount()
        {
            return _driverController.GetValueOf(textDiscount);
        }

        public string GetTotalAmount()
        {
            return _driverController.GetValueOf(textTotalAmount);
        }
        #endregion


    }
}
