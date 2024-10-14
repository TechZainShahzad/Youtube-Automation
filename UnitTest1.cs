using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace Youtube_Automation
{
    [TestClass]
    public class UnitTest1
    {

        public static IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void TestMethod1()
        {

            Like("https://youtube.com/", "what is selenium");

            driver.Close();
            driver.Dispose();
            driver.Quit();
        }

        void Like(String url,String keyword)
        {
            driver.Url = url;

            driver.Manage().Window.Maximize();

            Thread.Sleep(2000);

            IWebElement searchBox = driver.FindElement(By.XPath("//input[@id='search']"));

            searchBox.SendKeys(keyword);

            searchBox.Submit();

            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(2000);

                IWebElement videoThumbnail = driver.FindElement(By.XPath("(//a[@id='video-title'])[" + i.ToString() + "]"));
                videoThumbnail.Click();

                Thread.Sleep(5000);

                IWebElement likeButton = driver.FindElement(By.XPath("/html/body/ytd-app/div[1]/ytd-page-manager/ytd-watch-flexy/div[5]/div[1]/div/div[2]/ytd-watch-metadata/div/div[2]/div[2]/div/div/ytd-menu-renderer/div[1]/segmented-like-dislike-button-view-model/yt-smartimation/div/div/like-button-view-model/toggle-button-view-model/button-view-model/button/yt-touch-feedback-shape/div"));
                likeButton.Click();

                Thread.Sleep(2000);

                driver.Navigate().Back();
            }
        }
    }
}
