namespace PP_Zad3;

public class HtmlDocument
{
    private readonly List<IExpression> _expressions = new();

    public void AddExpression(IExpression expression)
    {
        _expressions.Add(expression);
    }

    public string Interpret()
    {
        var result = "";
        foreach (var expression in _expressions)
        {
            result += expression.Interpret() + "\n";
        }
        return result;
    }
}