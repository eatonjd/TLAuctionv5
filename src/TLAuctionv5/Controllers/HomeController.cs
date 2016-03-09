using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using TLAuctionv5.Models;
using TLAuctionv5.ViewModels.Main;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using System.Linq;
using System;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Routing;

namespace TLAuctionv5.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext mydbContext;

        public MyViewModel myViewModel;
        public string sCategory = "0";
        public string sCondition = "0";
        public string sEndDate = "0";

        public HomeController(MyDbContext dbContext)
        {
            mydbContext = dbContext;
            myViewModel = new MyViewModel();
        }

        [HttpGet]
        public IActionResult Index(int auctionid, string sortOrder)
        {
            if (sortOrder == null) sortOrder = "pricediff";
            switch (sortOrder)
            {
                case "pricediff":
                    myViewModel.AuctionMD.Auctions = mydbContext.Auctions.OrderBy(s => s.PctDiff);
                    break;
                case "enddate_desc":
                    myViewModel.AuctionMD.Auctions = mydbContext.Auctions.OrderBy(s => s.EndDate);
                    break;
                default:
                    myViewModel.AuctionMD.Auctions = mydbContext.Auctions.OrderBy(s => s.PctDiff);
                    break;
            }

            if (auctionid == 0)
                myViewModel.AuctionMD.SelectedAuction = mydbContext.Auctions.FirstOrDefault();
            else
                myViewModel.AuctionMD.SelectedAuction = mydbContext.Auctions.Single(m => m.AuctionId == auctionid);

            myViewModel.AuctionMD.SelectedAuctionId = myViewModel.AuctionMD.SelectedAuction.AuctionId;

            myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == myViewModel.AuctionMD.SelectedAuctionId)
                            .OrderBy(m => m.Total);

            ViewBag.sortList = myViewModel.SortList;
            ViewBag.sortOrder = sortOrder;

            return View(myViewModel);
        }


        public IActionResult AuctionDetails(int auctionid)
        {
            return ViewComponent("AuctionDetail", auctionid);
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
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.Total);
                    break;
                case "Qty_desc":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.Quantity);
                    break;
                case "Qty":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.Quantity);
                    break;
                case "Brand_desc":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.Manufacturer);
                    break;
                case "Brand":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.Manufacturer);
                    break;
                case "Part_desc":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.Partno);
                    break;
                case "Part":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.Partno);
                    break;
                case "Title_desc":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.AuctionTitle);
                    break;
                case "Title":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.AuctionTitle);
                    break;
                case "UPC_desc":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.UPC);
                    break;
                case "UPC":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.UPC);
                    break;
                case "SKU_desc":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.Sku);
                    break;
                case "SKU":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.Sku);
                    break;
                case "AvgPrice":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.AvgPrice);
                    break;
                case "AvgPrice_desc":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.AvgPrice);
                    break;
                case "ProdCnt":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderBy(m => m.ProductCnt);
                    break;
                case "ProdCnt_desc":
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.ProductCnt);
                    break;
                default:
                    myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.Total);
                    break;
            }

            ViewBag.Manifest = myViewModel.Manifests.FirstOrDefault();

            return View(myViewModel);
        }

        [HttpGet]
        public IActionResult Product(string ProductId, int ConditionId, string sortOrder)
        {
            ViewBag.SellPriceSortParm = String.IsNullOrEmpty(sortOrder) ? "SellPrice_desc" : "";
            ViewBag.AuctionIdSortParm = sortOrder == "AuctionId" ? "AuctionId_desc" : "AuctionId";
            ViewBag.AuctionTitleSortParm = sortOrder == "AuctionTitle" ? "AuctionTitle_desc" : "AuctionTitle";
            ViewBag.AuctionPriceSortParm = sortOrder == "AuctionPrice" ? "AuctionPrice_desc" : "AuctionPrice";
            ViewBag.EndDateSortParm = sortOrder == "EndDate" ? "EndDate_desc" : "EndDate";
            ViewBag.ManifestTitleSortParm = sortOrder == "ManifestTitle" ? "ManifestTitle_desc" : "ManifestTitle";
            ViewBag.QuantitySortParm = sortOrder == "Quantity" ? "Quantity_desc" : "Quantity";

            myViewModel.Products = mydbContext.Products
                            .Where(p => (p.id == ProductId) && (p.conditionid == ConditionId));

            switch (sortOrder)
            {
                case "SellPrice_desc":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.ProductPrice);
                    break;
                case "AuctionId":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.AuctionId);
                    break;
                case "AuctionId_desc":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                           .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.AuctionId);
                    break;
                case "AuctionTitle":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.AuctionTitle);
                    break;
                case "AuctionTitle_desc":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                           .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.AuctionTitle);
                    break;
                case "ManifestTitle":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.ManifestTitle);
                    break;
                case "ManifestTitle_desc":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                           .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.ManifestTitle);
                    break;
                case "AuctionPrice":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.AuctionPrice);
                    break;
                case "AuctionPrice_desc":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                           .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.AuctionPrice);
                    break;
                case "EndDate":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.EndDate);
                    break;
                case "EndDate_desc":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                           .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.EndDate);
                    break;
                case "Quantity":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.Quantity);
                    break;
                case "Quantity_desc":
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                           .Where(m => m.ProductId == ProductId)
                            .OrderByDescending(m => m.Quantity);
                    break;
                default:
                    myViewModel.ManifestsEnded = mydbContext.ManifestsEnded
                            .Where(m => m.ProductId == ProductId)
                            .OrderBy(m => m.ProductPrice);
                    break;
            }

            ViewBag.ProductId = ProductId;
            ViewBag.ConditionId = ConditionId;

            return View(myViewModel);
        }

        [HttpGet]
        public IActionResult Search()
        {
            sCategory = Request.Form["categories"].ToString();
            sCondition = Request.Form["conditions"].ToString();
            return View(myViewModel);
        }
        /*
        [HttpPost]
        public IActionResult Index()
        {
            //clean up to look like httpGet, add detail page when click on manifest item.
            sCategory = Request.Form["categories"].ToString();
            sCondition = Request.Form["conditions"].ToString();

            myViewModel.Categories = mydbContext.Set<Auction_Category>().FromSql("dbo.GetCategories");
            myViewModel.Conditions = mydbContext.Set<Auction_Condition>().FromSql("dbo.GetConditions");
            myViewModel.AuctionMD.Auctions = mydbContext.Set<AuctionOpenView>().FromSql("dbo.GetOpenAuctions @pCategoryList = {0}, @pConditionList = {1}, @pEndDate = {2}", sCategory, sCondition, sEndDate);

            ViewBag.Categories = myViewModel.Categories;
            ViewBag.Conditions = myViewModel.Conditions;
            ViewBag.Auctions = myViewModel.AuctionMD.Auctions;
            ViewBag.sortList = myViewModel.SortList;

            return View(myViewModel);
        }
        */
        public IActionResult Bootcards()
        {
            ViewData["Message"] = "";

            return View();
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
