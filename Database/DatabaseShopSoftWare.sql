USE [master]
GO
/****** Object:  Database [ShopSoftware]    Script Date: 03/06/2020 10:33:19 ******/
CREATE DATABASE [ShopSoftware]
GO
ALTER DATABASE [ShopSoftware] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopSoftware].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopSoftware] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopSoftware] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopSoftware] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopSoftware] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopSoftware] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopSoftware] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopSoftware] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopSoftware] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopSoftware] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopSoftware] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopSoftware] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopSoftware] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopSoftware] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopSoftware] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopSoftware] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopSoftware] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopSoftware] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopSoftware] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopSoftware] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopSoftware] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopSoftware] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopSoftware] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopSoftware] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopSoftware] SET  MULTI_USER 
GO
ALTER DATABASE [ShopSoftware] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopSoftware] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopSoftware] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopSoftware] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ShopSoftware] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ShopSoftware]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 03/06/2020 10:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[IDCategory] [nvarchar](50) NOT NULL,
	[NameCategory] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
	[Status] [bit] NULL,
	[MetaTitle] [nvarchar](250) NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[IDCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DescriptionOne]    Script Date: 03/06/2020 10:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DescriptionOne](
	[IDCategory] [nvarchar](50) NOT NULL,
	[IDDesOne] [bigint] IDENTITY(1,1) NOT NULL,
	[Content] [ntext] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_DescriptionOne] PRIMARY KEY CLUSTERED 
(
	[IDCategory] ASC,
	[IDDesOne] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DescriptionTwo]    Script Date: 03/06/2020 10:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DescriptionTwo](
	[IDCategory] [nvarchar](50) NOT NULL,
	[IDDesTwo] [bigint] IDENTITY(1,1) NOT NULL,
	[Content] [ntext] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_DescriptionTwo] PRIMARY KEY CLUSTERED 
(
	[IDCategory] ASC,
	[IDDesTwo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Footer]    Script Date: 03/06/2020 10:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DayWorkforWeek] [nvarchar](100) NULL,
	[TimeWork] [nvarchar](50) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_Footer_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_Footer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 03/06/2020 10:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [bigint] NULL,
	[OrderName] [nvarchar](250) NULL,
	[OrderAddress] [nvarchar](250) NULL,
	[OderPhone] [nvarchar](50) NULL,
	[OrderEmail] [nvarchar](250) NULL,
	[OrderRequest] [ntext] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 03/06/2020 10:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[IDOrder] [bigint] NOT NULL,
	[IDProduct] [nvarchar](50) NOT NULL,
	[NameProduct] [nvarchar](250) NULL,
	[Price] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderDetails_1] PRIMARY KEY CLUSTERED 
(
	[IDOrder] ASC,
	[IDProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 03/06/2020 10:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[IDProduct] [nvarchar](50) NOT NULL,
	[NameProduct] [nvarchar](250) NULL,
	[IDCategory] [nvarchar](50) NULL,
	[Price] [decimal](18, 0) NULL,
	[Images] [nvarchar](250) NULL,
	[Quantity] [int] NULL,
	[CreateDate] [datetime] NULL,
	[ModifiDate] [datetime] NULL,
	[Status] [bit] NULL,
	[MetaTitle] [nvarchar](250) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[IDProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 03/06/2020 10:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Name] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[CreateDate] [datetime] NULL CONSTRAINT [DF_User_CreateDate]  DEFAULT (getdate()),
	[ModifiDate] [datetime] NULL,
	[Permission] [bit] NULL CONSTRAINT [DF_User_Permission]  DEFAULT ((0)),
	[Status] [bit] NULL CONSTRAINT [DF_User_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Category] ([IDCategory], [NameCategory], [CreateDate], [ModifyDate], [Status], [MetaTitle]) VALUES (N'DM01', N'Bản quyền Windows', NULL, NULL, 1, N'key-window')
INSERT [dbo].[Category] ([IDCategory], [NameCategory], [CreateDate], [ModifyDate], [Status], [MetaTitle]) VALUES (N'DM02', N'Bản quyền Office', NULL, NULL, 1, N'key-office')
INSERT [dbo].[Category] ([IDCategory], [NameCategory], [CreateDate], [ModifyDate], [Status], [MetaTitle]) VALUES (N'DM03', N'Bản quyền Game', NULL, NULL, 1, N'key-game')
INSERT [dbo].[Category] ([IDCategory], [NameCategory], [CreateDate], [ModifyDate], [Status], [MetaTitle]) VALUES (N'DM04', N'Bản quyền diệt virus', NULL, NULL, 1, N'key-game')
INSERT [dbo].[Category] ([IDCategory], [NameCategory], [CreateDate], [ModifyDate], [Status], [MetaTitle]) VALUES (N'DM05', N'Đô gia dụng', CAST(N'2020-05-18 01:15:32.240' AS DateTime), CAST(N'2020-05-18 01:15:51.440' AS DateTime), 1, N'Do-gia-dung')
SET IDENTITY_INSERT [dbo].[Footer] ON 

INSERT [dbo].[Footer] ([ID], [Address], [Phone], [Email], [DayWorkforWeek], [TimeWork], [Status]) VALUES (1, N'165 Cầu Giấy - Hà Nội', N'(+84) 988.258.361', N'software@software.com', N'Thứ 2 - Thứ 3', N'7:00 - 23:00 ', 1)
SET IDENTITY_INSERT [dbo].[Footer] OFF
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP01', N'Key Window 10 Pro', N'DM01', CAST(4500000 AS Decimal(18, 0)), N'https://i.imgur.com/96Mb7ZA.jpg', 100, NULL, NULL, 1, N'key-10-pro')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP02', N'Key Window 10 Home', N'DM01', CAST(3500000 AS Decimal(18, 0)), N'https://i.imgur.com/ijokpvH.jpg', 100, NULL, NULL, 1, N'key-10-home')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP03', N'Key Window 8 Pro', N'DM01', CAST(2000000 AS Decimal(18, 0)), N'https://i.imgur.com/rQc4WpW.jpg', 100, NULL, NULL, 1, N'key-8-pro')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP04', N'Key Window 7 Pro', N'DM01', CAST(1000000 AS Decimal(18, 0)), N'https://i.imgur.com/eFMAN1R.jpg', 50, NULL, NULL, 1, N'key-7-pro')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP05', N'Key Office 2013', N'DM02', CAST(5500000 AS Decimal(18, 0)), N'https://i.imgur.com/iy5iJPW.jpg', 100, NULL, NULL, 1, N'key-office-2013')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP06', N'Key Key Office Home 2016', N'DM02', CAST(2000000 AS Decimal(18, 0)), N'https://i.imgur.com/8KHq1E0.jpg', 100, NULL, NULL, 1, N'key-office-home-2016')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP07', N'Key Office Business 2016', N'DM02', CAST(3000000 AS Decimal(18, 0)), N'https://i.imgur.com/RrGcJWg.jpg', 100, NULL, NULL, 1, N'key-office-business-2016')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP08', N'Key Office 2019', N'DM02', CAST(4500000 AS Decimal(18, 0)), N'https://i.imgur.com/JRsuryM.jpg', 100, NULL, NULL, 1, N'key-office-2019')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP09', N'Key Game FIFA Online 4', N'DM03', CAST(350000 AS Decimal(18, 0)), N'https://i.imgur.com/81yFTkF.jpg', 100, NULL, NULL, 1, N'key-game-fifa')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP10', N'Key Game ARK: Survival Evolved PC', N'DM03', CAST(230000 AS Decimal(18, 0)), N'https://i.imgur.com/2rr8hxp.jpg', 100, NULL, NULL, 1, N'key-game-ark')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP11', N'Key Game Battlefield IV', N'DM03', CAST(500000 AS Decimal(18, 0)), N'https://i.imgur.com/z7I1Bqg.jpg', 100, NULL, NULL, 1, N'key-game-battlefield-iv')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP12', N'Key Game Grand Theft Auto V', N'DM03', CAST(360000 AS Decimal(18, 0)), N'https://i.imgur.com/ie7cAqK.jpg', 100, NULL, NULL, 1, N'key-game-gta-v')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP13', N'Key Kaspersky Internet ', N'DM04', CAST(1000000 AS Decimal(18, 0)), N'https://i.imgur.com/sRHUG1E.jpg', 100, NULL, NULL, 1, N'key-virus-kaspersky')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP14', N'Key CClean', N'DM04', CAST(250000 AS Decimal(18, 0)), N'https://i.imgur.com/F8qrnf1.png', 60, NULL, NULL, 1, N'key-virus-cclean')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP15', N'Key AVG AntiVirus', N'DM04', CAST(150000 AS Decimal(18, 0)), N'https://i.imgur.com/alvbFBk.png', 100, NULL, NULL, 1, N'key-virus-avg')
INSERT [dbo].[Product] ([IDProduct], [NameProduct], [IDCategory], [Price], [Images], [Quantity], [CreateDate], [ModifiDate], [Status], [MetaTitle]) VALUES (N'SP16', N'Key BKAV', N'DM04', CAST(300000 AS Decimal(18, 0)), N'https://i.imgur.com/p8tYX6b.jpg', 100, NULL, NULL, 1, N'key-virus-bkav')
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Username], [Password], [Name], [Address], [Phone], [Email], [CreateDate], [ModifiDate], [Permission], [Status]) VALUES (1, N'admin', N'admin', N'Nguyễn Văn Hùng', N'Bắc Giang', N'0988258361', N'hungnguyen99.nvh@gmail.com', CAST(N'2020-05-07 09:09:34.857' AS DateTime), NULL, 1, 1)
INSERT [dbo].[User] ([ID], [Username], [Password], [Name], [Address], [Phone], [Email], [CreateDate], [ModifiDate], [Permission], [Status]) VALUES (4, N'ngochuyen', N'huyenvau', N'Vi Thị Ngọc Huyền', N'Bắc Giang', N'0988258361', N'huyen@gmail.com', CAST(N'2020-05-10 17:12:02.777' AS DateTime), CAST(N'2020-05-12 15:57:01.567' AS DateTime), 1, 1)
INSERT [dbo].[User] ([ID], [Username], [Password], [Name], [Address], [Phone], [Email], [CreateDate], [ModifiDate], [Permission], [Status]) VALUES (6, N'ducquan', N'123456', N'Nguyễn Khắc Đức Quân', N'Hà Nội', N'123456789', N'quan@gmail.com', CAST(N'2020-05-12 08:52:37.867' AS DateTime), CAST(N'2020-05-12 08:52:37.867' AS DateTime), 0, 1)
INSERT [dbo].[User] ([ID], [Username], [Password], [Name], [Address], [Phone], [Email], [CreateDate], [ModifiDate], [Permission], [Status]) VALUES (10006, N'phamde', N'123456', N'Phạm Văn Đệ', N'Nam Định', N'0987654321', N'phamde@gmail.com', CAST(N'2020-05-19 01:06:22.263' AS DateTime), NULL, 0, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Trigger [dbo].[CapNhapSoLuong]    Script Date: 03/06/2020 10:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[CapNhapSoLuong] ON [dbo].[OrderDetails]
FOR INSERT
AS
BEGIN
	DECLARE @idProduct NVARCHAR(50), @soluong INT
	SELECT @idProduct = Inserted.IDProduct, @soluong = Inserted.Quantity FROM Inserted

	UPDATE dbo.Product SET Quantity = (Quantity - @soluong) WHERE dbo.Product.IDProduct = @idProduct
END
GO
USE [master]
GO
ALTER DATABASE [ShopSoftware] SET  READ_WRITE 
GO
