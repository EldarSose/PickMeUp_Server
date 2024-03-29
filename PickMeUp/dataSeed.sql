USE [PickMeUP]

--gender
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT INTO Gender (genderId, description, isDeleted) 
VALUES 
(1, 'Male', false), 
(2, 'Female', false);

SET IDENTITY_INSERT [dbo].[Gender] OFF

--roles
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT INTO Roles (roleId, roleName, roleDescription, isDeleted) 
VALUES 
(1, 'Admin', 'Administrator', false), 
(2, 'User', 'User', false),
(3, 'Customer',	'Customer', false),
(4, 'Employee', 'Employee', false);

SET IDENTITY_INSERT [dbo].[Roles] OFF 

SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT INTO UserAccount (userAccountId, email, passwordHash,passwordSalt,isDeleted) 
VALUES 
(1, 'eldar', HASHBYTES('SHA2_256', 'eldar'), HASHBYTES('SHA2_256', 'salt'), false), 
(2, 'aida', HASHBYTES('SHA2_256', 'aida'), HASHBYTES('SHA2_256', 'salt'), false);

SET IDENTITY_INSERT [dbo].[Car] OFF --Turn off IDENTITY_INSERT for City

SET IDENTITY_INSERT [dbo].[User] ON 

INSERT INTO [User] (userId, firstName, lastName, userAccountID, dateOfBirth, genderID, phoneNumber, taxiCompanyID, isDeleted) 
VALUES 
(1, 'eldar', 'sose', 1, '23/8/2001', 1, '063799704', null, false),
(2, 'aida', 'zuhric', 2, '23/8/2001', 2, '063799704', null, false);

SET IDENTITY_INSERT [dbo].[User] OFF --Turn off IDENTITY_INSERT for Users

SET IDENTITY_INSERT [dbo].[RoleUser] ON 

INSERT INTO RoleUser (userId, roleId, isDeleted) 
VALUES 
(1, 1, false), 
(2, 2, false);

SET IDENTITY_INSERT [dbo].[RoleUser] OFF --Turn off IDENTITY_INSERT for UserRoles

SET IDENTITY_INSERT [dbo].[Taxi] ON 

INSERT INTO Taxi (taxiId, taxiName, userId, startingPrice, pricePerKilometer, address, isDeleted) 
VALUES 
(1, 'EldarTaxi', 1,2.0, 1.2, 'Musala', false), 
(2, 'AidaTaxi', 2,2.2, 1.0, 2, 'Fejiceva', false);

SET IDENTITY_INSERT [dbo].[Taxi] OFF --Turn off IDENTITY_INSERT for Salon

