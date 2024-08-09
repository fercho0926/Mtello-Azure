using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatchPaycheck",
                columns: table => new
                {
                    BatchPaycheckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordsByFile = table.Column<int>(type: "int", nullable: false),
                    RecordsProcessed = table.Column<int>(type: "int", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: false),
                    TotalMoney = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchPaycheck", x => x.BatchPaycheckId);
                    table.ForeignKey(
                        name: "FK_BatchPaycheck_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayCheckRecords_BatchPaycheckId",
                table: "PayCheckRecords",
                column: "BatchPaycheckId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchPaycheck_CompanyId",
                table: "BatchPaycheck",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayCheckRecords_BatchPaycheck_BatchPaycheckId",
                table: "PayCheckRecords",
                column: "BatchPaycheckId",
                principalTable: "BatchPaycheck",
                principalColumn: "BatchPaycheckId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayCheckRecords_BatchPaycheck_BatchPaycheckId",
                table: "PayCheckRecords");

            migrationBuilder.DropTable(
                name: "BatchPaycheck");

            migrationBuilder.DropIndex(
                name: "IX_PayCheckRecords_BatchPaycheckId",
                table: "PayCheckRecords");
        }
    }
}
