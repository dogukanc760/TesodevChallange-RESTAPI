# TesodevChallange-API
 What is a Rest-API for Challenge made with Net 5.0.
 
 For detailed information about API
You can look at the pdf-word and html files in the ApiDocumentation folder. Related e-mail address: dogukanc760@hotmail.com
Contact Person: Doğukan Canerler
MSSQL 2019 Engine Script for the database I use:


USE [Tesodev]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 10.08.2021 21:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [varchar](50) NOT NULL,
	[CustomerId] [varchar](50) NOT NULL,
	[AdressLine] [varchar](150) NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[CityCode] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 10.08.2021 21:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[PasswordSalt] [varbinary](500) NULL,
	[PasswordHash] [varbinary](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerOperationClaims]    Script Date: 10.08.2021 21:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [varchar](50) NOT NULL,
	[OperationClaimId] [int] NOT NULL,
 CONSTRAINT [PK_CustomerOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 10.08.2021 21:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10.08.2021 21:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [varchar](50) NULL,
	[CustomerId] [varchar](50) NULL,
	[AddressId] [varchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Status] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderContent]    Script Date: 10.08.2021 21:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderContent](
	[Id] [varchar](50) NULL,
	[OrderId] [varchar](50) NULL,
	[ProductId] [varchar](50) NULL,
	[Quantity] [decimal](18, 2) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10.08.2021 21:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [varchar](50) NULL,
	[ImageUrl] [varchar](250) NULL,
	[Name] [varchar](50) NULL,
	[Price] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([Id], [Name], [Email], [CreatedAt], [UpdateAt], [PasswordSalt], [PasswordHash]) VALUES (N'123e4567-e89b-12d3-a456-426655440000', N'Jhon Doe', N'jhondoe@hostname.com', CAST(N'2000-05-05T00:00:00.000' AS DateTime), CAST(N'2021-05-05T00:00:00.000' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[CustomerOperationClaims] ON 
GO
INSERT [dbo].[CustomerOperationClaims] ([Id], [CustomerId], [OperationClaimId]) VALUES (1, N'123e4567-e89b-12d3-a456-426655440000', 1)
GO
INSERT [dbo].[CustomerOperationClaims] ([Id], [CustomerId], [OperationClaimId]) VALUES (2, N'123e4567-e89b-12d3-a456-426655440000', 2)
GO
INSERT [dbo].[CustomerOperationClaims] ([Id], [CustomerId], [OperationClaimId]) VALUES (3, N'123e4567-e89b-12d3-a456-426655440000', 3)
GO
INSERT [dbo].[CustomerOperationClaims] ([Id], [CustomerId], [OperationClaimId]) VALUES (4, N'123e4567-e89b-12d3-a456-426655440000', 4)
GO
INSERT [dbo].[CustomerOperationClaims] ([Id], [CustomerId], [OperationClaimId]) VALUES (5, N'123e4567-e89b-12d3-a456-426655440000', 5)
GO
SET IDENTITY_INSERT [dbo].[CustomerOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'Product.List')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'Product.Update')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (3, N'Product.Delete')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (4, N'Product.Add')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (5, N'Product.Get')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (6, N'Customer.Update')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (7, N'Customer.Delete')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (8, N'Customer.Add')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (9, N'Customer.Get')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (10, N'Customer.GetByMail')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (11, N'Customer.GetAll')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (12, N'Customer.CreateOrder')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (13, N'Customer.UpdateOrder')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (14, N'Customer.DeleteOrder')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (15, N'Customer.GetOrder')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (16, N'Customer.GetOrderListById')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (17, N'Customer.GetList')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (18, N'Customer.ChangeStatus')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (19, N'Content.GetListById')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (20, N'Content.Get')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (21, N'Content.GetList')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (22, N'Content.Add')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (23, N'Content.Update')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (24, N'Content.Delete')
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO

 
 
