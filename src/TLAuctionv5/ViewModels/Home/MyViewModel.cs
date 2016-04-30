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
            if (currPrice < lowPrice)
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

        public decimal getCurPricePct(decimal currPrice, decimal startPrice, decimal endPrice)
        {
            return Math.Round(((currPrice - startPrice) /(endPrice- startPrice)) * 100, 2);
        }

        public decimal getLowPricePct(decimal lowPrice, decimal startPrice, decimal endPrice)
        {
            return Math.Round(((lowPrice - startPrice) / (endPrice - startPrice)) * 100, 2);
        }

        public decimal getHighPricePct(decimal highPrice, decimal startPrice, decimal endPrice)
        {
            return Math.Round(((highPrice - startPrice) / (endPrice - startPrice)) * 100, 2);
        }

        public string getLowStepColor(decimal curPrice, decimal lowPrice)
        {
            if (curPrice > lowPrice)
                return "low green-color";
            else
                return "low no-color";
        }
        
        public string getHighStepColor(decimal curPrice, decimal highPrice)
        {
            if (curPrice > highPrice)
                return "high danger-color";
            else
                return "high no-color";
        }

        public string getBarColor(decimal curPrice, decimal greenLimit, decimal yellowLimit)
        {
            if (curPrice <= greenLimit)
                return "progress-bar progress-bar-success";

            if (curPrice > greenLimit && curPrice <= yellowLimit )
                return " progress-bar progress-bar-warning";

            return "progress-bar progress-bar-danger";

        }

        public string getCurrPriceStyle(decimal currPricePct)
        {
            if (currPricePct <= 50)
                return "left: " + currPricePct; 
            else
                return "right: " + (100 - currPricePct);
        }

        public string getBarColor(decimal currPricePct)
        {
            if (currPricePct <= 60)
                return "#5cb85c;";
            if (currPricePct > 60 && currPricePct <= 90)
                return "#f0ad4e;";
            if (currPricePct > 90 && currPricePct <= 100)
                return "#d9534f;";

            return "";

        }

        public decimal getGreenBarPct(decimal currPricePct)
        {
            if (currPricePct <= 60)
                return currPricePct;
            else
                return 60;
        }


        public decimal getYellowBarPct(decimal currPricePct)
        {
            if (currPricePct > 60 && currPricePct <= 90)
                return currPricePct - 60;
            if (currPricePct > 90)
                return 30;

            return 0;
        }

        public decimal getRedBarPct(decimal currPricePct)
        {
            if (currPricePct >= 100)
                return 10;
            if (currPricePct > 90 && currPricePct < 100)
                return currPricePct - 90;
            else
                return 0;
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
        public decimal SelectedAuctionId { get; set; }
        public IQueryable<AuctionOpenView> Auctions { get; set; }
    }
}