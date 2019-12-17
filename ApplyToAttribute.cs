namespace UnitTestProject.Selenium
{
   using NUnit.Framework;
   using NUnit.Framework.Interfaces;
   using System;
   using System.Linq;

   public class ApplyToAttribute : Attribute, ITestAction
   {
       private readonly string[] browsersRequested;

       public ApplyToAttribute(params string[] browsersRequested)
       {
           this.browsersRequested = browsersRequested.ToArray();
       }

       public ActionTargets Targets { get; private set; } 

       public void BeforeTest(ITest test)
       {
           var browsersAllowed = GetBrowsersAllowed();
           var browserTestsName = test.Fixture.ToString();

            if (browsersRequested.Any(b => IsTestForTheBrowser(browserTestsName, b) 
                 && BrowserIsIncludedInConfiguration(browsersAllowed, b))) 
            {
                return;
            }
                
           Assert.Ignore();
       }


       private static bool BrowserIsIncludedInConfiguration(string[] browsersAllowed, string browser)
       {
           return browsersAllowed.Contains(browser);
       }

       private static bool IsTestForTheBrowser(string browserTestsName, string browser)
       {
           return browserTestsName.Contains(browser);
       }

       public void AfterTest(ITest test)
       {
       }

       private static string[] GetBrowsersAllowed()
       {
           var browsersResource = Resources.Browsers;
           var browsersAllowed = browsersResource.Split(',').Select(Trim).ToArray();
           return browsersAllowed;
       }
   }
}
