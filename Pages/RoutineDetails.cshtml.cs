using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Jorneymate_WEB.Models;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using Logic;

namespace Jorneymate_WEB.Pages;

public class RoutineDetails : PageModel
{
    public Routine routineDetails = new Routine();

    public async System.Threading.Tasks.Task OnGetAsync()
    {
        
    }
}