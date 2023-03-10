USE [master]
GO
/****** Object:  Database [EnocaChallengeDbContext]    Script Date: 17.01.2023 02:05:44 ******/
CREATE DATABASE [EnocaChallengeDbContext]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EnocaChallengeDbContext', FILENAME = N'/var/opt/mssql/data/EnocaChallengeDbContext.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EnocaChallengeDbContext_log', FILENAME = N'/var/opt/mssql/data/EnocaChallengeDbContext_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EnocaChallengeDbContext] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EnocaChallengeDbContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EnocaChallengeDbContext] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET ARITHABORT OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET RECOVERY FULL 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET  MULTI_USER 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EnocaChallengeDbContext] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EnocaChallengeDbContext] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EnocaChallengeDbContext', N'ON'
GO
ALTER DATABASE [EnocaChallengeDbContext] SET QUERY_STORE = OFF
GO
USE [EnocaChallengeDbContext]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17.01.2023 02:05:45 ******/
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
/****** Object:  Table [dbo].[Firms]    Script Date: 17.01.2023 02:05:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firms](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FirmState] [bit] NOT NULL,
	[OrderStartTime] [datetime2](7) NULL,
	[OrderEndTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Firms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 17.01.2023 02:05:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerName] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[FirmId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 17.01.2023 02:05:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Stock] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[FirmId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_FirmId]    Script Date: 17.01.2023 02:05:45 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_FirmId] ON [dbo].[Orders]
(
	[FirmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_ProductId]    Script Date: 17.01.2023 02:05:45 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_ProductId] ON [dbo].[Orders]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_FirmId]    Script Date: 17.01.2023 02:05:45 ******/
CREATE NONCLUSTERED INDEX [IX_Products_FirmId] ON [dbo].[Products]
(
	[FirmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Firms_FirmId] FOREIGN KEY([FirmId])
REFERENCES [dbo].[Firms] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Firms_FirmId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Firms_FirmId] FOREIGN KEY([FirmId])
REFERENCES [dbo].[Firms] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Firms_FirmId]
GO
USE [master]
GO
ALTER DATABASE [EnocaChallengeDbContext] SET  READ_WRITE 
GO
