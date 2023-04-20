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

/*Create an application where users can post simple ads for others to see.
 An ad consists of a Title, Phone number and description. To create an ad, a user must be logged in. 

Here are the basic pages you'll need:

Home Page - on this page, display all the ads in the system. If the current user is logged in,
and some of the ads belong to them, those ads should also have a delete button that gives that user 
the ability to delete that ad.

New Ad - (Put a link to this page up in the nav bar using the layout page) - When this page is accessed, 
if the current user isn't logged in, they should be redirected to a login page. 
If they are logged in however, they should be shown a form where they can create a new ad. 

My Account (this should be shown in the nav bar using the layout as well - however, 
this link should only be shown if the current user is logged in) - 
on this page, display all the ads that the current user has created as well as a delete button for each one.

Finally, in the nav bar on top, if the current user is logged in, display a Logout link. 
If they're NOT logged in, display a link called Login.
*/