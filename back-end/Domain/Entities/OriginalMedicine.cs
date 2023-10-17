using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class OriginalMedicine : BaseEntity
    {
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Uses { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? DosageAndAdministration { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? SideEffectsAndInteractions { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? ContraindicationsandPrecautions { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? StorageAndExpiry { get; set; }
        public int Numbers { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Unit { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Notes { get; set; }
        public MedicineStatus MedicineStatus { get; set; }
        public virtual ICollection<MedicineDisease> MedicineForDisease { get; set; }

    }
    public enum MedicineStatus
    {
        NOTUSED = 0,
        INUSED = 1,
    }
}
