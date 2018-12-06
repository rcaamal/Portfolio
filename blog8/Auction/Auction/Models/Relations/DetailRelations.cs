using Auction.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiddingApp.Models.ViewModels
{
    public class DetailsViewModel
    {
        [DisplayName("Buyer")]
        public string Buyer { get; set; }

        [DisplayName("Seller")]
        public string Seller { get; set; }

        [DisplayName("Price")]
        public int Price { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("ID")]
        public int ItemID { get; set; }

        [DisplayName("Item Name")]
        public string Name { get; set; }

        [DisplayName("Timestamp")]
        public DateTime TimeStamp { get; set; }

        [DisplayName("Bids")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids { get; set; }
    }
}