using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrcture.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeDecimalPrecisisionForPriceForAddlAuthorCopiesUSD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<decimal>(
            //    name: "Specs_PriceForAddlAuthorCopiesUSD",
            //    table: "ContractVersions",
            //    type: "decimal(18,5)",
            //    nullable: false,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(18,2)");
            migrationBuilder.Sql("ALTER TABLE [ContractVersions] ALTER COLUMN [Specs_PriceForAddlAuthorCopiesUSD] decimal(18,5) NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			//migrationBuilder.AlterColumn<decimal>(
			//    name: "Specs_PriceForAddlAuthorCopiesUSD",
			//    table: "ContractVersions",
			//    type: "decimal(18,2)",
			//    nullable: false,
			//    oldClrType: typeof(decimal),
			//    oldType: "decimal(18,5)");
			migrationBuilder.Sql("ALTER TABLE [ContractVersions] ALTER COLUMN [Specs_PriceForAddlAuthorCopiesUSD] decimal(18,2) NOT NULL");
		}
    }
}
