using GraphQL;
using SI_10a.Queries;

namespace SI_10a
{
    public class SI10aSchema : GraphQL.Types.Schema
    {
        public SI10aSchema(IDependencyResolver resolver) : base (resolver) 
        {
            Query = resolver.Resolve<Query>();
            Mutation = resolver.Resolve<Mutation>();
        }
    }
}
