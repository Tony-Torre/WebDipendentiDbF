using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using WebDipendentiDbF.BLogic.Authentication;
using WebDipendentiDbF.Models;

namespace WebDipendentiDbF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]

        public IActionResult Auth(User user)
        {
            //TO DO check user/pwd in DB, inserimento in DB
            //Se utente esiste o utente nuovo inserito correttamente, tutto ok
            using (var authorizationDB = new DatabaseDipendentiContext())
            {
                var password = authorizationDB.MyUser.FromSqlRaw($"SELECT * from [dbo].[MyUser] where Email = 'adsjhaskdjhsda@gmail.com'");
                var utente = authorizationDB.MyUser.FromSqlRaw($"select * from [dbo].[MyUser] where username = @username and password = @password", new SqlParameter("@username", user.Email), new SqlParameter("@password", user.Password)).SingleOrDefault();

                Console.WriteLine(utente);
                if (utente != null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        public class User
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
