CREATE TABLE[dbo].[Accounting] (
    [Id]      INT IDENTITY PRIMARY KEY NOT NULL,
    [UserId]  INT           NOT NULL,
    [Date]    DATETIME      NOT NULL,
    [Balance] MONEY         NOT NULL,
    [Type]    NVARCHAR (50) NOT NULL,
    CONSTRAINT[FK_User] FOREIGN KEY([UserId]) REFERENCES[dbo].[User]([Id])
);