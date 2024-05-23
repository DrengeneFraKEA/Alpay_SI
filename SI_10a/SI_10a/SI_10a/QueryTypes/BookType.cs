using GraphQL.Types;
using SI_10a.Models;

namespace SI_10a.QueryTypes
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType() 
        {
            Field<NonNullGraphType<IntGraphType>>(nameof(Book.Id));
            Field<NonNullGraphType<StringGraphType>>(nameof(Book.Title));
            Field<NonNullGraphType<IntGraphType>>(nameof(Book.ReleaseYear));
            Field<NonNullGraphType<IntGraphType>>(nameof(Book.AuthorId));
            Field<AuthorType>("author", resolve: context => Database.Authors.FirstOrDefault(a => a.Id == context.Source.AuthorId));
        }
    }
}
