using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_API.Models.Models
{
    [Table("USER_PROJECT", Schema = "timesheet")]
    [Index("ProjectId", Name = "IX_USER_PROJECT_PROJECT_ID")]
    public partial class UserProject
    {
        public UserProject()
        {
            TaskTables = new HashSet<ProjectTask>();
        }

        [Key]
        [Column("USER_TABLE_ID")]
        public Guid UserId { get; set; }
        [Key]
        [Column("PROJECT_ID")]
        public Guid ProjectId { get; set; }
        public DateTime? DeletedDate { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("UserProjects")]
        public virtual Project Project { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("UserProjects")]
        public virtual User User { get; set; } = null!;
        [InverseProperty("UserProject")]
        public virtual LeadProject LeadProject { get; set; } = null!;
        [InverseProperty("UserProject")]
        public virtual ICollection<ProjectTask> TaskTables { get; set; }
    }
}
