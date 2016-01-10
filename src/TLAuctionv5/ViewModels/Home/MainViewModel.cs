using System;
using System.Collections.Generic;
using System.Linq;
using TLAuctionv5.Models;

namespace TLAuctionv5.ViewModels.Main
{
    public class MainViewModel
    {
        public List<Auction> Auctions { get; set; }
        public List<Category> Categories { get; set; }
        public List<Condition> Conditions { get; set; }
        public List<AuctionEndDate> AuctionEndDates { get; set; }
        public List<Manifest> Manifests { get; set; }
    }
}