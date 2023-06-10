using Jorneymate_WEB.Models;

namespace Jorneymate_WEB.Models
{
    public class UserContext
    {
        public User User { get; set; }

        public void ResetInstance()
        {
            User = null;
        }
    }
}
