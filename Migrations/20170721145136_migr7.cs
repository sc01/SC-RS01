using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sign.Migrations
{
    public partial class migr7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentForApartment_Apartments_ApartmentId",
                table: "AttachmentForApartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttachmentForApartment",
                table: "AttachmentForApartment");

            migrationBuilder.RenameTable(
                name: "AttachmentForApartment",
                newName: "AttachmentForApartments");

            migrationBuilder.RenameIndex(
                name: "IX_AttachmentForApartment_ApartmentId",
                table: "AttachmentForApartments",
                newName: "IX_AttachmentForApartments_ApartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttachmentForApartments",
                table: "AttachmentForApartments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentForApartments_Apartments_ApartmentId",
                table: "AttachmentForApartments",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentForApartments_Apartments_ApartmentId",
                table: "AttachmentForApartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttachmentForApartments",
                table: "AttachmentForApartments");

            migrationBuilder.RenameTable(
                name: "AttachmentForApartments",
                newName: "AttachmentForApartment");

            migrationBuilder.RenameIndex(
                name: "IX_AttachmentForApartments_ApartmentId",
                table: "AttachmentForApartment",
                newName: "IX_AttachmentForApartment_ApartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttachmentForApartment",
                table: "AttachmentForApartment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentForApartment_Apartments_ApartmentId",
                table: "AttachmentForApartment",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
