using Core.Entities.Concrete;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Abstract
{
    public interface ICustomerService
    {
        List<OperationClaim> GetClaims(Customer customer);
        Customer GetUser(string customerId);
        List<Customer> GetAll();
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Customer GetByMail(string email);
        bool UserExist(string mail);
    }
}
