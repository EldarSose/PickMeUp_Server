IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Contacts] (
    [contactId] int NOT NULL IDENTITY,
    [contactName] nvarchar(max) NULL,
    [contactInfo] nvarchar(max) NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([contactId])
);
GO

CREATE TABLE [Genders] (
    [genderId] int NOT NULL IDENTITY,
    [description] nvarchar(max) NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_Genders] PRIMARY KEY ([genderId])
);
GO

CREATE TABLE [OrderStatuses] (
    [ordedStatusId] int NOT NULL IDENTITY,
    [orderStatusName] nvarchar(max) NULL,
    [orderStatusDescription] nvarchar(max) NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_OrderStatuses] PRIMARY KEY ([ordedStatusId])
);
GO

CREATE TABLE [ReportTypes] (
    [reportTypeId] int NOT NULL IDENTITY,
    [reportName] int NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_ReportTypes] PRIMARY KEY ([reportTypeId])
);
GO

CREATE TABLE [Roles] (
    [roleId] int NOT NULL IDENTITY,
    [roleName] nvarchar(max) NULL,
    [roleDescription] nvarchar(max) NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([roleId])
);
GO

CREATE TABLE [UserAccounts] (
    [userAccountId] int NOT NULL IDENTITY,
    [email] nvarchar(max) NULL,
    [passwordHash] varbinary(max) NULL,
    [passwordSalt] varbinary(max) NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_UserAccounts] PRIMARY KEY ([userAccountId])
);
GO

CREATE TABLE [Cars] (
    [carId] int NOT NULL IDENTITY,
    [taxiID] int NULL,
    [carModel] nvarchar(max) NULL,
    [taxiNumber] nvarchar(max) NULL,
    [plateNumber] nvarchar(max) NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY ([carId])
);
GO

CREATE TABLE [DriverRatings] (
    [driverRatingsId] int NOT NULL IDENTITY,
    [driverId] int NULL,
    [userId] int NULL,
    [rating] real NULL,
    [comment] nvarchar(max) NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_DriverRatings] PRIMARY KEY ([driverRatingsId])
);
GO

CREATE TABLE [Orders] (
    [orderId] int NOT NULL IDENTITY,
    [taxiId] int NULL,
    [userId] int NULL,
    [taxiDriverId] int NULL,
    [timeUntilArrival] datetime2 NULL,
    [orderStatusId] int NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([orderId]),
    CONSTRAINT [FK_Orders_OrderStatuses_orderStatusId] FOREIGN KEY ([orderStatusId]) REFERENCES [OrderStatuses] ([ordedStatusId])
);
GO

CREATE TABLE [Reports] (
    [reportId] int NOT NULL IDENTITY,
    [reportName] nvarchar(max) NULL,
    [reportDescription] nvarchar(max) NULL,
    [madeAt] datetime2 NULL,
    [reportTypeId] int NULL,
    [userId] int NULL,
    [adminId] int NULL,
    [reportAnswer] nvarchar(max) NULL,
    [answeredAt] datetime2 NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_Reports] PRIMARY KEY ([reportId]),
    CONSTRAINT [FK_Reports_ReportTypes_reportTypeId] FOREIGN KEY ([reportTypeId]) REFERENCES [ReportTypes] ([reportTypeId])
);
GO

CREATE TABLE [Reviews] (
    [reviewId] int NOT NULL IDENTITY,
    [taxiId] int NULL,
    [userId] int NULL,
    [comment] nvarchar(max) NULL,
    [rating] real NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY ([reviewId])
);
GO

CREATE TABLE [RoleUsers] (
    [userId] int NOT NULL,
    [roleId] int NOT NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_RoleUsers] PRIMARY KEY ([userId], [roleId]),
    CONSTRAINT [FK_RoleUsers_Roles_roleId] FOREIGN KEY ([roleId]) REFERENCES [Roles] ([roleId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Shifts] (
    [shiftId] int NOT NULL IDENTITY,
    [startTime] datetime2 NULL,
    [endTime] datetime2 NULL,
    [taxiDriverId] int NULL,
    [taxiCompanyId] int NULL,
    [tookABreak] bit NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_Shifts] PRIMARY KEY ([shiftId])
);
GO

CREATE TABLE [TaxiContacts] (
    [taxiId] int NOT NULL,
    [contactId] int NOT NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_TaxiContacts] PRIMARY KEY ([contactId], [taxiId]),
    CONSTRAINT [FK_TaxiContacts_Contacts_contactId] FOREIGN KEY ([contactId]) REFERENCES [Contacts] ([contactId]) ON DELETE CASCADE
);
GO

CREATE TABLE [taxiDriverCars] (
    [carId] int NOT NULL,
    [taxiDriverId] int NOT NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_taxiDriverCars] PRIMARY KEY ([carId], [taxiDriverId]),
    CONSTRAINT [FK_taxiDriverCars_Cars_carId] FOREIGN KEY ([carId]) REFERENCES [Cars] ([carId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Taxis] (
    [taxiId] int NOT NULL IDENTITY,
    [taxiName] nvarchar(max) NULL,
    [userId] int NULL,
    [startingPrice] real NULL,
    [pricePerKilometer] real NULL,
    [address] nvarchar(max) NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_Taxis] PRIMARY KEY ([taxiId])
);
GO

CREATE TABLE [Users] (
    [userId] int NOT NULL IDENTITY,
    [firstName] nvarchar(max) NULL,
    [lastName] nvarchar(max) NULL,
    [userAccountID] int NULL,
    [dateOfBirth] datetime2 NULL,
    [genderID] int NULL,
    [phoneNumber] nvarchar(max) NULL,
    [taxiCompanyID] int NULL,
    [isDeleted] bit NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([userId]),
    CONSTRAINT [FK_Users_Genders_genderID] FOREIGN KEY ([genderID]) REFERENCES [Genders] ([genderId]),
    CONSTRAINT [FK_Users_Taxis_taxiCompanyID] FOREIGN KEY ([taxiCompanyID]) REFERENCES [Taxis] ([taxiId]),
    CONSTRAINT [FK_Users_UserAccounts_userAccountID] FOREIGN KEY ([userAccountID]) REFERENCES [UserAccounts] ([userAccountId])
);
GO

CREATE INDEX [IX_Cars_taxiID] ON [Cars] ([taxiID]);
GO

CREATE INDEX [IX_DriverRatings_driverId] ON [DriverRatings] ([driverId]);
GO

CREATE INDEX [IX_DriverRatings_userId] ON [DriverRatings] ([userId]);
GO

CREATE INDEX [IX_Orders_orderStatusId] ON [Orders] ([orderStatusId]);
GO

CREATE INDEX [IX_Orders_taxiDriverId] ON [Orders] ([taxiDriverId]);
GO

CREATE INDEX [IX_Orders_taxiId] ON [Orders] ([taxiId]);
GO

CREATE INDEX [IX_Orders_userId] ON [Orders] ([userId]);
GO

CREATE INDEX [IX_Reports_adminId] ON [Reports] ([adminId]);
GO

CREATE INDEX [IX_Reports_reportTypeId] ON [Reports] ([reportTypeId]);
GO

CREATE INDEX [IX_Reports_userId] ON [Reports] ([userId]);
GO

CREATE INDEX [IX_Reviews_taxiId] ON [Reviews] ([taxiId]);
GO

CREATE INDEX [IX_Reviews_userId] ON [Reviews] ([userId]);
GO

CREATE INDEX [IX_RoleUsers_roleId] ON [RoleUsers] ([roleId]);
GO

CREATE INDEX [IX_Shifts_taxiCompanyId] ON [Shifts] ([taxiCompanyId]);
GO

CREATE INDEX [IX_Shifts_taxiDriverId] ON [Shifts] ([taxiDriverId]);
GO

CREATE INDEX [IX_TaxiContacts_taxiId] ON [TaxiContacts] ([taxiId]);
GO

CREATE INDEX [IX_taxiDriverCars_taxiDriverId] ON [taxiDriverCars] ([taxiDriverId]);
GO

CREATE INDEX [IX_Taxis_userId] ON [Taxis] ([userId]);
GO

CREATE INDEX [IX_Users_genderID] ON [Users] ([genderID]);
GO

CREATE INDEX [IX_Users_taxiCompanyID] ON [Users] ([taxiCompanyID]);
GO

CREATE INDEX [IX_Users_userAccountID] ON [Users] ([userAccountID]);
GO

ALTER TABLE [Cars] ADD CONSTRAINT [FK_Cars_Taxis_taxiID] FOREIGN KEY ([taxiID]) REFERENCES [Taxis] ([taxiId]);
GO

ALTER TABLE [DriverRatings] ADD CONSTRAINT [FK_DriverRatings_Users_driverId] FOREIGN KEY ([driverId]) REFERENCES [Users] ([userId]);
GO

ALTER TABLE [DriverRatings] ADD CONSTRAINT [FK_DriverRatings_Users_userId] FOREIGN KEY ([userId]) REFERENCES [Users] ([userId]);
GO

ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_Taxis_taxiId] FOREIGN KEY ([taxiId]) REFERENCES [Taxis] ([taxiId]);
GO

ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_Users_taxiDriverId] FOREIGN KEY ([taxiDriverId]) REFERENCES [Users] ([userId]);
GO

ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_Users_userId] FOREIGN KEY ([userId]) REFERENCES [Users] ([userId]);
GO

ALTER TABLE [Reports] ADD CONSTRAINT [FK_Reports_Users_adminId] FOREIGN KEY ([adminId]) REFERENCES [Users] ([userId]);
GO

ALTER TABLE [Reports] ADD CONSTRAINT [FK_Reports_Users_userId] FOREIGN KEY ([userId]) REFERENCES [Users] ([userId]);
GO

ALTER TABLE [Reviews] ADD CONSTRAINT [FK_Reviews_Taxis_taxiId] FOREIGN KEY ([taxiId]) REFERENCES [Taxis] ([taxiId]);
GO

ALTER TABLE [Reviews] ADD CONSTRAINT [FK_Reviews_Users_userId] FOREIGN KEY ([userId]) REFERENCES [Users] ([userId]);
GO

ALTER TABLE [RoleUsers] ADD CONSTRAINT [FK_RoleUsers_Users_userId] FOREIGN KEY ([userId]) REFERENCES [Users] ([userId]) ON DELETE CASCADE;
GO

ALTER TABLE [Shifts] ADD CONSTRAINT [FK_Shifts_Taxis_taxiCompanyId] FOREIGN KEY ([taxiCompanyId]) REFERENCES [Taxis] ([taxiId]);
GO

ALTER TABLE [Shifts] ADD CONSTRAINT [FK_Shifts_Users_taxiDriverId] FOREIGN KEY ([taxiDriverId]) REFERENCES [Users] ([userId]);
GO

ALTER TABLE [TaxiContacts] ADD CONSTRAINT [FK_TaxiContacts_Taxis_taxiId] FOREIGN KEY ([taxiId]) REFERENCES [Taxis] ([taxiId]) ON DELETE CASCADE;
GO

ALTER TABLE [taxiDriverCars] ADD CONSTRAINT [FK_taxiDriverCars_Users_taxiDriverId] FOREIGN KEY ([taxiDriverId]) REFERENCES [Users] ([userId]) ON DELETE CASCADE;
GO

ALTER TABLE [Taxis] ADD CONSTRAINT [FK_Taxis_Users_userId] FOREIGN KEY ([userId]) REFERENCES [Users] ([userId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230406143925_init', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ReportTypes]') AND [c].[name] = N'reportName');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ReportTypes] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ReportTypes] ALTER COLUMN [reportName] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230801091248_nova', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240801173551_UpdateContactsTable', N'8.0.8');
GO

COMMIT;
GO

