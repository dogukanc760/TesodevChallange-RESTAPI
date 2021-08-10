using Core.Utilities.Results;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Abstract
{
    public interface IAddressService
    {
        IDataResult<List<Address>> GetAll();
        IDataResult<List<Address>> GetAllByCustomer(string customerId);
        IDataResult<Address> GetAddressByCustomer(string customerId);
        IResult Add(Address address);
        IResult Delete(Address address);
        IResult Update(Address address);

    }
}
