using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Skills")]
    public class CompanyJobSkillPoco : IPoco
    {

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Job { get; set; }

        [Required]
        public string Skill { get; set; }

        [Column("Skill_Level")]
        [Required]
        public string SkillLevel { get; set; }

        [Required]
        public int Importance { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual CompanyJobPoco CompanyJob { get; set; }
    }
}
