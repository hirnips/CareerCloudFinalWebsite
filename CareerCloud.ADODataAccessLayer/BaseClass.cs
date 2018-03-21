using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
    public class BaseClass
    {
        protected readonly string _connString;

        public BaseClass()
        {
            _connString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }
    }
}
