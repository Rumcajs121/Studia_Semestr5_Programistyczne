namespace PP_Zad3;
public static class HtmlParser
{
    public static HtmlDocument Parse(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var document = new HtmlDocument();

        foreach (var line in lines)
        {
            if (line.StartsWith("[header]") && line.EndsWith("[/header]"))
            {
                var content = line[8..^9]; // Wyciąganie tekstu między znacznikami
                document.AddExpression(new HeaderExpression(content));
            }
            else if (line.StartsWith("[paragraph]") && line.EndsWith("[/paragraph]"))
            {
                var content = line[11..^12];
                document.AddExpression(new ParagraphExpression(content));
            }
        }

        return document;
    }
}