using Domain.Models.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTOs
{
    public class UsingHistoryDto : BaseDto
    {
        public string UserName { get; set; }
        public Guid? MedicineId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public UsingHistoryStatus Status { get; set; }
        [NotMapped]
        public string? MedicineName { get; set; }
    }
    public enum UsingHistoryStatus
    {
        OK = 0,
        NOTOK = 1,
    }
}
