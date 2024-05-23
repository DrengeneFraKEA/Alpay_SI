using SI_10a.Models;

namespace SI_10a
{
    public static class Database
    {
        public static List<Author> Authors { get; set; } = new List<Author>() 
        {
            new Author()
            {
                Id = 1,
                Name = "Terence McKenna"
            },

            new Author()
            {
                Id = 2,
                Name = "JK Rowling"
            },
        };

        public static List<Book> Books { get; set; } = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title = "Food of the gods",
                AuthorId = 1,
                Author = Authors.ElementAt(0),
                ReleaseYear = 1992
            },

            new Book()
            {
                Id = 2,
                Title = "Harry Potter 1",
                AuthorId = 2,
                Author = Authors.ElementAt(1),
                ReleaseYear = 1997
            }
        };
    }
}
