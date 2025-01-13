using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazzar.Infrastructures.Data.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Delete_picture_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Advertisments_AdvertismentId",
                table: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Picture");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_AdvertismentId",
                table: "Picture",
                newName: "IX_Picture_AdvertismentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Advertisments_AdvertismentId",
                table: "Picture",
                column: "AdvertismentId",
                principalTable: "Advertisments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Advertisments_AdvertismentId",
                table: "Picture");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Picture",
                table: "Picture");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "Pictures");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_AdvertismentId",
                table: "Pictures",
                newName: "IX_Pictures_AdvertismentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Advertisments_AdvertismentId",
                table: "Pictures",
                column: "AdvertismentId",
                principalTable: "Advertisments",
                principalColumn: "Id");
        }
    }
}
