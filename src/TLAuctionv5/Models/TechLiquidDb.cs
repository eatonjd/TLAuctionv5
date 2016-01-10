using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TLAuctionv5.ViewModels.Main;

namespace TLAuctionv5.Models
{
    public class TechLiquidDbContext : DbContext
    {
        private MainViewModel myMainModel;
        public void PopulateMainModel(MainViewModel lMainModel, string sCategory = "0", string sCondition = "0", string sEndDate="0")
        {
            myMainModel = lMainModel;
            getCategories();
            getConditions();
            getOpenEndDates();
            getAuctions(sCategory,sCondition,sEndDate);
        }

        public void getAuctions(string sCategory, string sCondition, string sEndDate)
        {
            try
            {
                if (myMainModel.Auctions != null)
                    return;

                if (sEndDate == "All Dates")
                    sEndDate = "0";

                myMainModel.Auctions = new List<Auction>();
                var connection = (SqlConnection)Database.GetDbConnection();
                connection.Open();
                SqlCommand command = new SqlCommand("GetOpenAuctions", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pCategoryList", sCategory);
                command.Parameters.AddWithValue("@pConditionList", sCondition);
                command.Parameters.AddWithValue("@pEndDate", sEndDate);
                using (SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dataReader.Read())
                    {
                        Auction oAuction = new Auction();
                        oAuction.AuctionId = (int)dataReader["auctionid"];
                        oAuction.Title = dataReader["title"].ToString();
                        oAuction.Categoryid = (int)dataReader["categoryid"];
                        oAuction.ConditionId = (int)dataReader["conditionid"];
                        oAuction.ConditionName = dataReader["conditionname"].ToString();
                        oAuction.TLCategoryName = dataReader["tlcategoryname"].ToString();
                        oAuction.MSRP = (decimal)dataReader.GetDecimal(7);
                        oAuction.Price = (decimal)dataReader.GetDecimal(9);
                        oAuction.AvgPrice = (decimal)dataReader.GetDecimal(10);
                        oAuction.PriceDiff = (decimal)dataReader.GetDecimal(11);
                        oAuction.PctDiff = (decimal)dataReader.GetDecimal(12);
                        oAuction.Bid = (int)dataReader["Bid"];
                        oAuction.EndDate = (DateTime) dataReader["Enddate"];
                        myMainModel.Auctions.Add(oAuction);
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getManifest(MainViewModel lMainModel, int iAuctionId)
        {
            try
            {
                myMainModel = lMainModel;
                myMainModel.Manifests = new List<Manifest>();
                var connection = (SqlConnection)Database.GetDbConnection();
                connection.Open();
                SqlCommand command = new SqlCommand("GetManifest", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pAuctionId", iAuctionId);
                using (SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dataReader.Read())
                    {
                        Manifest oManifest = new Manifest();
                        oManifest.AuctionId = (int)dataReader["auctionid"];
                        oManifest.AuctionTitle = dataReader["auctiontitle"].ToString();
                        oManifest.Sku = (long)dataReader["sku"];
                        oManifest.UPC = dataReader["upc"].ToString();
                        oManifest.Title = dataReader["title"].ToString();
                        oManifest.BB_name = dataReader["bb_name"].ToString();
                        oManifest.AvgPrice = (decimal)dataReader.GetDecimal(7);
                        oManifest.MinPrice = (decimal)dataReader.GetDecimal(8);
                        oManifest.MaxPrice = (decimal)dataReader.GetDecimal(9);
                        oManifest.ConditionId = (int)dataReader["conditionid"];
                        oManifest.Manufacturer = dataReader["manufacturer"].ToString();
                        oManifest.BB_model = dataReader["bb_model"].ToString();
                        oManifest.Actual_Product = (decimal)dataReader.GetDecimal(15);
                        oManifest.Actual_Prodqty = (decimal)dataReader.GetDecimal(16);
                        oManifest.Ended = dataReader["ended"].ToString();
                        myMainModel.Manifests.Add(oManifest);
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getCategories()
        {
            try
            {
                if (myMainModel.Categories != null)
                    return;

                myMainModel.Categories = new List<Category>();
                var connection = (SqlConnection)Database.GetDbConnection();
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlCommand command = new SqlCommand("GetCategories", connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dataReader.Read())
                    {
                        Category oCategory = new Category();
                        oCategory.CategoryId = (int)dataReader["CategoryId"];
                        oCategory.TLCategoryName = dataReader["TLCategoryName"].ToString();
                        oCategory.IsSelected = false;
                        myMainModel.Categories.Add(oCategory);
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void getConditions()
        {
            try
            {
                if (myMainModel.Conditions != null)
                    return;
                myMainModel.Conditions = new List<Condition>();

                var connection = (SqlConnection)Database.GetDbConnection();
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlCommand command = new SqlCommand("GetConditions", connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dataReader.Read())
                    {
                        Condition oCondition = new Condition();
                        oCondition.ConditionId = (int)dataReader["ConditionId"];
                        oCondition.ConditionName = dataReader["ConditionName"].ToString();
                        oCondition.IsSelected = false;
                        myMainModel.Conditions.Add(oCondition);
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void getOpenEndDates()
        {
            try
            {
                if (myMainModel.AuctionEndDates != null)
                    return;

                myMainModel.AuctionEndDates = new List<AuctionEndDate>();
                AuctionEndDate oEDate = new AuctionEndDate();
                oEDate.EndDate = "All Dates";
                myMainModel.AuctionEndDates.Add(oEDate);

                var connection = (SqlConnection)Database.GetDbConnection();
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                SqlCommand command = new SqlCommand("GetOpenEndDates", connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dataReader.Read())
                    {
                        AuctionEndDate oAuctionEndDate = new AuctionEndDate();
                        oAuctionEndDate.EndDate = Convert.ToDateTime(dataReader["EndDate"]).ToString("MM/dd/yyyy");
                        myMainModel.AuctionEndDates.Add(oAuctionEndDate);
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}