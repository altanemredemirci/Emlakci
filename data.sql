USE [Emlakci]
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
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (1, N'Levent Lüx Ofis', CAST(2000000.00 AS Decimal(18, 2)), N'property-1.jpg', N'İstanbul', N'Levent', N'123 Sokak No:10', N'Yeni Bina', 3, N'Satılık')
INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (4, N'Zorlu Center', CAST(30000000.00 AS Decimal(18, 2)), N'property-2.jpg', N'İstanbul', N'Etiler', N'Sosyete Sokak.', N'Rezidans', 5, N'Kiralık')
INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (5, N'Sıcak Yuva', CAST(5000000.00 AS Decimal(18, 2)), N'property-3.jpg', N'İstanbul', N'Ümraniye', N'Tantavi Mah. Akın Sok.', N'Metroya yürüme mesafasi', 6, N'Kiralık')
INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (6, N'Dubleks Villa', CAST(30000000.00 AS Decimal(18, 2)), N'property-4.jpg', N'İstanbul', N'Beykoz', N'Acar Kent ', N'Giriş 5000 uçak ring var', 2, N'Satılık')
INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (7, N'Satılık Yazlıık', CAST(1500000.00 AS Decimal(18, 2)), N'property-5.jpg', N'Ankara', N'Mamak', N'Askeri kışlka karşısı ', N'Giriş 5000 uçak ring var', 4, N'Satılık')
INSERT [dbo].[Products] ([Id], [Title], [Price], [CoverImage], [City], [District], [Address], [Description], [CategoryId], [Type]) VALUES (8, N'Satılık Sıfır Daire', CAST(3000000.00 AS Decimal(18, 2)), N'property-7.jpg', N'İzmir', N'Konak', N'Saat Kulesi sokak', N'Saat kulesini arkana ver 150 metre sonra', 1, N'Satılık')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240330084759_CreateDatabase', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240407074621_AddEmploymentandWhoWeAre', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240407092546_AddTypeToProductTable', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240420073431_UpdateCategory', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240420084638_AddingAgency', N'8.0.3')
GO
SET IDENTITY_INSERT [dbo].[Agencies] ON 

INSERT [dbo].[Agencies] ([Id], [FullName], [Title], [Image], [SocialOne], [SocialTwo], [SocialThree]) VALUES (1, N'Altan Emre', N'Profession', N'team-2.jpg', N'https://www.facebook.com', N'https://www.x.com', N'https://www.instagram')
INSERT [dbo].[Agencies] ([Id], [FullName], [Title], [Image], [SocialOne], [SocialTwo], [SocialThree]) VALUES (2, N'Alper Dan', N'Profession', N'team-4.jpg', N'https://www.facebook.com', N'https://www.x.com', N'https://www.instagram')
INSERT [dbo].[Agencies] ([Id], [FullName], [Title], [Image], [SocialOne], [SocialTwo], [SocialThree]) VALUES (3, N'Şeyma Hacıosmanoğlu', N'Profession', N'team-3.jpg', N'https://www.facebook.com', N'https://www.x.com', N'https://www.instagram')
INSERT [dbo].[Agencies] ([Id], [FullName], [Title], [Image], [SocialOne], [SocialTwo], [SocialThree]) VALUES (4, N'Sudenaz Say', N'Profession', N'team-1.jpg', N'https://www.facebook.com', N'https://www.x.com', N'https://www.instagram')
SET IDENTITY_INSERT [dbo].[Agencies] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([Id], [Title], [Name], [Comment]) VALUES (1, N'Profession', N'Altan Emre', N'Çok memnun kaldım')
INSERT [dbo].[Clients] ([Id], [Title], [Name], [Comment]) VALUES (2, N'Profession', N'Alper Dan', N'Emlak dediğin budur.')
INSERT [dbo].[Clients] ([Id], [Title], [Name], [Comment]) VALUES (3, N'Profession', N'Eray Koç', N'Motorum için sıcak bir yuva.')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Employments] ON 

INSERT [dbo].[Employments] ([Id], [Name], [Status]) VALUES (1, N'Emlak Danışmalığı', 1)
INSERT [dbo].[Employments] ([Id], [Name], [Status]) VALUES (2, N'Yatırımlık Arsa', 1)
INSERT [dbo].[Employments] ([Id], [Name], [Status]) VALUES (3, N'Kentsel Dönüşüm', 1)
INSERT [dbo].[Employments] ([Id], [Name], [Status]) VALUES (5, N'İç Mimarrlık', 0)
SET IDENTITY_INSERT [dbo].[Employments] OFF
GO
SET IDENTITY_INSERT [dbo].[WhoWeAres] ON 

INSERT [dbo].[WhoWeAres] ([Id], [Title], [Description]) VALUES (1, N'#1 Emlak Sektöründe Yılların Deneyimi ve Yatırım Danışmalığında Öncü Firma', N'Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit. Aliqu diam amet diam et eos. Clita erat ipsum et lorem et sit, sed stet lorem sit clita duo justo magna dolore erat amet')
SET IDENTITY_INSERT [dbo].[WhoWeAres] OFF
GO
