using System.Data;
using TeamTasker.Models;

namespace TeamTasker.ViewModels
{
    public class RoleViewModel
    {
        public AppRole Role { get; set; } = default!;
        public List<AppRole> RoleList { get; set; } = new List<AppRole>();
    }
}
