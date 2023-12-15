using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

namespace WebDipendentiDbF.BLogic.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Response.Headers.Add("WWW-authenticate", "Basic");
            
            //Controlla se la richiesta non torna nulla
            if (!Request.Headers.ContainsKey("Authorization"))
            {return Task.FromResult(AuthenticateResult.Fail("Autorizzazione mancante: Impossibile accedere al servizio"));}
            
            //Se torna qualcosa lo metto dentro una variabile
            var authorizationHeader = Request.Headers["Authorization"].ToString();

            //Mi faccio una Regex(Una finta string) che mi servirà per il controllo
            var authorizationRegEx = new Regex(@"Basic (.*)");

            //Dico che se non è compatibile mi da errore
            if (!authorizationRegEx.IsMatch(authorizationHeader))
            { return Task.FromResult(AuthenticateResult.Fail("Autorizzazione mancante: Impossibile accedere al servizio")); }

            //
            var authorizationBase64 = Encoding.UTF8.GetString(Convert.FromBase64String(authorizationRegEx.Replace(authorizationHeader, "$1")));

            var authorizationSplit = authorizationBase64.Split(':',2);

            if (authorizationSplit.Length != 2)
            {return Task.FromResult(AuthenticateResult.Fail("Autorizzazione non valida: Impossibile Accedere al servizio"));}

            var username = authorizationSplit[0];

            //if((username != "claudio") || (authorizationSplit[1] != "orloff"))
            //{ return Task.FromResult(AuthenticateResult.Fail("Nome utente o password non validi: Impossibile Accedere al servizio")); }

            var authenticationUser = new AuthenticationUser(username, "BasicAuthentication", true);

            var claims = new ClaimsPrincipal(new ClaimsIdentity(authenticationUser));

            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claims, "BasicAuthentication")));
        }
    }
}
