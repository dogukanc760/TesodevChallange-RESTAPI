using Business.Constants;

using Businness.Abstract;

using Core.Utilities.Results;

using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

using Entities;
using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order orderContent)
        {
            _orderDal.Add(orderContent);
            return new SuccessResult(Messages.Added);
        }

        public IResult ChangeStatus(string orderContentId, string status)
        {
            var result = _orderDal.Get(c => c.Id == orderContentId);
            result.Status = status;
            _orderDal.Update(result);
            return new SuccessResult("Status "+Messages.Added);
        }

        public IResult Delete(Order orderContent)
        {
            _orderDal.Delete(orderContent);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<Order> Get(string orderContentId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(c => c.Id == orderContentId));
        }

        public IDataResult<List<Order>> GetList()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetList().ToList());
        }

        public IDataResult<List<Order>> GetListById(string orderId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetList(c=>c.Id==orderId).ToList());
        }

        public IResult Update(Order orderContent)
        {
            _orderDal.Update(orderContent);
            return new SuccessResult(Messages.Updated);
        }
    }
}
