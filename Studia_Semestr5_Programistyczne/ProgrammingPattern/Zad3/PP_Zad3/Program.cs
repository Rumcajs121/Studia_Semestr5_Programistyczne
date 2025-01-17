using PP_Zad3;

string input = @"
[header]Nagłówek[/header]
[paragraph]To jest paragraf.[/paragraph]
";

var document = HtmlParser.Parse(input.Trim());
var output = document.Interpret();

Console.WriteLine("Input:");
Console.WriteLine(input);
Console.WriteLine("Output:");
Console.WriteLine(output);