using System.ComponentModel.DataAnnotations.Schema;

namespace Ocean_Tec_Task.Models
{
    public class Unit
    {
        public Guid UnitId { get; set; }
        public UnitSelection UnitSelection { get; set; }

        public decimal WholesalePrice { get; set; }
        public decimal HalfWholesalePrice { get; set; }
        public decimal ConsumerPrice { get; set; }

        [ForeignKey(nameof(Characteristics))]
        public Guid? CharacteristicsId { get; set; }
        public Characteristics? Characteristics { get; set; }
    }

    public enum UnitSelection
    {
        SmallUnit,
        MediumUnit,
        MainUnit
    }
}
