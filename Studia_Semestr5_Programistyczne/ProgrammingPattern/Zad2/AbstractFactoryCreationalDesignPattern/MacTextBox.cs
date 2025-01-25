namespace AbstractFactoryCreationalDesignPattern;

public class MacTextBox : ITextBox
{
    public void HandleInPut()
    {
        System.Console.WriteLine("Handle Mac input");
    }

    public void Render()
    {
        System.Console.WriteLine("Render Mac textbox");
    }
}
