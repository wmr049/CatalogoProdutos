using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CatalogoProdutos.Infra.Dados.Migrations.EventStoreSQL
{
    public partial class EventStoreSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoredEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AgregacaoId = table.Column<Guid>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Action = table.Column<string>(type: "varchar(100)", nullable: true),                    
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredEvent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoredEvent");
        }
    }
}
