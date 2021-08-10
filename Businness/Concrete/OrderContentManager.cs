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
    public class OrderContentManager : IOrderContentService
    {

        private IOrderContentDal _orderContentDal;
        public OrderContentManager(IOrderContentDal orderContentDal)
        {
            _orderContentDal = orderContentDal;
        }
        public IResult Add(OrderContent orderContent)
        {
            _orderContentDal.Add(orderContent);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(OrderContent orderContent)
        {
            _orderContentDal.Delete(orderContent);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<OrderContent> Get(string orderContentId)
        {
            return new SuccessDataResult<OrderContent>(_orderContentDal.Get(c => c.Id == orderContentId));
        }

        public IDataResult<List<OrderContent>> GetList()
        {
            return new SuccessDataResult<List<OrderContent>>(_orderContentDal.GetList().ToList());
        }

        public IDataResult<List<OrderContent>> GetListById(string orderContentId)
        {
            return new SuccessDataResult<List<OrderContent>>(_orderContentDal.GetList(c=>c.Id == orderContentId).ToList());
        }

        public IResult Update(OrderContent orderContent)
        {
            _orderContentDal.Update(orderContent);
            return new SuccessResult(Messages.Updated);
        }
    }
}
