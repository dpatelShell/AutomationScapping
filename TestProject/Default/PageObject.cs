using TestProject.Default;

namespace TestProject.Default
{
   public class PageObject
    {

        public DriverController _driverController { get; set; }

        #region ctor
        public PageObject(DriverController driverController)
        {
            _driverController = driverController;
        }
        #endregion

        #region public api

        /// <summary>
        /// Check if element exists
        /// </summary>
        /// <param name="elem">string type ex:Xpath or Id</param>
        /// <param name="t">int type ex:1</param>
        /// <returns>Bool type ex:true or false</returns>
        public bool Exists(string elem, int t = 1)
        {
            return _driverController.Exists(elem, t);
        }

        /// <summary>
        /// check if element doest not exists
        /// </summary>
        /// <param name="elm">String Type ex:Xpath or Id</param>
        /// <param name="t">Int type ex:0 or 1</param>
        /// <returns>Bool Type Ex:True or False</returns>
        public bool DoesNotExist(string elm, int t = 1)
        {
            return _driverController.DoesNotExist(elm, t);
        }


        /// <summary>
        /// wait until element is visible
        /// </summary>
        /// <param name="elem">String type ex:Xpath or Id</param>
        /// <param name="t">Int type ex:5</param>
        /// <returns>Bool Type ex:True or False</returns>
        public bool IsVisible(string elem, int t = 5)
        {
            return _driverController.IsVisible(elem, t);
        }

        /// <summary>
        /// wait until element disappears
        /// </summary>
        /// <param name="elem">String type ex:Xpath or Id</param>
        /// <param name="t">Int type ex:2</param>
        /// <returns>Bool Type ex:true or false</returns>
        public bool IsNotVisible(string elem, int t = 2)
        {
            return _driverController.IsNotVisible(elem, t);
        }

        /// <summary>
        /// Check if element is enabled
        /// </summary>
        /// <param name="elem">String type ex:Xpath or Id</param>
        /// <param name="t">Int type ex:1</param>
        /// <returns>Bool type Ex:true or false</returns>
        public bool IsEnabled(string elem, int t = 1)
        {
            return _driverController.IsEnabled(elem, t);
        }

        /// <summary>
        /// get element checked property
        /// </summary>
        /// <param name="elem">String type ex:Xpath or Id</param>
        /// <returns>Bool type Ex:true or false</returns>
        public bool IsChecked(string elem)
        {
            return _driverController.FindElement(elem).GetAttribute("checked").Equals("true");
        }


        /// <summary>
        /// wait until element disappears
        /// </summary>
        /// <param name="elem">String type ex:Xpath or Id</param>
        /// <param name="t">Int type ex:5</param>
        /// <returns>Bool type Ex:true or false</returns>
        public bool WaitUntilElementDisappears(string elem, int t = 10)
        {
            return _driverController.IsNotVisible(elem, t);
        }


        /// <summary>
        /// wait until element appears
        /// </summary>
        /// <param name="elem">String type ex:Xpath or Id</param>
        /// <param name="t">Int type ex:5</param>
        /// <returns>Bool type ex:true or false</returns>
        public bool WaitUntilElementAppears(string elem, int t = 10)
        {
            return _driverController.IsVisible(elem, t);
        }

        /// <summary>
        /// wait until element get selected
        /// </summary>
        /// <param name="elem">String type ex:Xpath or Id</param>
        /// <param name="t">Int type ex:5</param>
        /// <returns>Bool type ex:true or false</returns>
        public bool WaitUntilElementSelected(string elem, int t = 10)
        {
            return _driverController.WaitForElementToBeSelected(elem, t);
        }

        #endregion
    }
}
