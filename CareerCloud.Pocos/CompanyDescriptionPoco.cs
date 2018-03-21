using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Descriptions")]
    public class CompanyDescriptionPoco : IPoco
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Company { get; set; }

        [Column("LanguageID")]
        [Required]
        //public string LanguageID { get; set; }
        public string LanguageId { get; set; }

        [Column("Company_Name")]
        [Required]
        public string CompanyName { get; set; }

        [Column("Company_Description")]
        [Required]
        public string CompanyDescription { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual CompanyProfilePoco companyProfile { get; set; }
        public virtual SystemLanguageCodePoco SystemLanguageCode { get; set; }
    }
}
