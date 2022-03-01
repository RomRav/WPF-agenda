using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_Agenda.Migrations
{
    public partial class erreurColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Brokers_IdBrokerNavigationIdBrokers",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Customers_IdCustomerNavigationIdCustomer",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_IdBrokerNavigationIdBrokers",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_IdCustomerNavigationIdCustomer",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IdBrokerNavigationIdBrokers",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IdCustomerNavigationIdCustomer",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "IdBrokers",
                table: "Brokers",
                newName: "IdBroker");

            migrationBuilder.AddColumn<int>(
                name: "BrokerIdBroker",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerIdCustomer",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BrokerIdBroker",
                table: "Appointments",
                column: "BrokerIdBroker");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerIdCustomer",
                table: "Appointments",
                column: "CustomerIdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Brokers_BrokerIdBroker",
                table: "Appointments",
                column: "BrokerIdBroker",
                principalTable: "Brokers",
                principalColumn: "IdBroker");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Customers_CustomerIdCustomer",
                table: "Appointments",
                column: "CustomerIdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Brokers_BrokerIdBroker",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Customers_CustomerIdCustomer",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BrokerIdBroker",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CustomerIdCustomer",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "BrokerIdBroker",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CustomerIdCustomer",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "IdBroker",
                table: "Brokers",
                newName: "IdBrokers");

            migrationBuilder.AddColumn<int>(
                name: "IdBrokerNavigationIdBrokers",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCustomerNavigationIdCustomer",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_IdBrokerNavigationIdBrokers",
                table: "Appointments",
                column: "IdBrokerNavigationIdBrokers");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_IdCustomerNavigationIdCustomer",
                table: "Appointments",
                column: "IdCustomerNavigationIdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Brokers_IdBrokerNavigationIdBrokers",
                table: "Appointments",
                column: "IdBrokerNavigationIdBrokers",
                principalTable: "Brokers",
                principalColumn: "IdBrokers",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Customers_IdCustomerNavigationIdCustomer",
                table: "Appointments",
                column: "IdCustomerNavigationIdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
