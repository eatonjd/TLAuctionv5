using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using TLAuctionv5.Models;
using TLAuctionv5.ViewModels.Main;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using System.Linq;

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
        public IActionResult Manifest(int auctionid)
        {

            //myMainModel.Manifests = mydbContext.Set<ManifestOpenView>().FromSql("dbo.GetOpenManifests @pAuctionId = {0}", auctionid);

            myMainModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == auctionid)
                            .OrderByDescending(m => m.Total);

            ViewBag.Manifests = myMainModel.Manifests;

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
