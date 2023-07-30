using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumRev.Gulfzel
{
    public class GulfuzelSignUp
    {
        public IWebDriver driver;

        [SeleniumExtras.PageObjects.FindsBy(How = How.Name, Using = "name")]
        private IWebElement usernameInput;

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement emailInput;

        [FindsBy(How = How.Name, Using = "phone")]
        private IWebElement phoneInput;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='First Name']")]
        private IWebElement firstNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Last Name']")]
        private IWebElement lastNameInput;

        [FindsBy(How = How.ClassName, Using = "listivo-login-form__checkbox listivo-checkbox")]
        private IWebElement checkBoxInput;

        [FindsBy(How = How.CssSelector, Using = "button.listivo-simple-button.listivo-simple-button--background-primary-2.listivo-button-primary-2-selector.listivo-simple-button--full-width.listivo-simple-button--height-60:contains('Register')")]
        private IWebElement registerButton;

        public GulfuzelSignUp(IWebDriver driver)
        {
            this.driver = driver;
            //PageFactory.InitElements(driver, this);
           // driver = driver;
           // PageFactory.InitElements(driver, this);
        }

        public void EnterUsername(string username)
        {
            usernameInput.SendKeys(username);
        }

        public void EnterEmail(string email)
        {
            emailInput.SendKeys(email);
        }

        public void EnterPhone(string phone)
        {
            phoneInput.SendKeys(phone);
        }

        public void EnterPassword(string password)
        {
            passwordInput.SendKeys(password);
        }

        public void EnterFirstName(string firstName)
        {
            firstNameInput.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            lastNameInput.SendKeys(lastName);
        }

        public void ClickCheckBox()
        {
            checkBoxInput.Click();
        }

        public void ClickRegisterButton()
        {
            registerButton.Click();
        }
    }
}
