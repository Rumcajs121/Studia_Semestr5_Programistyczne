namespace AbstractFactoryCreationalDesignPattern;

public class MacButton : IButton
{
    public void HandleClick()
    {
        System.Console.WriteLine("Render Mac click event");
    }

    public void Render()
    {
        System.Console.WriteLine("Render Mac button");
    }
}
