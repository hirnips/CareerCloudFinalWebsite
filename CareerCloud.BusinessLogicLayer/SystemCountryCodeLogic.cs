using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic 
    {
        protected IDataRepository<SystemCountryCodePoco> _repository;
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository) 
        {
            _repository = repository;
        }
        
        public void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Add(pocos);
        }

        public void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository.Update(pocos);
        }

        protected void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
           
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code))
                {
                    exceptions.Add(new ValidationException(900, $"Code cannot be empty {poco.Code}."));
                }

                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(901, $"Name cannot be empty {poco.Code}."));
                }

            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
