using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Security_Roles")]
    public class SecurityRolePoco : IPoco
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Role { get; set; }

        [Column("Is_Inactive")]
        [Required]
        public Boolean IsInactive { get; set; }

        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
    }
}
