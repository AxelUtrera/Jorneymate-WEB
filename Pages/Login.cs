using Jorneymate_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jorneymate_WEB.Pages
{
    public class Login : PageModel
    {
        public User UserLogged { get; set; }

        [BindProperty]
        public string Email { get; set; } 

        [BindProperty]
        public string Password { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            User userResult = await Logic.Autentication.Login(Email, Password);

            if (userResult != null)
            {
                UserLogged = userResult;
                return RedirectToPage("/Index");
            }
            else
            {
                TempData["Error"] = "Los datos ingresados son incorrectos. Intenta nuevamente.";
                return Page();
            }
        }
    }
}
