using Ocean_Tec_Task.Models;

namespace Ocean_Tec_Task.Shared
{
    public class UnitDto
    {
        public Guid UnitId { get; set; }
        public UnitSelection UnitSelection { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal HalfWholesalePrice { get; set; }
        public decimal ConsumerPrice { get; set; }
        public Guid CharacteristicsId { get; set; }
        public CharacteristicsDto Characteristic { get; set; }

    }
}
