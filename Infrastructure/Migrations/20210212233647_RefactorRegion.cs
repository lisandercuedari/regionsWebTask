using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RefactorRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Regions_RegionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Regions_ParentRegionId",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Regions_ParentRegionId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "ParentRegionId",
                table: "Regions");

            migrationBuilder.AddColumn<int>(
                name: "ParentRegionRegionId",
                table: "Regions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ParentRegionRegionId",
                table: "Regions",
                column: "ParentRegionRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Regions_RegionId",
                table: "Employees",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Regions_ParentRegionRegionId",
                table: "Regions",
                column: "ParentRegionRegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Regions_RegionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Regions_ParentRegionRegionId",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Regions_ParentRegionRegionId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "ParentRegionRegionId",
                table: "Regions");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Regions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ParentRegionId",
                table: "Regions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ParentRegionId",
                table: "Regions",
                column: "ParentRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Regions_RegionId",
                table: "Employees",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Regions_ParentRegionId",
                table: "Regions",
                column: "ParentRegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
