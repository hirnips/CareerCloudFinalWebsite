using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Educations")]
    public class CompanyJobEducationPoco : IPoco
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Job { get; set; }

        [Required]
        public string Major { get; set; }

        [Required]
        public Int16 Importance { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual CompanyJobPoco CompanyJob { get; set; }
    }
}
