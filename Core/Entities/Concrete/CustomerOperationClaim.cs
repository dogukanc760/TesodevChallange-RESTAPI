using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class CustomerOperationClaim:IEntity
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
