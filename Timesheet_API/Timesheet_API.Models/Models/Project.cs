using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timesheet_API.Models.Models
{
    [Table("PROJECT", Schema = "timesheet")]
    [Index("ClientId", Name = "IX_PROJECT_CLIENT_ID")]
    public partial class Project : IGenericObject
    {
        public Project()
        {
            UserProjects = new HashSet<UserProject>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("CLIENT_ID")]
        public Guid ClientId { get; set; }
        [Column("PROJECT_NAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string ProjectName { get; set; } = null!;
        [Column("PROJECT_DESCRIPTION")]
        [StringLength(200)]
        [Unicode(false)]
        public string? ProjectDescription { get; set; }
        [Column("PROJECT_STATUS")]
        [StringLength(20)]
        [Unicode(false)]
        public string ProjectStatus { get; set; } = null!;
        public DateTime? DeletedDate { get; set; }

        [ForeignKey("ClientId")]
        [InverseProperty("Projects")]
        public virtual Client Client { get; set; } = null!;
        [InverseProperty("Project")]
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
