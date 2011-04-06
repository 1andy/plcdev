
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFA88A7FA2CEFF2F6]') AND parent_object_id = OBJECT_ID('[Category]'))
alter table [Category]  drop constraint FKFA88A7FA2CEFF2F6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEF141043C67A5BBC]') AND parent_object_id = OBJECT_ID('CategoryProduct'))
alter table CategoryProduct  drop constraint FKEF141043C67A5BBC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEF1410435F55A6EA]') AND parent_object_id = OBJECT_ID('CategoryProduct'))
alter table CategoryProduct  drop constraint FKEF1410435F55A6EA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59090D7B3A0DB368]') AND parent_object_id = OBJECT_ID('[OrderItem]'))
alter table [OrderItem]  drop constraint FK59090D7B3A0DB368


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59090D7BA341C5B6]') AND parent_object_id = OBJECT_ID('[OrderItem]'))
alter table [OrderItem]  drop constraint FK59090D7BA341C5B6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD1436656C8BFB3CA]') AND parent_object_id = OBJECT_ID('[Order]'))
alter table [Order]  drop constraint FKD1436656C8BFB3CA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD14366566827A512]') AND parent_object_id = OBJECT_ID('[Order]'))
alter table [Order]  drop constraint FKD14366566827A512


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD1436656D9A7125]') AND parent_object_id = OBJECT_ID('[Order]'))
alter table [Order]  drop constraint FKD1436656D9A7125


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1C83FFA2C67A5BBC]') AND parent_object_id = OBJECT_ID('[ProductVariant]'))
alter table [ProductVariant]  drop constraint FK1C83FFA2C67A5BBC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6729C397C67A5BBC]') AND parent_object_id = OBJECT_ID('[ProductVariantOption]'))
alter table [ProductVariantOption]  drop constraint FK6729C397C67A5BBC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49AC5D002269DB12]') AND parent_object_id = OBJECT_ID('[ProductVariantOptionValue]'))
alter table [ProductVariantOptionValue]  drop constraint FK49AC5D002269DB12


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49AC5D00A341C5B6]') AND parent_object_id = OBJECT_ID('[ProductVariantOptionValue]'))
alter table [ProductVariantOptionValue]  drop constraint FK49AC5D00A341C5B6


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
        add constraint FKFA88A7FA2CEFF2F6 
        foreign key (ParentCategoryID) 
        references [Category]

    alter table CategoryProduct 
        add constraint FKEF141043C67A5BBC 
        foreign key (ProductID) 
        references [Product]

    alter table CategoryProduct 
        add constraint FKEF1410435F55A6EA 
        foreign key (CategoryID) 
        references [Category]

    alter table [OrderItem] 
        add constraint FK59090D7B3A0DB368 
        foreign key (OrderID) 
        references [Order]

    alter table [OrderItem] 
        add constraint FK59090D7BA341C5B6 
        foreign key (ProductVariantID) 
        references [ProductVariant]

    alter table [Order] 
        add constraint FKD1436656C8BFB3CA 
        foreign key (CustomerID) 
        references [Customer]

    alter table [Order] 
        add constraint FKD14366566827A512 
        foreign key (ShippingAddressID) 
        references [Address]

    alter table [Order] 
        add constraint FKD1436656D9A7125 
        foreign key (BillingAddressID) 
        references [Address]

    alter table [ProductVariant] 
        add constraint FK1C83FFA2C67A5BBC 
        foreign key (ProductID) 
        references [Product]

    alter table [ProductVariantOption] 
        add constraint FK6729C397C67A5BBC 
        foreign key (ProductID) 
        references [Product]

    alter table [ProductVariantOptionValue] 
        add constraint FK49AC5D002269DB12 
        foreign key (ProductVariantOptionID) 
        references [ProductVariantOption]

    alter table [ProductVariantOptionValue] 
        add constraint FK49AC5D00A341C5B6 
        foreign key (ProductVariantID) 
        references [ProductVariant]
