using Business.Constants;

using Businness.Abstract;

using Core.Entities.Concrete;
using Core.Utilities.Results;

using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
}
        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(_customerDal.GetList().ToList());
        }

        public Customer GetByMail(string email)
        {
            return _customerDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(Customer customer)
        {
            return _customerDal.GetClaims(customer);
        }

        public Customer GetUser(string customerId)
        {
            return _customerDal.Get(c => c.Id == customerId);
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }

        public bool UserExist(string mail)
        {
            var result = _customerDal.GetList(c => c.Email == mail).ToList();
            if (result.Count>0)
            {
                return true;
            }
            return false;
        }
    }
}
