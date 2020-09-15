using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity_Crud.Data.Migrations
{
    public partial class add_columExtendsIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_FUNCIONARIO",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_FUNCIONARIO",
                table: "AspNetUsers");
        }
    }
}
