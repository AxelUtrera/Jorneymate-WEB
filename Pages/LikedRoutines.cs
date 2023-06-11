using Microsoft.AspNetCore.Mvc.RazorPages;
using Jorneymate_WEB.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Jorneymate_WEB.Pages;

public class LikedRoutines : PageModel
{
    public List<Routine> followedRoutines = new List<Routine>();
    private UserContext UserLogged {get; set;}

    public LikedRoutines(UserContext userContext)
    {
        UserLogged = userContext;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        try{
            followedRoutines = await RoutineLogic.GetRoutinesFollowed(UserLogged.User.Username);
        }
        catch(Exception e){
            Console.WriteLine("Ha habido un error" + e.Message);
        }
        
        return Page();
    }


    public async Task<IActionResult> OnPost(string idRoutine)
    {
        int statusCode = await RoutineLogic.UnfollowRoutine(UserLogged.User.Username, idRoutine);

        return RedirectToPage();
    }
}