using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using TLAuctionv5.Models;

namespace TLAuctionv5.ViewModels.Main
{
    public class MainViewModel
    {
        public IEnumerable<AuctionOpenView> Auctions { get; set; }
        public IQueryable<Auction_Category> Categories { get; set; }
        public IQueryable<Auction_Condition> Conditions { get; set; }
        public IQueryable<ManifestOpenView> Manifests { get; set; }

        public SelectList SortList
        {
            get
            {
                var sortList = new SelectList(
                new List<SelectListItem>
                {
                new SelectListItem { Text = "Best price first", Value = "pricediff"},
                new SelectListItem { Text = "Auctions ending soonest", Value = "enddate_desc"},
                }, "Value", "Text");

                return sortList;
            }

            set { }
        }
    }
}