using Jorneymate_WEB.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jorneymate_WEB.Pages;

public class Profile : PageModel
{

    public User user;

    public async Task<IActionResult> OnGetAsync(string username)
    {
        user = await UserLogic.RecoverUserByUsername("DanielPaxtian69");
        return Page();
    }
}