using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLAuctionv5.Models
{
    public class AuctionOpenView
    {
        [Key]
        public int AuctionId { get; set; }
        public String Title { get; set; }
        public string TLCategoryName { get; set; }
        public string ConditionName { get; set; }
        public String Status { get; set; }
        public int ProductRun { get; set; }
        public int Quantity { get; set; }
        public Decimal MSRP { get; set; }
        public int Bid { get; set; }
        public Decimal Price { get; set; }
        public Decimal AvgPrice { get; set; }
        public Decimal PriceDiff { get; set; }
        public Decimal PctDiff { get; set; }
        public string EndDate { get; set; }
        public int CategoryId { get; set; }
        public int ConditionId { get; set; }
        public int ProductCnt { get; set; }

        public virtual ICollection<ManifestOpenView> Manifests { get; set; }

        public string getCategoryImage(String sCategoryName)
        {
            switch (sCategoryName)
            {
                case "Apple Desktops":
                    return "cat_appledesktop.jpg";
                case "Audio & Video":
                    return "cat_audiovideo.jpg";
                case "Audio Electronics":
                    return "cat_audioelectronics.jpg";
                case "Cameras & Photo":
                    return "cat_cameraphoto.jpg";
                case "Car Electroncis":
                    return "cat_carelectronics.jpg";
                case "Computer Acceessoris":
                    return "cat_compaccessories.jpg";
                case "Computer Hardware":
                    return "cat_comphardware.jpg";
                case "Electronic Accessories":
                    return "cat_electronics.jpg";
                case "Electronics":
                    return "cat_electronics.jpg";
                case "Home Electronics":
                    return "cat_electronics.jpg";
                case "iPads & Tablets":
                    return "cat_ipadtablets.jpg";
                case "Laptops & Netbooks":
                    return "cat_laptops.jpg";
                case "Laptops & Notebooks":
                    return "cat_laptops.jpg";
                case "PC Desktops":
                    return "cat_desktops.jpg";
                case "Video Games":
                    return "cat_videogames.jpg";
            }

            return "cat_noimage.png";
        }
    }

    public class ManifestOpenView
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AuctionId")]
        public int AuctionId { get; set; }
        public AuctionOpenView Auction { get; set; }

        public string ProductId { get; set; }
        public string AuctionTitle { get; set; }
        public long Sku { get; set; }
        public string UPC { get; set; }
        public string Title { get; set; }
        public string BB_name { get; set; }
        public int Quantity { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public int ConditionId { get; set; }
        public int ProductCnt { get; set; }
        public string Manufacturer { get; set; }
        public string Partno { get; set; }
        public string BB_model { get; set; }
        public decimal Total { get; set; }
        public DateTime Updated { get; set; }
    }

    public class Auction_Category
    {
        [Key]
        public int CategoryId { get; set; }
        public String TLCategoryName { get; set; }
    }

    public class Auction_Condition
    {
        [Key]
        public int ConditionId { get; set; }
        public String ConditionName { get; set; }
    }
}
