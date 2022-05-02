using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HakimLivsGrupp4.Migrations
{
    public partial class ProductBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketProduct_Basket_BasketID",
                table: "BasketProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketProduct",
                table: "BasketProduct");

            migrationBuilder.RenameTable(
                name: "BasketProduct",
                newName: "BasketProducts");

            migrationBuilder.RenameIndex(
                name: "IX_BasketProduct_BasketID",
                table: "BasketProducts",
                newName: "IX_BasketProducts_BasketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketProducts",
                table: "BasketProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketProducts_Basket_BasketID",
                table: "BasketProducts",
                column: "BasketID",
                principalTable: "Basket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketProducts_Basket_BasketID",
                table: "BasketProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketProducts",
                table: "BasketProducts");

            migrationBuilder.RenameTable(
                name: "BasketProducts",
                newName: "BasketProduct");

            migrationBuilder.RenameIndex(
                name: "IX_BasketProducts_BasketID",
                table: "BasketProduct",
                newName: "IX_BasketProduct_BasketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketProduct",
                table: "BasketProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketProduct_Basket_BasketID",
                table: "BasketProduct",
                column: "BasketID",
                principalTable: "Basket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
