
using TestAutomationFramework.Core.BasePage;

namespace ReportPortal.TestAutomation.Web.Helper
{
    public static class Navigation
    {
        public static TPage GetPage<TPage>() where TPage : BasePage
        {
            return (TPage)Activator.CreateInstance(typeof(TPage), 0);
        }
    }
}
