USE [master]
GO
/****** Object:  Database [HalıSaha]    Script Date: 20.12.2019 10:38:10 ******/
CREATE DATABASE [HalıSaha]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HalıSaha', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\HalıSaha.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HalıSaha_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\HalıSaha_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HalıSaha] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HalıSaha].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HalıSaha] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HalıSaha] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HalıSaha] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HalıSaha] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HalıSaha] SET ARITHABORT OFF 
GO
ALTER DATABASE [HalıSaha] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HalıSaha] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HalıSaha] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HalıSaha] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HalıSaha] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HalıSaha] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HalıSaha] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HalıSaha] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HalıSaha] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HalıSaha] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HalıSaha] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HalıSaha] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HalıSaha] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HalıSaha] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HalıSaha] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HalıSaha] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HalıSaha] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HalıSaha] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HalıSaha] SET  MULTI_USER 
GO
ALTER DATABASE [HalıSaha] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HalıSaha] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HalıSaha] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HalıSaha] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HalıSaha] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HalıSaha', N'ON'
GO
ALTER DATABASE [HalıSaha] SET QUERY_STORE = OFF
GO
USE [HalıSaha]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [HalıSaha]
GO
/****** Object:  Table [dbo].[KiralanmışSahaTablo]    Script Date: 20.12.2019 10:38:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KiralanmışSahaTablo](
	[KSID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NULL,
	[SahaID] [int] NULL,
	[Tarih] [datetime] NULL,
	[SaatBaslangic] [int] NULL,
	[SemtID] [int] NULL,
 CONSTRAINT [PK_KiralanmışSahaTablo] PRIMARY KEY CLUSTERED 
(
	[KSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KullaniciGirisTablo]    Script Date: 20.12.2019 10:38:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KullaniciGirisTablo](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [nvarchar](20) NULL,
	[KullaniciSifre] [nvarchar](20) NULL,
	[KullaniciTipi] [bit] NULL,
 CONSTRAINT [PK_KullaniciGirisTablo] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MevkiTablo]    Script Date: 20.12.2019 10:38:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MevkiTablo](
	[MevkiID] [int] IDENTITY(1,1) NOT NULL,
	[Mevki] [nvarchar](20) NULL,
 CONSTRAINT [PK_MevkiTablo] PRIMARY KEY CLUSTERED 
(
	[MevkiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OyuncuTablo]    Script Date: 20.12.2019 10:38:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OyuncuTablo](
	[OyuncuID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NULL,
	[OyuncuAdi] [nvarchar](50) NOT NULL,
	[OyuncuSoyadi] [nvarchar](50) NOT NULL,
	[MevkiID] [int] NOT NULL,
	[OyuncuTelefon] [nvarchar](11) NOT NULL,
	[Durum] [bit] NOT NULL,
	[OyuncuSilmedurum] [bit] NULL,
	[SahaID] [int] NOT NULL,
	[Tarih] [datetime] NULL,
	[MacSaati] [int] NULL,
 CONSTRAINT [PK_OyuncuTablo] PRIMARY KEY CLUSTERED 
(
	[OyuncuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SahaTablo]    Script Date: 20.12.2019 10:38:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SahaTablo](
	[SahaID] [int] IDENTITY(1,1) NOT NULL,
	[SahaAdi] [nvarchar](50) NOT NULL,
	[SemtID] [int] NOT NULL,
	[Telefon] [nchar](11) NOT NULL,
	[Adres] [nvarchar](50) NOT NULL,
	[SahaSilmeDurum] [bit] NOT NULL,
 CONSTRAINT [PK_Sahalar] PRIMARY KEY CLUSTERED 
(
	[SahaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SemtTablo]    Script Date: 20.12.2019 10:38:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SemtTablo](
	[SemtID] [int] IDENTITY(1,1) NOT NULL,
	[SemtAdi] [nvarchar](50) NULL,
 CONSTRAINT [PK_SemtTablo] PRIMARY KEY CLUSTERED 
(
	[SemtID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TakımTablo]    Script Date: 20.12.2019 10:38:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TakımTablo](
	[TakımID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NULL,
	[TakımAdı] [nvarchar](50) NOT NULL,
	[Telefon] [nvarchar](11) NOT NULL,
	[SemtID] [int] NOT NULL,
	[TakımDurum] [bit] NOT NULL,
	[Tarih] [datetime] NULL,
	[TakımSilmedurum] [bit] NOT NULL,
	[SahaID] [int] NOT NULL,
	[MacSaati] [int] NULL,
 CONSTRAINT [PK_TakımTablo] PRIMARY KEY CLUSTERED 
(
	[TakımID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[KiralanmışSahaTablo] ON 

INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (1, NULL, 1, NULL, 0, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (2, NULL, 1, NULL, 1, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (3, NULL, 1, NULL, 2, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (4, NULL, 1, NULL, 3, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (5, NULL, 1, NULL, 4, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (6, NULL, 1, NULL, 5, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (7, NULL, 1, NULL, 6, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (8, NULL, 1, NULL, 7, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (9, NULL, 1, NULL, 8, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (10, NULL, 1, NULL, 9, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (11, NULL, 1, NULL, 10, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (12, NULL, 1, NULL, 11, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (13, NULL, 1, NULL, 12, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (14, NULL, 1, NULL, 13, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (15, NULL, 1, NULL, 14, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (16, NULL, 1, NULL, 15, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (17, NULL, 1, NULL, 16, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (18, NULL, 1, NULL, 17, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (19, NULL, 1, NULL, 18, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (20, NULL, 1, NULL, 19, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (21, NULL, 1, NULL, 20, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (22, NULL, 1, NULL, 21, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (23, NULL, 1, NULL, 22, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (24, NULL, 1, NULL, 23, 1)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (25, NULL, 12, NULL, 0, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (26, NULL, 12, NULL, 1, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (27, NULL, 12, NULL, 2, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (28, NULL, 12, NULL, 3, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (29, NULL, 12, NULL, 4, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (30, NULL, 12, NULL, 5, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (31, NULL, 12, NULL, 6, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (32, NULL, 12, NULL, 7, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (33, NULL, 12, NULL, 8, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (34, NULL, 12, NULL, 9, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (35, NULL, 12, NULL, 10, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (36, NULL, 12, NULL, 11, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (37, NULL, 12, NULL, 12, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (38, NULL, 12, NULL, 13, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (39, NULL, 12, NULL, 14, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (40, NULL, 12, NULL, 15, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (41, NULL, 12, NULL, 16, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (42, NULL, 12, NULL, 17, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (43, NULL, 12, NULL, 18, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (44, NULL, 12, NULL, 19, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (45, NULL, 12, NULL, 20, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (46, NULL, 12, NULL, 21, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (47, NULL, 12, NULL, 22, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (48, NULL, 12, NULL, 23, 4)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (49, NULL, 13, NULL, 0, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (50, NULL, 13, NULL, 1, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (51, NULL, 13, NULL, 2, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (52, NULL, 13, NULL, 3, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (53, NULL, 13, NULL, 4, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (54, NULL, 13, NULL, 5, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (55, NULL, 13, NULL, 6, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (56, NULL, 13, NULL, 7, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (57, NULL, 13, NULL, 8, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (58, NULL, 13, NULL, 9, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (59, NULL, 13, NULL, 10, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (60, NULL, 13, NULL, 11, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (61, NULL, 13, NULL, 12, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (62, NULL, 13, NULL, 13, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (63, NULL, 13, NULL, 14, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (64, NULL, 13, NULL, 15, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (65, NULL, 13, NULL, 16, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (66, NULL, 13, NULL, 17, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (67, NULL, 13, NULL, 18, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (68, NULL, 13, NULL, 19, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (69, NULL, 13, NULL, 20, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (70, NULL, 13, NULL, 21, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (71, NULL, 13, NULL, 22, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (72, NULL, 13, NULL, 23, 2)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (73, NULL, 14, NULL, 0, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (74, NULL, 14, NULL, 1, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (75, NULL, 14, NULL, 2, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (76, NULL, 14, NULL, 3, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (77, NULL, 14, NULL, 4, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (78, NULL, 14, NULL, 5, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (79, NULL, 14, NULL, 6, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (80, NULL, 14, NULL, 7, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (81, NULL, 14, NULL, 8, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (82, NULL, 14, NULL, 9, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (83, NULL, 14, NULL, 10, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (84, NULL, 14, NULL, 11, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (85, NULL, 14, NULL, 12, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (86, NULL, 14, NULL, 13, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (87, NULL, 14, NULL, 14, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (88, NULL, 14, NULL, 15, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (89, NULL, 14, NULL, 16, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (90, NULL, 14, NULL, 17, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (91, NULL, 14, NULL, 18, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (92, NULL, 14, NULL, 19, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (93, NULL, 14, NULL, 20, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (94, NULL, 14, NULL, 21, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (95, NULL, 14, NULL, 22, 3)
INSERT [dbo].[KiralanmışSahaTablo] ([KSID], [KullaniciID], [SahaID], [Tarih], [SaatBaslangic], [SemtID]) VALUES (96, NULL, 14, NULL, 23, 3)
SET IDENTITY_INSERT [dbo].[KiralanmışSahaTablo] OFF
SET IDENTITY_INSERT [dbo].[KullaniciGirisTablo] ON 

INSERT [dbo].[KullaniciGirisTablo] ([KullaniciID], [KullaniciAdi], [KullaniciSifre], [KullaniciTipi]) VALUES (1, N'butkan', N'12345', 1)
INSERT [dbo].[KullaniciGirisTablo] ([KullaniciID], [KullaniciAdi], [KullaniciSifre], [KullaniciTipi]) VALUES (2, N'nuru', N'1234', 0)
INSERT [dbo].[KullaniciGirisTablo] ([KullaniciID], [KullaniciAdi], [KullaniciSifre], [KullaniciTipi]) VALUES (3, N'ayberk', N'1234', 0)
INSERT [dbo].[KullaniciGirisTablo] ([KullaniciID], [KullaniciAdi], [KullaniciSifre], [KullaniciTipi]) VALUES (12, N'kadir', N'1234', 0)
SET IDENTITY_INSERT [dbo].[KullaniciGirisTablo] OFF
SET IDENTITY_INSERT [dbo].[MevkiTablo] ON 

INSERT [dbo].[MevkiTablo] ([MevkiID], [Mevki]) VALUES (1, N'Kaleci')
INSERT [dbo].[MevkiTablo] ([MevkiID], [Mevki]) VALUES (2, N'Defans')
INSERT [dbo].[MevkiTablo] ([MevkiID], [Mevki]) VALUES (3, N'Orta Saha')
INSERT [dbo].[MevkiTablo] ([MevkiID], [Mevki]) VALUES (4, N'Forvet')
SET IDENTITY_INSERT [dbo].[MevkiTablo] OFF
SET IDENTITY_INSERT [dbo].[OyuncuTablo] ON 

INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (1, NULL, N'İlker', N'İspir', 2, N'05361236498', 1, 1, 1, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (2, NULL, N'Oğuzhan', N'Sakallı', 1, N'080077887', 1, 1, 1, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (3, NULL, N'Lionel', N'Messi', 4, N'0536589', 1, 1, 12, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (4, NULL, N'Cristiano', N'Ronaldo', 4, N'05365899', 1, 1, 12, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (5, NULL, N'Hernandez', N'Xavi', 3, N'05365899', 1, 1, 12, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (6, NULL, N'Andress', N'Iniesta', 3, N'05365899', 1, 1, 12, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (7, NULL, N'Fabiano', N'Cannavaro', 2, N'05365899', 1, 1, 12, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (8, NULL, N'Carles', N'Puyol', 2, N'05365899', 1, 1, 12, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (9, NULL, N'Iker', N'Casillas', 1, N'05365899', 1, 1, 12, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (10, NULL, N'Manuel', N'Neuer', 1, N'05365899', 1, 1, 12, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (11, NULL, N'Gianluigi ', N'Buffon', 1, N'05365899', 1, 1, 14, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (12, NULL, N'Fernando', N'Muslera', 1, N'05365899', 1, 1, 14, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (13, NULL, N'Rio', N'Ferdinand', 2, N'05365899', 1, 1, 14, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (14, NULL, N'David', N'Luis', 2, N'05365899', 1, 1, 14, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (15, NULL, N'Kevin', N'De Bruyne', 3, N'05365899', 1, 1, 14, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (16, NULL, N'Eden', N'Hazard', 3, N'05365899', 1, 1, 14, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (17, NULL, N'Luis', N'Suarez', 4, N'05365899', 1, 1, 14, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (18, NULL, N'Robert', N'Lewandowski', 4, N'05365899', 1, 1, 14, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (19, NULL, N'Hugo', N'Lloris', 1, N'05365899', 1, 1, 5, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (20, NULL, N'Petr', N'Cech', 1, N'05365899', 1, 1, 5, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (21, NULL, N'Gerard', N'Pique', 2, N'05365899', 1, 1, 5, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (22, NULL, N'Lilian', N'Thuram', 2, N'05365899', 1, 1, 5, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (23, NULL, N'David', N'Silva', 3, N'05365899', 1, 1, 5, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (24, NULL, N'Paul', N'Pogba', 3, N'05365899', 1, 1, 5, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (25, NULL, N'Wayne', N'Rooney', 4, N'05365899', 1, 1, 5, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (26, NULL, N'David', N'Villa', 4, N'05365899', 1, 1, 5, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (27, NULL, N'Marc', N'Ter Stegen', 1, N'05365899', 1, 1, 13, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (28, NULL, N'Javier', N'Zanetti', 2, N'05365899', 1, 1, 13, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (29, NULL, N'Mesut', N'Özil', 3, N'05365899', 1, 1, 13, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (30, NULL, N'Carlos', N'Tevez', 4, N'05365899', 1, 1, 13, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (31, NULL, N'Keylor', N'Navas', 1, N'05365899', 1, 1, 13, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (32, NULL, N'Philipp', N'Lahm', 2, N'05365899', 1, 1, 13, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (33, NULL, N'Steven', N'Gerrard', 3, N'05365899', 1, 1, 13, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (34, NULL, N'Didier', N'Drogba', 4, N'05365899', 1, 1, 13, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (35, NULL, N'Bernd', N'Leno', 1, N'05365899', 1, 1, 9, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (36, NULL, N'Roberto', N'Carlos', 2, N'05365899', 1, 1, 9, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (37, NULL, N'Raheem', N'Sterling', 3, N'05365899', 1, 1, 9, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (38, NULL, N'Radamel', N'Falcao', 4, N'05365899', 1, 1, 9, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (39, NULL, N'Joe', N'Hart', 1, N'05365899', 1, 1, 1, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (40, NULL, N'John', N'Terry', 2, N'05365899', 1, 1, 1, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (41, NULL, N'Zinedine', N'Zidane', 4, N'05365899', 1, 1, 1, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (42, NULL, N'Edinson', N'Cavani', 4, N'05365899', 1, 1, 1, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (43, NULL, N'Mahmut', N'Yanar', 1, N'05369895', 1, 1, 1, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (44, NULL, N'Mehmet', N'Çolak', 2, N'05369895', 1, 1, 11, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (45, NULL, N'Seyfi', N'Sami', 3, N'05369895', 1, 1, 11, NULL, NULL)
INSERT [dbo].[OyuncuTablo] ([OyuncuID], [KullaniciID], [OyuncuAdi], [OyuncuSoyadi], [MevkiID], [OyuncuTelefon], [Durum], [OyuncuSilmedurum], [SahaID], [Tarih], [MacSaati]) VALUES (46, NULL, N'Ali', N'Tataroğlu', 4, N'05369895', 1, 1, 11, NULL, NULL)
SET IDENTITY_INSERT [dbo].[OyuncuTablo] OFF
SET IDENTITY_INSERT [dbo].[SahaTablo] ON 

INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (1, N'Ay Işığı', 1, N'053678914  ', N'Maltepede bir yerlerde', 1)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (2, N'Aydınoğlu', 1, N'053658712  ', N'E-5 in yanı', 0)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (4, N'Bostancı Spor Klübü', 3, N'05364849   ', N'Bostancı Merkez', 0)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (5, N'Clup Sporium', 3, N'0536215684 ', N'Bostancıda bir yer', 0)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (6, N'Kılıç Spor Tesisleri', 3, N'0536215687 ', N'Bostancıda bir yer', 0)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (7, N'Aydınoğlu Halı Saha', 3, N'0536215687 ', N'Bostancıda bir yer', 0)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (8, N'Maltepe Spor Tesisi', 1, N'0536215687 ', N'Maltepede bir yer', 0)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (9, N'Moda Halı Saha', 4, N'0536215687 ', N'Caferağa ', 0)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (10, N'Kalamış Halı Saha', 4, N'0536215687 ', N'Fenerbahçe', 0)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (11, N'Küçükyalı Spor Klübü', 2, N'05368962145', N'Minübüs Yolu Üstü', 0)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (12, N'Şükrü Saraçoğlu', 4, N'05365816242', N'Söğütlüçeşme', 1)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (13, N'Küçükyalı Yelken', 2, N'05945662894', N'Minübüs yolu üstü', 1)
INSERT [dbo].[SahaTablo] ([SahaID], [SahaAdi], [SemtID], [Telefon], [Adres], [SahaSilmeDurum]) VALUES (14, N'Clup Sporium', 3, N'05945662894', N'e5 in yani', 1)
SET IDENTITY_INSERT [dbo].[SahaTablo] OFF
SET IDENTITY_INSERT [dbo].[SemtTablo] ON 

INSERT [dbo].[SemtTablo] ([SemtID], [SemtAdi]) VALUES (1, N'Maltepe')
INSERT [dbo].[SemtTablo] ([SemtID], [SemtAdi]) VALUES (2, N'Küçükyalı')
INSERT [dbo].[SemtTablo] ([SemtID], [SemtAdi]) VALUES (3, N'Bostancı')
INSERT [dbo].[SemtTablo] ([SemtID], [SemtAdi]) VALUES (4, N'Kadıköy')
SET IDENTITY_INSERT [dbo].[SemtTablo] OFF
SET IDENTITY_INSERT [dbo].[TakımTablo] ON 

INSERT [dbo].[TakımTablo] ([TakımID], [KullaniciID], [TakımAdı], [Telefon], [SemtID], [TakımDurum], [Tarih], [TakımSilmedurum], [SahaID], [MacSaati]) VALUES (1, NULL, N'CanavarSpor', N'05365989', 1, 1, NULL, 1, 1, NULL)
INSERT [dbo].[TakımTablo] ([TakımID], [KullaniciID], [TakımAdı], [Telefon], [SemtID], [TakımDurum], [Tarih], [TakımSilmedurum], [SahaID], [MacSaati]) VALUES (2, NULL, N'MaltepeSpor', N'05139416', 1, 1, NULL, 1, 2, NULL)
INSERT [dbo].[TakımTablo] ([TakımID], [KullaniciID], [TakımAdı], [Telefon], [SemtID], [TakımDurum], [Tarih], [TakımSilmedurum], [SahaID], [MacSaati]) VALUES (3, NULL, N'FutbolGücü', N'05361247899', 2, 1, NULL, 1, 2, NULL)
INSERT [dbo].[TakımTablo] ([TakımID], [KullaniciID], [TakımAdı], [Telefon], [SemtID], [TakımDurum], [Tarih], [TakımSilmedurum], [SahaID], [MacSaati]) VALUES (4, NULL, N'A Takımı', N'053689654', 2, 1, NULL, 1, 2, NULL)
INSERT [dbo].[TakımTablo] ([TakımID], [KullaniciID], [TakımAdı], [Telefon], [SemtID], [TakımDurum], [Tarih], [TakımSilmedurum], [SahaID], [MacSaati]) VALUES (5, NULL, N'Delispor', N'0536984525', 2, 1, NULL, 1, 11, NULL)
INSERT [dbo].[TakımTablo] ([TakımID], [KullaniciID], [TakımAdı], [Telefon], [SemtID], [TakımDurum], [Tarih], [TakımSilmedurum], [SahaID], [MacSaati]) VALUES (6, NULL, N'B Takımı', N'059498984', 4, 1, NULL, 1, 9, NULL)
INSERT [dbo].[TakımTablo] ([TakımID], [KullaniciID], [TakımAdı], [Telefon], [SemtID], [TakımDurum], [Tarih], [TakımSilmedurum], [SahaID], [MacSaati]) VALUES (7, NULL, N'Aslangücü', N'55555', 2, 1, NULL, 1, 11, NULL)
INSERT [dbo].[TakımTablo] ([TakımID], [KullaniciID], [TakımAdı], [Telefon], [SemtID], [TakımDurum], [Tarih], [TakımSilmedurum], [SahaID], [MacSaati]) VALUES (8, NULL, N'Kralspor', N'05369855', 1, 1, NULL, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[TakımTablo] OFF
ALTER TABLE [dbo].[KiralanmışSahaTablo]  WITH CHECK ADD  CONSTRAINT [FK_KiralanmışSahaTablo_KullaniciGirisTablo] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[KullaniciGirisTablo] ([KullaniciID])
GO
ALTER TABLE [dbo].[KiralanmışSahaTablo] CHECK CONSTRAINT [FK_KiralanmışSahaTablo_KullaniciGirisTablo]
GO
ALTER TABLE [dbo].[KiralanmışSahaTablo]  WITH CHECK ADD  CONSTRAINT [FK_KiralanmışSahaTablo_SahaTablo] FOREIGN KEY([SahaID])
REFERENCES [dbo].[SahaTablo] ([SahaID])
GO
ALTER TABLE [dbo].[KiralanmışSahaTablo] CHECK CONSTRAINT [FK_KiralanmışSahaTablo_SahaTablo]
GO
ALTER TABLE [dbo].[KiralanmışSahaTablo]  WITH CHECK ADD  CONSTRAINT [FK_KiralanmışSahaTablo_SemtTablo] FOREIGN KEY([SemtID])
REFERENCES [dbo].[SemtTablo] ([SemtID])
GO
ALTER TABLE [dbo].[KiralanmışSahaTablo] CHECK CONSTRAINT [FK_KiralanmışSahaTablo_SemtTablo]
GO
ALTER TABLE [dbo].[OyuncuTablo]  WITH CHECK ADD  CONSTRAINT [FK_OyuncuTablo_KullaniciGirisTablo] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[KullaniciGirisTablo] ([KullaniciID])
GO
ALTER TABLE [dbo].[OyuncuTablo] CHECK CONSTRAINT [FK_OyuncuTablo_KullaniciGirisTablo]
GO
ALTER TABLE [dbo].[OyuncuTablo]  WITH CHECK ADD  CONSTRAINT [FK_OyuncuTablo_MevkiTablo] FOREIGN KEY([MevkiID])
REFERENCES [dbo].[MevkiTablo] ([MevkiID])
GO
ALTER TABLE [dbo].[OyuncuTablo] CHECK CONSTRAINT [FK_OyuncuTablo_MevkiTablo]
GO
ALTER TABLE [dbo].[OyuncuTablo]  WITH CHECK ADD  CONSTRAINT [FK_OyuncuTablo_SahaTablo] FOREIGN KEY([SahaID])
REFERENCES [dbo].[SahaTablo] ([SahaID])
GO
ALTER TABLE [dbo].[OyuncuTablo] CHECK CONSTRAINT [FK_OyuncuTablo_SahaTablo]
GO
ALTER TABLE [dbo].[SahaTablo]  WITH CHECK ADD  CONSTRAINT [FK_SahaTablo_SemtTablo] FOREIGN KEY([SemtID])
REFERENCES [dbo].[SemtTablo] ([SemtID])
GO
ALTER TABLE [dbo].[SahaTablo] CHECK CONSTRAINT [FK_SahaTablo_SemtTablo]
GO
ALTER TABLE [dbo].[TakımTablo]  WITH CHECK ADD  CONSTRAINT [FK_TakımTablo_KullaniciGirisTablo1] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[KullaniciGirisTablo] ([KullaniciID])
GO
ALTER TABLE [dbo].[TakımTablo] CHECK CONSTRAINT [FK_TakımTablo_KullaniciGirisTablo1]
GO
ALTER TABLE [dbo].[TakımTablo]  WITH CHECK ADD  CONSTRAINT [FK_TakımTablo_SahaTablo] FOREIGN KEY([SahaID])
REFERENCES [dbo].[SahaTablo] ([SahaID])
GO
ALTER TABLE [dbo].[TakımTablo] CHECK CONSTRAINT [FK_TakımTablo_SahaTablo]
GO
ALTER TABLE [dbo].[TakımTablo]  WITH CHECK ADD  CONSTRAINT [FK_TakımTablo_SemtTablo] FOREIGN KEY([SemtID])
REFERENCES [dbo].[SemtTablo] ([SemtID])
GO
ALTER TABLE [dbo].[TakımTablo] CHECK CONSTRAINT [FK_TakımTablo_SemtTablo]
GO
USE [master]
GO
ALTER DATABASE [HalıSaha] SET  READ_WRITE 
GO
