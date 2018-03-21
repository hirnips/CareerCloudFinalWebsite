using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityLoginsRoleLogic : BaseLogic<SecurityLoginsRolePoco>
    {
        public SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repository) : base(repository)
        {
        }
    }
}
