using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins")]
    public class SecurityLoginPoco : IPoco
    {

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Column("Created_Date")]
        //public DateTime CreatedDate { get; set; }
        public DateTime Created { get; set; }

        [Column("Password_Update_Date")]
        //public DateTime? PasswordUpdateDate { get; set; }
        public DateTime? PasswordUpdate { get; set; }

        [Column("Agreement_Accepted_Date")]
        //public DateTime? AgreementAcceptedDate { get; set; }
        public DateTime? AgreementAccepted { get; set; }

        [Column("Is_Locked")]
        [Required]
        public Boolean IsLocked { get; set; }

        [Column("Is_Inactive")]
        [Required]
        public Boolean IsInactive { get; set; }

        [Column("Email_Address")]
        [Required]
        public string EmailAddress { get; set; }

        [Column("Phone_Number")]
        public string PhoneNumber { get; set; }

        [Column("Full_Name")]
        public string FullName { get; set; }

        [Column("Force_Change_Password")]
        [Required]
        public Boolean ForceChangePassword { get; set; }

        [Column("Prefferred_Language")]
        public string PrefferredLanguage { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
    }
}
