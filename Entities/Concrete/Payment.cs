using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int PaymentId { get; set; }
        public int CardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExpirationDate { get; set; }
        public int CVV { get; set; }
    }
}
