namespace Auction.Models
{
    using Auction.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bid")]
    public partial class Bid
    {
        public int ID { get; set; }

        [DisplayName("Item ID")]
        public int ItemID { get; set; }

        [DisplayName("Buyer Name")]
        public int Buyer { get; set; }

        [DisplayName("Bid")]
        public int Price { get; set; }

        [DisplayName("Time")]
        public DateTime TimeStamp { get; set; }

        public virtual Item Item { get; set; }

        public virtual Buyer Buyer1 { get; set; }
    }
}