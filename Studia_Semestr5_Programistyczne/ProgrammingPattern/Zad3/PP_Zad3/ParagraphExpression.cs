namespace PP_Zad3;

public class ParagraphExpression : IExpression
{
    private readonly string _content;

    public ParagraphExpression(string content)
    {
        _content = content;
    }

    public string Interpret()
    {
        return $"<p>{_content}</p>";
    }
}