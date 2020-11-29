using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Desafio_Concert
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        string textSearch = "Concert Technologies";

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(options);
            driver.Url = "https://www.google.com/";
        }


        //This test tests if the gmail button on top-right of page redirects correctly to gmail page.
        [Test]
        public void Test01_linkGmail()
        {
            Thread.Sleep(2000);
            IWebElement linkGmail = driver.FindElement(By.CssSelector("#gbw > div > div > div.gb_ke.gb_i.gb_Ig.gb_yg > div:nth-child(1) > a"));
            
            linkGmail.Click();
            Thread.Sleep(5000);

            IWebElement gmailCheck = driver.FindElement(By.CssSelector("body > div.hercules-header.h-c-header.h-c-header--product-marketing-one-tier.header--desktop > div.h-c-header__bar > div.h-c-header__lockup > div.h-c-header__product-logo > div > span"));
            //Console.WriteLine(gmailCheck.Text);
            Assert.IsTrue(gmailCheck.Text == "Gmail");
        }


        // This test tests if the google images button on top-right of page redirects correctly to google images page.
        [Test]
        public void Test02_imagesGoogle()
        {
            Thread.Sleep(2000);
            IWebElement googleImages = driver.FindElement(By.CssSelector("#gbw > div > div > div.gb_ke.gb_i.gb_Ig.gb_yg > div:nth-child(2) > a"));
            googleImages.Click();
            Thread.Sleep(5000);

            IWebElement imagesCheck = driver.FindElement(By.CssSelector("#hplogo > div > span"));
            //Console.WriteLine(imagesCheck.Text);
            Assert.IsTrue(imagesCheck.Text == "Imagens");
        }


        // This test select one of elements in apps button on top-right of page, in this case Google Play and click on it. 
        // Then verify if redirects correctly to Google Play.
        [Test]
        public void Test03_appsGoogle()
        {
            Thread.Sleep(2000);
            IWebElement appsGoogle = driver.FindElement(By.CssSelector("#gbwa > div > a"));
            appsGoogle.Click();
            Thread.Sleep(5000);

            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector(".gb_Wa > div:nth-child(3) > iframe:nth-child(1)")));

            IWebElement GooglePlay = driver.FindElement(By.CssSelector("ul.LVal7b:nth-child(3) > li:nth-child(5) > a:nth-child(1) > span:nth-child(2)"));
            GooglePlay.Click();

            IWebElement GooglePlayCheck = driver.FindElement(By.CssSelector("#fcxH9b > div:nth-child(2) > c-wiz.Knqxbd.tzLNed.Mfkobe > div:nth-child(4) > ul > li:nth-child(1) > a > span:nth-child(2)")); 
            //Console.WriteLine(GooglePlayCheck.Text);
            Assert.IsTrue(GooglePlayCheck.Text == "Conta"); 
        }


        // This test tests if the login button on top-right of page redirects correctly to login page.
        [Test]
        public void Test04_loginGoogle()
        {
            Thread.Sleep(2000);
            IWebElement loginGoogle = driver.FindElement(By.Id("gb_70"));
            loginGoogle.Click();
            Thread.Sleep(5000);

            IWebElement loginCheck = driver.FindElement(By.CssSelector("#headingText > span"));
            //Console.WriteLine(loginCheck.Text);
            Assert.IsTrue(loginCheck.Text == "Fazer login");           
        }


        // This test receives a text input and press enter to search. Then I check de result page if contains the keyword searched.
        [Test]
        public void Test05_searchInput() 
        {
            Thread.Sleep(2000);
            IWebElement searchInput = driver.FindElement(By.CssSelector("#tsf > div:nth-child(2) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input"));
            
            searchInput.SendKeys(textSearch);
            Thread.Sleep(1000);

            searchInput.Submit();
            Thread.Sleep(5000);

            IWebElement SearchResultCheck = driver.FindElement(By.CssSelector("#rhs > div > div.kp-blk.knowledge-panel.Wnoohf.OJXvsb > div > div.ifM9O > div > div.kp-header > div.fYOrjf.iB08Xb.kp-hc > div.Hhmu2e.mod.NFQFxe.viOShc.LKPcQc > div > div.SPZz6b > h2 > span"));
            //Console.WriteLine(SearchResultCheck.Text);
            Assert.IsTrue(textSearch == SearchResultCheck.Text);
        }


        // This test receives a text input, but instead pressing enter, this test will click on search button to search. Then confirm if the result page 
        // contains the keyword typed.
        [Test]
        public void Test06_search_btn()
        {
            Thread.Sleep(2000);
            IWebElement searchInput = driver.FindElement(By.CssSelector("#tsf > div:nth-child(2) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input"));
            IWebElement search_btn = driver.FindElement(By.CssSelector("#tsf > div:nth-child(2) > div.A8SBwf > div.FPdoLc.tfB0Bf > center > input.gNO89b")); 
            
            searchInput.SendKeys(textSearch);
            Thread.Sleep(1000);

            search_btn.Click();
            Thread.Sleep(5000);

            IWebElement SearchResultCheck = driver.FindElement(By.CssSelector("#rhs > div > div.kp-blk.knowledge-panel.Wnoohf.OJXvsb > div > div.ifM9O > div > div.kp-header > div.fYOrjf.iB08Xb.kp-hc > div.Hhmu2e.mod.NFQFxe.viOShc.LKPcQc > div > div.SPZz6b > h2 > span"));
            //Console.WriteLine(SearchResultCheck.Text);
            Assert.IsTrue(textSearch == SearchResultCheck.Text);
        }
        

        // This test clicks on "I'm feeling lucky" button and verifies if it works.
        [Test]
        public void Test07_lucky_btn()
        {
            Thread.Sleep(2000);
            IWebElement lucky_btn = driver.FindElement(By.CssSelector("#tsf > div:nth-child(2) > div.A8SBwf > div.FPdoLc.tfB0Bf > center > input.RNmpXc"));
            lucky_btn.Click();
            Thread.Sleep(5000);

            IWebElement luckyCheck = driver.FindElement(By.Id("archive-link-link"));
            //Console.WriteLine(luckyCheck.Text);
            Assert.IsTrue(luckyCheck.Text == "Arquivo de doodles");
        }


        [TearDown]
        public void Close()
        {
            Thread.Sleep(3000);
            driver.Close();
        }
    }
}