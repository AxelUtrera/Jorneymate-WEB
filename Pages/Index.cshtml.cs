using Microsoft.AspNetCore.Mvc.RazorPages;
using Jorneymate_WEB.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Jorneymate_WEB.Pages;

public class Explorer : PageModel
{
    public List<Routine> routines = new List<Routine>();
    private UserContext UserLogged { get; set; }

    public Explorer(UserContext userContext)
    {
        UserLogged = userContext;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            routines = await RoutineLogic.GetRoutines();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ha habido un error" + e.Message);
        }
        return Page();
    }


    public async Task<IActionResult> OnPost(string idRoutine)
    {
        if (UserLogged == null || string.IsNullOrEmpty(UserLogged.User?.Username))
        {
            return RedirectToPage();
        }

        List<Routine> followedRoutines = await RoutineLogic.GetRoutinesFollowed(UserLogged.User.Username);
        List<string> idsFollowed = new List<string>();
        foreach(var item in followedRoutines)
        {
            idsFollowed.Add(item.Id);
        }

        if (!idsFollowed.Contains(idRoutine))
        {
            int statusCode = await RoutineLogic.FollowRoutine(UserLogged.User.Username, idRoutine);

            if (statusCode == 200)
            {
                return RedirectToPage("/LikedRoutines");
            }
        }
        else
        {
            return RedirectToPage("/LikedRoutines");
        }

        return RedirectToPage();
    }
}