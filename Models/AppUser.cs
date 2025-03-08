using Microsoft.AspNetCore.Identity;

namespace TeamTasker.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>(); 
    }
}
