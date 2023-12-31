USE [master]
GO
/****** Object:  Database [SQLDoAn]    Script Date: 12/4/2023 7:25:17 AM ******/
CREATE DATABASE [SQLDoAn]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SQLDoAn', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SQLDoAn.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SQLDoAn_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SQLDoAn_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SQLDoAn] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SQLDoAn].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SQLDoAn] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SQLDoAn] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SQLDoAn] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SQLDoAn] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SQLDoAn] SET ARITHABORT OFF 
GO
ALTER DATABASE [SQLDoAn] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SQLDoAn] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SQLDoAn] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SQLDoAn] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SQLDoAn] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SQLDoAn] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SQLDoAn] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SQLDoAn] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SQLDoAn] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SQLDoAn] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SQLDoAn] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SQLDoAn] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SQLDoAn] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SQLDoAn] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SQLDoAn] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SQLDoAn] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SQLDoAn] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SQLDoAn] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SQLDoAn] SET  MULTI_USER 
GO
ALTER DATABASE [SQLDoAn] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SQLDoAn] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SQLDoAn] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SQLDoAn] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SQLDoAn] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SQLDoAn] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SQLDoAn] SET QUERY_STORE = OFF
GO
USE [SQLDoAn]
GO
/****** Object:  Table [dbo].[BinhLuan]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinhLuan](
	[MaBinhLuan] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NULL,
	[MaTruyen] [int] NULL,
	[NoiDung] [nvarchar](500) NOT NULL,
	[ThoiGian] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBinhLuan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatData]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaCTDonHang] [int] IDENTITY(1,1) NOT NULL,
	[MaDonHang] [int] NULL,
	[MaTruyen] [int] NULL,
	[GiaBan] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCTDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chuong]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chuong](
	[MaChuong] [int] IDENTITY(1,1) NOT NULL,
	[MaTruyen] [int] NULL,
	[SoChuong] [int] NOT NULL,
	[TieuDe] [nvarchar](100) NULL,
	[NoiDung] [nvarchar](200) NULL,
	[hinh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[MaDanhGia] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NULL,
	[MaTruyen] [int] NULL,
	[DiemDanhGia] [nvarchar](500) NOT NULL,
	[ThoiGian] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanhGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDonHang] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NULL,
	[TongTien] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHangGoiTaiKhoan]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHangGoiTaiKhoan](
	[IDdh] [int] IDENTITY(1,1) NOT NULL,
	[MaGoiTaiKhoan] [int] NULL,
	[MaNguoiDung] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDdh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoiTaiKhoan]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoiTaiKhoan](
	[MaGoiTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TenGoi] [nvarchar](255) NULL,
	[GiaGoi] [int] NULL,
	[ThongTinGoi] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGoiTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lichsu]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lichsu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NULL,
	[MaTruyen] [int] NULL,
	[Thoigiandoc] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[SDT] [nvarchar](20) NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
	[QuyenTruyCap] [nvarchar](100) NOT NULL,
	[TaiKhoan] [nvarchar](50) NOT NULL,
	[ResetCode] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SachDaDoc]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SachDaDoc](
	[MaSachDaDoc] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NULL,
	[MaTruyen] [int] NULL,
	[MaChuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSachDaDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[MaTheLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenTheLoai] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Truyen]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Truyen](
	[MaTruyen] [int] IDENTITY(1,1) NOT NULL,
	[TenTruyen] [nvarchar](100) NOT NULL,
	[TacGia] [nvarchar](100) NOT NULL,
	[MoTa] [nvarchar](200) NOT NULL,
	[TrangThai] [nvarchar](100) NOT NULL,
	[MaTheLoai] [int] NULL,
	[NgayXuatBan] [date] NULL,
	[Hinh] [nvarchar](50) NULL,
	[SoLuotXem] [int] NULL,
	[DiemDanhGia] [int] NULL,
	[GiaTruyen] [int] NULL,
	[SoLuongTon] [int] NULL,
	[SoLuongBan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTruyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TruyenYeuThich]    Script Date: 12/4/2023 7:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TruyenYeuThich](
	[MaTruyenYeuThich] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NULL,
	[MaTruyen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTruyenYeuThich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BinhLuan] ON 

INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (10, 3, NULL, N'testtruyen1', CAST(N'2023-11-14T19:00:44.037' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (11, 3, NULL, N'testtruyen1', CAST(N'2023-11-14T19:50:35.373' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (12, 3, NULL, N'testtruyen1', CAST(N'2023-11-14T19:55:22.730' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (13, 3, NULL, N'qqqq', CAST(N'2023-11-14T21:34:45.133' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (14, 3, NULL, N'as', CAST(N'2023-11-14T21:36:10.377' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (15, 3, NULL, N'wwfe', CAST(N'2023-11-14T21:36:43.427' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (16, 3, NULL, N'asa', CAST(N'2023-11-14T21:38:40.973' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (17, 3, NULL, N'as', CAST(N'2023-11-14T21:40:07.363' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (18, 3, NULL, N'asas', CAST(N'2023-11-14T21:41:29.727' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (20, 3, 1, N'testtruyen1', CAST(N'2023-11-15T15:03:58.367' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (21, 10, 1, N'truyen hay dien', CAST(N'2023-11-16T11:49:46.773' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (22, 10, 1, N'hay nka', CAST(N'2023-11-16T11:53:43.797' AS DateTime))
INSERT [dbo].[BinhLuan] ([MaBinhLuan], [MaNguoiDung], [MaTruyen], [NoiDung], [ThoiGian]) VALUES (23, 3, 1, N'hay dean', CAST(N'2023-11-17T05:07:26.210' AS DateTime))
SET IDENTITY_INSERT [dbo].[BinhLuan] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietDonHang] ON 

INSERT [dbo].[ChiTietDonHang] ([MaCTDonHang], [MaDonHang], [MaTruyen], [GiaBan]) VALUES (1, 1, 1, 0)
INSERT [dbo].[ChiTietDonHang] ([MaCTDonHang], [MaDonHang], [MaTruyen], [GiaBan]) VALUES (2, 2, 1, 0)
INSERT [dbo].[ChiTietDonHang] ([MaCTDonHang], [MaDonHang], [MaTruyen], [GiaBan]) VALUES (3, 4, 1, 0)
INSERT [dbo].[ChiTietDonHang] ([MaCTDonHang], [MaDonHang], [MaTruyen], [GiaBan]) VALUES (4, 5, 1, 0)
INSERT [dbo].[ChiTietDonHang] ([MaCTDonHang], [MaDonHang], [MaTruyen], [GiaBan]) VALUES (5, 6, 4, 0)
INSERT [dbo].[ChiTietDonHang] ([MaCTDonHang], [MaDonHang], [MaTruyen], [GiaBan]) VALUES (6, 7, 4, 0)
INSERT [dbo].[ChiTietDonHang] ([MaCTDonHang], [MaDonHang], [MaTruyen], [GiaBan]) VALUES (7, 8, 4, 0)
INSERT [dbo].[ChiTietDonHang] ([MaCTDonHang], [MaDonHang], [MaTruyen], [GiaBan]) VALUES (8, 9, 2, 0)
INSERT [dbo].[ChiTietDonHang] ([MaCTDonHang], [MaDonHang], [MaTruyen], [GiaBan]) VALUES (9, 10, 3, 0)
INSERT [dbo].[ChiTietDonHang] ([MaCTDonHang], [MaDonHang], [MaTruyen], [GiaBan]) VALUES (10, 11, 3, 0)
SET IDENTITY_INSERT [dbo].[ChiTietDonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[Chuong] ON 

INSERT [dbo].[Chuong] ([MaChuong], [MaTruyen], [SoChuong], [TieuDe], [NoiDung], [hinh]) VALUES (1, 1, 1, N'Chuong1', N'Onepice', N'1.jpg')
INSERT [dbo].[Chuong] ([MaChuong], [MaTruyen], [SoChuong], [TieuDe], [NoiDung], [hinh]) VALUES (2, 1, 2, N'Chuong2', N'Onepice2', N'2.jpg')
INSERT [dbo].[Chuong] ([MaChuong], [MaTruyen], [SoChuong], [TieuDe], [NoiDung], [hinh]) VALUES (6, 2, 1, N'Chuong1', N'Test', N'2.jpg')
INSERT [dbo].[Chuong] ([MaChuong], [MaTruyen], [SoChuong], [TieuDe], [NoiDung], [hinh]) VALUES (7, 3, 1, N'Chuong1', N'<p>testchuong1</p>
', N'chuong1manga.png')
INSERT [dbo].[Chuong] ([MaChuong], [MaTruyen], [SoChuong], [TieuDe], [NoiDung], [hinh]) VALUES (8, 3, 2, N'Chuong2', N'<p>testchuong2</p>
', N'chuong2manga.png')
INSERT [dbo].[Chuong] ([MaChuong], [MaTruyen], [SoChuong], [TieuDe], [NoiDung], [hinh]) VALUES (9, 3, 3, N'Chuong3', N'<p>testchuong3</p>
', N'chuong3manga.png')
INSERT [dbo].[Chuong] ([MaChuong], [MaTruyen], [SoChuong], [TieuDe], [NoiDung], [hinh]) VALUES (10, 4, 1, N'Chuong1', N'<p>testchuong1</p>
', N'chuong1.png')
INSERT [dbo].[Chuong] ([MaChuong], [MaTruyen], [SoChuong], [TieuDe], [NoiDung], [hinh]) VALUES (11, 4, 2, N'Chuong2', N'<p>testchuong2</p>
', N'chuong2.jpg')
SET IDENTITY_INSERT [dbo].[Chuong] OFF
GO
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [TongTien]) VALUES (1, 3, 10000)
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [TongTien]) VALUES (2, 3, 100000)
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [TongTien]) VALUES (3, 10, 10000000)
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [TongTien]) VALUES (4, 12, 10000)
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [TongTien]) VALUES (5, 12, 100000)
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [TongTien]) VALUES (6, 3, 100000000)
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [TongTien]) VALUES (7, 3, 100000000)
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [TongTien]) VALUES (8, 3, 100000000)
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [TongTien]) VALUES (9, 3, 10000)
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [TongTien]) VALUES (10, 3, 1000000)
INSERT [dbo].[DonHang] ([MaDonHang], [MaNguoiDung], [TongTien]) VALUES (11, 3, 1000000)
SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[DonHangGoiTaiKhoan] ON 

INSERT [dbo].[DonHangGoiTaiKhoan] ([IDdh], [MaGoiTaiKhoan], [MaNguoiDung]) VALUES (1, 1, 3)
INSERT [dbo].[DonHangGoiTaiKhoan] ([IDdh], [MaGoiTaiKhoan], [MaNguoiDung]) VALUES (2, 1, 10)
INSERT [dbo].[DonHangGoiTaiKhoan] ([IDdh], [MaGoiTaiKhoan], [MaNguoiDung]) VALUES (3, 1, 3)
INSERT [dbo].[DonHangGoiTaiKhoan] ([IDdh], [MaGoiTaiKhoan], [MaNguoiDung]) VALUES (4, 1, 3)
INSERT [dbo].[DonHangGoiTaiKhoan] ([IDdh], [MaGoiTaiKhoan], [MaNguoiDung]) VALUES (5, 1, 3)
INSERT [dbo].[DonHangGoiTaiKhoan] ([IDdh], [MaGoiTaiKhoan], [MaNguoiDung]) VALUES (6, 1, 10)
INSERT [dbo].[DonHangGoiTaiKhoan] ([IDdh], [MaGoiTaiKhoan], [MaNguoiDung]) VALUES (7, 1, 11)
INSERT [dbo].[DonHangGoiTaiKhoan] ([IDdh], [MaGoiTaiKhoan], [MaNguoiDung]) VALUES (8, 1, 12)
INSERT [dbo].[DonHangGoiTaiKhoan] ([IDdh], [MaGoiTaiKhoan], [MaNguoiDung]) VALUES (9, 1, 10)
SET IDENTITY_INSERT [dbo].[DonHangGoiTaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[GoiTaiKhoan] ON 

INSERT [dbo].[GoiTaiKhoan] ([MaGoiTaiKhoan], [TenGoi], [GiaGoi], [ThongTinGoi]) VALUES (1, N'VIP', 10000000, N'vip nhat he mat troi')
SET IDENTITY_INSERT [dbo].[GoiTaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[Lichsu] ON 

INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (1, 10, 2, CAST(N'2023-12-02T10:14:18.170' AS DateTime))
INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (2, 10, 4, CAST(N'2023-12-02T10:16:36.913' AS DateTime))
INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (3, 10, 3, CAST(N'2023-12-04T00:30:51.267' AS DateTime))
INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (4, 10, 3, CAST(N'2023-12-04T00:36:38.923' AS DateTime))
INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (5, 10, 3, CAST(N'2023-12-04T00:36:42.930' AS DateTime))
INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (6, 10, 3, CAST(N'2023-12-04T00:37:45.867' AS DateTime))
INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (7, 10, 4, CAST(N'2023-12-04T00:37:52.603' AS DateTime))
INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (8, 10, 4, CAST(N'2023-12-04T00:39:16.593' AS DateTime))
INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (9, 10, 3, CAST(N'2023-12-04T00:59:57.587' AS DateTime))
INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (10, 10, 4, CAST(N'2023-12-04T01:00:26.407' AS DateTime))
INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (11, 10, 3, CAST(N'2023-12-04T01:20:41.897' AS DateTime))
INSERT [dbo].[Lichsu] ([Id], [MaNguoiDung], [MaTruyen], [Thoigiandoc]) VALUES (12, 10, 3, CAST(N'2023-12-04T01:28:24.603' AS DateTime))
SET IDENTITY_INSERT [dbo].[Lichsu] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [DiaChi], [Email], [SDT], [MatKhau], [QuyenTruyCap], [TaiKhoan], [ResetCode]) VALUES (1, N'min', N'abc', N'abc@gmail.com', N'0585531247', N'123', N'Admin', N'minh123', NULL)
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [DiaChi], [Email], [SDT], [MatKhau], [QuyenTruyCap], [TaiKhoan], [ResetCode]) VALUES (3, N'test123', N'test', N'test@gmail.com', NULL, N'202cb962ac59075b964b07152d234b70', N'NguoiDung', N'test', NULL)
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [DiaChi], [Email], [SDT], [MatKhau], [QuyenTruyCap], [TaiKhoan], [ResetCode]) VALUES (10, N'tam', N'nkaanhtam', N'tam@gmail.com', N'01234567899', N'202cb962ac59075b964b07152d234b70', N'VIP', N'tam123', NULL)
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [DiaChi], [Email], [SDT], [MatKhau], [QuyenTruyCap], [TaiKhoan], [ResetCode]) VALUES (11, N'vi', N'abc', N'vi@gmail.com', N'0823468234', N'202cb962ac59075b964b07152d234b70', N'VIP', N'vusongvi', NULL)
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Ten], [DiaChi], [Email], [SDT], [MatKhau], [QuyenTruyCap], [TaiKhoan], [ResetCode]) VALUES (12, N'minh', N'abc', N'bakaminhdang@gmail.com', N'0585531247', N'202cb962ac59075b964b07152d234b70', N'VIP', N'minh123', NULL)
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[TheLoai] ON 

INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (1, N'Ecchi')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (2, N'Harem')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (3, N'Fantasy')
SET IDENTITY_INSERT [dbo].[TheLoai] OFF
GO
SET IDENTITY_INSERT [dbo].[Truyen] ON 

INSERT [dbo].[Truyen] ([MaTruyen], [TenTruyen], [TacGia], [MoTa], [TrangThai], [MaTheLoai], [NgayXuatBan], [Hinh], [SoLuotXem], [DiemDanhGia], [GiaTruyen], [SoLuongTon], [SoLuongBan]) VALUES (1, N'OnePice', N'oda', N'test', N'1', 1, CAST(N'2023-02-03' AS Date), N'cover1.jpg', 10, 10, 10000, 10, 5)
INSERT [dbo].[Truyen] ([MaTruyen], [TenTruyen], [TacGia], [MoTa], [TrangThai], [MaTheLoai], [NgayXuatBan], [Hinh], [SoLuotXem], [DiemDanhGia], [GiaTruyen], [SoLuongTon], [SoLuongBan]) VALUES (2, N'OnePice2', N'oda', N'test', N'1', 1, CAST(N'2023-02-03' AS Date), N'cover2.jpg', 10, 10, 10000, 10, 5)
INSERT [dbo].[Truyen] ([MaTruyen], [TenTruyen], [TacGia], [MoTa], [TrangThai], [MaTheLoai], [NgayXuatBan], [Hinh], [SoLuotXem], [DiemDanhGia], [GiaTruyen], [SoLuongTon], [SoLuongBan]) VALUES (3, N'OTOME GAME NO HEROINE', N'tam123', N'', N'1', 3, CAST(N'2023-11-27' AS Date), N'ome.JPG', 100000, 10, 1000000, 1, 1)
INSERT [dbo].[Truyen] ([MaTruyen], [TenTruyen], [TacGia], [MoTa], [TrangThai], [MaTheLoai], [NgayXuatBan], [Hinh], [SoLuotXem], [DiemDanhGia], [GiaTruyen], [SoLuongTon], [SoLuongBan]) VALUES (4, N'Chinatest', N'tam123', N'<p>testchuong</p>
', N'1', 1, CAST(N'2023-11-26' AS Date), N'ecchi.JPG', 1, 1, 100000000, 1, 1)
SET IDENTITY_INSERT [dbo].[Truyen] OFF
GO
SET IDENTITY_INSERT [dbo].[TruyenYeuThich] ON 

INSERT [dbo].[TruyenYeuThich] ([MaTruyenYeuThich], [MaNguoiDung], [MaTruyen]) VALUES (14, 10, 1)
INSERT [dbo].[TruyenYeuThich] ([MaTruyenYeuThich], [MaNguoiDung], [MaTruyen]) VALUES (16, 3, 1)
INSERT [dbo].[TruyenYeuThich] ([MaTruyenYeuThich], [MaNguoiDung], [MaTruyen]) VALUES (17, 10, 2)
INSERT [dbo].[TruyenYeuThich] ([MaTruyenYeuThich], [MaNguoiDung], [MaTruyen]) VALUES (18, 3, 2)
SET IDENTITY_INSERT [dbo].[TruyenYeuThich] OFF
GO
ALTER TABLE [dbo].[NguoiDung] ADD  CONSTRAINT [nd_QuyenTruyCap]  DEFAULT ('Ngu?i dùng') FOR [QuyenTruyCap]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD FOREIGN KEY([MaTruyen])
REFERENCES [dbo].[Truyen] ([MaTruyen])
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[DonHang] ([MaDonHang])
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaTruyen])
REFERENCES [dbo].[Truyen] ([MaTruyen])
GO
ALTER TABLE [dbo].[Chuong]  WITH CHECK ADD FOREIGN KEY([MaTruyen])
REFERENCES [dbo].[Truyen] ([MaTruyen])
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD FOREIGN KEY([MaTruyen])
REFERENCES [dbo].[Truyen] ([MaTruyen])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[DonHangGoiTaiKhoan]  WITH CHECK ADD FOREIGN KEY([MaGoiTaiKhoan])
REFERENCES [dbo].[GoiTaiKhoan] ([MaGoiTaiKhoan])
GO
ALTER TABLE [dbo].[DonHangGoiTaiKhoan]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[Lichsu]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[Lichsu]  WITH CHECK ADD FOREIGN KEY([MaTruyen])
REFERENCES [dbo].[Truyen] ([MaTruyen])
GO
ALTER TABLE [dbo].[SachDaDoc]  WITH CHECK ADD FOREIGN KEY([MaChuong])
REFERENCES [dbo].[Chuong] ([MaChuong])
GO
ALTER TABLE [dbo].[SachDaDoc]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[SachDaDoc]  WITH CHECK ADD FOREIGN KEY([MaTruyen])
REFERENCES [dbo].[Truyen] ([MaTruyen])
GO
ALTER TABLE [dbo].[Truyen]  WITH CHECK ADD FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[TheLoai] ([MaTheLoai])
GO
ALTER TABLE [dbo].[TruyenYeuThich]  WITH CHECK ADD FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[TruyenYeuThich]  WITH CHECK ADD FOREIGN KEY([MaTruyen])
REFERENCES [dbo].[Truyen] ([MaTruyen])
GO
USE [master]
GO
ALTER DATABASE [SQLDoAn] SET  READ_WRITE 
GO
