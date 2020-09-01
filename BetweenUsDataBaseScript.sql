IF DB_ID('BetweenUs') IS NULL
CREATE DATABASE BetweenUs
GO
USE BetweenUs;


if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblLike')
drop table tblLike;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblRequest')
drop table tblRequest;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblPost')
drop table tblPost;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblAccount')
drop table tblAccount;


create table tblAccount(
AccountID int identity(1,1) primary key,
FirstName varchar(30) not null,
LastName varchar(30) not null,
Gender varchar(2) check(Gender in ('M', 'Z')) not null,
UserName varchar(30) check(len(UserName) > 5) not null unique,
Pass varchar(30) check(len(Pass) > 5) not null
)

create table tblRequest(
RequestID int identity(1,1) primary key,
SenderAccountID int foreign key (SenderAccountID) references tblAccount(AccountID) not null,
ReciverAccountID int foreign key (ReciverAccountID) references tblAccount(AccountID) not null,
Accepted bit
)

create table tblPost(
PostID int identity(1,1) primary key,
AccountID int foreign key (AccountID) references tblAccount(AccountID) not null,
Content varchar(100) not null,
PostTime datetime,
LikesNumber int
)

create table tblLike(
PostID int foreign key (PostID) references tblPost(PostID) not null,
AccountID int foreign key (AccountID) references tblAccount(AccountID) not null,
)