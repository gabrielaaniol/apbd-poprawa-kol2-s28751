﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pop2kolokwium.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.RaceId);
                });

            migrationBuilder.CreateTable(
                name: "Racer",
                columns: table => new
                {
                    RacerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racer", x => x.RacerId);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthInKm = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.TrackId);
                });

            migrationBuilder.CreateTable(
                name: "TrackRace",
                columns: table => new
                {
                    TrackRaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    Laps = table.Column<int>(type: "int", nullable: false),
                    BestTimeInSeconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackRace", x => x.TrackRaceId);
                    table.ForeignKey(
                        name: "FK_TrackRace_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackRace_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Race_Participation",
                columns: table => new
                {
                    TrackRaceId = table.Column<int>(type: "int", nullable: false),
                    RacerId = table.Column<int>(type: "int", nullable: false),
                    FinishTimeInSeconds = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race_Participation", x => new { x.RacerId, x.TrackRaceId });
                    table.ForeignKey(
                        name: "FK_Race_Participation_Racer_RacerId",
                        column: x => x.RacerId,
                        principalTable: "Racer",
                        principalColumn: "RacerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Race_Participation_TrackRace_TrackRaceId",
                        column: x => x.TrackRaceId,
                        principalTable: "TrackRace",
                        principalColumn: "TrackRaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "RaceId", "Date", "Location", "Name" },
                values: new object[] { 1, new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silverstone, UK", "British Grand Prix" });

            migrationBuilder.InsertData(
                table: "Racer",
                columns: new[] { "RacerId", "FirstName", "LastName" },
                values: new object[] { 1, "Lewis", "Hamilton" });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "TrackId", "LengthInKm", "Name" },
                values: new object[] { 1, 5.8899999999999997, "Silverstone Circuit" });

            migrationBuilder.InsertData(
                table: "TrackRace",
                columns: new[] { "TrackRaceId", "BestTimeInSeconds", "Laps", "RaceId", "TrackId" },
                values: new object[] { 1, 5480, 52, 1, 1 });

            migrationBuilder.InsertData(
                table: "Race_Participation",
                columns: new[] { "RacerId", "TrackRaceId", "FinishTimeInSeconds", "Position" },
                values: new object[] { 1, 1, 5460, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Race_Participation_TrackRaceId",
                table: "Race_Participation",
                column: "TrackRaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackRace_RaceId",
                table: "TrackRace",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackRace_TrackId",
                table: "TrackRace",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Race_Participation");

            migrationBuilder.DropTable(
                name: "Racer");

            migrationBuilder.DropTable(
                name: "TrackRace");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Track");
        }
    }
}
