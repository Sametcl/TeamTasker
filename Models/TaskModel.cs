using TeamTasker.Models.Enums;

namespace TeamTasker.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeadLine { get; set; } 
        public TaskPriority Priority { get; set; }=TaskPriority.Düşük;
        public bool Status { get; set; } = false;
        public string? AssignedToId { get; set; }
        public AppUser? AssignedTo { get; set; }
        public string? CreatedById { get; set; }
        public AppUser? CreatedBy { get; set; }
    }
}
