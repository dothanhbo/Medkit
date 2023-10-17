using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        [Column(TypeName = "nvarchar(200)")]
        public string CustormerName { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Address { get; set; }
        public DateTime SellDate { get; set; }
        public Payment Payment { get; set; }
        public OrderStatus Status { get; set; }
        public virtual ICollection<Product> Product { get; set; }
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
