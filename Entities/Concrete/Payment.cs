using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
    }
}
