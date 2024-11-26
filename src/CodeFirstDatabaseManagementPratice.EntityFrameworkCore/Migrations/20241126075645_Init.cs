using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstDatabaseManagementPratice.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "流水號")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "名稱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NullableName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "可Null名稱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                },
                comment: "示範資料表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Samples",
                columns: new[] { "Id", "CreatedAt", "Name", "NullableName", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2024, 11, 26, 7, 56, 45, 21, DateTimeKind.Utc).AddTicks(2012), "不可為Null欄位", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samples");
        }
    }
}
