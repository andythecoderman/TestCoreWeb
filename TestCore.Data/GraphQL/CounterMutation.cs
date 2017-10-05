using GraphQL.Types;
using TestCore.Data.Models;
using TestCore.Data.Repositories;

namespace TestCore.Data.GraphQL
{
    public class CounterMutation : ObjectGraphType<object>
    {
        public CounterMutation(ICounterRepository repo)
        {
            Name = "Mutation";

            Field<CounterType>(
                "createCounter",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CounterInputType>> { Name = "input" }
                ),
                resolve: context => 
                {
                    var counter = context.GetArgument<Counter>("input");
                    return repo.CreateCounter(counter);
                });

            Field<CounterType>(
                "updateCounter",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CounterInputType>> { Name = "input" }
                ),
                resolve: context =>
                {
                    var counter = context.GetArgument<Counter>("input");
                    return repo.UpdateCounter(counter);
                });
        }
    }
}