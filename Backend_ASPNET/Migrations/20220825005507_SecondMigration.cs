using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "ItemModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "ItemModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemModel_EmpresaId",
                table: "ItemModel",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModel_EmpresaModel_EmpresaId",
                table: "ItemModel",
                column: "EmpresaId",
                principalTable: "EmpresaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemModel_EmpresaModel_EmpresaId",
                table: "ItemModel");

            migrationBuilder.DropIndex(
                name: "IX_ItemModel_EmpresaId",
                table: "ItemModel");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "ItemModel");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "ItemModel");
        }
    }
}
