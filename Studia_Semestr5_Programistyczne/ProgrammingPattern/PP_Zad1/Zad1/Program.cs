// See https://aka.ms/new-console-template for more information

using Zad1;

//var cfg = new Configuration();
var cfg1 = Configuration.GetInstance();
var cfg2 = Configuration.GetInstance();

if (ReferenceEquals(cfg1, cfg2))
{
    Console.WriteLine("Configuration is a singleton");
}


