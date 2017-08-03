using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCRS01.Migrations
{
    public partial class h4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Apartments_ApartmentId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Buildings_BuildingId1",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_BuildingId1",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "BuildingId1",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "Contracts",
                newName: "BuldId");

            migrationBuilder.AlterColumn<long>(
                name: "ApartmentId",
                table: "Contracts",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "ApartId",
                table: "Contracts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Apartments_ApartmentId",
                table: "Contracts",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Apartments_ApartmentId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ApartId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "BuldId",
                table: "Contracts",
                newName: "BuildingId");

            migrationBuilder.AlterColumn<long>(
                name: "ApartmentId",
                table: "Contracts",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingId1",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BuildingId1",
                table: "Contracts",
                column: "BuildingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Apartments_ApartmentId",
                table: "Contracts",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Buildings_BuildingId1",
                table: "Contracts",
                column: "BuildingId1",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
