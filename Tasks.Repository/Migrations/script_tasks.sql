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

CREATE TABLE [User] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    [CPF] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220716175021_CreateDatabase', N'6.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Board] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(200) NOT NULL,
    [UserId] uniqueidentifier NULL,
    CONSTRAINT [PK_Board] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Board_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Task] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(200) NOT NULL,
    [Description] nvarchar(500) NOT NULL,
    [Done] bit NOT NULL DEFAULT CAST(0 AS bit),
    [AssignedToId] uniqueidentifier NOT NULL,
    [BoardId1] uniqueidentifier NOT NULL,
    [BoardId] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Task_Board_BoardId] FOREIGN KEY ([BoardId]) REFERENCES [Board] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Task_Board_BoardId1] FOREIGN KEY ([BoardId1]) REFERENCES [Board] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Task_User_AssignedToId] FOREIGN KEY ([AssignedToId]) REFERENCES [User] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Task_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Board_UserId] ON [Board] ([UserId]);
GO

CREATE INDEX [IX_Task_AssignedToId] ON [Task] ([AssignedToId]);
GO

CREATE INDEX [IX_Task_BoardId] ON [Task] ([BoardId]);
GO

CREATE INDEX [IX_Task_BoardId1] ON [Task] ([BoardId1]);
GO

CREATE INDEX [IX_Task_UserId] ON [Task] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220716181020_Tasks', N'6.0.7');
GO

COMMIT;
GO

