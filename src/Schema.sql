
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6482F244801F5FD]') AND parent_object_id = OBJECT_ID('[Category]'))
alter table [Category]  drop constraint FK6482F244801F5FD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1C2EC218AE3C05E0]') AND parent_object_id = OBJECT_ID('CategoryProduct'))
alter table CategoryProduct  drop constraint FK1C2EC218AE3C05E0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1C2EC218FAE6AC78]') AND parent_object_id = OBJECT_ID('CategoryProduct'))
alter table CategoryProduct  drop constraint FK1C2EC218FAE6AC78


    if exists (select * from dbo.sysobjects where id = object_id(N'[Category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Category]

    if exists (select * from dbo.sysobjects where id = object_id(N'CategoryProduct') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table CategoryProduct

    if exists (select * from dbo.sysobjects where id = object_id(N'[Product]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Product]

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
