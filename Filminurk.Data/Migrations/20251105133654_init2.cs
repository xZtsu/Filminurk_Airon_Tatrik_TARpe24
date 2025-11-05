using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filminurk.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActorID",
                table: "FilesToApi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoviesActedFor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortraitID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActorRating = table.Column<double>(type: "float", nullable: true),
                    HomeCountry = table.Column<int>(type: "int", nullable: true),
                    FavouriteHobby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropColumn(
                name: "ActorID",
                table: "FilesToApi");
        }
    }
}
