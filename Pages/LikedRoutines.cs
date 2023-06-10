using Microsoft.AspNetCore.Mvc.RazorPages;
using Jorneymate_WEB.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Jorneymate_WEB.Pages;

public class LikedRoutines : PageModel
{
    public List<Routine> followedRoutines = new List<Routine>();

    public async Task<IActionResult> OnGetAsync()
    {
        try{
            followedRoutines = await RoutineLogic.GetRoutines();
        }
        catch(Exception e){
            Console.WriteLine("Ha habido un error" + e.Message);
        }
        
        return Page();
    }
}