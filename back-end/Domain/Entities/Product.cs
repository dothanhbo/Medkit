using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        [Column(TypeName = "nvarchar(10)")]
        public string code { get; set; }
        public ProductStatus Status { get; set; }
        public Guid OrderId { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<Medicine> Medicine { get; set; }
    }
    public enum ProductStatus
    {
        INUSED = 0,
        NOTUSED = 1,
    }
}
