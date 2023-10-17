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
    public class DiseaseDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string Prevalence { get; set; }
        public string RiskFactors { get; set; }
        public string Treatment { get; set; }
        public string Prognosis { get; set; }
        public DiseaseStatus DiseaseStatus { get; set; }
        public virtual ICollection<MedicineDiseaseDto>? MedicineDisease { get; set; }
        [NotMapped]
        public virtual ICollection<OriginalMedicineDto>? OriginalMedicines { get; set; }
    }

}
