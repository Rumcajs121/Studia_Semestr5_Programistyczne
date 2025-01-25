using AbstractFactoryCreationalDesignPattern;

var uiApplication=new Application(new WindowsFactory());

uiApplication.RenderUI();

var uiApplication2=new Application(new MacFactory());

uiApplication2.RenderUI();