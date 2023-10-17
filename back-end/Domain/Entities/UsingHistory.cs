using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UsingHistory : BaseEntity
    {
        public string UserName { get; set; }
        [ForeignKey("Medicine")]
        public Guid MedicineId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public UsingHistoryStatus Status { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
    public enum UsingHistoryStatus
    {
        OK = 0,
        NOTOK = 1,
    }

}
