using Microsoft.EntityFrameworkCore.Migrations;

namespace React_Asp.Migrations
{
    public partial class Mydata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Userdonotion",
                table: "User",
                newName: "Userdonation");

            migrationBuilder.AlterColumn<string>(
                name: "Userstatus",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Quest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Userdonation",
                table: "User",
                newName: "Userdonotion");

            migrationBuilder.AlterColumn<int>(
                name: "Userstatus",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Quest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
