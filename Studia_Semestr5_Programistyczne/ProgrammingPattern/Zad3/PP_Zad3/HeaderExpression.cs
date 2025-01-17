namespace PP_Zad3;

public class HeaderExpression : IExpression
{
    private readonly string _content;

    public HeaderExpression(string content)
    {
        _content = content;
    }

    public string Interpret()
    {
        return $"<h1>{_content}</h1>";
    }
}