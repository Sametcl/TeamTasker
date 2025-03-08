using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace TeamTasker.Models.Context
{
    public class TaskDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public TaskDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.AssignedTo)  // TaskModel'in AssignedTo özelliği ile ilişkilendirme
                .HasForeignKey(t => t.AssignedToId);  // ForeignKey olarak AssignedToId'yi kullanıyoruz
        }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
