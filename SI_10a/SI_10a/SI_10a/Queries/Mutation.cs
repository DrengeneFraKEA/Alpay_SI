using GraphQL.Types;
using SI_10a.Models;
using SI_10a.QueryTypes;

namespace SI_10a.Queries
{
    public class Mutation : ObjectGraphType
    {
        public Mutation() 
        {
            Field<BookType>(
            "createBook",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "authorId" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "title" },
                new QueryArgument<IntGraphType> { Name = "releaseYear" }
            ),
            resolve: context =>
            {
                Book book = new Book()
                {
                    AuthorId = context.GetArgument<int>("authorId"),
                    Title = context.GetArgument<string>("title"),
                    ReleaseYear = context.GetArgument<int>("releaseYear")
                };

                Database.Books.Add(book);

                return book;
            }
        );

            Field<BookType>(
                "updateBook",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<IdGraphType> { Name = "authorId" },
                    new QueryArgument<StringGraphType> { Name = "title" },
                    new QueryArgument<IntGraphType> { Name = "releaseYear" }
                ),
                resolve: context =>
                {
                    Book book = Database.Books.Where(x => x.Id == context.GetArgument<int>("id")).FirstOrDefault();
                    if (book != null)
                    {
                        Book tempBook = new Book()
                        {
                            Id = context.GetArgument<int>("id"),
                            AuthorId = context.GetArgument<int>("authorId"),
                            Title = context.GetArgument<string>("title"),
                            ReleaseYear = context.GetArgument<int>("releaseYear")
                        };

                        Database.Books.Remove(book);
                        Database.Books.Add(tempBook);

                        return tempBook;
                    }
                    else
                    {
                        return null;
                    }
                }
            );

            Field<MessageType>("deleteBook", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    Book book = Database.Books.Where(x => x.Id == context.GetArgument<int>("id")).FirstOrDefault();
                    if (book != null)
                    {
                        Database.Books.Remove(book);
                        return new Message() { msg = "Book deleted" };
                    }
                    else
                    {
                        return new Message() { msg = "Book not found" };
                    }
                }
            );
        }
    }
}
