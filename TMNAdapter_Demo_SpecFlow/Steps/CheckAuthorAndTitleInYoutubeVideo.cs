using NUnit.Framework;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TMNAdapter.SpecFlow.Common;
using TMNAdapter.SpecFlow.Utilities;
using TMNAdapter_Demo_SpecFlow.BaseObject;
using TMNAdapter_Demo_SpecFlow.Common;

namespace TMNAdapter_Demo_SpecFlow.Steps
{
    [Binding]
    public class CheckAuthorAndTitleInYoutubeVideo
    {
        private readonly ScenarioContext scenarioContext;
        private YouTubePage page;
        private Screenshoter screenshoter;

        public CheckAuthorAndTitleInYoutubeVideo(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            this.scenarioContext = scenarioContext;
            screenshoter = new Screenshoter(scenarioContext, BrowserContainer.GetBrowser(scenarioContext.ScenarioInfo.Title).Driver);
            page = new YouTubePage(BrowserContainer.GetBrowser(scenarioContext.ScenarioInfo.Title));
        }

        [Given("I navigate to (.*)")]
        public void INavigateToMainPage(string mainPage)
        {
            JiraInfoProvider.SaveParameter("title", page.GetVideoTitle(), scenarioContext);
        }

        [Then("the (.*) should be correct")]
        public void TheAuthorNameShouldBeCorrect(string authorName)
        {
            JiraInfoProvider.SaveParameter("authorName", page.GetAuthorName(), scenarioContext);
            string name = page.GetAuthorName();
            screenshoter.GetScreenshot();
            Assert.AreEqual(name, authorName);
        }

        [Then("the (.*) should be wrong")]
        public void TheTitleNameNameShouldBeWrong(string titleName)
        {
            JiraInfoProvider.SaveAttachment(new FileInfo($@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\Resources\jenkins-oops.jpg"), scenarioContext);
            JiraInfoProvider.SaveParameter("authorName", page.GetAuthorName(), scenarioContext);
            string name = page.GetVideoTitle();
            screenshoter.GetScreenshot();
            Assert.AreEqual(name, titleName);
        }
    }
}