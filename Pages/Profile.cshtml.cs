using Jorneymate_WEB.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jorneymate_WEB.Pages;

public class Profile : PageModel
{
    private UserContext UserLogged {get; set;}

    public Profile(UserContext userContext)
    {
        UserLogged = userContext;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        UserLogged.User = await UserLogic.RecoverUserByUsername(UserLogged.User.Username);
        return Page();
    }

    [HttpPost]
    public void OnPost()
    {
        Console.WriteLine("agarre el post");
        
    }
}