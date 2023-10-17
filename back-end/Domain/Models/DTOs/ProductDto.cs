using Domain.Models.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTOs
{
    public class ProductDto : BaseDto
    {
        public string code { get; set; }
        public ProductStatus Status { get; set; }
        public Guid OrderId { get; set; }
        public virtual ICollection<UserDto> User { get; set; }
        //public virtual ICollection<MedicineDto> Medicine { get; set; }
    }
    public enum ProductStatus
    {
        INUSED = 0,
        NOTUSED = 1,
    }
}
