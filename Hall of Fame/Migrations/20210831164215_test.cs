using Microsoft.EntityFrameworkCore.Migrations;

namespace Hall_of_Fame.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_PersonId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Skills");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Persons",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Persons",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                columns: new[] { "PersonId", "Name" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1L, "T1", "Test1" },
                    { 2L, "T2", "Test2" },
                    { 3L, "T3", "Test3" },
                    { 4L, "T4", "Test4" },
                    { 5L, "T5", "Test5" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name", "PersonId", "Level" },
                values: new object[,]
                {
                    { "Skill1", 1L, (byte)1 },
                    { "Skill2", 2L, (byte)2 },
                    { "Skill3", 3L, (byte)3 },
                    { "Skill4", 4L, (byte)4 },
                    { "Skill5", 5L, (byte)5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "Skill1", 1L });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "Skill2", 2L });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "Skill3", 3L });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "Skill4", 4L });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "Skill5", 5L });

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PersonId",
                table: "Skills",
                column: "PersonId");
        }
    }
}
