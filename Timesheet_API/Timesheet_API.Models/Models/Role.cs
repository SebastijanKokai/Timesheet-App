using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timesheet_API.Models.Models
{
    [Table("ROLE_TABLE", Schema = "timesheet")]
    public partial class Role : IGenericObject
    {
        public Role()
        {
            UserTables = new HashSet<User>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("ROLE_NAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string RoleName { get; set; } = null!;
        public DateTime? DeletedDate { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<User> UserTables { get; set; }
    }
}
