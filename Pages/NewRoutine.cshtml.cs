    using Jorneymate_WEB.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Logic; 

    namespace Jorneymate_WEB.Pages
    {
    public class NewRoutine : PageModel
    {

        private UserContext UserLogged { get; set; }

        public NewRoutine(UserContext userLogged){
            UserLogged = userLogged;
        }

        public void OnGet(){

        }

        public async Task<IActionResult> OnPost(Routine newRoutine)
        {
            string idRoutine = await RoutineLogic.SaveRoutine(UserLogged.User.Username, newRoutine);
            return RedirectToPage("/Index");
        }
    }
    }

