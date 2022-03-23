using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Timesheet_API.Models.Models
{
    [Table("COUNTRY", Schema = "timesheet")]
    public partial class Country : IGenericObject
    {
        public Country()
        {
            Clients = new HashSet<Client>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("COUNTRY_NAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string CountryName { get; set; } = null!;
        public DateTime? DeletedDate { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<Client> Clients { get; set; }
    }
}
