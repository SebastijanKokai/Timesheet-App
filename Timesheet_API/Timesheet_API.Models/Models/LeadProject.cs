using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_API.Models.Models
{
    [Table("LEAD_PROJECT", Schema = "timesheet")]
    public partial class LeadProject
    {
        [Key]
        [Column("USER_TABLE_ID")]
        public Guid UserId { get; set; }
        [Key]
        [Column("PROJECT_ID")]
        public Guid ProjectId { get; set; }
        public DateTime? DeletedDate { get; set; }

        [ForeignKey("UserId,ProjectId")]
        [InverseProperty("LeadProject")]
        public virtual UserProject UserProject { get; set; } = null!;
    }
}
