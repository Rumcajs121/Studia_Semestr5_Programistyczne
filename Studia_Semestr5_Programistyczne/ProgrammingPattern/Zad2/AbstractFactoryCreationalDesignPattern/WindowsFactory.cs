namespace AbstractFactoryCreationalDesignPattern;

public class WindowsFactory : UIElementFactory
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }

    public ITextBox CreateTextBox()
    {
        return new WindowsTextBox();
    }
}
