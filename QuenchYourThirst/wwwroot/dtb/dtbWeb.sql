USE [QuenchYourThirst]
GO
/****** Object:  Table [dbo].[flavors]    Script Date: 10/21/2023 8:18:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[flavors](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_flavors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_category]    Script Date: 10/21/2023 8:18:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_category](
	[id] [bigint] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_product_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_images]    Script Date: 10/21/2023 8:18:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_images](
	[id] [bigint] NOT NULL,
	[product_id] [bigint] NOT NULL,
	[url] [text] NOT NULL,
 CONSTRAINT [PK_product_images] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_size_flavors]    Script Date: 10/21/2023 8:18:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_size_flavors](
	[id] [bigint] NOT NULL,
	[product_id] [bigint] NOT NULL,
	[size_id] [bigint] NOT NULL,
	[flavor_id] [bigint] NOT NULL,
	[price] [decimal](20, 3) NOT NULL,
 CONSTRAINT [PK_product_size_flavors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 10/21/2023 8:18:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[status_product_id] [bigint] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[description] [ntext] NULL,
	[quantity] [bigint] NOT NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sizes]    Script Date: 10/21/2023 8:18:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sizes](
	[id] [bigint] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[size] [char](10) NOT NULL,
 CONSTRAINT [PK_sizes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[status_products]    Script Date: 10/21/2023 8:18:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status_products](
	[id] [bigint] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_status_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[flavors] ON 

INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (1, N'Trà sữa trân châu đường đen', N'Trà sữa')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (2, N'Trà sữa matcha', N'Trà sữa')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (3, N'Trà sữa socola', N'Trà sữa')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (4, N'Trà sữa khoai môn', N'Trà sữa')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (5, N'Trà sữa dâu', N'Trà sữa')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (6, N'Cà phê sữa đá', N'Cà phê')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (7, N'Cà phê đen', N'Cà phê')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (8, N'Cà phê bạc xỉu', N'Cà phê')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (9, N'Cà phê mocha', N'Cà phê')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (10, N'Cà phê caramel', N'Cà phê')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (11, N'Nước ép cam', N'Nước ép')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (12, N'Nước ép bưởi', N'Nước ép')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (13, N'Nước ép táo', N'Nước ép')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (14, N'Nước ép nho', N'Nước ép')
INSERT [dbo].[flavors] ([id], [name], [type]) VALUES (15, N'Nước ép cà rốt', N'Nước ép')
SET IDENTITY_INSERT [dbo].[flavors] OFF
GO
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (1, 1, N'https://cdn.ordermo.ph/photos/resto/MLYg69uB/menu/nnsPWmgJ-dQFPTQhk.jpg?v=1603683131089')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (2, 2, N'https://picdn.gomaji.com/products/o/232/255232/255232_3.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (3, 3, N'https://s.yimg.com/bf/tw/ysm/soeasy/pr/businessImg/aom20191230043_14.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (4, 4, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (5, 5, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (6, 6, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (7, 7, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (8, 8, N'https://cdn.ordermo.ph/photos/resto/MLYg69uB/menu/nnsPWmgJ-dQFPTQhk.jpg?v=1603683131089')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (9, 9, N'https://cdn.ordermo.ph/photos/resto/MLYg69uB/menu/nnsPWmgJ-dQFPTQhk.jpg?v=1603683131089')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (10, 10, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (11, 11, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (12, 12, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (13, 13, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (14, 14, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (15, 15, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (16, 16, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (17, 17, N'https://cdn.ordermo.ph/photos/resto/MLYg69uB/menu/nnsPWmgJ-dQFPTQhk.jpg?v=1603683131089')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (18, 18, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (19, 19, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (20, 20, N'https://picdn.gomaji.com/products/o/232/255232/255232_3.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (21, 21, N'https://picdn.gomaji.com/products/o/232/255232/255232_3.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (22, 22, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (23, 23, N'https://cdn.ordermo.ph/photos/resto/MLYg69uB/menu/nnsPWmgJ-dQFPTQhk.jpg?v=1603683131089')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (24, 24, N'https://picdn.gomaji.com/products/o/232/255232/255232_3.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (25, 25, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (26, 26, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (27, 27, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (28, 28, N'https://picdn.gomaji.com/products/o/232/255232/255232_3.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (29, 29, N'https://cdn.ordermo.ph/photos/resto/MLYg69uB/menu/nnsPWmgJ-dQFPTQhk.jpg?v=1603683131089')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (30, 30, N'https://picdn.gomaji.com/products/o/232/255232/255232_3.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (31, 31, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (32, 32, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (33, 33, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (34, 34, N'https://cdn.ordermo.ph/photos/resto/MLYg69uB/menu/nnsPWmgJ-dQFPTQhk.jpg?v=1603683131089')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (35, 35, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (36, 36, N'https://picdn.gomaji.com/products/o/232/255232/255232_3.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (37, 37, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (38, 38, N'https://s.yimg.com/bf/tw/ysm/soeasy/pr/businessImg/aom20191230043_14.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (39, 39, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (40, 40, N'https://cdn.ordermo.ph/photos/resto/MLYg69uB/menu/nnsPWmgJ-dQFPTQhk.jpg?v=1603683131089')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (41, 41, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (42, 42, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (43, 43, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (44, 44, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (45, 45, N'https://i.pinimg.com/originals/6b/9c/bc/6b9cbc331eca2467e01dbd4d3a7027f0.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (46, 46, N'https://s.yimg.com/bf/tw/ysm/soeasy/pr/businessImg/aom20191230043_14.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (47, 47, N'https://s.yimg.com/bf/tw/ysm/soeasy/pr/businessImg/aom20191230043_14.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (48, 48, N'https://picdn.gomaji.com/products/o/232/255232/255232_3.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (49, 49, N'https://abar.vn/wp-content/uploads/2021/05/sua-tuoi-tran-chau-duong-den.jpg')
INSERT [dbo].[product_images] ([id], [product_id], [url]) VALUES (50, 50, N'https://picdn.gomaji.com/products/o/232/255232/255232_3.jpg')
GO
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (1, 1, 1, 4, CAST(44.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (2, 2, 3, 11, CAST(23.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (3, 3, 3, 6, CAST(26.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (4, 4, 3, 1, CAST(47.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (5, 5, 1, 9, CAST(48.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (6, 6, 2, 1, CAST(44.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (7, 7, 2, 7, CAST(18.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (8, 8, 2, 8, CAST(43.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (9, 9, 3, 14, CAST(30.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (10, 10, 1, 5, CAST(35.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (11, 11, 3, 2, CAST(48.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (12, 12, 1, 7, CAST(24.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (13, 13, 1, 15, CAST(27.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (14, 14, 3, 5, CAST(31.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (15, 15, 3, 11, CAST(24.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (16, 16, 3, 4, CAST(28.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (17, 17, 1, 6, CAST(18.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (18, 18, 1, 13, CAST(16.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (19, 19, 1, 9, CAST(14.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (20, 20, 3, 7, CAST(46.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (21, 21, 3, 7, CAST(24.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (22, 22, 3, 7, CAST(35.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (23, 23, 3, 7, CAST(49.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (24, 24, 3, 2, CAST(49.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (25, 25, 2, 10, CAST(24.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (26, 26, 3, 5, CAST(20.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (27, 27, 1, 4, CAST(12.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (28, 28, 2, 10, CAST(42.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (29, 29, 2, 12, CAST(14.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (30, 30, 1, 5, CAST(20.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (31, 31, 2, 12, CAST(10.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (32, 32, 2, 6, CAST(38.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (33, 33, 1, 1, CAST(19.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (34, 34, 2, 3, CAST(47.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (35, 35, 3, 5, CAST(36.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (36, 36, 1, 3, CAST(32.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (37, 37, 3, 11, CAST(12.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (38, 38, 3, 13, CAST(32.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (39, 39, 3, 6, CAST(42.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (40, 40, 2, 1, CAST(14.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (41, 41, 3, 12, CAST(39.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (42, 42, 2, 9, CAST(11.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (43, 43, 1, 3, CAST(45.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (44, 44, 3, 7, CAST(22.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (45, 45, 1, 3, CAST(22.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (46, 46, 3, 1, CAST(20.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (47, 47, 2, 2, CAST(14.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (48, 48, 2, 12, CAST(31.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (49, 49, 3, 2, CAST(14.000 AS Decimal(20, 3)))
INSERT [dbo].[product_size_flavors] ([id], [product_id], [size_id], [flavor_id], [price]) VALUES (50, 50, 3, 4, CAST(25.000 AS Decimal(20, 3)))
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (1, 1, N'Sản phẩm thứ: 1', NULL, 61, CAST(N'2023-10-19T01:22:35.250' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (2, 1, N'Sản phẩm thứ: 2', NULL, 83, CAST(N'2023-10-19T01:22:35.253' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (3, 1, N'Sản phẩm thứ: 3', NULL, 78, CAST(N'2023-10-19T01:22:35.253' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (4, 1, N'Sản phẩm thứ: 4', NULL, 41, CAST(N'2023-10-19T01:22:35.257' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (5, 1, N'Sản phẩm thứ: 5', NULL, 80, CAST(N'2023-10-19T01:22:35.257' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (6, 1, N'Sản phẩm thứ: 6', NULL, 54, CAST(N'2023-10-19T01:22:35.257' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (7, 1, N'Sản phẩm thứ: 7', NULL, 64, CAST(N'2023-10-19T01:22:35.257' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (8, 1, N'Sản phẩm thứ: 8', NULL, 86, CAST(N'2023-10-19T01:22:35.257' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (9, 1, N'Sản phẩm thứ: 9', NULL, 92, CAST(N'2023-10-19T01:22:35.257' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (10, 1, N'Sản phẩm thứ: 10', NULL, 61, CAST(N'2023-10-19T01:22:35.260' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (11, 1, N'Sản phẩm thứ: 11', NULL, 54, CAST(N'2023-10-19T01:22:35.260' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (12, 1, N'Sản phẩm thứ: 12', NULL, 87, CAST(N'2023-10-19T01:22:35.260' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (13, 1, N'Sản phẩm thứ: 13', NULL, 42, CAST(N'2023-10-19T01:22:35.260' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (14, 1, N'Sản phẩm thứ: 14', NULL, 84, CAST(N'2023-10-19T01:22:35.260' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (15, 1, N'Sản phẩm thứ: 15', NULL, 9, CAST(N'2023-10-19T01:22:35.260' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (16, 1, N'Sản phẩm thứ: 16', NULL, 37, CAST(N'2023-10-19T01:22:35.263' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (17, 1, N'Sản phẩm thứ: 17', NULL, 48, CAST(N'2023-10-19T01:22:35.263' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (18, 1, N'Sản phẩm thứ: 18', NULL, 97, CAST(N'2023-10-19T01:22:35.263' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (19, 1, N'Sản phẩm thứ: 19', NULL, 36, CAST(N'2023-10-19T01:22:35.263' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (20, 1, N'Sản phẩm thứ: 20', NULL, 69, CAST(N'2023-10-19T01:22:35.263' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (21, 1, N'Sản phẩm thứ: 21', NULL, 33, CAST(N'2023-10-19T01:22:35.267' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (22, 1, N'Sản phẩm thứ: 22', NULL, 81, CAST(N'2023-10-19T01:22:35.267' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (23, 1, N'Sản phẩm thứ: 23', NULL, 43, CAST(N'2023-10-19T01:22:35.267' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (24, 1, N'Sản phẩm thứ: 24', NULL, 16, CAST(N'2023-10-19T01:22:35.267' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (25, 1, N'Sản phẩm thứ: 25', NULL, 22, CAST(N'2023-10-19T01:22:35.270' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (26, 1, N'Sản phẩm thứ: 26', NULL, 94, CAST(N'2023-10-19T01:22:35.270' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (27, 1, N'Sản phẩm thứ: 27', NULL, 75, CAST(N'2023-10-19T01:22:35.270' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (28, 1, N'Sản phẩm thứ: 28', NULL, 66, CAST(N'2023-10-19T01:22:35.270' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (29, 1, N'Sản phẩm thứ: 29', NULL, 61, CAST(N'2023-10-19T01:22:35.270' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (30, 1, N'Sản phẩm thứ: 30', NULL, 61, CAST(N'2023-10-19T01:22:35.277' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (31, 1, N'Sản phẩm thứ: 31', NULL, 47, CAST(N'2023-10-19T01:22:35.277' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (32, 1, N'Sản phẩm thứ: 32', NULL, 82, CAST(N'2023-10-19T01:22:35.280' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (33, 1, N'Sản phẩm thứ: 33', NULL, 37, CAST(N'2023-10-19T01:22:35.280' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (34, 1, N'Sản phẩm thứ: 34', NULL, 23, CAST(N'2023-10-19T01:22:35.280' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (35, 1, N'Sản phẩm thứ: 35', NULL, 42, CAST(N'2023-10-19T01:22:35.280' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (36, 1, N'Sản phẩm thứ: 36', NULL, 14, CAST(N'2023-10-19T01:22:35.280' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (37, 1, N'Sản phẩm thứ: 37', NULL, 95, CAST(N'2023-10-19T01:22:35.283' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (38, 1, N'Sản phẩm thứ: 38', NULL, 21, CAST(N'2023-10-19T01:22:35.283' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (39, 1, N'Sản phẩm thứ: 39', NULL, 78, CAST(N'2023-10-19T01:22:35.283' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (40, 1, N'Sản phẩm thứ: 40', NULL, 29, CAST(N'2023-10-19T01:22:35.283' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (41, 1, N'Sản phẩm thứ: 41', NULL, 91, CAST(N'2023-10-19T01:22:35.283' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (42, 1, N'Sản phẩm thứ: 42', NULL, 70, CAST(N'2023-10-19T01:22:35.283' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (43, 1, N'Sản phẩm thứ: 43', NULL, 13, CAST(N'2023-10-19T01:22:35.283' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (44, 1, N'Sản phẩm thứ: 44', NULL, 32, CAST(N'2023-10-19T01:22:35.287' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (45, 1, N'Sản phẩm thứ: 45', NULL, 64, CAST(N'2023-10-19T01:22:35.287' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (46, 1, N'Sản phẩm thứ: 46', NULL, 35, CAST(N'2023-10-19T01:22:35.287' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (47, 1, N'Sản phẩm thứ: 47', NULL, 29, CAST(N'2023-10-19T01:22:35.287' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (48, 1, N'Sản phẩm thứ: 48', NULL, 14, CAST(N'2023-10-19T01:22:35.287' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (49, 1, N'Sản phẩm thứ: 49', NULL, 86, CAST(N'2023-10-19T01:22:35.287' AS DateTime))
INSERT [dbo].[products] ([id], [status_product_id], [name], [description], [quantity], [created_at]) VALUES (50, 1, N'Sản phẩm thứ: 50', NULL, 98, CAST(N'2023-10-19T01:21:51.860' AS DateTime))
SET IDENTITY_INSERT [dbo].[products] OFF
GO
INSERT [dbo].[sizes] ([id], [name], [size]) VALUES (1, N'Nhỏ', N'S         ')
INSERT [dbo].[sizes] ([id], [name], [size]) VALUES (2, N'Vừa', N'M         ')
INSERT [dbo].[sizes] ([id], [name], [size]) VALUES (3, N'Large', N'L         ')
GO
INSERT [dbo].[status_products] ([id], [name]) VALUES (1, N'Hoạt động')
INSERT [dbo].[status_products] ([id], [name]) VALUES (2, N'Ẩn')
INSERT [dbo].[status_products] ([id], [name]) VALUES (3, N'Xoá')
GO
ALTER TABLE [dbo].[product_images]  WITH CHECK ADD  CONSTRAINT [FK_product_images_products] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([id])
GO
ALTER TABLE [dbo].[product_images] CHECK CONSTRAINT [FK_product_images_products]
GO
ALTER TABLE [dbo].[product_size_flavors]  WITH CHECK ADD  CONSTRAINT [FK_product_size_flavors_flavors] FOREIGN KEY([flavor_id])
REFERENCES [dbo].[flavors] ([id])
GO
ALTER TABLE [dbo].[product_size_flavors] CHECK CONSTRAINT [FK_product_size_flavors_flavors]
GO
ALTER TABLE [dbo].[product_size_flavors]  WITH CHECK ADD  CONSTRAINT [FK_product_size_flavors_products] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([id])
GO
ALTER TABLE [dbo].[product_size_flavors] CHECK CONSTRAINT [FK_product_size_flavors_products]
GO
ALTER TABLE [dbo].[product_size_flavors]  WITH CHECK ADD  CONSTRAINT [FK_product_size_flavors_sizes] FOREIGN KEY([size_id])
REFERENCES [dbo].[sizes] ([id])
GO
ALTER TABLE [dbo].[product_size_flavors] CHECK CONSTRAINT [FK_product_size_flavors_sizes]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_products_status_products] FOREIGN KEY([status_product_id])
REFERENCES [dbo].[status_products] ([id])
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_products_status_products]
GO
