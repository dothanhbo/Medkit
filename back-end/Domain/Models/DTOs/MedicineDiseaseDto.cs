using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTOs
{
    public class MedicineDiseaseDto
    {
        public Guid DiseaseId { get; set; }
        public Guid OriginalMedicineId { get; set; }
        public virtual DiseaseDto? Disease { get; set; }
        public virtual OriginalMedicineDto? OriginalMedicine { get; set; }
    }
}
