using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco : IPoco
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Applicant { get; set; }

        [Required]
        public Guid Job { get; set; }

        [Column("Application_Date")]
        [Required]
        public DateTime ApplicationDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }

        //public virtual ICollection<CompanyJobPoco> CompanyJobs { get; set; }
        public virtual CompanyJobPoco CompanyJob { get; set; }
    }
}
