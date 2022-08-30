using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoque.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemModel_EmpresaModel_EmpresaId",
                table: "ItemModel");

            migrationBuilder.DropTable(
                name: "EmpresaModel");

            migrationBuilder.DropIndex(
                name: "IX_ItemModel_EmpresaId",
                table: "ItemModel");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "ItemModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "ItemModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EmpresaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaModel", x => x.Id);
                });

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
    }
}
