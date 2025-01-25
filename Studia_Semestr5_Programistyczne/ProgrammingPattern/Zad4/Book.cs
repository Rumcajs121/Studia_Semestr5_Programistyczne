namespace PP_Zad4;


public class Book
{
    
    public Guid Isbn { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public Category Category { get; set; }

    public override string ToString(){
        return $"ISNB Number: {Isbn} ,Title: {Title}, Author: {Author}, Category: {Category}";
    }
}
