using System.ComponentModel.DataAnnotations.Schema;

namespace Ocean_Tec_Task.Models
{
    public class Bill
    {
        public Guid BillId { get; set; }
        
        public DateTime BillingDate { get; set; }

        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }

}
