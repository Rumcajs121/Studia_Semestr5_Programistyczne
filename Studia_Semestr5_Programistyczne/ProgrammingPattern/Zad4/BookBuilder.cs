
namespace PP_Zad4;

public class BookBuilder : IBookBuilder
{        private Book book = new Book();

        public IBookBuilder WithAuthor(string author)
        {
            book.Author = author;
            return this;
        }

        public IBookBuilder WithCategory(Category category)
        {
            book.Category = category;
            return this;
        }

        public IBookBuilder WithTitle(string title)
        {
            book.Title = title;
            return this;
        }

        public Book Build()
        {
            book.Isbn=Guid.NewGuid();
            return book;
        }
}