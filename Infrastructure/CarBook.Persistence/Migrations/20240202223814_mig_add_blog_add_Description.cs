using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migaddblogaddDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPricing_Cars_CarID",
                table: "CarPricing");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPricing_Pricings_PricingID",
                table: "CarPricing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPricing",
                table: "CarPricing");

            migrationBuilder.RenameTable(
                name: "CarPricing",
                newName: "CarPricings");

            migrationBuilder.RenameIndex(
                name: "IX_CarPricing_PricingID",
                table: "CarPricings",
                newName: "IX_CarPricings_PricingID");

            migrationBuilder.RenameIndex(
                name: "IX_CarPricing_CarID",
                table: "CarPricings",
                newName: "IX_CarPricings_CarID");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPricings",
                table: "CarPricings",
                column: "CarPricingID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricings_Cars_CarID",
                table: "CarPricings",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricings_Pricings_PricingID",
                table: "CarPricings",
                column: "PricingID",
                principalTable: "Pricings",
                principalColumn: "PricingID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPricings_Cars_CarID",
                table: "CarPricings");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPricings_Pricings_PricingID",
                table: "CarPricings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarPricings",
                table: "CarPricings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "CarPricings",
                newName: "CarPricing");

            migrationBuilder.RenameIndex(
                name: "IX_CarPricings_PricingID",
                table: "CarPricing",
                newName: "IX_CarPricing_PricingID");

            migrationBuilder.RenameIndex(
                name: "IX_CarPricings_CarID",
                table: "CarPricing",
                newName: "IX_CarPricing_CarID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarPricing",
                table: "CarPricing",
                column: "CarPricingID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricing_Cars_CarID",
                table: "CarPricing",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricing_Pricings_PricingID",
                table: "CarPricing",
                column: "PricingID",
                principalTable: "Pricings",
                principalColumn: "PricingID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
