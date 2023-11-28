CREATE TABLE [dbo].[User] (
    [Id]          INT IDENTITY PRIMARY KEY NOT NULL,
    [FirstName]   NVARCHAR (50) NOT NULL,
    [LastName]    NVARCHAR (50) NOT NULL,
    [Email]       NVARCHAR (50) UNIQUE NOT NULL,
    [MobileNumber] NVARCHAR (50) UNIQUE NOT NULL,
    [Password]    NVARCHAR (50) UNIQUE NOT NULL,
);

