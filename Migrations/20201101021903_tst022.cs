using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight_Project.Migrations
{
    public partial class tst022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftTbl",
                columns: table => new
                {
                    AircraftDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTbl", x => x.AircraftDBId);
                });

            migrationBuilder.CreateTable(
                name: "ArrivalTbl",
                columns: table => new
                {
                    ArrivalDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iataCode = table.Column<string>(nullable: true),
                    terminal = table.Column<string>(nullable: true),
                    at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrivalTbl", x => x.ArrivalDBId);
                });

            migrationBuilder.CreateTable(
                name: "DepartureTbl",
                columns: table => new
                {
                    DepartureDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iataCode = table.Column<string>(nullable: true),
                    terminal = table.Column<string>(nullable: true),
                    at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartureTbl", x => x.DepartureDBId);
                });

            migrationBuilder.CreateTable(
                name: "DictionariesTbl",
                columns: table => new
                {
                    DictionariesDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionariesTbl", x => x.DictionariesDBId);
                });

            migrationBuilder.CreateTable(
                name: "IncludedCheckedBagsTbl",
                columns: table => new
                {
                    IncludedCheckedBagsDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    weight = table.Column<int>(nullable: false),
                    weightUnit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncludedCheckedBagsTbl", x => x.IncludedCheckedBagsDBId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinksId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    self = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinksId);
                });

            migrationBuilder.CreateTable(
                name: "LinksTbl",
                columns: table => new
                {
                    LinksDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    self = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinksTbl", x => x.LinksDBId);
                });

            migrationBuilder.CreateTable(
                name: "OccupentPriceTbl",
                columns: table => new
                {
                    TravelPriceDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currency = table.Column<string>(nullable: true),
                    total = table.Column<string>(nullable: true),
                    @base = table.Column<string>(name: "base", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupentPriceTbl", x => x.TravelPriceDBId);
                });

            migrationBuilder.CreateTable(
                name: "OperatingDB",
                columns: table => new
                {
                    OperatingDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carrierCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingDB", x => x.OperatingDBId);
                });

            migrationBuilder.CreateTable(
                name: "PriceTbl",
                columns: table => new
                {
                    PriceDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currency = table.Column<string>(nullable: true),
                    total = table.Column<string>(nullable: true),
                    @base = table.Column<string>(name: "base", nullable: true),
                    grandTotal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTbl", x => x.PriceDBId);
                });

            migrationBuilder.CreateTable(
                name: "PricingOptionsTbl",
                columns: table => new
                {
                    PricingOptionsDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fareType = table.Column<string>(nullable: true),
                    includedCheckedBagsOnly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingOptionsTbl", x => x.PricingOptionsDBId);
                });

            migrationBuilder.CreateTable(
                name: "AircraftsDB",
                columns: table => new
                {
                    AircraftsDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(nullable: true),
                    DictionariesDBId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftsDB", x => x.AircraftsDBId);
                    table.ForeignKey(
                        name: "FK_AircraftsDB_DictionariesTbl_DictionariesDBId",
                        column: x => x.DictionariesDBId,
                        principalTable: "DictionariesTbl",
                        principalColumn: "DictionariesDBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarriersDB",
                columns: table => new
                {
                    CarriersDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(nullable: true),
                    DictionariesDBId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarriersDB", x => x.CarriersDBId);
                    table.ForeignKey(
                        name: "FK_CarriersDB_DictionariesTbl_DictionariesDBId",
                        column: x => x.DictionariesDBId,
                        principalTable: "DictionariesTbl",
                        principalColumn: "DictionariesDBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurenciesDB",
                columns: table => new
                {
                    CurenciesDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(nullable: true),
                    DictionariesDBId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurenciesDB", x => x.CurenciesDBId);
                    table.ForeignKey(
                        name: "FK_CurenciesDB_DictionariesTbl_DictionariesDBId",
                        column: x => x.DictionariesDBId,
                        principalTable: "DictionariesTbl",
                        principalColumn: "DictionariesDBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetaTbl",
                columns: table => new
                {
                    MetaDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    count = table.Column<int>(nullable: false),
                    LinksId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaTbl", x => x.MetaDBId);
                    table.ForeignKey(
                        name: "FK_MetaTbl_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "LinksId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeeTbl",
                columns: table => new
                {
                    FeeDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    PriceDBId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeTbl", x => x.FeeDBId);
                    table.ForeignKey(
                        name: "FK_FeeTbl_PriceTbl_PriceDBId",
                        column: x => x.PriceDBId,
                        principalTable: "PriceTbl",
                        principalColumn: "PriceDBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightresultsTbl",
                columns: table => new
                {
                    FlightOffersSearchDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetaDBId = table.Column<int>(nullable: true),
                    DictionariesDBId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightresultsTbl", x => x.FlightOffersSearchDBId);
                    table.ForeignKey(
                        name: "FK_FlightresultsTbl_DictionariesTbl_DictionariesDBId",
                        column: x => x.DictionariesDBId,
                        principalTable: "DictionariesTbl",
                        principalColumn: "DictionariesDBId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightresultsTbl_MetaTbl_MetaDBId",
                        column: x => x.MetaDBId,
                        principalTable: "MetaTbl",
                        principalColumn: "MetaDBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataTbl",
                columns: table => new
                {
                    DatumDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true),
                    id = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    instantTicketingRequired = table.Column<bool>(nullable: false),
                    nonHomogeneous = table.Column<bool>(nullable: false),
                    oneWay = table.Column<bool>(nullable: false),
                    lastTicketingDate = table.Column<string>(nullable: true),
                    numberOfBookableSeats = table.Column<int>(nullable: false),
                    PriceDBId = table.Column<int>(nullable: true),
                    PricingOptionsDBId = table.Column<int>(nullable: true),
                    validatingAirlineCodes = table.Column<string>(nullable: true),
                    FlightOffersSearchDBId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTbl", x => x.DatumDBId);
                    table.ForeignKey(
                        name: "FK_DataTbl_FlightresultsTbl_FlightOffersSearchDBId",
                        column: x => x.FlightOffersSearchDBId,
                        principalTable: "FlightresultsTbl",
                        principalColumn: "FlightOffersSearchDBId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataTbl_PriceTbl_PriceDBId",
                        column: x => x.PriceDBId,
                        principalTable: "PriceTbl",
                        principalColumn: "PriceDBId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataTbl_PricingOptionsTbl_PricingOptionsDBId",
                        column: x => x.PricingOptionsDBId,
                        principalTable: "PricingOptionsTbl",
                        principalColumn: "PricingOptionsDBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItineraryTbl",
                columns: table => new
                {
                    ItineraryDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    duration = table.Column<string>(nullable: true),
                    DatumDBId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryTbl", x => x.ItineraryDBId);
                    table.ForeignKey(
                        name: "FK_ItineraryTbl_DataTbl_DatumDBId",
                        column: x => x.DatumDBId,
                        principalTable: "DataTbl",
                        principalColumn: "DatumDBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelerPricingTbl",
                columns: table => new
                {
                    TravelerPricingDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    travelerId = table.Column<string>(nullable: true),
                    fareOption = table.Column<string>(nullable: true),
                    travelerType = table.Column<string>(nullable: true),
                    priceTravelPriceDBId = table.Column<int>(nullable: true),
                    DatumDBId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerPricingTbl", x => x.TravelerPricingDBId);
                    table.ForeignKey(
                        name: "FK_TravelerPricingTbl_DataTbl_DatumDBId",
                        column: x => x.DatumDBId,
                        principalTable: "DataTbl",
                        principalColumn: "DatumDBId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TravelerPricingTbl_OccupentPriceTbl_priceTravelPriceDBId",
                        column: x => x.priceTravelPriceDBId,
                        principalTable: "OccupentPriceTbl",
                        principalColumn: "TravelPriceDBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SegmentTbl",
                columns: table => new
                {
                    SegmentDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureDBId = table.Column<int>(nullable: true),
                    ArrivalDBId = table.Column<int>(nullable: true),
                    carrierCode = table.Column<string>(nullable: true),
                    number = table.Column<string>(nullable: true),
                    AircraftDBId = table.Column<int>(nullable: true),
                    OperatingDBId = table.Column<int>(nullable: true),
                    duration = table.Column<string>(nullable: true),
                    id = table.Column<string>(nullable: true),
                    numberOfStops = table.Column<int>(nullable: false),
                    blacklistedInEU = table.Column<bool>(nullable: false),
                    ItineraryDBId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentTbl", x => x.SegmentDBId);
                    table.ForeignKey(
                        name: "FK_SegmentTbl_AircraftTbl_AircraftDBId",
                        column: x => x.AircraftDBId,
                        principalTable: "AircraftTbl",
                        principalColumn: "AircraftDBId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SegmentTbl_ArrivalTbl_ArrivalDBId",
                        column: x => x.ArrivalDBId,
                        principalTable: "ArrivalTbl",
                        principalColumn: "ArrivalDBId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SegmentTbl_DepartureTbl_DepartureDBId",
                        column: x => x.DepartureDBId,
                        principalTable: "DepartureTbl",
                        principalColumn: "DepartureDBId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SegmentTbl_ItineraryTbl_ItineraryDBId",
                        column: x => x.ItineraryDBId,
                        principalTable: "ItineraryTbl",
                        principalColumn: "ItineraryDBId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SegmentTbl_OperatingDB_OperatingDBId",
                        column: x => x.OperatingDBId,
                        principalTable: "OperatingDB",
                        principalColumn: "OperatingDBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FareDetailsBySegment",
                columns: table => new
                {
                    FareDetailsBySegmentDBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    segmentId = table.Column<string>(nullable: true),
                    cabin = table.Column<string>(nullable: true),
                    fareBasis = table.Column<string>(nullable: true),
                    @class = table.Column<string>(name: "class", nullable: true),
                    IncludedCheckedBagsDBId = table.Column<int>(nullable: true),
                    TravelerPricingDBId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FareDetailsBySegment", x => x.FareDetailsBySegmentDBId);
                    table.ForeignKey(
                        name: "FK_FareDetailsBySegment_IncludedCheckedBagsTbl_IncludedCheckedBagsDBId",
                        column: x => x.IncludedCheckedBagsDBId,
                        principalTable: "IncludedCheckedBagsTbl",
                        principalColumn: "IncludedCheckedBagsDBId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FareDetailsBySegment_TravelerPricingTbl_TravelerPricingDBId",
                        column: x => x.TravelerPricingDBId,
                        principalTable: "TravelerPricingTbl",
                        principalColumn: "TravelerPricingDBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AircraftsDB_DictionariesDBId",
                table: "AircraftsDB",
                column: "DictionariesDBId");

            migrationBuilder.CreateIndex(
                name: "IX_CarriersDB_DictionariesDBId",
                table: "CarriersDB",
                column: "DictionariesDBId");

            migrationBuilder.CreateIndex(
                name: "IX_CurenciesDB_DictionariesDBId",
                table: "CurenciesDB",
                column: "DictionariesDBId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTbl_FlightOffersSearchDBId",
                table: "DataTbl",
                column: "FlightOffersSearchDBId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTbl_PriceDBId",
                table: "DataTbl",
                column: "PriceDBId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTbl_PricingOptionsDBId",
                table: "DataTbl",
                column: "PricingOptionsDBId");

            migrationBuilder.CreateIndex(
                name: "IX_FareDetailsBySegment_IncludedCheckedBagsDBId",
                table: "FareDetailsBySegment",
                column: "IncludedCheckedBagsDBId");

            migrationBuilder.CreateIndex(
                name: "IX_FareDetailsBySegment_TravelerPricingDBId",
                table: "FareDetailsBySegment",
                column: "TravelerPricingDBId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeTbl_PriceDBId",
                table: "FeeTbl",
                column: "PriceDBId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightresultsTbl_DictionariesDBId",
                table: "FlightresultsTbl",
                column: "DictionariesDBId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightresultsTbl_MetaDBId",
                table: "FlightresultsTbl",
                column: "MetaDBId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryTbl_DatumDBId",
                table: "ItineraryTbl",
                column: "DatumDBId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaTbl_LinksId",
                table: "MetaTbl",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentTbl_AircraftDBId",
                table: "SegmentTbl",
                column: "AircraftDBId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentTbl_ArrivalDBId",
                table: "SegmentTbl",
                column: "ArrivalDBId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentTbl_DepartureDBId",
                table: "SegmentTbl",
                column: "DepartureDBId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentTbl_ItineraryDBId",
                table: "SegmentTbl",
                column: "ItineraryDBId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentTbl_OperatingDBId",
                table: "SegmentTbl",
                column: "OperatingDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerPricingTbl_DatumDBId",
                table: "TravelerPricingTbl",
                column: "DatumDBId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerPricingTbl_priceTravelPriceDBId",
                table: "TravelerPricingTbl",
                column: "priceTravelPriceDBId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftsDB");

            migrationBuilder.DropTable(
                name: "CarriersDB");

            migrationBuilder.DropTable(
                name: "CurenciesDB");

            migrationBuilder.DropTable(
                name: "FareDetailsBySegment");

            migrationBuilder.DropTable(
                name: "FeeTbl");

            migrationBuilder.DropTable(
                name: "LinksTbl");

            migrationBuilder.DropTable(
                name: "SegmentTbl");

            migrationBuilder.DropTable(
                name: "IncludedCheckedBagsTbl");

            migrationBuilder.DropTable(
                name: "TravelerPricingTbl");

            migrationBuilder.DropTable(
                name: "AircraftTbl");

            migrationBuilder.DropTable(
                name: "ArrivalTbl");

            migrationBuilder.DropTable(
                name: "DepartureTbl");

            migrationBuilder.DropTable(
                name: "ItineraryTbl");

            migrationBuilder.DropTable(
                name: "OperatingDB");

            migrationBuilder.DropTable(
                name: "OccupentPriceTbl");

            migrationBuilder.DropTable(
                name: "DataTbl");

            migrationBuilder.DropTable(
                name: "FlightresultsTbl");

            migrationBuilder.DropTable(
                name: "PriceTbl");

            migrationBuilder.DropTable(
                name: "PricingOptionsTbl");

            migrationBuilder.DropTable(
                name: "DictionariesTbl");

            migrationBuilder.DropTable(
                name: "MetaTbl");

            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
