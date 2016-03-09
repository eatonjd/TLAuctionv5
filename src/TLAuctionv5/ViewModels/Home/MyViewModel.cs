using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TLAuctionv5.Models;

namespace TLAuctionv5.ViewModels.Main
{
    public class MyViewModel
    {
        public MyViewModel()
        {
            AuctionMD = new AuctionMasterDetail();
        }
        
        public IQueryable<Auction_Category> Categories { get; set; }
        public IQueryable<Auction_Condition> Conditions { get; set; }
        public IQueryable<ManifestOpenView> Manifests { get; set; }
        public IQueryable<ManifestEndedView> ManifestsEnded { get; set; }
        public IQueryable<ProductView> Products { get; set; }

        public AuctionMasterDetail AuctionMD { get; set; }

        public string getDiffColor(decimal lPctDiff)
        {
            if (lPctDiff > 0.50m)
                return "pricediff-darkgreen";
            if (lPctDiff <= 0.50m && lPctDiff > 0.25m)
                return "pricediff-green";
            if (lPctDiff <= 0.25m && lPctDiff > 0.10m)
                return "pricediff-lightgreen";
            if (lPctDiff <= 0.10m && lPctDiff > 0.5m)
                return "pricediff-yellow";

            return "pricediff-red";
        }

        public string getLowPriceColor(decimal lowPrice, decimal currPrice)
        {
            if (lowPrice < currPrice)
                return "pricediff-green";

            return "pricediff-red";
        }

        public string getDiffArrow(decimal lPctDiff)
        {
            if (lPctDiff > 0.50m)
                return "fa fa-arrow-circle-up fa-3x fa-pull-left";
            if (lPctDiff <= 0.50m && lPctDiff > 0.25m)
                return "fa fa-arrow-circle-up fa-3x fa-pull-left";
            if (lPctDiff <= 0.25m && lPctDiff > 0.10m)
                return "fa fa-arrow-circle-up fa-3x fa-pull-left";
            if (lPctDiff <= 0.10m && lPctDiff > 0.5m)
                return "fa fa-arrow-circle-right fa-3x fa-pull-left";

            return "fa fa-arrow-circle-down fa-3x fa-pull-left";
        }

        [NotMapped]
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

    public class AuctionMasterDetail
    {
        public AuctionOpenView SelectedAuction { get; set; }
        public int SelectedAuctionId { get; set; }
        public IQueryable<AuctionOpenView> Auctions { get; set; }
    }
}