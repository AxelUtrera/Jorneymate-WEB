using Jorneymate_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic; 

namespace Jorneymate_WEB.Pages;

public class EditProfile : PageModel
{
    
    public void OnGet()
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> OnPost(User user)
    {
        await UserLogic.EditProfile(user).ConfigureAwait(false);
        return RedirectToPage("/Profile");
    }
}