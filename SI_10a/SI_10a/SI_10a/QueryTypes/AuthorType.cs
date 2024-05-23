using GraphQL.Types;
using SI_10a.Models;

namespace SI_10a.QueryTypes
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType() 
        {
            Field<NonNullGraphType<IntGraphType>>(nameof(Author.Id));
            Field<NonNullGraphType<StringGraphType>>(nameof(Author.Name));
            Field<ListGraphType<BookType>>( "books", resolve: context => Database.Books.Where(a => a.AuthorId == context.Source.Id));
        }
    }
}
