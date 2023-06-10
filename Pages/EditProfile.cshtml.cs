using Jorneymate_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic; 

namespace Jorneymate_WEB.Pages;

public class EditProfile : PageModel
{
    public User userRecover = new User();

    public async Task<IActionResult> OnGet(string username)
    {
        userRecover = await UserLogic.RecoverUserByUsername(username);
        Console.WriteLine(userRecover.Username);
        return Page();
    }

    [HttpPost]
    public async Task<IActionResult> OnPost(User user)
    {
        user.Username = userRecover.Username;
        await UserLogic.EditProfile(user).ConfigureAwait(false);
        return RedirectToPage("/Profile");
    }
}