using System.Linq;
using System.Net.Http.Headers;
using GraphQL.Types;
using TestCore.Data.Models;
using TestCore.Data.Repositories;

namespace TestCore.Data.GraphQL
{
    public class CounterQuery : ObjectGraphType
    {
        public CounterQuery(ICounterRepository repo)
        {
            Name = "Query";

            Field<CounterType>(
                "counter",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id" }),
                resolve: context => 
                {
                    var id = context.GetArgument<int>("id");
                    return repo.GetCounter(id);
                }); 

            Field<ListGraphType<CounterType>>("counters",
                resolve: context => repo.AllCounters());
        }
    }
}