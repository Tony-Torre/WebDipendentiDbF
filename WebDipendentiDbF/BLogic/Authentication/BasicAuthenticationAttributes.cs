using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace WebDipendentiDbF.BLogic.Authentication
{
    public class BasicAuthenticationAttributes : AuthorizeAttribute
    {
        public BasicAuthenticationAttributes() {

            Policy = "BasicAuthentication";
        }
    }
}
