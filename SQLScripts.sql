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

CREATE TABLE [Companies] (
    [ID] uniqueidentifier NOT NULL,
    [Name] nvarchar(80) NOT NULL,
    [State] bit NOT NULL,
    [OrderStart] time NOT NULL,
    [OrderEnd] time NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Products] (
    [ID] nvarchar(36) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Stock] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Orders] (
    [ID] nvarchar(36) NOT NULL,
    [CompanyID] uniqueidentifier NOT NULL,
    [OrderOwner] nvarchar(max) NOT NULL,
    [OrderDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Orders_Companies_CompanyID] FOREIGN KEY ([CompanyID]) REFERENCES [Companies] ([ID])
);
GO

CREATE TABLE [OrderProduct] (
    [OrdersID] nvarchar(36) NOT NULL,
    [ProductsID] nvarchar(36) NOT NULL,
    CONSTRAINT [PK_OrderProduct] PRIMARY KEY ([OrdersID], [ProductsID]),
    CONSTRAINT [FK_OrderProduct_Orders_OrdersID] FOREIGN KEY ([OrdersID]) REFERENCES [Orders] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderProduct_Products_ProductsID] FOREIGN KEY ([ProductsID]) REFERENCES [Products] ([ID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_OrderProduct_ProductsID] ON [OrderProduct] ([ProductsID]);
GO

CREATE INDEX [IX_Orders_CompanyID] ON [Orders] ([CompanyID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230120205744_init', N'7.0.2');
GO

COMMIT;
GO