using Domain.Entities;
using Domain.Entities.Base;
using Domain.Models.DTOs.Base;

namespace Domain.Models.DTOs
{
    public class OriginalMedicineDto : BaseDto
    {
        public string Name { get; set; }
        public string Uses { get; set; }
        public string? DosageAndAdministration { get; set; }
        public string? SideEffectsAndInteractions { get; set; }
        public string? ContraindicationsandPrecautions { get; set; }
        public string? StorageAndExpiry { get; set; }
        public int Numbers { get; set; }
        public string Unit { get; set; }
        public string? Notes { get; set; }
        public MedicineStatus MedicineStatus { get; set; }
    }
    public enum MedicineStatus
    {
        NOTUSED = 0,
        INUSED = 1,
    }
}
