using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Disease : BaseEntity
    {
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string  Description { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Symptoms { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Prevalence { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string RiskFactors { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Treatment { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Prognosis { get; set; }
        public DiseaseStatus DiseaseStatus { get; set; }
        public virtual ICollection<MedicineDisease> MedicineDisease { get; set; }
    }
    public enum DiseaseStatus
    {
        UNAVAILABLE = 0,
        AVAILABLE = 1,
    }
}
