using AppUITests;
using ClassLibrary1.PageObjects;
using ClassLibrary1.Utility;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;
using Xunit;


namespace ClassLibrary1
{
     public class OnlineShoppingTest : ApplicationContext
     {

        [Fact]
        [Trait("Application", "Smoke")]
        public void SignUpToMercuryTourApplicationTest()
        {
            LaunchApplicationPage();
            Assert.Equal("My Store", getDriver().Title);
           
            HomePage home = new HomePage(getDriver());
            home.clickOnSignInLink();
            AuthenticationPage authenticationPage = new AuthenticationPage(getDriver());
            Assert.Equal("Login - My Store", authenticationPage.isAuthenticationPageDisplayed());

            AuthenticationPage authenticationPage1 = new AuthenticationPage(getDriver());
            authenticationPage1.enterEmailForSignUp();
            authenticationPage1.clickOnCreateAccountButton();

            RegisterUserPage registerUserPage = new RegisterUserPage(getDriver());
            Assert.Equal("CREATE AN ACCOUNT", registerUserPage.isDislayedRegisterUserPage());

            registerUserPage.enterUserDetails();
            Assert.Equal(registerUserPage.isDisplayedAccountPage(),  testData.FirstName.Concat(" "+testData.LastName));

            closeSession();
        }
        [Fact]
        [Trait("Application", "Smoke")]
        public void logInToApplicationTest()
        {
            LaunchApplicationPage();
            Assert.Equal("My Store", getDriver().Title);

            HomePage home = new HomePage(getDriver());
            home.clickOnSignInLink();

            AuthenticationPage authenticationPage = new AuthenticationPage(getDriver());
            Assert.Equal("Login - My Store", authenticationPage.isAuthenticationPageDisplayed());

            authenticationPage.logInToApplication();
            Assert.Equal(authenticationPage.isDisplayedAccountPage(), testData.FirstName.Concat(" " + testData.LastName));

        }
        [Fact]
        [Trait("Application", "Smoke")]
        public void logInAndPlaceOrderForTShirt()
        {
            logInToApplicationTest();
            AuthenticationPage authenticationPage = new AuthenticationPage(getDriver());
            authenticationPage.switchToTshirtStorePage();

            MyStoreTshirtPage myStoreTshirtPage = new MyStoreTshirtPage(getDriver());
            Assert.Equal("Women - My Store", myStoreTshirtPage.isDisplayedMyStoreTshirtPage());

            myStoreTshirtPage.placeOrderOfTshirt();
            Assert.Equal("Order confirmation - My Store", getDriver().Title);
            closeSession();
        }
        

    }
}
