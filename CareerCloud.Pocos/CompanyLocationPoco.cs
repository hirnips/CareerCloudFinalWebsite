using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
    public class CompanyLocationPoco : IPoco
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Company { get; set; }

        [Column("Country_Code")]
        [Required]
        public string CountryCode { get; set; }

        [Column("State_Province_Code")]
        //public string StateProvinceCode { get; set; }
        public string Province { get; set; }

        [Column("Street_Address")]
        //public string StreetAddress { get; set; }
        public string Street { get; set; }

        [Column("City_Town")]
        //public string CityTown { get; set; }
        public string City { get; set; }

        [Column("Zip_Postal_Code")]
        //public string ZipPostalCode { get; set; }
        public string PostalCode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual CompanyProfilePoco CompanyProfile { get; set; }
    }
}
