using GraphQL.Types;
using GraphQL;
namespace TestCore.Data.GraphQL
{
    public class CounterSchema : Schema
    {
        public CounterSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<CounterQuery>();
            Mutation = resolver.Resolve<CounterMutation>();
        }
    }
}