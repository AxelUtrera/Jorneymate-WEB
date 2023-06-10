using Jorneymate_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic;

namespace Jorneymate_WEB.Pages
{
    public class Login : PageModel
    {
        public UserContext UserLogged { get; set; }

        public Login(UserContext userLogged)
        {
            UserLogged = userLogged;
        }

        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            User? userResult = null;
            try
            {
                if (Email != null && Password != null)
                {
                    userResult = await Autentication.Login(Email, Password);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ha habido un error" + e.Message);
            }

            if (userResult != null)
            {
                UserLogged.User = userResult;
                Console.WriteLine(UserLogged.User.Username);
                return RedirectToPage("/Index");
            }
            else
            {
                TempData["Error"] = "El correo o la contraseña son incorrectos";
                return Page();
            }
        }
    }
}
