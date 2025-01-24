using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazzar.Infrastructures.Data.SqlServer.Migrations
{
	/// <inheritdoc />
	public partial class changeAdvertismentPropertySettings : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
			    name: "Title",
			    table: "Advertisments",
			    type: "nvarchar(max)",
			    nullable: true,
			    oldClrType: typeof(string),
			    oldType: "nvarchar(max)");

			migrationBuilder.AlterColumn<string>(
			    name: "Text",
			    table: "Advertisments",
			    type: "nvarchar(max)",
			    nullable: true,
			    oldClrType: typeof(string),
			    oldType: "nvarchar(max)");

			migrationBuilder.AlterColumn<long>(
			    name: "Price",
			    table: "Advertisments",
			    type: "bigint",
			    nullable: true,
			    oldClrType: typeof(long),
			    oldType: "bigint");

			migrationBuilder.AlterColumn<string>(
			    name: "ApprovedBy",
			    table: "Advertisments",
			    type: "nvarchar(max)",
			    nullable: true,
			    oldClrType: typeof(string),
			    oldType: "nvarchar(max)");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
			    name: "Title",
			    table: "Advertisments",
			    type: "nvarchar(max)",
			    nullable: false,
			    defaultValue: "",
			    oldClrType: typeof(string),
			    oldType: "nvarchar(max)",
			    oldNullable: true);

			migrationBuilder.AlterColumn<string>(
			    name: "Text",
			    table: "Advertisments",
			    type: "nvarchar(max)",
			    nullable: false,
			    defaultValue: "",
			    oldClrType: typeof(string),
			    oldType: "nvarchar(max)",
			    oldNullable: true);

			migrationBuilder.AlterColumn<long>(
			    name: "Price",
			    table: "Advertisments",
			    type: "bigint",
			    nullable: false,
			    defaultValue: 0L,
			    oldClrType: typeof(long),
			    oldType: "bigint",
			    oldNullable: true);

			migrationBuilder.AlterColumn<string>(
			    name: "ApprovedBy",
			    table: "Advertisments",
			    type: "nvarchar(max)",
			    nullable: false,
			    defaultValue: "",
			    oldClrType: typeof(string),
			    oldType: "nvarchar(max)",
			    oldNullable: true);
		}
	}
}
