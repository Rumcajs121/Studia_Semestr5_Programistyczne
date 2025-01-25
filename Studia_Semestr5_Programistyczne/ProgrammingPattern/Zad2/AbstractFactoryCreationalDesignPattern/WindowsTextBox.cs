namespace AbstractFactoryCreationalDesignPattern;

public class WindowsTextBox : ITextBox
{
    public void HandleInPut()
    {
        System.Console.WriteLine("Handle Windows input");
    }

    public void Render()
    {
        System.Console.WriteLine("Render Windows textbox");
    }
}
