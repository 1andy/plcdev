
    if exists (select * from dbo.sysobjects where id = object_id(N'[Category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Category]

    create table [Category] (
        CategoryID INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       Description NVARCHAR(MAX) not null,
       primary key (CategoryID)
    )
