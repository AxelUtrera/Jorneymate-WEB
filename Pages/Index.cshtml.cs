using Microsoft.AspNetCore.Mvc.RazorPages;
using Jorneymate_WEB.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Jorneymate_WEB.Pages;

public class Explorer : PageModel
{
    public List<Routine> routines = new List<Routine>();
    
    // public async Task<IActionResult> OnGetAsync()
    // {
    //     try{
    //         routines = await RoutineLogic.GetRoutines();
    //     }
    //     catch(Exception e){
    //         Console.WriteLine("Ha habido un error" + e.Message);
    //     }
        
    //     return Page();
    // }

    public void OnGet()
    {

    }
}