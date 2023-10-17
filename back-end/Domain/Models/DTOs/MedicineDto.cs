using Domain.Entities;
using Domain.Models.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTOs
{
    public class MedicineDto : BaseDto
    {
        public string Name { get; set; }
        public int Numbers { get; set; }
        public string Unit { get; set; }
        public string Notes { get; set; }
        public Guid ProductId { get; set; }
        public virtual ICollection<UsingHistory> UsingHistory { get; set; }
    }
}
