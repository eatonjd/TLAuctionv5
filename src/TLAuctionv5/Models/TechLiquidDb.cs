﻿using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TLAuctionv5.ViewModels.Main;

namespace TLAuctionv5.Models
{
    public class TechLiquidDbContext : DbContext
    {
        public DbSet<AuctionOpenView> Auctions { get; set; }
        public DbSet<Auction_Category> Categories { get; set; }
        public DbSet<Auction_Condition> Conditions { get; set; }
        public DbSet<ManifestOpenView> Manifests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AuctionOpenView>()
                                .HasMany(a => a.Manifests);



            modelBuilder.Entity<ManifestOpenView>()
                                .HasOne(a => a.Auction)
                                .WithMany(r => r.Manifests)
                                .HasForeignKey(a => a.AuctionId);
                             

        }
    }
}