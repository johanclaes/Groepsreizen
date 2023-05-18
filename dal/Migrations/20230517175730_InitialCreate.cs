using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestemmingstypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestemmingstypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLid = table.Column<bool>(type: "bit", nullable: false),
                    Telefoonnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monitorbrevet = table.Column<bool>(type: "bit", nullable: false),
                    Hoofdmonitorbrevet = table.Column<bool>(type: "bit", nullable: false),
                    Webadmin = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Woonplaats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medicatie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rolstoel = table.Column<bool>(type: "bit", nullable: true),
                    Opmerking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paswoord = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpleidingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpleidingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bestemmingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gemeente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Straat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capaciteit = table.Column<int>(type: "int", nullable: false),
                    Fotonaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestemmingstypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestemmingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bestemmingen_Bestemmingstypes_BestemmingstypeId",
                        column: x => x.BestemmingstypeId,
                        principalTable: "Bestemmingstypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opleidingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpleidingTypeId = table.Column<int>(type: "int", nullable: false),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Einddatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opleidingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opleidingen_OpleidingTypes_OpleidingTypeId",
                        column: x => x.OpleidingTypeId,
                        principalTable: "OpleidingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groepsreizen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deelneemprijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Thema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestemmingId = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Einddatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Minimumleeftijd = table.Column<int>(type: "int", nullable: false),
                    Maximumleeftijd = table.Column<int>(type: "int", nullable: false),
                    OverschotBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PlaatsenVrij = table.Column<bool>(type: "bit", nullable: false),
                    InschrijvingGestopt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groepsreizen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groepsreizen_Bestemmingen_BestemmingId",
                        column: x => x.BestemmingId,
                        principalTable: "Bestemmingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GebruikerOpleidingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(type: "int", nullable: false),
                    OpleidingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GebruikerOpleidingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GebruikerOpleidingen_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GebruikerOpleidingen_Opleidingen_OpleidingId",
                        column: x => x.OpleidingId,
                        principalTable: "Opleidingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inschrijvingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Betaald = table.Column<bool>(type: "bit", nullable: false),
                    GroepsreisId = table.Column<int>(type: "int", nullable: false),
                    GebruikerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijvingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_Groepsreizen_GroepsreisId",
                        column: x => x.GroepsreisId,
                        principalTable: "Groepsreizen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroepsreisId = table.Column<int>(type: "int", nullable: false),
                    GebruikerId = table.Column<int>(type: "int", nullable: false),
                    Hoofdmonitor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitors_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monitors_Groepsreizen_GroepsreisId",
                        column: x => x.GroepsreisId,
                        principalTable: "Groepsreizen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestemmingen_BestemmingstypeId",
                table: "Bestemmingen",
                column: "BestemmingstypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerOpleidingen_GebruikerId",
                table: "GebruikerOpleidingen",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerOpleidingen_OpleidingId",
                table: "GebruikerOpleidingen",
                column: "OpleidingId");

            migrationBuilder.CreateIndex(
                name: "IX_Groepsreizen_BestemmingId",
                table: "Groepsreizen",
                column: "BestemmingId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_GebruikerId",
                table: "Inschrijvingen",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_GroepsreisId",
                table: "Inschrijvingen",
                column: "GroepsreisId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitors_GebruikerId",
                table: "Monitors",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitors_GroepsreisId",
                table: "Monitors",
                column: "GroepsreisId");

            migrationBuilder.CreateIndex(
                name: "IX_Opleidingen_OpleidingTypeId",
                table: "Opleidingen",
                column: "OpleidingTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GebruikerOpleidingen");

            migrationBuilder.DropTable(
                name: "Inschrijvingen");

            migrationBuilder.DropTable(
                name: "Monitors");

            migrationBuilder.DropTable(
                name: "Opleidingen");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropTable(
                name: "Groepsreizen");

            migrationBuilder.DropTable(
                name: "OpleidingTypes");

            migrationBuilder.DropTable(
                name: "Bestemmingen");

            migrationBuilder.DropTable(
                name: "Bestemmingstypes");
        }
    }
}
