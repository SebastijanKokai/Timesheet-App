using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timesheet_API.Models.Models
{
    [Table("CATEGORY", Schema = "timesheet")]
    public partial class Category : IGenericObject
    {
        public Category()
        {
            TaskTables = new HashSet<ProjectTask>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("CATEGORY_NAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string CategoryName { get; set; } = null!;
        public DateTime? DeletedDate { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<ProjectTask> TaskTables { get; set; }
    }
}
