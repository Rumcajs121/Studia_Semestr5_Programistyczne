namespace AbstractFactoryCreationalDesignPattern;

public class WindowsButton : IButton
{
    public void HandleClick()
    {
        System.Console.WriteLine("Render windows click event");
    }

    public void Render()
    {
        System.Console.WriteLine("Render widows button");
    }
}
