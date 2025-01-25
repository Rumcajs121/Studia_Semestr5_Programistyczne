namespace PP_Zad4;

    public interface IBookBuilder
    {
        IBookBuilder WithAuthor(string author);
        IBookBuilder WithCategory(Category category);
        IBookBuilder WithTitle(string title);
        Book Build();
    }
