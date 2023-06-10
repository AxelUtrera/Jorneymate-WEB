
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Jorneymate_WEB.Models;
using Logic;
using System.ComponentModel.DataAnnotations;
using System.Collections.Specialized;

namespace Jorneymate_WEB.Pages
{
    public class Register : PageModel
    {
        [BindProperty]
        public string? Name { get; set; }

        [BindProperty]
        public string? Lastname { get; set; }

        [BindProperty]
        public int? Age { get; set; }

        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        [Compare(nameof(Password), ErrorMessage ="Las contraseñas no coinciden")]
        [BindProperty]
        public string? PasswordRepeated { get; set; }

        private int ValidateFields()
        {
            int codeResult = (int)Models.StatusCode.Ok;

            if (string.IsNullOrWhiteSpace(Name))
            {
                codeResult = (int)Models.StatusCode.ProccessError;
            }

            if (string.IsNullOrWhiteSpace(Lastname))
            {
                codeResult = (int)Models.StatusCode.ProccessError;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                codeResult = (int)Models.StatusCode.ProccessError;
            }

            if (string.IsNullOrWhiteSpace(PasswordRepeated))
            {
                codeResult = (int)Models.StatusCode.ProccessError;
            }

            if (!Password.Equals(PasswordRepeated))
            {
                codeResult = (int)Models.StatusCode.ProccessError;
            }

            

            return codeResult;
        }


        public async Task<IActionResult> OnPostAsync()
        {
            int codeResult = (int)Models.StatusCode.ProccessError;
            try
            {
                if (ValidateFields() == (int)Models.StatusCode.Ok)
                {
                    User userToCreate = new()
                    {
                        Name = Name,
                        Lastname = Lastname,
                        Age = (int)Age,
                        Username = GenerateUsername(),
                        Email = Email,
                        Password = Encription.GetHashedPassword(Password),
                    };

                    codeResult = await UserLogic.SignUp(userToCreate);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if(codeResult == (int)Models.StatusCode.Ok)
            {
                return RedirectToPage("/Login");
            }else if(codeResult == (int)Models.StatusCode.Conflict)
            {
                ModelState.AddModelError(string.Empty, "El correo electrónico ya está registrado");
            }
            return Page();
        }

        private string GenerateUsername()
        {
            Random random = new();
            return Name+Lastname+random.Next(1,1001).ToString();
        }
    }
}

