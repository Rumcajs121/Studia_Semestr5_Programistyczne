namespace AbstractFactoryCreationalDesignPattern;

public interface UIElementFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
}
