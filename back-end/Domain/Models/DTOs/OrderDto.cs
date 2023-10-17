using Domain.Models.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTOs
{ 
    public class OrderDto : BaseDto
    {
        public string CustormerName { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime SellDate { get; set; }
        public Payment Payment { get; set; }
        public OrderStatus Status { get; set; }
        //public virtual ICollection<ProductDto> Product { get; set; }
    }
    public enum Payment
    {
        ONLINE = 0,
        COD = 1,
    }
    public enum OrderStatus
    {
        PENDING = 0,
        PROCESSING = 1,
        SHIPING = 2,
        DONE = 3,
    }
}
