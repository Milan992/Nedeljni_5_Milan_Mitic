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

if exists (SELECT name FROM sys.sysobjects WHERE name = 'vwPost')
drop view vwPost;


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
LikeID int identity(1,1) primary key,
PostID int foreign key (PostID) references tblPost(PostID) not null,
AccountID int foreign key (AccountID) references tblAccount(AccountID) not null,
)
go


USE [BetweenUs]
GO

/****** Object:  View [dbo].[vwPost]    Script Date: 9/1/2020 12:45:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwPost]
AS
SELECT        dbo.tblPost.PostID, dbo.tblAccount.AccountID, dbo.tblPost.AccountID AS Expr1, dbo.tblAccount.UserName, dbo.tblPost.[Content], dbo.tblPost.PostTime, dbo.tblPost.LikesNumber
FROM            dbo.tblAccount INNER JOIN
                         dbo.tblPost ON dbo.tblAccount.AccountID = dbo.tblPost.AccountID
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblAccount"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "tblPost"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwPost'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwPost'
GO


