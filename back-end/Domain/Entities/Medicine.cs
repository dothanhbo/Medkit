using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Medicine : BaseEntity
    {
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public int Numbers { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Unit { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Notes { get; set; }
        public Guid ProductId { get; set; }
        public virtual ICollection<UsingHistory> UsingHistory { get; set; }
    }
}
