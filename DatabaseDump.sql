CREATE DATABASE [Kwikemart]
GO

USE [Kwikemart]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 09/04/2019 08:47:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderUser] [varchar](30) NULL,
	[OrderDate] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 09/04/2019 08:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductDescription] [varchar](150) NULL,
	[ProductEnabled] [bit] NULL,
	[ProductStock] [int] NULL,
	[ProductCreationDate] [datetime] NULL,
	[ProductCreationUser] [varchar](150) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsLikes]    Script Date: 09/04/2019 08:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsLikes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[User] [varchar](150) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_ProductsLikes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsOrders]    Script Date: 09/04/2019 08:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsOrders](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_ProductsOrders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsPrices]    Script Date: 09/04/2019 08:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsPrices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[ProductPrice] [numeric](19, 2) NULL,
	[PriceCreationDate] [datetime] NULL,
	[PriceCreationUser] [varchar](150) NULL,
 CONSTRAINT [PK_ProductsPrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductStockHistory]    Script Date: 09/04/2019 08:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStockHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[TransactionId] [varchar](10) NULL,
	[OrderId] [int] NULL,
	[Quantity] [int] NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_ProductsStock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 09/04/2019 08:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](30) NULL,
	[Enabled] [bit] NULL,
	[CreationDate] [datetime] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 09/04/2019 08:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [varchar](10) NOT NULL,
	[TransactionDescription] [varchar](50) NULL,
	[TransactionEnabled] [bit] NULL,
	[TransactionCreationDate] [datetime] NULL,
	[TransactionCreationUser] [varchar](30) NULL,
 CONSTRAINT [PK_TransactionId] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/04/2019 08:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserName] [varchar](30) NOT NULL,
	[Password] [varchar](150) NULL,
	[Enabled] [bit] NULL,
	[CreationDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersRoles]    Script Date: 09/04/2019 08:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](30) NULL,
	[RoleId] [int] NULL,
	[CreationDate] [datetime] NULL,
 CONSTRAINT [PK_UsersRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [OrderUser], [OrderDate]) VALUES (1, N'rjpazs', CAST(N'2019-04-06T23:42:30.370' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [OrderUser], [OrderDate]) VALUES (2, N'rjpazs', CAST(N'2019-04-07T00:24:54.827' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [OrderUser], [OrderDate]) VALUES (3, N'rjpazs', CAST(N'2019-04-07T00:46:16.637' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [OrderUser], [OrderDate]) VALUES (4, N'rjpazs', CAST(N'2019-04-07T00:46:53.747' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [OrderUser], [OrderDate]) VALUES (5, N'rjpazs', CAST(N'2019-04-07T00:50:46.710' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [OrderUser], [OrderDate]) VALUES (8, N'rjpazs', CAST(N'2019-04-07T01:38:15.440' AS DateTime))
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (1, N'Pencil', 1, 0, CAST(N'2019-04-06T20:37:47.667' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (2, N'Eraser', 1, 45, CAST(N'2019-04-06T20:37:47.667' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (3, N'Toilet Paper', 1, 10, CAST(N'2019-04-06T20:37:47.667' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (4, N'Tissues', 1, 10, CAST(N'2019-04-06T20:37:47.667' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (5, N'Batteries', 1, 15, CAST(N'2019-04-06T20:37:47.667' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (6, N'Coca Cola', 1, 250, CAST(N'2019-04-06T20:37:47.667' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (7, N'Oreo Cookies', 1, 75, CAST(N'2019-04-06T20:37:47.667' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (8, N'Pringles', 1, 5, CAST(N'2019-04-06T20:37:47.667' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (9, N'Lays', 1, 3, CAST(N'2019-04-06T20:37:47.667' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (10, N'Snickers', 1, 0, CAST(N'2019-04-06T20:37:47.667' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (11, N'Chicken', 1, 12, CAST(N'2019-04-06T20:53:23.890' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (12, N'Pasta', 1, 35, CAST(N'2019-04-06T21:45:15.530' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (13, N'Froot Loops', 1, 65, CAST(N'2019-04-06T21:56:18.347' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (14, N'Avena', 1, 15, CAST(N'2019-04-06T22:26:41.273' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (15, N'Donuts', 1, 55, CAST(N'2019-04-08T17:45:44.857' AS DateTime), N'rjpazs')
INSERT [dbo].[Products] ([ProductId], [ProductDescription], [ProductEnabled], [ProductStock], [ProductCreationDate], [ProductCreationUser]) VALUES (16, N'Duff Beers', 1, 75, CAST(N'2019-04-08T17:45:45.460' AS DateTime), N'rjpazs')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[ProductsLikes] ON 

INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (1, 13, N'rjpazs', CAST(N'2019-04-06T21:58:43.907' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (3, 13, N'rjpazs', CAST(N'2019-04-09T01:04:24.207' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (4, 13, N'rjpazs', CAST(N'2019-04-09T01:04:27.660' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (5, 1, N'rjpazs', CAST(N'2019-04-09T01:04:31.090' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (6, 1, N'rjpazs', CAST(N'2019-04-09T01:04:33.147' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (7, 2, N'rjpazs', CAST(N'2019-04-09T01:04:35.350' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (8, 10, N'rjpazs', CAST(N'2019-04-09T01:04:39.587' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (9, 5, N'rjpazs', CAST(N'2019-04-09T01:04:41.863' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (10, 13, N'rjpazs', CAST(N'2019-04-09T01:04:45.083' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (11, 1, N'rjpazs', CAST(N'2019-04-09T01:04:47.250' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (12, 3, N'rjpazs', CAST(N'2019-04-09T01:04:49.520' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (13, 5, N'rjpazs', CAST(N'2019-04-09T01:04:51.630' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (14, 6, N'rjpazs', CAST(N'2019-04-09T01:04:59.003' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (15, 7, N'rjpazs', CAST(N'2019-04-09T01:05:02.717' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (16, 8, N'rjpazs', CAST(N'2019-04-09T01:05:05.023' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (17, 13, N'rjpazs', CAST(N'2019-04-09T01:05:08.893' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (18, 10, N'rjpazs', CAST(N'2019-04-09T01:05:11.100' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (19, 12, N'rjpazs', CAST(N'2019-04-09T01:05:14.053' AS DateTime))
INSERT [dbo].[ProductsLikes] ([Id], [ProductId], [User], [Date]) VALUES (20, 15, N'rjpazs', CAST(N'2019-04-09T01:05:17.500' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProductsLikes] OFF
INSERT [dbo].[ProductsOrders] ([OrderId], [ProductId], [Quantity]) VALUES (2, 1, 10)
INSERT [dbo].[ProductsOrders] ([OrderId], [ProductId], [Quantity]) VALUES (3, 1, 10)
INSERT [dbo].[ProductsOrders] ([OrderId], [ProductId], [Quantity]) VALUES (4, 1, 15)
INSERT [dbo].[ProductsOrders] ([OrderId], [ProductId], [Quantity]) VALUES (5, 1, 20)
INSERT [dbo].[ProductsOrders] ([OrderId], [ProductId], [Quantity]) VALUES (5, 2, 5)
INSERT [dbo].[ProductsOrders] ([OrderId], [ProductId], [Quantity]) VALUES (8, 1, 5)
INSERT [dbo].[ProductsOrders] ([OrderId], [ProductId], [Quantity]) VALUES (8, 3, 25)
INSERT [dbo].[ProductsOrders] ([OrderId], [ProductId], [Quantity]) VALUES (8, 4, 10)
SET IDENTITY_INSERT [dbo].[ProductsPrices] ON 

INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (1, 13, CAST(12.50 AS Numeric(19, 2)), CAST(N'2019-04-06T21:58:00.193' AS DateTime), N'rjpazs')
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (2, 13, CAST(17.50 AS Numeric(19, 2)), CAST(N'2019-04-06T21:58:24.810' AS DateTime), N'rjpazs')
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (3, 11, CAST(7.50 AS Numeric(19, 2)), CAST(N'2019-04-07T23:46:43.410' AS DateTime), N'rjpazs')
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (4, 11, CAST(10.50 AS Numeric(19, 2)), CAST(N'2019-04-07T23:48:09.407' AS DateTime), N'rjpazs')
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (5, 11, CAST(10.75 AS Numeric(19, 2)), CAST(N'2019-04-07T23:50:40.700' AS DateTime), N'rjpazs')
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (6, 11, CAST(9.75 AS Numeric(19, 2)), CAST(N'2019-04-08T00:42:32.113' AS DateTime), N'rjpazs')
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (7, 1, CAST(15.00 AS Numeric(19, 2)), CAST(N'2019-04-09T01:18:33.553' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (8, 2, CAST(10.00 AS Numeric(19, 2)), CAST(N'2019-04-09T01:18:35.567' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (9, 3, CAST(5.75 AS Numeric(19, 2)), CAST(N'2019-04-09T01:18:41.027' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (10, 4, CAST(7.50 AS Numeric(19, 2)), CAST(N'2019-04-09T01:18:43.860' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (11, 5, CAST(8.50 AS Numeric(19, 2)), CAST(N'2019-04-09T01:18:46.697' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (12, 6, CAST(10.25 AS Numeric(19, 2)), CAST(N'2019-04-09T01:18:51.110' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (13, 7, CAST(7.75 AS Numeric(19, 2)), CAST(N'2019-04-09T01:18:55.540' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (14, 8, CAST(12.00 AS Numeric(19, 2)), CAST(N'2019-04-09T01:18:58.883' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (15, 9, CAST(1.50 AS Numeric(19, 2)), CAST(N'2019-04-09T01:19:01.780' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (16, 10, CAST(7.25 AS Numeric(19, 2)), CAST(N'2019-04-09T01:19:05.910' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (17, 11, CAST(10.25 AS Numeric(19, 2)), CAST(N'2019-04-09T01:19:10.800' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (18, 12, CAST(7.75 AS Numeric(19, 2)), CAST(N'2019-04-09T01:19:16.570' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (19, 13, CAST(12.50 AS Numeric(19, 2)), CAST(N'2019-04-09T01:19:22.190' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (20, 1, CAST(9.50 AS Numeric(19, 2)), CAST(N'2019-04-09T01:19:26.717' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (21, 3, CAST(4.50 AS Numeric(19, 2)), CAST(N'2019-04-09T01:19:30.563' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (22, 6, CAST(3.50 AS Numeric(19, 2)), CAST(N'2019-04-09T01:19:34.787' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (23, 14, CAST(10.00 AS Numeric(19, 2)), CAST(N'2019-04-09T01:19:56.260' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (24, 15, CAST(7.50 AS Numeric(19, 2)), CAST(N'2019-04-09T01:20:05.570' AS DateTime), NULL)
INSERT [dbo].[ProductsPrices] ([Id], [ProductId], [ProductPrice], [PriceCreationDate], [PriceCreationUser]) VALUES (25, 16, CAST(17.50 AS Numeric(19, 2)), CAST(N'2019-04-09T01:20:09.213' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[ProductsPrices] OFF
SET IDENTITY_INSERT [dbo].[ProductStockHistory] ON 

INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (1, 13, N'STORAGE', NULL, 50, CAST(N'2019-04-06T21:56:18.503' AS DateTime))
INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (2, 13, N'STORAGE', NULL, 65, CAST(N'2019-04-06T21:56:59.047' AS DateTime))
INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (3, 14, N'STORAGE', NULL, 15, CAST(N'2019-04-06T22:26:42.693' AS DateTime))
INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (4, 1, N'PURCHASE', NULL, 40, CAST(N'2019-04-07T00:46:16.760' AS DateTime))
INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (5, 1, N'PURCHASE', NULL, 25, CAST(N'2019-04-07T00:46:53.770' AS DateTime))
INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (6, 1, N'PURCHASE', NULL, 5, CAST(N'2019-04-07T00:50:46.870' AS DateTime))
INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (7, 2, N'PURCHASE', NULL, 45, CAST(N'2019-04-07T00:50:46.943' AS DateTime))
INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (8, 1, N'PURCHASE', NULL, 0, CAST(N'2019-04-07T01:38:15.690' AS DateTime))
INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (9, 3, N'PURCHASE', NULL, 10, CAST(N'2019-04-07T01:38:15.727' AS DateTime))
INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (10, 4, N'PURCHASE', NULL, 10, CAST(N'2019-04-07T01:38:15.753' AS DateTime))
INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (11, 15, N'STORAGE', NULL, 55, CAST(N'2019-04-08T17:45:45.260' AS DateTime))
INSERT [dbo].[ProductStockHistory] ([Id], [ProductId], [TransactionId], [OrderId], [Quantity], [Date]) VALUES (12, 16, N'STORAGE', NULL, 75, CAST(N'2019-04-08T17:45:45.610' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProductStockHistory] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName], [Enabled], [CreationDate]) VALUES (1, N'Admin', 1, CAST(N'2019-04-08T00:29:38.530' AS DateTime))
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Enabled], [CreationDate]) VALUES (2, N'User', 1, CAST(N'2019-04-08T00:29:38.530' AS DateTime))
SET IDENTITY_INSERT [dbo].[Roles] OFF
INSERT [dbo].[Transactions] ([TransactionId], [TransactionDescription], [TransactionEnabled], [TransactionCreationDate], [TransactionCreationUser]) VALUES (N'PURCHASE', N'PRODUCT PURCHASE', 1, CAST(N'2019-04-06T21:49:29.063' AS DateTime), NULL)
INSERT [dbo].[Transactions] ([TransactionId], [TransactionDescription], [TransactionEnabled], [TransactionCreationDate], [TransactionCreationUser]) VALUES (N'STORAGE', N'PRODUCT STORAGE', 1, CAST(N'2019-04-06T21:49:29.063' AS DateTime), NULL)
INSERT [dbo].[Users] ([UserName], [Password], [Enabled], [CreationDate]) VALUES (N'apu', N'e67cce67a1e574929e51b412021d668229643f6171d27bfea0d385d180f8df2e', 1, CAST(N'2019-04-08T00:29:33.537' AS DateTime))
INSERT [dbo].[Users] ([UserName], [Password], [Enabled], [CreationDate]) VALUES (N'rjpazs', N'a20643337873a2a2d62155fe67572cb7b3ec1728a58c6889dfb8da827c22c3e9', 1, CAST(N'2019-04-08T00:29:33.537' AS DateTime))
INSERT [dbo].[Users] ([UserName], [Password], [Enabled], [CreationDate]) VALUES (N'user', N'f5a0134bfcc8cc2a819387bfeffee01f7156ad8c5777c5b98cafac44b361b433', 1, CAST(N'2019-04-08T00:29:33.537' AS DateTime))
SET IDENTITY_INSERT [dbo].[UsersRoles] ON 

INSERT [dbo].[UsersRoles] ([Id], [UserName], [RoleId], [CreationDate]) VALUES (1, N'rjpazs', 1, CAST(N'2019-04-08T00:29:44.387' AS DateTime))
INSERT [dbo].[UsersRoles] ([Id], [UserName], [RoleId], [CreationDate]) VALUES (2, N'apu', 1, CAST(N'2019-04-08T00:29:44.387' AS DateTime))
INSERT [dbo].[UsersRoles] ([Id], [UserName], [RoleId], [CreationDate]) VALUES (3, N'user', 2, CAST(N'2019-04-08T00:29:44.387' AS DateTime))
SET IDENTITY_INSERT [dbo].[UsersRoles] OFF
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (getdate()) FOR [ProductCreationDate]
GO
ALTER TABLE [dbo].[ProductsLikes] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[ProductsPrices] ADD  DEFAULT (getdate()) FOR [PriceCreationDate]
GO
ALTER TABLE [dbo].[ProductStockHistory] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT (getdate()) FOR [TransactionCreationDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[UsersRoles] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[ProductsLikes]  WITH CHECK ADD  CONSTRAINT [FK_ProductsLikes_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[ProductsLikes] CHECK CONSTRAINT [FK_ProductsLikes_Products]
GO
ALTER TABLE [dbo].[ProductsOrders]  WITH CHECK ADD  CONSTRAINT [FK_ProductsOrders_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[ProductsOrders] CHECK CONSTRAINT [FK_ProductsOrders_Orders]
GO
ALTER TABLE [dbo].[ProductsOrders]  WITH CHECK ADD  CONSTRAINT [FK_ProductsOrders_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[ProductsOrders] CHECK CONSTRAINT [FK_ProductsOrders_Products]
GO
ALTER TABLE [dbo].[ProductsPrices]  WITH CHECK ADD  CONSTRAINT [FK_ProductsPrice_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[ProductsPrices] CHECK CONSTRAINT [FK_ProductsPrice_Products]
GO
ALTER TABLE [dbo].[ProductStockHistory]  WITH CHECK ADD  CONSTRAINT [FK_ProductsStockHistory_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[ProductStockHistory] CHECK CONSTRAINT [FK_ProductsStockHistory_Products]
GO
ALTER TABLE [dbo].[ProductStockHistory]  WITH CHECK ADD  CONSTRAINT [FK_ProductsStockHistory_Transactions] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[Transactions] ([TransactionId])
GO
ALTER TABLE [dbo].[ProductStockHistory] CHECK CONSTRAINT [FK_ProductsStockHistory_Transactions]
GO
ALTER TABLE [dbo].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UsersRoles] CHECK CONSTRAINT [FK_UsersRoles_Roles]
GO
ALTER TABLE [dbo].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Users] FOREIGN KEY([UserName])
REFERENCES [dbo].[Users] ([UserName])
GO
ALTER TABLE [dbo].[UsersRoles] CHECK CONSTRAINT [FK_UsersRoles_Users]
GO
/****** Object:  Trigger [dbo].[ProductStockChangeInsUpd]    Script Date: 09/04/2019 08:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   TRIGGER [dbo].[ProductStockChangeInsUpd] ON [dbo].[Products] FOR INSERT,UPDATE

AS
BEGIN

/*
 * OBJECTIVE:	Register a new change on the product stock
 * HISTORY	:	06/04/2019	CREATED BY:	Rafael Paz	
 */

 SET NOCOUNT ON
  
 --Variables
 DECLARE	@NumberError INT,
			@MessageError VARCHAR(255)
			
 DECLARE	@TransactionId	VARCHAR(10),
			@ProductId		INT,
			@ProductStockOld	INT,
			@ProductStockNew INT,
			@OperationType VARCHAR(50)

 IF	EXISTS(	SELECT	TOP(1) 1
			FROM	INSERTED) 
	AND EXISTS(	SELECT	TOP(1) 1
				FROM	DELETED)
 BEGIN
	SET @OperationType = 'UPDATE'
 END
 ELSE
 IF EXISTS(	SELECT	TOP (1) 1
           	FROM	INSERTED)
 BEGIN
 	SET @OperationType = 'INSERT'
 	SET @TransactionId = 'STORAGE'
 END
 
 BEGIN TRAN
 
 IF @OperationType = 'INSERT'
 BEGIN
 	
 	INSERT	INTO [dbo].[ProductStockHistory](ProductId,TransactionId,Quantity)
 	SELECT	i.ProductId,
 			@TransactionId,
 			i.ProductStock
 	FROM	INSERTED AS i
 	
 	IF @@ERROR <> 0
	BEGIN
 		SET @NumberError = 50000
 		SET @MessageError = 'Error on insert history'
 		GOTO ERROR
	END
	
 END
 ELSE
 BEGIN
 	IF @OperationType = 'UPDATE'
 	BEGIN
 		
 		SELECT	@ProductStockNew = i.ProductStock
 		FROM	INSERTED AS i
 		
 		SELECT  @ProductStockOld = d.ProductStock
 		FROM	DELETED AS d
 		
 		IF @ProductStockOld > @ProductStockNew
 			SET @TransactionId = 'PURCHASE'
 		ELSE
 			SET @TransactionId = 'STORAGE'
 			
 		INSERT	INTO [dbo].[ProductStockHistory](ProductId,TransactionId,Quantity)
 		SELECT	i.ProductId,
 				@TransactionId,
 				i.ProductStock
 		FROM	INSERTED AS i
 	
 		IF @@ERROR <> 0
		BEGIN
 			SET @NumberError = 50000
 			SET @MessageError = 'Error on insert history'
 			GOTO ERROR
		END
 	END
 END
 	
 COMMIT TRAN
 RETURN
 
 ERROR:
	IF @@TRANCOUNT <> 0
		ROLLBACK TRAN
	SELECT	@MessageError = @MessageError;
	THROW	@NumberError, @MessageError,1

END
GO
ALTER TABLE [dbo].[Products] ENABLE TRIGGER [ProductStockChangeInsUpd]
GO
/****** Object:  Trigger [dbo].[ProductOrderIns]    Script Date: 09/04/2019 08:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   TRIGGER [dbo].[ProductOrderIns] ON [dbo].[ProductsOrders] FOR INSERT

AS
BEGIN

/*
 * OBJECTIVE:	Register a new change on the product stock
 * HISTORY	:	06/04/2019	CREATED BY :	Rafael Paz
 */
 
 SET NOCOUNT ON

  --Variables
 DECLARE	@NumberError INT,
			@MessageError VARCHAR(255),
			@ProductId	 INT,
			@Quantity    INT
			
 SELECT	@ProductId = i.ProductId,
		@Quantity = i.Quantity
 FROM	INSERTED i
 
 BEGIN TRAN
 
	IF EXISTS(	SELECT	TOP(1) 1
	          	FROM	[dbo].[Products]
	          	WHERE	ProductId = @ProductId
	          	AND		ProductStock < @Quantity
	)
	BEGIN
		SET @NumberError  = 50000
		SET @MessageError = 'We doesnt have that enought quantity of product in our storage'
		GOTO ERROR
	END
		
	UPDATE	[dbo].[Products]
	SET		ProductStock = ProductStock - @Quantity
	WHERE	ProductId = @ProductId
	
	IF @@ERROR <> 0
	BEGIN
		SET @NumberError = 50001
		SET @MessageError = 'Error on updating row'
		GOTO ERROR
	END	

 COMMIT TRAN
 RETURN
 
 ERROR:
	IF @@TRANCOUNT <> 0
		ROLLBACK TRAN
	SELECT	@MessageError = @MessageError;
	THROW	@NumberError, @MessageError,1

END
GO
ALTER TABLE [dbo].[ProductsOrders] ENABLE TRIGGER [ProductOrderIns]
GO
