using GraphQL.Types;
using TestCore.Data.Models;

namespace TestCore.Data.GraphQL
{
    public class CounterType : ObjectGraphType<Counter>
    {
        public CounterType()
        {
            Name = "Counter";

            Field(x => x.CounterId).Description("Primary Key of the counter");
            Field(x => x.Count).Description("Current Counter Value of the Counter");
        }
    }
}