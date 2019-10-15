using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Core.Infra.Data.EFCore.Postgres.Tests.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ActivationUser = table.Column<string>(maxLength: 150, nullable: true),
                    ActivationDate = table.Column<DateTime>(nullable: true),
                    InactivationUser = table.Column<string>(maxLength: 150, nullable: true),
                    InactivationDate = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedUser = table.Column<string>(maxLength: 150, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    RegistryVersion = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Observation = table.Column<string>(maxLength: 500, nullable: true),
                    CreatedUser = table.Column<string>(maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedUser = table.Column<string>(maxLength: 150, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    RegistryVersion = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointment_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_CreatedDate",
                schema: "public",
                table: "appointment",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_CreatedUser",
                schema: "public",
                table: "appointment",
                column: "CreatedUser");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_CustomerId",
                schema: "public",
                table: "appointment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_Date",
                schema: "public",
                table: "appointment",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_RegistryVersion",
                schema: "public",
                table: "appointment",
                column: "RegistryVersion");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_UpdatedDate",
                schema: "public",
                table: "appointment",
                column: "UpdatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_UpdatedUser",
                schema: "public",
                table: "appointment",
                column: "UpdatedUser");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_CustomerId_Date",
                schema: "public",
                table: "appointment",
                columns: new[] { "CustomerId", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_customer_ActivationDate",
                schema: "public",
                table: "customer",
                column: "ActivationDate");

            migrationBuilder.CreateIndex(
                name: "IX_customer_ActivationUser",
                schema: "public",
                table: "customer",
                column: "ActivationUser");

            migrationBuilder.CreateIndex(
                name: "IX_customer_CreatedDate",
                schema: "public",
                table: "customer",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_customer_CreatedUser",
                schema: "public",
                table: "customer",
                column: "CreatedUser");

            migrationBuilder.CreateIndex(
                name: "IX_customer_InactivationDate",
                schema: "public",
                table: "customer",
                column: "InactivationDate");

            migrationBuilder.CreateIndex(
                name: "IX_customer_InactivationUser",
                schema: "public",
                table: "customer",
                column: "InactivationUser");

            migrationBuilder.CreateIndex(
                name: "IX_customer_IsActive",
                schema: "public",
                table: "customer",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_customer_Name",
                schema: "public",
                table: "customer",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_customer_RegistryVersion",
                schema: "public",
                table: "customer",
                column: "RegistryVersion");

            migrationBuilder.CreateIndex(
                name: "IX_customer_UpdatedDate",
                schema: "public",
                table: "customer",
                column: "UpdatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_customer_UpdatedUser",
                schema: "public",
                table: "customer",
                column: "UpdatedUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment",
                schema: "public");

            migrationBuilder.DropTable(
                name: "customer",
                schema: "public");
        }
    }
}


