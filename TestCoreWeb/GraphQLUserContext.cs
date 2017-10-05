using System.Security.Claims;

namespace TestCoreWeb
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}