using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachine.Service.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductComponents",
                table: "ProductComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryProducts",
                table: "InventoryProducts");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "ProductComponents",
                newName: "product_components");

            migrationBuilder.RenameTable(
                name: "InventoryProducts",
                newName: "inventory_product");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalePrice",
                table: "products",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "products",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                table: "products",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProfitPercentage",
                table: "products",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "PackageType",
                table: "products",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "PackageBag",
                table: "products",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "products",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_components",
                table: "product_components",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_product",
                table: "inventory_product",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_products_Reference",
                table: "products",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_components_ComponentProductId",
                table: "product_components",
                column: "ComponentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_components_KitProductId",
                table: "product_components",
                column: "KitProductId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_product_InventoryId_ProductId",
                table: "inventory_product",
                columns: new[] { "InventoryId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_product_ProductId",
                table: "inventory_product",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_product_inventories_InventoryId",
                table: "inventory_product",
                column: "InventoryId",
                principalTable: "inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_product_products_ProductId",
                table: "inventory_product",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_components_products_ComponentProductId",
                table: "product_components",
                column: "ComponentProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_components_products_KitProductId",
                table: "product_components",
                column: "KitProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_product_inventories_InventoryId",
                table: "inventory_product");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_product_products_ProductId",
                table: "inventory_product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_components_products_ComponentProductId",
                table: "product_components");

            migrationBuilder.DropForeignKey(
                name: "FK_product_components_products_KitProductId",
                table: "product_components");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_Reference",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_components",
                table: "product_components");

            migrationBuilder.DropIndex(
                name: "IX_product_components_ComponentProductId",
                table: "product_components");

            migrationBuilder.DropIndex(
                name: "IX_product_components_KitProductId",
                table: "product_components");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_product",
                table: "inventory_product");

            migrationBuilder.DropIndex(
                name: "IX_inventory_product_InventoryId_ProductId",
                table: "inventory_product");

            migrationBuilder.DropIndex(
                name: "IX_inventory_product_ProductId",
                table: "inventory_product");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "product_components",
                newName: "ProductComponents");

            migrationBuilder.RenameTable(
                name: "inventory_product",
                newName: "InventoryProducts");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalePrice",
                table: "Products",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                table: "Products",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "ProfitPercentage",
                table: "Products",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "PackageType",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "PackageBag",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductComponents",
                table: "ProductComponents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryProducts",
                table: "InventoryProducts",
                column: "Id");
        }
    }
}
