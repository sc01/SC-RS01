using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCRS01.Migrations
{
    public partial class migr5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Apartments_ApartmentDetilsId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "ApartmentDetilsId",
                table: "Contracts",
                newName: "ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_ApartmentDetilsId",
                table: "Contracts",
                newName: "IX_Contracts_ApartmentId");

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

            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "Contracts",
                newName: "ApartmentDetilsId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_ApartmentId",
                table: "Contracts",
                newName: "IX_Contracts_ApartmentDetilsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Apartments_ApartmentDetilsId",
                table: "Contracts",
                column: "ApartmentDetilsId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
