using Jorneymate_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic; 

namespace Jorneymate_WEB.Pages;

public class NewRoutine : PageModel
{

    public void OnGet(){

    }

    [HttpPost]
    public async Task<IActionResult> OnPost(Routine newRoutine)
    {
        string idRoutine = await RoutineLogic.SaveRoutine("DanielPaxtian69", newRoutine);
        return RedirectToPage("/Index");
    }
}