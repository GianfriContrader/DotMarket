using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotMarket.Migrations
{
    /// <inheritdoc />
    public partial class ControlValidatorAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Profiles",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FiscalCode",
                table: "Profiles",
                type: "VARCHAR(16)",
                fixedLength: true,
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Profiles",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Profiles",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AtCreated",
                table: "Profiles",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "QtyToBuy",
                table: "ProductsKart",
                type: "INT",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Products",
                type: "VARCHAR(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "Stars",
                table: "Products",
                type: "INT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "INT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Products",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "ResponsePay",
                table: "Payments",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFastDelivery",
                table: "Orders",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelivered",
                table: "Orders",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CodeOrd",
                table: "Orders",
                type: "VARCHAR(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "Karts",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Karts",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "InvoicesPDF",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<float>(
                name: "LoadingStatus",
                table: "InvoicesPDF",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceCode",
                table: "InvoicesPDF",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<byte>(
                name: "DataPDF",
                table: "InvoicesPDF",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<byte>(
                name: "DataExcel",
                table: "InvoicesPDF",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "PathImage",
                table: "Images",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SecurityCode",
                table: "DataPayments",
                type: "VARCHAR(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "DataPayments",
                type: "VARCHAR(16)",
                fixedLength: true,
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "DataPayments",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Circuit",
                table: "DataPayments",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsLike",
                table: "Comments",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Addresses",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Addresses",
                type: "VARCHAR(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FiscalCode",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(16)",
                oldFixedLength: true,
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AtCreated",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<int>(
                name: "QtyToBuy",
                table: "ProductsKart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Products",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<long>(
                name: "Stars",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<long>(
                name: "ResponsePay",
                table: "Payments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFastDelivery",
                table: "Orders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelivered",
                table: "Orders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT");

            migrationBuilder.AlterColumn<string>(
                name: "CodeOrd",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "Karts",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Karts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "InvoicesPDF",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<float>(
                name: "LoadingStatus",
                table: "InvoicesPDF",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<long>(
                name: "InvoiceCode",
                table: "InvoicesPDF",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<byte>(
                name: "DataPDF",
                table: "InvoicesPDF",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TINYINT");

            migrationBuilder.AlterColumn<byte>(
                name: "DataExcel",
                table: "InvoicesPDF",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TINYINT");

            migrationBuilder.AlterColumn<string>(
                name: "PathImage",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "SecurityCode",
                table: "DataPayments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(3)",
                oldFixedLength: true,
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "DataPayments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(16)",
                oldFixedLength: true,
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "DataPayments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<string>(
                name: "Circuit",
                table: "DataPayments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "IsLike",
                table: "Comments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);
        }
    }
}
