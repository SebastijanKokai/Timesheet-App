using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timesheet_API.Models.Models
{
    [Table("CLIENT", Schema = "timesheet")]
    [Index("CountryId", Name = "IX_CLIENT_COUNTRY_ID")]
    public partial class Client : IGenericObject
    {
        public Client()
        {
            Projects = new HashSet<Project>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("COUNTRY_ID")]
        public Guid CountryId { get; set; }
        [Column("CLIENT_NAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string ClientName { get; set; } = null!;
        [Column("CLIENT_ADDRESS")]
        [StringLength(50)]
        [Unicode(false)]
        public string? ClientAddress { get; set; }
        [Column("CLIENT_CITY")]
        [StringLength(50)]
        [Unicode(false)]
        public string? ClientCity { get; set; }
        [Column("CLIENT_ZIP_CODE")]
        [StringLength(20)]
        [Unicode(false)]
        public string? ClientZipCode { get; set; }
        public DateTime? DeletedDate { get; set; }

        [ForeignKey("CountryId")]
        [InverseProperty("Clients")]
        public virtual Country Country { get; set; } = null!;
        [InverseProperty("Client")]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
