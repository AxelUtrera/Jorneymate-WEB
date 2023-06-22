using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Jorneymate_WEB.Models;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using Logic;

namespace Jorneymate_WEB.Pages;

public class MyRoutineDetails : PageModel
{
    public Routine routineDetails = new Routine();
    public List<Models.Task> tasksRoutines = new List<Models.Task>();

    [BindProperty]
    public string Title { get; set; }

    [BindProperty]
    public string Direction { get; set; }
    [BindProperty]
    public string Budget { get; set; }
    [BindProperty]
    public string Description { get; set; }

    public async Task<IActionResult> OnGetAsync(string idRoutine)
    {
        routineDetails = await RoutineLogic.GetDetailsRoutine(idRoutine);
        tasksRoutines = await TaskLogic.GetTasksByRoutineId(routineDetails.Id);
        return Page();
    }

    public async Task<IActionResult> OnPostSaveNewTask(string idRoutine, string Name, string Direction, string Budget, string TaskDescription)
    {
        int codeResult = (int)Models.StatusCode.ProccessError;

        Models.Task taskToAdd = new()
        {
            Name = Name,
            Address = Direction,
            Budget = Int32.Parse(Budget),
            TaskDescription = TaskDescription,
            IsCompleted = false
        };
        try
        {
            codeResult = await TaskLogic.AddNewTaskToRoutine(idRoutine, taskToAdd);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        Console.WriteLine(codeResult);

        return codeResult == (int)Models.StatusCode.Ok ? RedirectToPage("/MyRoutineDetails", new { idRoutine }) : BadRequest();
    }

    public async Task<IActionResult> OnDeleteTask(string idTask, string idRoutine)
    {
        Console.WriteLine(idTask);
        Console.WriteLine(idRoutine);
        int codeResult = (int)Models.StatusCode.ProccessError;
        
        try
        {
            codeResult = await TaskLogic.DeleteTask(idTask);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString);
        }

        return codeResult == (int)Models.StatusCode.Ok ? RedirectToPage("/MyRoutineDetails", new { idRoutine }) : BadRequest(); ;

    }

}