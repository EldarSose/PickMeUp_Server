using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickMeUp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    contactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.contactId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    genderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.genderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    ordedStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderStatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.ordedStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ReportTypes",
                columns: table => new
                {
                    reportTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reportName = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTypes", x => x.reportTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    userAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    passwordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.userAccountId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    carId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taxiID = table.Column<int>(type: "int", nullable: true),
                    carModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    taxiNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.carId);
                });

            migrationBuilder.CreateTable(
                name: "DriverRatings",
                columns: table => new
                {
                    driverRatingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    driverId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    rating = table.Column<float>(type: "real", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverRatings", x => x.driverRatingsId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taxiId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    taxiDriverId = table.Column<int>(type: "int", nullable: true),
                    timeUntilArrival = table.Column<DateTime>(type: "datetime2", nullable: true),
                    orderStatusId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_orderStatusId",
                        column: x => x.orderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "ordedStatusId");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    reportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reportDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    madeAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reportTypeId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    adminId = table.Column<int>(type: "int", nullable: true),
                    reportAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    answeredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.reportId);
                    table.ForeignKey(
                        name: "FK_Reports_ReportTypes_reportTypeId",
                        column: x => x.reportTypeId,
                        principalTable: "ReportTypes",
                        principalColumn: "reportTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    reviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taxiId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<float>(type: "real", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.reviewId);
                });

            migrationBuilder.CreateTable(
                name: "RoleUsers",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUsers", x => new { x.userId, x.roleId });
                    table.ForeignKey(
                        name: "FK_RoleUsers_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    shiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    taxiDriverId = table.Column<int>(type: "int", nullable: true),
                    taxiCompanyId = table.Column<int>(type: "int", nullable: true),
                    tookABreak = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.shiftId);
                });

            migrationBuilder.CreateTable(
                name: "TaxiContacts",
                columns: table => new
                {
                    taxiId = table.Column<int>(type: "int", nullable: false),
                    contactId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiContacts", x => new { x.contactId, x.taxiId });
                    table.ForeignKey(
                        name: "FK_TaxiContacts_Contacts_contactId",
                        column: x => x.contactId,
                        principalTable: "Contacts",
                        principalColumn: "contactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taxiDriverCars",
                columns: table => new
                {
                    carId = table.Column<int>(type: "int", nullable: false),
                    taxiDriverId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxiDriverCars", x => new { x.carId, x.taxiDriverId });
                    table.ForeignKey(
                        name: "FK_taxiDriverCars_Cars_carId",
                        column: x => x.carId,
                        principalTable: "Cars",
                        principalColumn: "carId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxis",
                columns: table => new
                {
                    taxiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taxiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    startingPrice = table.Column<float>(type: "real", nullable: true),
                    pricePerKilometer = table.Column<float>(type: "real", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxis", x => x.taxiId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userAccountID = table.Column<int>(type: "int", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    genderID = table.Column<int>(type: "int", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    taxiCompanyID = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Users_Genders_genderID",
                        column: x => x.genderID,
                        principalTable: "Genders",
                        principalColumn: "genderId");
                    table.ForeignKey(
                        name: "FK_Users_Taxis_taxiCompanyID",
                        column: x => x.taxiCompanyID,
                        principalTable: "Taxis",
                        principalColumn: "taxiId");
                    table.ForeignKey(
                        name: "FK_Users_UserAccounts_userAccountID",
                        column: x => x.userAccountID,
                        principalTable: "UserAccounts",
                        principalColumn: "userAccountId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_taxiID",
                table: "Cars",
                column: "taxiID");

            migrationBuilder.CreateIndex(
                name: "IX_DriverRatings_driverId",
                table: "DriverRatings",
                column: "driverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverRatings_userId",
                table: "DriverRatings",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_orderStatusId",
                table: "Orders",
                column: "orderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_taxiDriverId",
                table: "Orders",
                column: "taxiDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_taxiId",
                table: "Orders",
                column: "taxiId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_adminId",
                table: "Reports",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_reportTypeId",
                table: "Reports",
                column: "reportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_userId",
                table: "Reports",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_taxiId",
                table: "Reviews",
                column: "taxiId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_userId",
                table: "Reviews",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUsers_roleId",
                table: "RoleUsers",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_taxiCompanyId",
                table: "Shifts",
                column: "taxiCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_taxiDriverId",
                table: "Shifts",
                column: "taxiDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxiContacts_taxiId",
                table: "TaxiContacts",
                column: "taxiId");

            migrationBuilder.CreateIndex(
                name: "IX_taxiDriverCars_taxiDriverId",
                table: "taxiDriverCars",
                column: "taxiDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxis_userId",
                table: "Taxis",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_genderID",
                table: "Users",
                column: "genderID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_taxiCompanyID",
                table: "Users",
                column: "taxiCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userAccountID",
                table: "Users",
                column: "userAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Taxis_taxiID",
                table: "Cars",
                column: "taxiID",
                principalTable: "Taxis",
                principalColumn: "taxiId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRatings_Users_driverId",
                table: "DriverRatings",
                column: "driverId",
                principalTable: "Users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRatings_Users_userId",
                table: "DriverRatings",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Taxis_taxiId",
                table: "Orders",
                column: "taxiId",
                principalTable: "Taxis",
                principalColumn: "taxiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_taxiDriverId",
                table: "Orders",
                column: "taxiDriverId",
                principalTable: "Users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_userId",
                table: "Orders",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_adminId",
                table: "Reports",
                column: "adminId",
                principalTable: "Users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_userId",
                table: "Reports",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Taxis_taxiId",
                table: "Reviews",
                column: "taxiId",
                principalTable: "Taxis",
                principalColumn: "taxiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_userId",
                table: "Reviews",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUsers_Users_userId",
                table: "RoleUsers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Taxis_taxiCompanyId",
                table: "Shifts",
                column: "taxiCompanyId",
                principalTable: "Taxis",
                principalColumn: "taxiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Users_taxiDriverId",
                table: "Shifts",
                column: "taxiDriverId",
                principalTable: "Users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxiContacts_Taxis_taxiId",
                table: "TaxiContacts",
                column: "taxiId",
                principalTable: "Taxis",
                principalColumn: "taxiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_taxiDriverCars_Users_taxiDriverId",
                table: "taxiDriverCars",
                column: "taxiDriverId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Taxis_Users_userId",
                table: "Taxis",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Taxis_taxiCompanyID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DriverRatings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "RoleUsers");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "TaxiContacts");

            migrationBuilder.DropTable(
                name: "taxiDriverCars");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "ReportTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Taxis");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
