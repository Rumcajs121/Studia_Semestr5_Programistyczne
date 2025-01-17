using PP_Zad4;



BookBuilder builder = new BookBuilder();

Book book1 = builder
    .WithTitle("Harry Potter")
    .WithAuthor("J.K. Rowling")
    .WithCategory(Category.Fantasy)
    .Build(); 

Console.WriteLine(book1.ToString());

Book book2 = builder 
    .WithTitle("Władca Pieścieni Druyna Pierścienia")
    .WithAuthor("J.R.R. Tolkien")
    .WithCategory(Category.Fantasy)
    .Build(); 

Console.WriteLine(book2.ToString());


var carBuilder = new CarBuilder().WithBrand("Toyota").WithColor("red").WithModel("Corolla").WithYear(1997);
var car=carBuilder.Build();
var carBuilder1 = new CarBuilder().WithBrand("Fiat").WithColor("green").WithYear(2002);
var car1=carBuilder1.Build();

System.Console.WriteLine($"I use FluenBuilder when i created this object {car.ToString()}");
System.Console.WriteLine($"I use FluenBuilder when i created this object {car1.ToString()}");





