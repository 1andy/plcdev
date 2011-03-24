
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6482F244801F5FD]') AND parent_object_id = OBJECT_ID('[Category]'))
alter table [Category]  drop constraint FK6482F244801F5FD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1C2EC218AE3C05E0]') AND parent_object_id = OBJECT_ID('CategoryProduct'))
alter table CategoryProduct  drop constraint FK1C2EC218AE3C05E0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1C2EC218FAE6AC78]') AND parent_object_id = OBJECT_ID('CategoryProduct'))
alter table CategoryProduct  drop constraint FK1C2EC218FAE6AC78


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEA4983CCAE3C05E0]') AND parent_object_id = OBJECT_ID('[ProductVariant]'))
alter table [ProductVariant]  drop constraint FKEA4983CCAE3C05E0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC9372F26AE3C05E0]') AND parent_object_id = OBJECT_ID('[ProductVariantOption]'))
alter table [ProductVariantOption]  drop constraint FKC9372F26AE3C05E0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6DAFBC52F8AB4237]') AND parent_object_id = OBJECT_ID('[ProductVariantOptionValue]'))
alter table [ProductVariantOptionValue]  drop constraint FK6DAFBC52F8AB4237


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6DAFBC52BFB63F8D]') AND parent_object_id = OBJECT_ID('[ProductVariantOptionValue]'))
alter table [ProductVariantOptionValue]  drop constraint FK6DAFBC52BFB63F8D


    if exists (select * from dbo.sysobjects where id = object_id(N'[Category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Category]

    if exists (select * from dbo.sysobjects where id = object_id(N'CategoryProduct') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CategoryProduct

    if exists (select * from dbo.sysobjects where id = object_id(N'[Product]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Product]

    if exists (select * from dbo.sysobjects where id = object_id(N'[ProductVariant]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [ProductVariant]

    if exists (select * from dbo.sysobjects where id = object_id(N'[ProductVariantOption]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [ProductVariantOption]

    if exists (select * from dbo.sysobjects where id = object_id(N'[ProductVariantOptionValue]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [ProductVariantOptionValue]

    create table [Category] (
        CategoryID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       Description NVARCHAR(MAX) not null,
       ParentCategoryID INT null,
       primary key (CategoryID)
    )

    create table CategoryProduct (
        CategoryID INT not null,
       ProductID INT not null
    )

    create table [Product] (
        ProductID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       primary key (ProductID)
    )

    create table [ProductVariant] (
        ProductVariantID INT IDENTITY NOT NULL,
       Price DECIMAL(19,5) not null,
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
