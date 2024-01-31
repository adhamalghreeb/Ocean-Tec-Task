using System.ComponentModel.DataAnnotations.Schema;

namespace Ocean_Tec_Task.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public int Quantity { get; set; }
        public OrderType Type { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }


        public Bill Bill { get; set; }
    }

    public enum OrderType
    {
        BulkPurchase,
        Retailer,
        EndUser
    }

}
