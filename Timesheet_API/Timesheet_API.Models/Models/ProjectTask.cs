using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timesheet_API.Models.Models
{
    [Table("TASK_TABLE", Schema = "timesheet")]
    [Index("CategoryId", Name = "IX_TASK_TABLE_CATEGORY_ID")]
    [Index("UserTableId", "ProjectId", Name = "IX_TASK_TABLE_USER_TABLE_ID_PROJECT_ID")]
    public partial class ProjectTask : IGenericObject
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("USER_TABLE_ID")]
        public Guid UserId { get; set; }
        [Column("PROJECT_ID")]
        public Guid ProjectId { get; set; }
        [Column("CATEGORY_ID")]
        public Guid CategoryId { get; set; }
        [Column("TASK_DESCRIPTION")]
        [StringLength(200)]
        [Unicode(false)]
        public string? TaskDescription { get; set; }
        [Column("TASK_TIME", TypeName = "numeric(4, 2)")]
        public decimal TaskTime { get; set; }
        [Column("TASK_OVERTIME", TypeName = "numeric(4, 2)")]
        public decimal? TaskOvertime { get; set; }
        [Column("TASK_DATE", TypeName = "date")]
        public DateTime TaskDate { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("TaskTables")]
        public virtual Category Category { get; set; } = null!;
        [ForeignKey("UserTableId,ProjectId")]
        [InverseProperty("TaskTables")]
        public virtual UserProject UserProject { get; set; } = null!;
    }
}
