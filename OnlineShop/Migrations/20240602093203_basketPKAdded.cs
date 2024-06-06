using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class basketPKAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Basktets__Produc__403A8C7D",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_ProductId",
                table: "Baskets");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK__Basktets__Produc__403A8C7D",
                table: "Baskets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Basktets__Produc__403A8C7D",
                table: "Baskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Baskets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ProductId",
                table: "Baskets",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK__Basktets__Produc__403A8C7D",
                table: "Baskets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }
    }
}
