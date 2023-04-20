using AuthDemo.Data;
using AuthDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthDemo.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=AuthDemo;Integrated Security=true;";

        public IActionResult Index()
        {
            var vm = new HomePageViewModel
            {
                IsLoggedIn = User.Identity.IsAuthenticated
            };

            return View(vm);
        }

        [Authorize]
        public IActionResult Secret()
        {
            //this gets the email of the currently logged in user which we stored in the 
            //login cookie in the account controller login when doing this:

           /* var claims = new List<Claim>
           {
              new Claim("user", email) //this will store the users email into the login cookie
           };*/

            var currentUserEmail = User.Identity.Name;
            var repo = new UserRepository(_connectionString);
            var user = repo.GetByEmail(currentUserEmail);
            return View(new SecretPageViewModel
            {
                CurrentUserEmail = user.Email,
                CurrentUserId = user.Id,
                CurrentUserName = user.Name
            });
        }
    }
}