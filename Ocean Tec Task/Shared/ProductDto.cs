using Ocean_Tec_Task.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ocean_Tec_Task.Shared
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string GroupName { get; set; }
        public Guid MainUnitId { get; set; } = Guid.Empty;
        public Guid SmallUnitId { get; set; } = Guid.Empty;
        public Guid MediumUnitId { get; set; } = Guid.Empty;

        public UnitDto MainUnit { get; set; }
        public UnitDto SmallUnit { get; set; }
        public UnitDto MediumUnit { get; set; }

    }
}
