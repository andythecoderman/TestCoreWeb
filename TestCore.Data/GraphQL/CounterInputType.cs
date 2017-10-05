using GraphQL.Types;

namespace TestCore.Data.GraphQL
{
    public class CounterInputType : InputObjectGraphType
    {
        public CounterInputType()
        {
            Name = "CounterInput";
            Field<IntGraphType>("counterId");
            Field<IntGraphType>("count");
        }
    }
}