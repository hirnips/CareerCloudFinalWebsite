using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs_Descriptions")]
    public class CompanyJobDescriptionPoco : IPoco
    {

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Job { get; set; }

        [Column("Job_Name")]
        public string JobName { get; set; }

        [Column("Job_Descriptions")]
        //public string JobDescription { get; set; }
        public string JobDescriptions { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual CompanyJobPoco CompanyJob { get; set; }
    }
}
