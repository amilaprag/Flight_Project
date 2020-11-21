using Flight_Project.Models.Amadeus.DbMapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Project.Data
{
    public class DatabaseContext: DbContext
    {
        public DbSet<FlightOffersSearchDB> FlightresultsTbl { get; set; }
        public DbSet<LinksDB> LinksTbl { get; set; }
        public DbSet<MetaDB> MetaTbl { get; set; }
        public DbSet<DepartureDB> DepartureTbl { get; set; }
        public DbSet<ArrivalDB> ArrivalTbl { get; set; }
        public DbSet<AircraftDB> AircraftTbl { get; set; }
        public DbSet<SegmentDB> SegmentTbl { get; set; }
        public DbSet<ItineraryDB> ItineraryTbl { get; set; }
        public DbSet<FeeDB> FeeTbl { get; set; }
        public DbSet<PriceDB> PriceTbl { get; set; }
        public DbSet<PricingOptionsDB> PricingOptionsTbl { get; set; }
        public DbSet<TravelPriceDB> OccupentPriceTbl { get; set; }
        public DbSet<IncludedCheckedBagsDB> IncludedCheckedBagsTbl { get; set; }
        public DbSet<FareDetailsBySegmentDB> FareDetailsBySegment { get; set; }
        public DbSet<TravelerPricingDB> TravelerPricingTbl { get; set; }
        public DbSet<DatumDB> DataTbl { get; set; }
        public DbSet<DictionariesDB> DictionariesTbl { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=PRAGEETH\SERVER1;Database=FlightDB1;Trusted_Connection=True;");
        }
    }
}
