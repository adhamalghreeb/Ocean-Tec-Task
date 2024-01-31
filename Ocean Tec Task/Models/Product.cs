using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ocean_Tec_Task.Models
{
    public class Product
    {
        [Column("ProductId")]
        public Guid Id { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string GroupName { get; set; }

        [ForeignKey(nameof(MainUnit))]
        public Guid? MainUnitId { get; set; }
        public Unit? MainUnit { get; set; }

        [ForeignKey(nameof(MediumUnit))]
        public Guid? MediumUnitId { get; set; }
        public Unit? MediumUnit { get; set; }

        [ForeignKey(nameof(SmallUnit))]
        public Guid? SmallUnitId { get; set; }
        public Unit? SmallUnit { get; set; }

        public ICollection<Order> Orders { get; set; }
        
    }

}
