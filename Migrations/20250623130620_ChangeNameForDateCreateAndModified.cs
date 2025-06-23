using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDelivery.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameForDateCreateAndModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Orders",
                newName: "DateModifiedUtc");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Orders",
                newName: "DateCreatedUtc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateModifiedUtc",
                table: "Orders",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateCreatedUtc",
                table: "Orders",
                newName: "DateCreated");
        }
    }
}
