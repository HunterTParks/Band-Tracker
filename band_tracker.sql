CREATE DATABASE [band_tracker]
GO
USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 6/20/2017 9:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 6/20/2017 9:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_id] [int] NULL,
	[venue_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venues]    Script Date: 6/20/2017 9:08:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[bands] ON 

INSERT [dbo].[bands] ([id], [name]) VALUES (149, N'NSP')
INSERT [dbo].[bands] ([id], [name]) VALUES (150, N'Mayday Parade')
INSERT [dbo].[bands] ([id], [name]) VALUES (151, N'Bob Dylan')
INSERT [dbo].[bands] ([id], [name]) VALUES (152, N'TEST')
SET IDENTITY_INSERT [dbo].[bands] OFF
SET IDENTITY_INSERT [dbo].[venues] ON 

INSERT [dbo].[venues] ([id], [name]) VALUES (137, N'WallaWalla')
SET IDENTITY_INSERT [dbo].[venues] OFF
