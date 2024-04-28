USE [master]
GO
/****** Object:  Database [Emlakci]    Script Date: 28.04.2024 12:33:00 ******/
CREATE DATABASE [Emlakci]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Emlakci', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLDERS\MSSQL\DATA\Emlakci.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Emlakci_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLDERS\MSSQL\DATA\Emlakci_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Emlakci] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Emlakci].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Emlakci] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Emlakci] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Emlakci] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Emlakci] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Emlakci] SET ARITHABORT OFF 
GO
ALTER DATABASE [Emlakci] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Emlakci] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Emlakci] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Emlakci] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Emlakci] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Emlakci] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Emlakci] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Emlakci] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Emlakci] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Emlakci] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Emlakci] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Emlakci] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Emlakci] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Emlakci] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Emlakci] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Emlakci] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Emlakci] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Emlakci] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Emlakci] SET  MULTI_USER 
GO
ALTER DATABASE [Emlakci] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Emlakci] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Emlakci] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Emlakci] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Emlakci] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Emlakci] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Emlakci] SET QUERY_STORE = OFF
GO
USE [Emlakci]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 28.04.2024 12:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agencies]    Script Date: 28.04.2024 12:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](70) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](70) NOT NULL,
	[SocialOne] [nvarchar](150) NOT NULL,
	[SocialTwo] [nvarchar](150) NOT NULL,
	[SocialThree] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Agencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 28.04.2024 12:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[Icon] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 28.04.2024 12:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Comment] [nvarchar](2000) NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 28.04.2024 12:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Subject] [nvarchar](100) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 28.04.2024 12:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](100) NOT NULL,
	[Status] [bit] NOT NULL,
	[ImageUrl] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employments]    Script Date: 28.04.2024 12:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Employments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetails]    Script Date: 28.04.2024 12:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Size] [int] NOT NULL,
	[BathCount] [tinyint] NOT NULL,
	[BedRoomCount] [tinyint] NOT NULL,
	[RoomCount] [tinyint] NOT NULL,
	[GarageSize] [tinyint] NOT NULL,
	[BuildYear] [nvarchar](4) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Location] [nvarchar](500) NOT NULL,
	[VideoUrl] [nvarchar](500) NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_ProductDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 28.04.2024 12:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CoverImage] [nvarchar](250) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[District] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Type] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WhoWeAres]    Script Date: 28.04.2024 12:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WhoWeAres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_WhoWeAres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240330084759_CreateDatabase', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240407074621_AddEmploymentandWhoWeAre', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240407092546_AddTypeToProductTable', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240420073431_UpdateCategory', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240420084638_AddingAgency', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240421084837_UpdateClient', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240421091528_AddindContcat', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240427072151_ClientImage', N'8.0.3')
GO
SET IDENTITY_INSERT [dbo].[Agencies] ON 

INSERT [dbo].[Agencies] ([Id], [FullName], [Title], [Image], [SocialOne], [SocialTwo], [SocialThree]) VALUES (1, N'Altan Emre', N'Profession', N'team-2.jpg', N'https://www.facebook.com', N'https://www.x.com', N'https://www.instagram')
INSERT [dbo].[Agencies] ([Id], [FullName], [Title], [Image], [SocialOne], [SocialTwo], [SocialThree]) VALUES (2, N'Alper Dan', N'Profession', N'team-4.jpg', N'https://www.facebook.com', N'https://www.x.com', N'https://www.instagram')
INSERT [dbo].[Agencies] ([Id], [FullName], [Title], [Image], [SocialOne], [SocialTwo], [SocialThree]) VALUES (3, N'Şeyma Hacıosmanoğlu', N'Profession', N'team-3.jpg', N'https://www.facebook.com', N'https://www.x.com', N'https://www.instagram')
INSERT [dbo].[Agencies] ([Id], [FullName], [Title], [Image], [SocialOne], [SocialTwo], [SocialThree]) VALUES (4, N'Sudenaz Say', N'Profession', N'team-1.jpg', N'https://www.facebook.com', N'https://www.x.com', N'https://www.instagram')
SET IDENTITY_INSERT [dbo].[Agencies] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Status], [Icon]) VALUES (1, N'Daire', 1, N'icon-apartment.png')
INSERT [dbo].[Categories] ([Id], [Name], [Status], [Icon]) VALUES (2, N'Villa', 1, N'icon-villa.png')
INSERT [dbo].[Categories] ([Id], [Name], [Status], [Icon]) VALUES (3, N'Ofis', 1, N'icon-condominium.png')
INSERT [dbo].[Categories] ([Id], [Name], [Status], [Icon]) VALUES (4, N'Yazlık', 1, N'icon-building.png')
INSERT [dbo].[Categories] ([Id], [Name], [Status], [Icon]) VALUES (5, N'Dükkan', 1, N'icon-house.png')
INSERT [dbo].[Categories] ([Id], [Name], [Status], [Icon]) VALUES (6, N'Köy Evi', 1, N'icon-housing.png')
INSERT [dbo].[Categories] ([Id], [Name], [Status], [Icon]) VALUES (7, N'Bungalov', 1, N'icon-luxury.png')
INSERT [dbo].[Categories] ([Id], [Name], [Status], [Icon]) VALUES (8, N'Depo', 1, N'icon-neighborhood.png')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([Id], [Title], [Name], [Comment], [ImageUrl]) VALUES (3, N'Profession', N'Muhammed KRANDA', N'Çok güzel bir ev.', N'testimonial-1.jpg')
INSERT [dbo].[Clients] ([Id], [Title], [Name], [Comment], [ImageUrl]) VALUES (4, N'Profession', N'Alper DAN', N'Köpeklerimle sıcak bir yuva.', N'testimonial-4.jpg')
INSERT [dbo].[Clients] ([Id], [Title], [Name], [Comment], [ImageUrl]) VALUES (5, N'Profession', N'Şeyma Hacıosmanoğlu', N'Beşiktaş 0+1 daire', N'testimonial-3.jpg')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Employments] ON 

INSERT [dbo].[Employments] ([Id], [Name], [Status]) VALUES (1, N'Emlak Danışmalığı', 1)
INSERT [dbo].[Employments] ([Id], [Name], [Status]) VALUES (2, N'Yatırımlık Arsa', 1)
INSERT [dbo].[Employments] ([Id], [Name], [Status]) VALUES (3, N'Kentsel Dönüşüm', 1)
INSERT [dbo].[Employments] ([Id], [Name], [Status]) VALUES (5, N'İç Mimarrlık', 0)
SET IDENTITY_INSERT [dbo].[Employments] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (1, N'Levent Lüx Ofis', CAST(2000000.00 AS Decimal(18, 2)), N'property-1.jpg', N'İstanbul', N'Levent', N'123 Sokak No:10', N'Yeni Bina', 3, N'Satılık')
INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (4, N'Zorlu Center', CAST(30000000.00 AS Decimal(18, 2)), N'property-2.jpg', N'İstanbul', N'Etiler', N'Sosyete Sokak.', N'Rezidans', 5, N'Kiralık')
INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (5, N'Sıcak Yuva', CAST(5000000.00 AS Decimal(18, 2)), N'property-3.jpg', N'İstanbul', N'Ümraniye', N'Tantavi Mah. Akın Sok.', N'Metroya yürüme mesafasi', 6, N'Kiralık')
INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (6, N'Dubleks Villa', CAST(30000000.00 AS Decimal(18, 2)), N'property-4.jpg', N'İstanbul', N'Beykoz', N'Acar Kent ', N'Giriş 5000 uçak ring var', 2, N'Satılık')
INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (7, N'Satılık Yazlıık', CAST(1500000.00 AS Decimal(18, 2)), N'property-5.jpg', N'Ankara', N'Mamak', N'Askeri kışlka karşısı ', N'Giriş 5000 uçak ring var', 4, N'Satılık')
INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (8, N'Satılık Sıfır Daire', CAST(3000000.00 AS Decimal(18, 2)), N'property-7.jpg', N'İzmir', N'Konak', N'Saat Kulesi sokak', N'Saat kulesini arkana ver 150 metre sonra', 1, N'Satılık')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[WhoWeAres] ON 

INSERT [dbo].[WhoWeAres] ([Id], [Title], [Description]) VALUES (1, N'#1 Emlak Sektöründe Yılların Deneyimi ve Yatırım Danışmalığında Öncü Firma', N'Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit. Aliqu diam amet diam et eos. Clita erat ipsum et lorem et sit, sed stet lorem sit clita duo justo magna dolore erat amet')
SET IDENTITY_INSERT [dbo].[WhoWeAres] OFF
GO
/****** Object:  Index [IX_ProductDetails_ProductId]    Script Date: 28.04.2024 12:33:00 ******/
CREATE NONCLUSTERED INDEX [IX_ProductDetails_ProductId] ON [dbo].[ProductDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 28.04.2024 12:33:00 ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clients] ADD  DEFAULT (N'') FOR [ImageUrl]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [Type]
GO
ALTER TABLE [dbo].[ProductDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductDetails] CHECK CONSTRAINT [FK_ProductDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [Emlakci] SET  READ_WRITE 
GO
