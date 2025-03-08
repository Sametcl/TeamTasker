using Microsoft.AspNetCore.Identity;

namespace TeamTasker.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FullName => string.Join(" ", Name, SurName);
        public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>(); 
    }
}
