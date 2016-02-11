using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TLAuctionv5.Models;

namespace TLAuctionv5.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TLAuctionv5.Models.Auction_Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TLCategoryName");

                    b.HasKey("CategoryId");
                });

            modelBuilder.Entity("TLAuctionv5.Models.Auction_Condition", b =>
                {
                    b.Property<int>("ConditionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConditionName");

                    b.HasKey("ConditionId");
                });

            modelBuilder.Entity("TLAuctionv5.Models.AuctionOpenView", b =>
                {
                    b.Property<int>("AuctionId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AvgPrice");

                    b.Property<int>("Bid");

                    b.Property<int>("CategoryId");

                    b.Property<int>("ConditionId");

                    b.Property<string>("ConditionName");

                    b.Property<string>("EndDate");

                    b.Property<decimal>("MSRP");

                    b.Property<decimal>("PctDiff");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("PriceDiff");

                    b.Property<int>("ProductCnt");

                    b.Property<int>("ProductRun");

                    b.Property<int>("Quantity");

                    b.Property<string>("Status");

                    b.Property<string>("TLCategoryName");

                    b.Property<string>("Title");

                    b.HasKey("AuctionId");
                });

            modelBuilder.Entity("TLAuctionv5.Models.ManifestOpenView", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuctionId");

                    b.Property<string>("AuctionTitle");

                    b.Property<decimal>("AvgPrice");

                    b.Property<string>("BB_model");

                    b.Property<string>("BB_name");

                    b.Property<int>("ConditionId");

                    b.Property<string>("Manufacturer");

                    b.Property<decimal>("MaxPrice");

                    b.Property<decimal>("MinPrice");

                    b.Property<string>("Partno");

                    b.Property<int>("ProductCnt");

                    b.Property<string>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<long>("Sku");

                    b.Property<string>("Title");

                    b.Property<decimal>("Total");

                    b.Property<string>("UPC");

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");
                });
        }
    }
}
