using System;
using System.ComponentModel.DataAnnotations;

namespace TLAuctionv5.Models
{
    public class Auction
    {
        public int AuctionId { get; set; }
        public String Title { get; set; }
        public string TLCategoryName { get; set; }
        public string ConditionName { get; set; }
        public String Status { get; set; }
        public int ProductRun { get; set; }
        public int Quantity { get; set; }
        public Decimal MSRP { get; set; }
        public int Bid { get; set; }
        public Decimal AvgPrice { get; set; }
        public Decimal Price { get; set; }
        public Decimal PriceDiff { get; set; }
        public Decimal PctDiff { get; set; }
        public DateTime EndDate { get; set; }
        public int Categoryid { get; set; }
        public int ConditionId { get; set; }
        public int ProductCnt { get; set; }
        public Decimal e_AvgPrice { get; set; }
        public Decimal lowprice { get; set; }

        public String sAuctionHtml { get; set; }

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

    public class Manifest
    {
        public int AuctionId { get; set; }
        public string AuctionTitle { get; set; }
        public long Sku { get; set; }
        public string UPC { get; set; }
        public string Title { get; set; }
        public string BB_name { get; set; }
        public int Quantity { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public int ProductCnt { get; set; }
        public string Manufacturer { get; set; }
        public string Partno { get; set; }
        public string BB_model { get; set; }
        public decimal Actual_Product { get; set; }
        public decimal Actual_Prodqty { get; set; }
        public string Ended { get; set; }
        public DateTime Updated { get; set; }
        public int Categoryid { get; set; }
        public int ConditionId { get; set; }
        
    }
        public class Category
    {
        public int CategoryId { get; set; }
        public String TLCategoryName { get; set; }
        public bool IsSelected { get; set; }
        public string sHtml_Checkbox { get; set; }
        public string sHtml_Dropdown { get; set; }

        public void CreateHTML()
       {
            sHtml_Checkbox += "<input type='checkbox' />" + " " + TLCategoryName +  "<br />";
            sHtml_Dropdown += " <option value=" + CategoryId + ">" + TLCategoryName + "</option>";
        }
    }

    public class Condition
    {
        public int ConditionId { get; set; }
        public String ConditionName { get; set; }
        public bool IsSelected { get; set; }
        public string sHtml_Checkbox { get; set; }
        public string sHtml_Dropdown { get; set; }

        public void CreateHTML()
        {
            sHtml_Checkbox += "<input type='checkbox' />" + " " + ConditionName + "<br />";
            sHtml_Dropdown += " <option value=" + ConditionId + ">" + ConditionName + "</option>";
        }
    }

    public class AuctionEndDate
    {
        [Key]
        public string EndDate { get; set; }
        public bool IsSelected { get; set; }
    }

    public class SearchParameters
    {
        public int CategoryId { get; set; }
        public int ConditionId { get; set; }
        public string Enddate { get; set; }
    }
}
