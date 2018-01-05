/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2016
    Target Database Engine Edition : Microsoft SQL Server Express Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [PackageTracking]
GO

/****** Object:  Table [dbo].[Client]    Script Date: 05.01.2018 22:40:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Client](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Detail]    Script Date: 05.01.2018 22:40:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Detail](
	[DetailID] [int] NOT NULL,
	[IncomeID] [smallint] NOT NULL,
	[Customer] [nvarchar](250) NULL,
	[Number] [nvarchar](250) NULL,
	[ColorName] [nvarchar](250) NULL,
	[ArticleName] [nvarchar](250) NULL,
	[Qty] [smallint] NOT NULL,
	[GTIN] [int] NOT NULL,
	[Serial] [int] NULL,
	[LastEditDate] [datetime] NULL,
	[CreationDate] [datetime] NULL,
	[ForeignID] [nvarchar](250) NULL,
	[Status] [smallint] NULL,
	[Pallet] [nvarchar](250) NULL,
	[Length] [smallint] NULL,
	[Width] [smallint] NULL,
	[Texture] [smallint] NULL,
	[Edge] [nvarchar](250) NULL,
	[Taping] [smallint] NULL,
	[Rounding] [nvarchar](250) NULL,
	[Thickness] [smallint] NULL,
	[EdgeName] [nvarchar](250) NULL,
	[Legs] [nvarchar](250) NULL,
	[Note] [nvarchar](max) NULL,
	[FrezR] [smallint] NULL,
	[Shape] [nvarchar](250) NULL,
	[CathetusL] [smallint] NULL,
	[CathetusW] [smallint] NULL,
	[Waterproof] [smallint] NULL,
	[X] [decimal](18, 9) NULL,
	[Y] [decimal](18, 9) NULL,
	[StatusModfiedDate] [datetime] NULL,
	[AcceptDate] [datetime] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
 CONSTRAINT [PK_Detail] PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 05.01.2018 22:40:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[OrderID] [int] NOT NULL,
	[GTIN] [int] NOT NULL,
	[ShipID] [int] NOT NULL,
	[Customer] [nvarchar](250) NULL,
	[Number] [nvarchar](250) NULL,
	[Qty] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[AddedBy] [nvarchar](250) NULL,
	[AddedTime] [datetime] NOT NULL,
	[LastEditDate] [datetime] NULL,
	[Rowguid] [uniqueidentifier] NOT NULL,
	[OUID] [int] NULL,
	[Replacemented] [int] NULL,
	[ProgPack] [int] NULL,
	[ProgPackStr] [nvarchar](250) NULL,
	[Is2020] [int] NULL,
	[ForeignOrderId] [nvarchar](250) NULL,
	[OrderOUID] [nvarchar](250) NULL,
	[From2020] [int] NULL,
	[Ispacked] [int] NULL,
	[ForeignOrderId_int] [int] NULL,
	[ShipOrderID] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Pack]    Script Date: 05.01.2018 22:40:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pack](
	[Serial] [int] NOT NULL,
	[GTIN] [int] NOT NULL,
	[TaskID] [int] NOT NULL,
	[OrderID] [int] NULL,
	[RegTime] [datetime] NULL,
	[RegBy] [nvarchar](250) NULL,
	[RegAuto] [bit] NULL,
	[ShippedTime] [datetime] NULL,
	[ShippedBy] [nvarchar](250) NULL,
	[ShippedAuto] [bit] NULL,
	[AddedBy] [nvarchar](250) NULL,
	[AddedTime] [datetime] NULL,
	[STo] [int] NULL,
	[RTo] [int] NULL,
	[ITime] [datetime] NULL,
	[Inv] [bit] NULL,
	[LastEditDate] [datetime] NULL,
	[Rowguid] [uniqueidentifier] NOT NULL,
	[OIDAddedTime] [datetime] NULL,
	[Isprinted] [int] NULL,
	[DriverShip] [int] NULL,
	[DriverShipDate] [datetime] NULL,
	[IsSended] [bit] NULL,
	[IsInsight] [bit] NULL,
	[IsInsightPacked] [bit] NULL,
	[IsInsightShipped] [bit] NULL,
	[InsightCONid] [int] NULL,
	[AcceptedAuto] [bit] NULL,
	[AcceptedBy] [nvarchar](250) NULL,
	[AcceptedTime] [datetime] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
 CONSTRAINT [PK_Pack] PRIMARY KEY CLUSTERED 
(
	[Serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Role]    Script Date: 05.01.2018 22:40:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Access] [int] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Ship]    Script Date: 05.01.2018 22:40:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ship](
	[ShipID] [int] NOT NULL,
	[Number] [nvarchar](250) NOT NULL,
	[SDate] [datetime] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[State] [int] NOT NULL,
	[Closed] [datetime] NULL,
	[LastEditDate] [datetime] NULL,
	[CreationDate] [datetime] NULL,
	[Rowguid] [uniqueidentifier] NOT NULL,
	[SUID] [nvarchar](250) NULL,
	[ShipFromSborka] [bit] NULL,
	[ParentShipid] [int] NULL,
	[CreateUser] [nvarchar](250) NULL,
	[LorryDateDeparture] [datetime] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
 CONSTRAINT [PK_Ship] PRIMARY KEY CLUSTERED 
(
	[ShipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[User]    Script Date: 05.01.2018 22:40:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsGlobalAdmin] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[UserRole]    Script Date: 05.01.2018 22:40:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[RoleId] [int] NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Warehouse]    Script Date: 05.01.2018 22:40:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Warehouse](
	[WarehouseId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[WarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Client] ADD  DEFAULT ((1)) FOR [Enabled]
GO

ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [IsGlobalAdmin]
GO

ALTER TABLE [dbo].[User] ADD  DEFAULT ((1)) FOR [Enabled]
GO

ALTER TABLE [dbo].[Warehouse] ADD  DEFAULT ((1)) FOR [Enabled]
GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Ship] FOREIGN KEY([ShipID])
REFERENCES [dbo].[Ship] ([ShipID])
GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Ship]
GO

ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO

ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO

ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO

ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
GO

ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Warehouse]
GO

ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO

ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_Client]
GO

IF NOT EXISTS(SELECT * FROM [User] WHERE UserId = 1) BEGIN
	INSERT [User] ([Name], [Password], IsGlobalAdmin, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
	VALUES('admin', '21232f297a57a5a743894a0e4a801fc3', 1, GetDate(), 1, GetDate(), 1)
END