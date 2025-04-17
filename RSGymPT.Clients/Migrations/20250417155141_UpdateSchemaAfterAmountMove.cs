using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSGymPT.Clients.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaAfterAmountMove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payments");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "PaymentTypes",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PaymentTypes");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
