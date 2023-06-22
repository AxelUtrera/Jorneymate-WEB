
using Logic;
using Jorneymate_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jorneymate_WEB.Pages;

public class MyLists : PageModel
{
    public List<Routine> createdRoutines = new List<Routine>();
    private UserContext UserLogged {get; set;}

    public MyLists(UserContext userContext)
    {
        UserLogged = userContext;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        try{
            createdRoutines = await RoutineLogic.GetRoutinesCreated(UserLogged.User.Username);
        }
        catch(Exception e){
            Console.WriteLine("Ha habido un error" + e.Message);
        }
        return Page();
    }


    public async Task<IActionResult> OnPost(string idRoutine)
    {
        try
        {
            await RoutineLogic.DeleteRoutine(idRoutine);
            return RedirectToPage();
        }
        catch (Exception e)
        {
            Console.WriteLine("An excepcion ocurred" + e.Message);
            return RedirectToPage();
        }
    }
}