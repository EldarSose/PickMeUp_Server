using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickMeUp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Console.WriteLine("sqlmigracija");
            migrationBuilder.Sql(@"
USE [PickMeUP]

--gender
SET IDENTITY_INSERT [dbo].[Genders] ON 
INSERT INTO Genders (genderId, description, isDeleted) 
VALUES 
(1, 'Male', 0), 
(2, 'Female', 0);
SET IDENTITY_INSERT [dbo].[Genders] OFF


--roles
SET IDENTITY_INSERT [dbo].[Roles] ON 
INSERT INTO Roles (roleId, roleName, roleDescription, isDeleted) 
VALUES 
(1, 'Admin', 'Administrator', 0), 
(2, 'User', 'User', 0),
(3, 'Customer',	'Customer', 0),
(4, 'Employee', 'Employee', 0);
SET IDENTITY_INSERT [dbo].[Roles] OFF 


SET IDENTITY_INSERT [dbo].[UserAccounts] ON 
INSERT INTO UserAccounts (userAccountId, email, passwordHash,passwordSalt,isDeleted) 
VALUES 
(1, 'eldar', HASHBYTES('SHA2_256', 'eldar'), HASHBYTES('SHA2_256', 'salt'), 0), 
(2, 'aida', HASHBYTES('SHA2_256', 'aida'), HASHBYTES('SHA2_256', 'salt'), 0);
SET IDENTITY_INSERT [dbo].[UserAccounts] OFF 


SET IDENTITY_INSERT [dbo].[Users] ON 
INSERT INTO [Users] (userId, firstName, lastName, userAccountID, dateOfBirth, genderID, phoneNumber, taxiCompanyID, isDeleted) 
VALUES 
(1, 'eldar', 'sose', 1, GETDATE(), 1, '063799704', null, 0),
(2, 'aida', 'zuhric', 2, GETDATE(), 2, '063799704', null, 0);
SET IDENTITY_INSERT [dbo].[Users] OFF --Turn off IDENTITY_INSERT for Users



INSERT INTO RoleUsers (userId, roleId, isDeleted) 
VALUES 
(1, 1, 0), 
(2, 2, 0);



SET IDENTITY_INSERT [dbo].[Taxis] ON 
INSERT INTO Taxis (taxiId, taxiName, userId, startingPrice, pricePerKilometer, address, isDeleted) 
VALUES 
(1, 'EldarTaxi', 1,2.0, 1.2, 'Musala', 0), 
(2, 'AidaTaxi', 2,2.2, 1.0, 'Fejiceva', 0);
SET IDENTITY_INSERT [dbo].[Taxis] OFF --Turn off IDENTITY_INSERT for Salon


SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT INTO Cars(carId, taxiID, carModel, taxiNumber, plateNumber, isDeleted)
VALUES
(1, 1, 'Renault', 56, 123456, 0),
(2, 2, 'Ford', 57, 456789, 0);
SET IDENTITY_INSERT [dbo].[Cars] OFF


SET IDENTITY_INSERT [dbo].[Contacts] ON
INSERT INTO Contacts(contactId, contactName, contactInfo, isDeleted)
VALUES
(1, 'Eldar', 'eldar.sose@gmail.com', 0),
(2, 'Aida', 'aida.zuhric@gmail.com', 0);
SET IDENTITY_INSERT [dbo].[Contacts] OFF


SET IDENTITY_INSERT [dbo].[DriverRatings] ON
INSERT INTO DriverRatings(driverRatingsId, driverId, userId, rating, comment, isDeleted)
VALUES
(1, 1, 2, 5, 'najbolji sofer u ovom taksiju', 0),
(2, 2, 1, 5, 'jos bolji sofer od prethodnog', 0);
SET IDENTITY_INSERT [dbo].[DriverRatings] OFF


SET IDENTITY_INSERT [dbo].[OrderStatuses] ON
INSERT INTO OrderStatuses(ordedStatusId, orderStatusName, orderStatusDescription, isDeleted)
VALUES
(1, 'not new', 'old', 0),
(2, 'new', 'new', 0);
SET IDENTITY_INSERT [dbo].[OrderStatuses] OFF


SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT INTO [Orders](orderId, taxiId, userId, taxiDriverId, timeUntilArrival, orderStatusId, isDeleted)
VALUES
(1, 1, 1, 1, GETDATE(), 1, 0),
(2, 2, 2, 2, GETDATE(), 2, 0);
SET IDENTITY_INSERT [dbo].[Orders] OFF


SET IDENTITY_INSERT [dbo].[ReportTypes] ON
INSERT INTO ReportTypes(reportTypeId, reportName, isDeleted)
VALUES
(1, 'prijava', 0),
(2, 'prijava', 0);
SET IDENTITY_INSERT [dbo].[ReportTypes] OFF


SET IDENTITY_INSERT [dbo].[Reports] ON
INSERT INTO Reports(reportId, reportName, reportDescription, madeAt, reportTypeId, userId, adminId, reportAnswer, answeredAt, isDeleted)
VALUES
(1, 'prijava', 'nova', GETDATE(), 1, 1, 1, 'primljeno', GETDATE(), 0),
(2, 'prijava', 'nova', GETDATE(), 2, 2, 1, 'primljeno', GETDATE(), 0);
SET IDENTITY_INSERT [dbo].[Reports] OFF


SET IDENTITY_INSERT [dbo].[Reviews] ON
INSERT INTO Reviews(reviewId, taxiId, userId, comment, rating, isDeleted)
VALUES
(1, 1, 1, 'komentar', 4, 0),
(2, 2, 2, 'komentar opet', 5, 0);
SET IDENTITY_INSERT [dbo].[Reviews] OFF


SET IDENTITY_INSERT [dbo].[Shifts] ON
INSERT INTO Shifts(shiftId, startTime, endTime, taxiDriverId, taxiCompanyId, tookABreak, isDeleted)
VALUES
(1, GETDATE(), GETDATE(), 1, 1, 1, 0),
(2, GETDATE(), GETDATE(), 2, 1, 0, 0);
SET IDENTITY_INSERT [dbo].[Shifts] OFF



INSERT INTO TaxiContacts(taxiId, contactId, isDeleted)
VALUES
(1, 1, 0),
(2, 2, 0);




INSERT INTO TaxiDriverCars(carId, taxiDriverId, isDeleted)
VALUES
(1, 1, 0),
(2, 2, 0);

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM TaxiDriverCars");
            migrationBuilder.Sql("DELETE FROM TaxiContacts");
            migrationBuilder.Sql("DELETE FROM Shifts");
            migrationBuilder.Sql("DELETE FROM Reviews");
            migrationBuilder.Sql("DELETE FROM Reports");
            migrationBuilder.Sql("DELETE FROM ReportTypes");
            migrationBuilder.Sql("DELETE FROM Orders");
            migrationBuilder.Sql("DELETE FROM OrderStatuses");
            migrationBuilder.Sql("DELETE FROM DriverRatings");
            migrationBuilder.Sql("DELETE FROM Contacts");
            migrationBuilder.Sql("DELETE FROM Cars");
            migrationBuilder.Sql("DELETE FROM Taxis");
            migrationBuilder.Sql("DELETE FROM RoleUsers");
            migrationBuilder.Sql("DELETE FROM Users");
            migrationBuilder.Sql("DELETE FROM UserAccounts");
            migrationBuilder.Sql("DELETE FROM Roles");
            migrationBuilder.Sql("DELETE FROM Genders");
        }

    }
}
