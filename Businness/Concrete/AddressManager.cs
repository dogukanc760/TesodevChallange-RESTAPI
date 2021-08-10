using Business.Constants;

using Businness.Abstract;

using Core.Utilities.Results;

using DataAccess.Abstract;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Concrete
{



    public class AddressManager : IAddressService
    {

        private IAddressDal _addresDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addresDal = addressDal;
        }

        public IResult Add(Address address)
        {
            _addresDal.Add(address);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Address address)
        {
            _addresDal.Delete(address);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Address> GetAddressByCustomer(string customerId)
        {
            return new SuccessDataResult<Address>(_addresDal.Get(a => a.CustomerId == customerId));

        }

        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addresDal.GetList().ToList());
        }

        public IDataResult<List<Address>> GetAllByCustomer(string customerId)
        {
            return new SuccessDataResult<List<Address>>(_addresDal.GetList(a=>a.CustomerId == customerId).ToList());
        }

        public IResult Update(Address address)
        {
            _addresDal.Update(address);
            return new SuccessResult(Messages.Updated);
        }
    }
}
