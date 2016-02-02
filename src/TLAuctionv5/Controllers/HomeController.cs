using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using TLAuctionv5.Models;
using TLAuctionv5.ViewModels.Main;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using System.Linq;
using System;

namespace TLAuctionv5.Controllers
{
    public class HomeController : Controller
    {
        private readonly TechLiquidDbContext mydbContext;

        public MainViewModel myMainModel;
        public string sCategory = "0";
        public string sCondition = "0";
        public string sEndDate = "0";

        public HomeController(TechLiquidDbContext dbContext)
        {
            mydbContext = dbContext;
            myMainModel = new MainViewModel();
        }

        [HttpGet]
        public IActionResult Index(string sortOrder)
        {
            //myMainModel.Categories = mydbContext.Set<Auction_Category>().FromSql("dbo.GetCategories");
            //myMainModel.Conditions = mydbContext.Set<Auction_Condition>().FromSql("dbo.GetConditions");
            //myMainModel.AuctionEndDates = mydbContext.Set<AuctionEndDate>().FromSql("dbo.GetOpenEndDates");
            //myMainModel.Auctions = mydbContext.Set<AuctionOpenView>().FromSql("dbo.GetOpenAuctions @pCategoryList = {0}, @pConditionList = {1}, @pEndDate = {2}", sCategory, sCondition, sEndDate);

            if (sortOrder == null) sortOrder = "pricediff";
            switch (sortOrder)
            {
                case "pricediff":
                    myMainModel.Auctions = mydbContext.Auctions.OrderBy(s => s.PriceDiff);
                    break;
                case "enddate_desc":
                    myMainModel.Auctions = mydbContext.Auctions.OrderBy(s => s.EndDate);
                    break;
                default:
                    myMainModel.Auctions = mydbContext.Auctions.OrderBy(s => s.PriceDiff);
                    break;
            }

            myMainModel.Categories = mydbContext.Categories;
            ViewBag.Categories = myMainModel.Categories;

            myMainModel.Conditions = mydbContext.Conditions;
            ViewBag.Conditions = myMainModel.Conditions;

            ViewBag.Auctions = myMainModel.Auctions;
            ViewBag.sortList = myMainModel.SortList;

            return View(myMainModel);
        }

        [HttpGet]
        public IActionResult Manifest(int auctionid, string sortOrder)
        {
            ViewBag.TotalSortParm = String.IsNullOrEmpty(sortOrder) ? "Total_asc" : "";
            ViewBag.QtySortParm = sortOrder == "Qty" ? "Qty_desc" : "Qty";
            ViewBag.BrandSortParm = sortOrder == "Brand" ? "Brand_desc" : "Brand";
            ViewBag.PartSortParm = sortOrder == "Part" ? "Part_desc" : "Part";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "Title_desc" : "Title";
            ViewBag.UPCSortParm = sortOrder == "UPC" ? "UPC_desc" : "UPC";
            ViewBag.SKUSortParm = sortOrder == "SKU" ? "SKU_desc" : "SKU";
            ViewBag.AvgPriceSortParm = sortOrder == "AvgPrice" ? "AvgPrice_desc" : "AvgPrice";
            ViewBag.ProdCntSortParm = sortOrder == "ProdCnt" ? "ProdCnt_desc" : "ProdCnt";

            switch (sortOrder)
            {
                case "Total_asc":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.Total);
                    break;
                case "Qty_desc":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.Quantity);
                    break;
                case "Qty":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.Quantity);
                    break;
                case "Brand_desc":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.Manufacturer);
                    break;
                case "Brand":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.Manufacturer);
                    break;
                case "Part_desc":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.Partno);
                    break;
                case "Part":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.Partno);
                    break;
                case "Title_desc":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.AuctionTitle);
                    break;
                case "Title":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.AuctionTitle);
                    break;
                case "UPC_desc":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.UPC);
                    break;
                case "UPC":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.UPC);
                    break;
               case "SKU_desc":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.Sku);
                    break;
                case "SKU":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.Sku);
                    break;
                case "AvgPrice":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.AvgPrice);
                    break;
                case "AvgPrice_desc":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.AvgPrice);
                    break;
                case "ProdCnt":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.ProductCnt);
                    break;
                case "ProdCnt_desc":
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.ProductCnt);
                    break;
                default:
                    myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.Total);
                    break;
            }

            

            ViewBag.Manifests = myMainModel.Manifests;
            ViewBag.AuctionId = myMainModel.Manifests.FirstOrDefault().AuctionId;

            return View(myMainModel);
        }

        [HttpGet]
        public IActionResult Product(string ProductId, int ConditionId, string sortOrder)
        {
            ViewBag.SellPriceSortParm = String.IsNullOrEmpty(sortOrder) ? "SellPrice_desc" : "";
            ViewBag.AuctionIdSortParm = sortOrder == "AuctionId" ? "AuctionId_desc" : "AuctionId";
            ViewBag.AuctionTitleSortParm = sortOrder == "AuctionTitle" ? "AuctionTitle_desc" : "AuctionTitle";
            ViewBag.AuctionPriceSortParm = sortOrder == "AuctionPrice" ? "AuctionPrice_desc" : "AuctionPrice";
            ViewBag.EndDateSortParm = sortOrder == "EndDate" ? "EndDate_desc" : "EndDate";
            ViewBag.QuantitySortParm = sortOrder == "Quantity" ? "Quantity_desc" : "Quantity";

            myMainModel.Products = mydbContext.Products
                            .Where(p => (p.id == ProductId) && (p.conditionid == ConditionId));

            switch (sortOrder)
            {
                case "SellPrice_desc":
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.ProductPrice);
                    break;
                case "AuctionId":
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.AuctionId);
                    break;
                case "AuctionId_desc":
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                           .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.AuctionId);
                    break;
                case "AuctionTitle":
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.AuctionTitle);
                    break;
                case "AuctionTitle_desc":
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                           .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.AuctionTitle);
                    break;
                case "AuctionPrice":
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.AuctionPrice);
                    break;
                case "AuctionPrice_desc":
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                           .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.AuctionPrice);
                    break;
                case "EndDate":
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.EndDate);
                    break;
                case "EndDate_desc":
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                           .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.EndDate);
                    break;
                case "Quantity":
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.Quantity);
                    break;
                case "Quantity_desc":
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                           .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.Quantity);
                    break;
                default:
                    myMainModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.ProductPrice);
                    break;
            }

            ViewBag.ProductId = ProductId;
            ViewBag.ConditionId = ConditionId;

            return View(myMainModel);
        }

        [HttpGet]
        public IActionResult Search()
        {
            sCategory = Request.Form["categories"].ToString();
            sCondition = Request.Form["conditions"].ToString();
            return View(myMainModel);
        }
        [HttpPost]
        public IActionResult Index()
        {
            //clean up to look like httpGet, add detail page when click on manifest item.
            sCategory = Request.Form["categories"].ToString();
            sCondition = Request.Form["conditions"].ToString();

            myMainModel.Categories = mydbContext.Set<Auction_Category>().FromSql("dbo.GetCategories");
            myMainModel.Conditions = mydbContext.Set<Auction_Condition>().FromSql("dbo.GetConditions");
            myMainModel.Auctions = mydbContext.Set<AuctionOpenView>().FromSql("dbo.GetOpenAuctions @pCategoryList = {0}, @pConditionList = {1}, @pEndDate = {2}", sCategory, sCondition, sEndDate);

            ViewBag.Categories = myMainModel.Categories;
            ViewBag.Conditions = myMainModel.Conditions;
            ViewBag.Auctions = myMainModel.Auctions;
            ViewBag.sortList = myMainModel.SortList;

            return View(myMainModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
