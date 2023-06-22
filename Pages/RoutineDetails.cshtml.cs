using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Jorneymate_WEB.Models;
using Logic;

namespace Jorneymate_WEB.Pages;

public class RoutineDetails : PageModel
{
    public Routine routineDetails = new Routine();
    public List<Models.Task> tasksRoutines = new List<Models.Task>();

    public async Task<IActionResult> OnGetAsync(string idRoutine)
    {
        routineDetails = await RoutineLogic.GetDetailsRoutine(idRoutine);
        tasksRoutines = await TaskLogic.GetTasksByRoutineId(routineDetails.Id);
        return Page();
    }

}