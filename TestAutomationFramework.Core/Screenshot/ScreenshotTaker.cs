using TestAutomationFramework.Core.Helpers;
using System.Drawing;
using System.Drawing.Imaging;
using OpenQA.Selenium;

namespace TestAutomationFramework.Core.Screenshot
{
    internal static class ScreenshotTaker
    {
        internal static void TakeScreenshot(IWebDriver driver, string testName, string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string screenFileName =
                $"{testName} {DateTime.Now:dd,MM}.{ImageFormat.Jpeg.ToString().ToLowerInvariant()}";

            string screenPath = Path.Combine(TestSettings.ScreenShotPath, screenFileName);

            using (Image screenshot = Image.FromStream(new MemoryStream(((ITakesScreenshot)driver).GetScreenshot().AsByteArray)))
            {
                screenshot.Save(screenPath);
            }
        }

    }
}
