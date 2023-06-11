using Microsoft.AspNetCore.Mvc.RazorPages;
using Jorneymate_WEB.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Jorneymate_WEB.Pages;

public class EditRoutine : PageModel
{
    public Routine routineToEdit;
   
    public async Task<IActionResult> OnGetAsync(string idRoutine)
    {
        routineToEdit = await RoutineLogic.GetDetailsRoutine(idRoutine);
        return Page();
    }

    [HttpPost]
    public async Task<IActionResult> OnPost(string idRoutine, Routine updatedRoutine)
    {
        await RoutineLogic.UpdateRoutine(idRoutine, updatedRoutine);
        return RedirectToPage("/MyLists");
    }
}