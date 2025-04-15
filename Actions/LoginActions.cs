using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using ReqnrollProjectDemo.Pages;
using SeleniumExtras.WaitHelpers;

namespace ReqnrollProjectDemo.Actions
{
    public class LoginActions
    {
        private readonly GmailLoginPage _GmailloginPage;

        public LoginActions(IWebDriver driver)
        {
            _GmailloginPage = new GmailLoginPage(driver);
        }        

        public void Login(string email, string password)
        {
            _GmailloginPage.GmailLogin(email,password);
        }      
    }
}
