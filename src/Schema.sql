
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6482F244801F5FD]') AND parent_object_id = OBJECT_ID('[Category]'))
alter table [Category]  drop constraint FK6482F244801F5FD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1C2EC218AE3C05E0]') AND parent_object_id = OBJECT_ID('CategoryProduct'))
alter table CategoryProduct  drop constraint FK1C2EC218AE3C05E0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1C2EC218FAE6AC78]') AND parent_object_id = OBJECT_ID('CategoryProduct'))
alter table CategoryProduct  drop constraint FK1C2EC218FAE6AC78


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3EF888581E843911]') AND parent_object_id = OBJECT_ID('[OrderItem]'))
alter table [OrderItem]  drop constraint FK3EF888581E843911


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3EF88858BFB63F8D]') AND parent_object_id = OBJECT_ID('[OrderItem]'))
alter table [OrderItem]  drop constraint FK3EF88858BFB63F8D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3117099BC92C4711]') AND parent_object_id = OBJECT_ID('[Order]'))
alter table [Order]  drop constraint FK3117099BC92C4711


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3117099BB5B5E76]') AND parent_object_id = OBJECT_ID('[Order]'))
alter table [Order]  drop constraint FK3117099BB5B5E76


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3117099B1320ED69]') AND parent_object_id = OBJECT_ID('[Order]'))
alter table [Order]  drop constraint FK3117099B1320ED69


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEA4983CCAE3C05E0]') AND parent_object_id = OBJECT_ID('[ProductVariant]'))
alter table [ProductVariant]  drop constraint FKEA4983CCAE3C05E0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC9372F26AE3C05E0]') AND parent_object_id = OBJECT_ID('[ProductVariantOption]'))
alter table [ProductVariantOption]  drop constraint FKC9372F26AE3C05E0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6DAFBC52F8AB4237]') AND parent_object_id = OBJECT_ID('[ProductVariantOptionValue]'))
alter table [ProductVariantOptionValue]  drop constraint FK6DAFBC52F8AB4237


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6DAFBC52BFB63F8D]') AND parent_object_id = OBJECT_ID('[ProductVariantOptionValue]'))
alter table [ProductVariantOptionValue]  drop constraint FK6DAFBC52BFB63F8D


    if exists (select * from dbo.sysobjects where id = object_id(N'[Address]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Address]

    if exists (select * from dbo.sysobjects where id = object_id(N'[Category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Category]

    if exists (select * from dbo.sysobjects where id = object_id(N'CategoryProduct') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CategoryProduct

    if exists (select * from dbo.sysobjects where id = object_id(N'[Customer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Customer]

    if exists (select * from dbo.sysobjects where id = object_id(N'[OrderItem]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [OrderItem]

    if exists (select * from dbo.sysobjects where id = object_id(N'[Order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Order]

    if exists (select * from dbo.sysobjects where id = object_id(N'[Product]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Product]

    if exists (select * from dbo.sysobjects where id = object_id(N'[ProductVariant]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [ProductVariant]

    if exists (select * from dbo.sysobjects where id = object_id(N'[ProductVariantOption]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [ProductVariantOption]

    if exists (select * from dbo.sysobjects where id = object_id(N'[ProductVariantOptionValue]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [ProductVariantOptionValue]

    create table [Address] (
        AddressID INT IDENTITY NOT NULL,
       Address1 NVARCHAR(255) not null,
       primary key (AddressID)
    )

    create table [Category] (
        CategoryID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       Description NVARCHAR(MAX) not null,
       ParentCategoryID INT null,
       primary key (CategoryID)
    )

    create table CategoryProduct (
        CategoryID INT not null,
       ProductID INT not null,
       primary key (ProductID, CategoryID)
    )

    create table [Customer] (
        CustomerID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       Email NVARCHAR(255) not null unique,
       primary key (CustomerID)
    )

    create table [OrderItem] (
        OrderItemID INT IDENTITY NOT NULL,
       Quantity INT not null,
       OrderID INT not null,
       ProductVariantID INT null,
       primary key (OrderItemID)
    )

    create table [Order] (
        OrderID INT IDENTITY NOT NULL,
       CustomerID INT not null,
       ShippingAddressID INT null,
       BillingAddressID INT null,
       primary key (OrderID)
    )

    create table [Product] (
        ProductID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       Description NVARCHAR(MAX) not null,
       primary key (ProductID)
    )

    create table [ProductVariant] (
        ProductVariantID INT IDENTITY NOT NULL,
       Price MONEY not null,
       Sku NVARCHAR(255) not null,
       ProductID INT not null,
       primary key (ProductVariantID)
    )

    create table [ProductVariantOption] (
        ProductVariantOptionID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       ProductID INT not null,
       primary key (ProductVariantOptionID)
    )

    create table [ProductVariantOptionValue] (
        ProductVariantOptionValue INT IDENTITY NOT NULL,
       Value NVARCHAR(255) null,
       ProductVariantOptionID INT not null,
       ProductVariantID INT not null,
       primary key (ProductVariantOptionValue),
      unique (ProductVariantOptionID, ProductVariantID)
    )

    alter table [Category] 
        add constraint FK6482F244801F5FD 
        foreign key (ParentCategoryID) 
        references [Category]

    alter table CategoryProduct 
        add constraint FK1C2EC218AE3C05E0 
        foreign key (ProductID) 
        references [Product]

    alter table CategoryProduct 
        add constraint FK1C2EC218FAE6AC78 
        foreign key (CategoryID) 
        references [Category]

    alter table [OrderItem] 
        add constraint FK3EF888581E843911 
        foreign key (OrderID) 
        references [Order]

    alter table [OrderItem] 
        add constraint FK3EF88858BFB63F8D 
        foreign key (ProductVariantID) 
        references [ProductVariant]

    alter table [Order] 
        add constraint FK3117099BC92C4711 
        foreign key (CustomerID) 
        references [Customer]

    alter table [Order] 
        add constraint FK3117099BB5B5E76 
        foreign key (ShippingAddressID) 
        references [Address]

    alter table [Order] 
        add constraint FK3117099B1320ED69 
        foreign key (BillingAddressID) 
        references [Address]

    alter table [ProductVariant] 
        add constraint FKEA4983CCAE3C05E0 
        foreign key (ProductID) 
        references [Product]

    alter table [ProductVariantOption] 
        add constraint FKC9372F26AE3C05E0 
        foreign key (ProductID) 
        references [Product]

    alter table [ProductVariantOptionValue] 
        add constraint FK6DAFBC52F8AB4237 
        foreign key (ProductVariantOptionID) 
        references [ProductVariantOption]

    alter table [ProductVariantOptionValue] 
        add constraint FK6DAFBC52BFB63F8D 
        foreign key (ProductVariantID) 
        references [ProductVariant]
