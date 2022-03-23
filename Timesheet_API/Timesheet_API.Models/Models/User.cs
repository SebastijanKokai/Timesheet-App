using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timesheet_API.Models.Models
{
    [Table("USER_TABLE", Schema = "timesheet")]
    [Index("RoleId", Name = "IX_USER_TABLE_ROLE_ID")]
    public partial class User : IGenericObject
    {
        public User()
        {
            UserProjects = new HashSet<UserProject>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("ROLE_ID")]
        public Guid? RoleId { get; set; }
        [Column("EMAIL")]
        [StringLength(50)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [Column("USER_PASSWORD")]
        [StringLength(50)]
        [Unicode(false)]
        public string UserPassword { get; set; } = null!;
        [Column("FIRST_NAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [Column("LAST_NAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        [Column("HOURS_PER_WEEK")]
        public int HoursPerWeek { get; set; }
        [Column("USER_STATUS")]
        [StringLength(20)]
        [Unicode(false)]
        public string UserStatus { get; set; } = null!;
        public DateTime? DeletedDate { get; set; }
        [Column("USERNAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string Username { get; set; } = null!;

        [ForeignKey("RoleId")]
        [InverseProperty("UserTables")]
        public virtual Role? Role { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
