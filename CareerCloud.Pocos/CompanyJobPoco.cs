using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs")]
    public class CompanyJobPoco : IPoco
    {

        [Key] 
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public Guid Company { get; set; }


        [Column("Profile_Created")]
        [Required]
        public DateTime ProfileCreated { get; set; }

        [Column("Is_Inactive")]
        [Required]
        public Boolean IsInactive { get; set; }

        [Column("Is_Company_Hidden")]
        [Required]
        public Boolean IsCompanyHidden { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual ICollection<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public virtual ICollection<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public virtual CompanyProfilePoco CompanyProfile { get; set; }
        public virtual ICollection<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
    }
}
