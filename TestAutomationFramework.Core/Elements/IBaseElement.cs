
namespace TestAutomationFramework.Elements
{
    public interface IBaseElement
    {
        string GetText();
        string GetAttribute(string attributeName);

        void Click();
        void SendKeys(string text);
        void Clear();
        void MouseHover();

        bool IsDisplayed();
        bool IsEnabled();
    }
}
