using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicineDisease
    {
        public Guid DiseaseId { get; set; }
        public Guid OriginalMedicineId { get; set; }
        public virtual Disease? Disease { get; set; }
        public virtual OriginalMedicine? OriginalMedicine { get; set; }
    }
}
