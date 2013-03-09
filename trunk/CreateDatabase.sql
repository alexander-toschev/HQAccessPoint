USE [master]
GO

/****** Object:  Database [HQAccessPoint.Database]    Script Date: 03/07/2013 14:56:58 ******/
CREATE DATABASE [HQAccessPoint.Database]  
GO

ALTER DATABASE [HQAccessPoint.Database] SET COMPATIBILITY_LEVEL = 100
GO


USE [HQAccessPoint.Database]
GO

/****** Object:  Table [dbo].[Widgets]    Script Date: 03/07/2013 14:57:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Widgets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Metadata] [xml] NULL,
	[ClassName] [nvarchar](200) NULL,
 CONSTRAINT [PK_Widgets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [HQAccessPoint.Database]
GO

/****** Object:  Table [dbo].[Permissions]    Script Date: 03/07/2013 14:57:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Permissions](
	[UserID] [nvarchar](50) NOT NULL,
	[AccessMask] [int] NOT NULL,
	[WidgetID] [int] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[AccessMask] ASC,
	[WidgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Widgets] FOREIGN KEY([WidgetID])
REFERENCES [dbo].[Widgets] ([ID])
GO

ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_Widgets]
GO


