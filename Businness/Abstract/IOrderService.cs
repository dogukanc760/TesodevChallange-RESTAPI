using Core.Utilities.Results;

using Entities;
using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Abstract
{
    public interface IOrderService
    {
        IResult Add(Order orderContent);
        IResult Update(Order orderContent);
        IResult Delete(Order orderContent);
        IDataResult<List<Order>> GetList();
        IDataResult<List<Order>> GetListById(string orderId);
        IDataResult<Order> Get(string orderContentId);
        IResult ChangeStatus(string orderContentId, string status);
    }
}
