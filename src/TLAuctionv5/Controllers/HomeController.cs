using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using TLAuctionv5.Models;
using TLAuctionv5.ViewModels.Main;
using Microsoft.AspNet.Mvc.Rendering;

namespace TLAuctionv5.Controllers
{

    public class HomeController : Controller
    {
        private readonly TechLiquidDbContext mydbContext;

        public MainViewModel myMainModel;

        public HomeController(TechLiquidDbContext dbContext)
        {
            mydbContext = dbContext;
            myMainModel = new MainViewModel();
        }

        [HttpGet]
        public IActionResult Index()
        {
            mydbContext.PopulateMainModel(myMainModel);
            ViewBag.CategoryList = myMainModel.Categories;
            ViewBag.ConditionList = myMainModel.Conditions;
            ViewBag.AuctionEndDateList = myMainModel.AuctionEndDates;
            ViewBag.AuctionList = myMainModel.Auctions;

            return View(myMainModel);
        }

        [HttpGet]
        public IActionResult Manifest(int auctionid)
        {
            mydbContext.getManifest(myMainModel, auctionid);
            ViewBag.Manifests = myMainModel.Manifests;

            return View();
        }


        [HttpPost]
        public IActionResult Index(MainViewModel myModel)
        {
            string sCategory = Request.Form["categories"].ToString();
            string sCondition = Request.Form["conditions"].ToString();
            string sEndDate = Request.Form["auctionenddates"].ToString();
            mydbContext.PopulateMainModel(myMainModel, sCategory, sCondition, sEndDate);
            ViewBag.CategoryList = myMainModel.Categories;
            ViewBag.ConditionList = myMainModel.Conditions;
            ViewBag.AuctionEndDateList = myMainModel.AuctionEndDates;

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
