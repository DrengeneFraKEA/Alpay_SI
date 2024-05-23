using GraphQL.Types;
using SI_10a.QueryTypes;

namespace SI_10a.Queries
{
    public class Query : ObjectGraphType
    {
        public Query() 
        {
            // Books
            Field<ListGraphType<BookType>>("books", resolve: x => Database.Books);
            Field<BookType>("book", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return Database.Books.FirstOrDefault(x => x.Id == id);
                });

            // Authors
            Field<ListGraphType<AuthorType>>("authors", resolve: context => Database.Authors);
            Field<AuthorType>("author", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return Database.Authors.FirstOrDefault(a => a.Id == id);
                }
            );
        }
    }
}
