using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Login { get; set; }

        [Column("Current_Salary")]
        public Decimal? CurrentSalary { get; set; }

        [Column("Current_Rate")]
        public Decimal? CurrentRate { get; set; }

        public string Currency { get; set; }

        [Column("Country_Code")]
        //public string CountryCode { get; set; }
        public string Country { get; set; }

        [Column("State_Province_Code")]
        //public string StateProvinceCode { get; set; }
        public string Province { get; set; }

        [Column("Street_Address")]
        //public string  StreetAddress { get; set; }
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

        public virtual ICollection<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual SecurityLoginPoco SecurityLogin { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCode { get; set; }
        public virtual ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }
        //public virtual ApplicantResumePoco ApplicantResume { get; set; }
        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }

    }
}
