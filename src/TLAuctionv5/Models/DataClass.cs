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
        public Decimal LowPrice { get; set; }
        public Decimal HighPrice { get; set; }
        public Decimal StartPrice { get; set; }
        public Decimal EndPrice { get; set; }
        public Decimal currPricePct { get; set; }
        public Decimal lowPricePct { get; set; }
        public Decimal highPricePct { get; set; }
        public Decimal greenLimit { get; set; }
        public Decimal yellowLimit { get; set; }
      
        public Decimal PriceDiff { get; set; }
        public Decimal PctDiff { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy h:mm}")]
        public DateTime EndDate { get; set; }
        public int CategoryId { get; set; }
        public int ConditionId { get; set; }
        public int ProductCnt { get; set; }

        [NotMapped]
        public string ArrowType { get; set; }
        

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

        [ForeignKey("ProductId")]
        public string ProductId { get; set; }
        public ProductView Product { get; set; }

        [DisplayFormat(NullDisplayText = @"&nbsp;", HtmlEncode = false)]
        public string AuctionTitle { get; set; }
        public decimal Sku { get; set; }
        public string UPC { get; set; }
        public string ProductTitle { get; set; }
        public string ManifestTitle { get; set; }
        public string BB_name { get; set; }
        public int Quantity { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal Msrp { get; set; }
        public int ConditionId { get; set; }
        public int ProductCnt { get; set; }
        public string Manufacturer { get; set; }
        public string Partno { get; set; }
        public string BB_model { get; set; }
        public decimal Total { get; set; }
        public DateTime Updated { get; set; }
    }

    public class ManifestEndedView
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AuctionId")]
        public int AuctionId { get; set; }
        public AuctionOpenView Auction { get; set; }
        public string ProductId { get; set; }
        public string AuctionTitle { get; set; }
        public string ManifestTitle { get; set; }
        public int Quantity { get; set; }
        public decimal AuctionPrice { get; set; }
        public decimal ProdQtyPrice { get; set; }
        public decimal ProductPrice { get; set; }
        public int ConditionId { get; set; }
        public DateTime EndDate { get; set; }
    }
    
    public class ProductView
    {
        [Key]
        public string id { get; set; }

        public decimal sku { get; set; }
        public int conditionid { get; set; }
        public string upc { get; set; }
        public string partno { get; set; }
        [DisplayFormat(NullDisplayText = @"&nbsp;", HtmlEncode = false)]
        public string title { get; set; }
        public decimal avgprice { get; set; }
        public decimal minprice { get; set; }
        public decimal maxprice { get; set; }
        public int productcnt { get; set; }
        [DisplayFormat(NullDisplayText = @"&nbsp;", HtmlEncode = false)]
        public string manufacturer { get; set; }
        public string ConditionName { get; set; }
        /*
        public string ebtitle { get; set; }
        public string ebitemurl { get; set; }
        public string eblistingtype { get; set; }
        public DateTime ebstartdate { get; set; }
        public DateTime ebenddate { get; set; }
        public string ebcondition { get; set; }
        public string ebupc { get; set; }
        */

        public virtual ICollection<ManifestOpenView> Manifests { get; set; }
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
