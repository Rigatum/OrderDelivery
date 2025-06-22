using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDelivery.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeForOrderWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Orders",
                type: "decimal(18,3)",
                precision: 10,
                scale: 3,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real(10)",
                oldPrecision: 10,
                oldScale: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "Orders",
                type: "real(10)",
                precision: 10,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldPrecision: 10,
                oldScale: 3);
        }
    }
}
