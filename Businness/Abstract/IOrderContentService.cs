using Core.Utilities.Results;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Abstract
{
    public interface IOrderContentService
    {
        IResult Add(OrderContent orderContent);
        IResult Update(OrderContent orderContent);
        IResult Delete(OrderContent orderContent);
        IDataResult<List<OrderContent>> GetList();
        IDataResult<OrderContent> Get(string orderContentId);
        IDataResult<List<OrderContent>> GetListById(string orderContentId);
        //IResult ChangeStatus(string orderContentId, string status);
    }
}
