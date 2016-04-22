using Microsoft.AspNet.Mvc;
using TLAuctionv5.Models;
using TLAuctionv5.ViewModels.Main;
using System.Linq;

namespace TLAuctionv5.ViewComponents
{
    [ViewComponent(Name = "AuctionDetail")]
    public class AuctionDetailViewComponent : ViewComponent
    {
        private readonly MyDbContext mydbContext;
        public MyViewModel myViewModel;

        public AuctionDetailViewComponent(MyDbContext context)
        {
            mydbContext = context;
            myViewModel = new MyViewModel();
        }
        public IViewComponentResult Invoke(int auctionid)
        {
            if (auctionid == 0)
                myViewModel.AuctionMD.SelectedAuction = mydbContext.Auctions.FirstOrDefault();
            else
                myViewModel.AuctionMD.SelectedAuction = mydbContext.Auctions.Single(m => m.AuctionId == auctionid);

            myViewModel.AuctionMD.SelectedAuctionId = myViewModel.AuctionMD.SelectedAuction.AuctionId;

            myViewModel.Manifests = mydbContext.Manifests
                            .Where(m => m.AuctionId == myViewModel.AuctionMD.SelectedAuctionId)
                            .OrderByDescending(m => m.Total);

            return View(myViewModel);
        }
    }
}