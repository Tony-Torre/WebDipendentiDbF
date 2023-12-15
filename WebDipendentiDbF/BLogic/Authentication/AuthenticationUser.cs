using System.Security.Principal;

namespace WebDipendentiDbF.BLogic.Authentication
{
    public class AuthenticationUser : IIdentity
    {
        public string? AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string? Name { get; set; }

        public AuthenticationUser(string?name , string ?authenticationType, bool isAuthenticated)
        {
            AuthenticationType = authenticationType;
            Name = name;
            IsAuthenticated = isAuthenticated;
        }
    }
}
