﻿namespace Ocean_Tec_Task.Models
{
    public class Characteristics
    {
        public Guid CharacteristicsId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int OrderLimit { get; set; }
        public int MaximumLimit { get; set; }
        public int MinimumLimit { get; set; }
        public decimal Tax { get; set; }
        public decimal LastPurchasePrice { get; set; }
    }
}
