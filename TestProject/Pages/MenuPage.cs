using TestProject.Default;

namespace TestProject.Pages
{
    public class MenuPage : PageObject
    {
        #region page elements
        public string AdminAnchor = "LinkText==Admin";
        public string CartStatusAnchor = "Id==cart-status";
        public string HomeAnchor = "Id==current";
        public string StoreAnchor = "LinkText==Store";
        public string RockAnchor = "LinkText==Rock";
        public string ClassicalAnchor = "LinkText==Classical";
        public string JazzAnchor = "LinkText==Jazz";
        public string PopAnchor = "LinkText==Pop";
        public string DiscoAnchor = "LinkText==Disco";
        public string LatinAnchor = "LinkText==Latin";
        public string MetalAnchor = "LinkText==Metal";
        public string AlternativeAnchor = "LinkText==Alternative";
        public string ReggaeAnchor = "LinkText==Reggae";
        public string BluesAnchor = "LinkText==Blues";
        public string AlbumTitle = "XPath==//div[@class='genre']/h3/em";
        public string MenuIconClick = "XPath==//div[@class='hvzvcY']/svg";
        public string FuLink = "LinkText==Shell Energy Retail";
        public string ScheduleRunLink = "LinkText==Schedule Run";
        #endregion

        #region constructor
        public MenuPage(DriverController driver)
            : base(driver)
        {

        }
        #endregion

        #region public api
        public MenuPage ClickAdminAnchor()
        {
            _driverController.Click(AdminAnchor);
            return this;
        }

        public MenuPage ClickMenuIcon()
        {
            _driverController.Click(MenuIconClick);
            return this;
        }

        public MenuPage ClickFuLinkPage()
        {
            _driverController.Click(FuLink);
            return this;
        }

        public MenuPage ClickScheduleRunLink()
        {
            _driverController.Click(ScheduleRunLink);
            return this;
        }

        public MenuPage ClickCartStatusAnchor()
        {
            _driverController.Click(CartStatusAnchor);
            return this;
        }

        public MenuPage ClickHomeAnchor()
        {
            _driverController.Click(HomeAnchor);
            return this;
        }

        public MenuPage ClickStoreAnchor()
        {
            _driverController.Click(StoreAnchor);
            return this;
        }

        public MenuPage ClickRockAnchor()
        {
            _driverController.Click(RockAnchor);
            return this;
        }

        public MenuPage ClickClassicalAnchor()
        {
            _driverController.Click(ClassicalAnchor);
            return this;
        }
        public MenuPage ClickJazzAnchor()
        {
            _driverController.Click(JazzAnchor);
            return this;
        }
        public MenuPage ClickPopAnchor()
        {
            _driverController.Click(PopAnchor);
            return this;
        }
        public MenuPage ClickDiscoAnchor()
        {
            _driverController.Click(DiscoAnchor);
            return this;
        }
        public MenuPage ClickLatinAnchor()
        {
            _driverController.Click(LatinAnchor);
            return this;
        }
        public MenuPage ClickMetalAnchor()
        {
            _driverController.Click(MetalAnchor);
            return this;
        }

        public MenuPage ClickAlternativeAnchor()
        {
            _driverController.Click(AlternativeAnchor);
            return this;
        }

        public MenuPage ClickReggaeAnchor()
        {
            _driverController.Click(ReggaeAnchor);
            return this;
        }

        public MenuPage ClickBluesAnchor()
        {
            _driverController.Click(BluesAnchor);
            return this;
        }
        #endregion

        #region get values
        public string GetTitleOfAlbum()
        {
           
           return _driverController.GetAttribute(AlbumTitle, "textContent");
        }
        #endregion
    }
}
