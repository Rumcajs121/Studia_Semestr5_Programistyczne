namespace AbstractFactoryCreationalDesignPattern;

public class Application
{
    private readonly UIElementFactory _factory;

    public Application(UIElementFactory factory)
    {
        _factory = factory;
    }

    public void RenderUI(){
        var createNewFileButton=_factory.CreateButton();
        createNewFileButton.Render();
        var createNewTextBox=_factory.CreateTextBox();
        createNewTextBox.Render();
    }
}
