USE [master]
GO
/****** Object:  Database [QLCF]    Script Date: 10/20/2022 12:38:23 PM ******/
CREATE DATABASE [QLCF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLCF', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLCF.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLCF_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLCF_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLCF] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLCF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLCF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLCF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLCF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLCF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLCF] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLCF] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLCF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLCF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLCF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLCF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLCF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLCF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLCF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLCF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLCF] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLCF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLCF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLCF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLCF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLCF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLCF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLCF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLCF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLCF] SET  MULTI_USER 
GO
ALTER DATABASE [QLCF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLCF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLCF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLCF] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLCF] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLCF] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QLCF] SET QUERY_STORE = OFF
GO
USE [QLCF]
GO
/****** Object:  Table [dbo].[BAN]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAN](
	[maban] [int] IDENTITY(1,1) NOT NULL,
	[tenban] [nvarchar](100) NULL,
	[trangthaiban] [int] NULL,
 CONSTRAINT [PK__BAN] PRIMARY KEY CLUSTERED 
(
	[maban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[mahoadon] [int] NOT NULL,
	[madouong] [int] NOT NULL,
	[soluong] [int] NULL,
	[giatien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[mahoadon] ASC,
	[madouong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DANHMUCDOUONG]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANHMUCDOUONG](
	[madanhmuc] [int] IDENTITY(1,1) NOT NULL,
	[tendanhmuc] [nvarchar](100) NULL,
 CONSTRAINT [PK__DANHMUCD__7C8B70575CA1C101] PRIMARY KEY CLUSTERED 
(
	[madanhmuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOUONG]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOUONG](
	[madouong] [int] IDENTITY(1,1) NOT NULL,
	[tendouong] [nvarchar](100) NULL,
	[madanhmuc] [int] NULL,
	[dongia] [float] NULL,
 CONSTRAINT [PK__DOUONG__E76B50096442E2C9] PRIMARY KEY CLUSTERED 
(
	[madouong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[mahoadon] [int] IDENTITY(1,1) NOT NULL,
	[mataikhoan] [int] NULL,
	[giolap] [date] NULL,
	[maban] [int] NULL,
	[trangthaihoadon] [int] NULL,
 CONSTRAINT [PK__HOADON__8C708E0C74794A92] PRIMARY KEY CLUSTERED 
(
	[mahoadon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[mataikhoan] [int] IDENTITY(1,1) NOT NULL,
	[tendangnhap] [nvarchar](100) NULL,
	[matkhau] [nvarchar](100) NULL,
	[tennv] [nvarchar](100) NULL,
	[ngaysinh] [datetime] NULL,
	[gioitinh] [nvarchar](100) NULL,
	[cmnd] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[sdt] [nvarchar](100) NULL,
	[loaitk] [int] NULL,
	[trangthaitk] [int] NULL,
 CONSTRAINT [PK__TAIKHOAN__0477B98C57DD0BE4] PRIMARY KEY CLUSTERED 
(
	[mataikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HOADON] ADD  CONSTRAINT [DF__HOADON__trangtha__76619304]  DEFAULT ((0)) FOR [trangthaihoadon]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK__CHITIETHO__madou__7E02B4CC] FOREIGN KEY([madouong])
REFERENCES [dbo].[DOUONG] ([madouong])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK__CHITIETHO__madou__7E02B4CC]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK__CHITIETHO__mahoa__7D0E9093] FOREIGN KEY([mahoadon])
REFERENCES [dbo].[HOADON] ([mahoadon])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK__CHITIETHO__mahoa__7D0E9093]
GO
ALTER TABLE [dbo].[DOUONG]  WITH CHECK ADD  CONSTRAINT [FK__DOUONG__madanhmu__662B2B3B] FOREIGN KEY([madanhmuc])
REFERENCES [dbo].[DANHMUCDOUONG] ([madanhmuc])
GO
ALTER TABLE [dbo].[DOUONG] CHECK CONSTRAINT [FK__DOUONG__madanhmu__662B2B3B]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK__HOADON__maban__7755B73D] FOREIGN KEY([maban])
REFERENCES [dbo].[BAN] ([maban])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK__HOADON__maban__7755B73D]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK__HOADON__mataikho__7849DB76] FOREIGN KEY([mataikhoan])
REFERENCES [dbo].[TAIKHOAN] ([mataikhoan])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK__HOADON__mataikho__7849DB76]
GO
/****** Object:  StoredProcedure [dbo].[USP_Add_Account]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Add_Account]
@tendangnhap nvarchar(100)
,@matkhau nvarchar(100)
,@tennv nvarchar(100)
,@ngaysinh datetime
,@gioitinh nvarchar(100)
,@cmnd nvarchar(100)
,@email nvarchar(100)
,@sdt nvarchar(100)
,@loaitk int
AS
BEGIN
	INSERT INTO TAIKHOAN (tendangnhap,matkhau,tennv,ngaysinh,gioitinh,cmnd,email,sdt,loaitk,trangthaitk) 
	VALUES (@tendangnhap,@matkhau,@tennv,@ngaysinh,@gioitinh,@cmnd,@email,@sdt,@loaitk,0)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Add_Category]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[USP_Add_Category]
		@tendanhmuc nvarchar(100)
		as
		begin
		insert into DANHMUCDOUONG(tendanhmuc) values(@tendanhmuc)
		end
GO
/****** Object:  StoredProcedure [dbo].[USP_Add_Food]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Add_Food]
		@tendouong nvarchar(100),
		@madanhmuc int,
		@dongia float
		as
		begin
		insert into DOUONG(tendouong,madanhmuc,dongia) values(@tendouong,@madanhmuc,@dongia)
		end
GO
/****** Object:  StoredProcedure [dbo].[USP_Add_Table]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Add_Table]
		@tenban nvarchar(100)
		as
		begin
		insert into BAN (tenban,trangthaiban) values(@tenban,0)
		end
GO
/****** Object:  StoredProcedure [dbo].[USP_ChangeAccount]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_ChangeAccount] 
	@matk int,
	@ten nvarchar(100),
	@mk nvarchar(100),
	@tennv nvarchar(100)
	as
	begin
		update TAIKHOAN set tendangnhap = @ten,matkhau = @matk, tennv = @tennv where mataikhoan = @matk
	end
GO
/****** Object:  StoredProcedure [dbo].[USP_DangNhap]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_DangNhap]
        @tendangnhap nvarchar(100),
        @matkhau nvarchar(100)
        AS
        BEGIN
        SELECT * FROM dbo.TAIKHOAN where tendangnhap = @tendangnhap and matkhau = @matkhau and trangthaitk = 0
        END
GO
/****** Object:  StoredProcedure [dbo].[USP_DatBan]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_DatBan]
@trangthai int,
@maban int
as
begin
	update BAN set trangthaiban = @trangthai where maban= @maban
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Del_Category]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Del_Category]
		@tendanhmuc nvarchar(100)
		as
		begin
		delete from DANHMUCDOUONG where tendanhmuc = @tendanhmuc
		end
GO
/****** Object:  StoredProcedure [dbo].[USP_Del_Food]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Del_Food]
		@tendouong nvarchar(100)
		as
		begin
		delete from DOUONG where tendouong = @tendouong
		end
GO
/****** Object:  StoredProcedure [dbo].[USP_Del_Table]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Del_Table]
		@tenban nvarchar(100)
		as
		begin
		delete from BAN where tenban = @tenban
		end
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleFood]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 10/8/2022 9:17:30 AM ******/
create PROC [dbo].[USP_DeleFood]
       @mahd int, @madu int, @sl int
        as
        begin 
        declare @isExistBillInfo int
        declare @foodCount int =1
        declare @price float        
        select @price = dongia from douong where madouong=@madu
        select @isExistBillInfo = mahoadon,@foodCount=b.soluong
        from dbo.CHITIETHOADON as b
        where mahoadon = @mahd and madouong = @madu
        if(@isExistBillInfo >0)    
			begin
			declare @newcount int = @foodCount - @sl
			if(@newcount>0)
				begin
				if(@price>0)
					begin					
						update dbo.CHITIETHOADON set soluong = @foodCount - @sl, giatien=@newcount*@price where madouong = @madu and mahoadon = @mahd
					end
				end
			else
				begin
					delete from CHITIETHOADON where madouong=@madu
				end
			end
		 
        end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_InsertBill]
		@matk int,
        @maban int
        as
        begin 
        insert dbo.HOADON
        (
        mataikhoan,
        giolap,
        maban,
        trangthaihoadon
        )
        values(
        @matk,
        GETDATE(),
        @maban,
        0
        )
        end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_InsertBillInfo]
       @mahd int, @madu int, @sl int
        as
        begin 
        declare @isExistBillInfo int
        declare @foodCount int =1
        declare @price float        
        select @price = dongia from douong where madouong=@madu
        select @isExistBillInfo = mahoadon,@foodCount=b.soluong
        from dbo.CHITIETHOADON as b
        where mahoadon = @mahd and madouong = @madu
        if(@isExistBillInfo >0)    
			begin
			declare @newcount int = @foodCount + @sl
			if(@newcount>0)
				begin
				if(@price>0)
					begin					
						update dbo.CHITIETHOADON set soluong = @foodCount +@sl, giatien=@newcount*@price where madouong = @madu and mahoadon = @mahd
					end
				end
			end
        else
			begin
			if(@price >0)
				begin				        
					insert dbo.CHITIETHOADON
					(mahoadon,madouong,soluong,giatien)
					values(@mahd, @madu, @sl,@sl*@price) 
				end
			end
        end
GO
/****** Object:  StoredProcedure [dbo].[USP_LaychitietHD]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_LaychitietHD]
@mahd int
as
select a.mahoadon, b.tendouong, a.soluong, a.giatien
from dbo.CHITIETHOADON as a, dbo.DOUONG as b
where a.madouong = b.madouong and a.mahoadon = @mahd
GO
/****** Object:  StoredProcedure [dbo].[USP_LaychitietHDTheoBan]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_LaychitietHDTheoBan]
@maban int,
@trangthai int
as
select a.mahoadon, a.madouong, b.tendouong, a.soluong, a.giatien,c.maban,c.trangthaihoadon
from dbo.CHITIETHOADON as a, dbo.DOUONG as b, dbo.HOADON as c
where a.madouong = b.madouong and a.mahoadon = c.mahoadon and c.maban = @maban and c.trangthaihoadon = @trangthai
GO
/****** Object:  StoredProcedure [dbo].[USP_LayDanhSachBan]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[USP_LayDanhSachBan]
         AS
        SELECT maban, tenban, trangthaiban
         FROM dbo.BAN     
GO
/****** Object:  StoredProcedure [dbo].[USP_LayDanhSachDoUong]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_LayDanhSachDoUong]
		@madanhmuc nvarchar(100)
         AS
        SELECT madouong, tendouong, 
        dongia, madanhmuc
        FROM DOUONG where madanhmuc = @madanhmuc
GO
/****** Object:  StoredProcedure [dbo].[USP_LayDanhSachHoaDon]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_LayDanhSachHoaDon]
          AS
        SELECT a.mahoadon, b.tennv, a.giolap, c.tenban, trangthaihoadon
        FROM dbo.HOADON as a, dbo.TAIKHOAN as b, dbo.BAN as c
        where a.mataikhoan = b.mataikhoan and a.maban = c.maban
GO
/****** Object:  StoredProcedure [dbo].[USP_LayDanhSachTaiKhoan]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_LayDanhSachTaiKhoan]
          AS 
          SELECT mataikhoan , tendangnhap , matkhau , tennv , ngaysinh ,
          gioitinh , cmnd , email , sdt ,
          case loaitk
          when 0 then N'Admin'
         when 1 then N'Nhân viên' end as loaitk,
          case trangthaitk
          when 0 then N'Bình thường'
         when 1 then N'Khóa' end as  trangthaitk FROM dbo.TAIKHOAN
GO
/****** Object:  StoredProcedure [dbo].[USP_LayTTDoUong]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_LayTTDoUong]
as
select tendouong as "Tên Đồ Uống", tendanhmuc as "Tên Danh Mục", dongia as "Đơn Giá"
from DANHMUCDOUONG,DOUONG
where DOUONG.madanhmuc = DANHMUCDOUONG.madanhmuc
GO
/****** Object:  StoredProcedure [dbo].[USP_LayTTDoUongTheoDanhMuc]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_LayTTDoUongTheoDanhMuc]
@madm int
as
select tendouong as "Tên Đồ Uống", tendanhmuc as "Tên Danh Mục", dongia as "Đơn Giá"
from DANHMUCDOUONG,DOUONG
where DOUONG.madanhmuc = DANHMUCDOUONG.madanhmuc and DOUONG.madanhmuc = @madm
GO
/****** Object:  StoredProcedure [dbo].[USP_LDSDanhMuc]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_LDSDanhMuc]
AS
SELECT madanhmuc, tendanhmuc
FROM dbo.DANHMUCDOUONG
GO
/****** Object:  StoredProcedure [dbo].[USP_LoadAccount]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_LoadAccount]
as
select tendangnhap as 'Tên đăng nhập',matkhau as 'Mật khẩu', tennv as 'Tên nhân viên',ngaysinh as 'Ngày sinh', gioitinh as 'Giới tính', 
cmnd as 'CMND', email, sdt
from TAIKHOAN
GO
/****** Object:  StoredProcedure [dbo].[USP_LoadDSHoaDon]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_LoadDSHoaDon]
@maban int,
@trangthai int
as
select a.mahoadon, b.tendouong, a.soluong, a.giatien,c.maban,c.trangthaihoadon
from dbo.CHITIETHOADON as a, dbo.DOUONG as b, dbo.HOADON as c
where a.madouong = b.madouong and a.mahoadon = c.mahoadon and c.maban = @maban and c.trangthaihoadon = @trangthai
GO
/****** Object:  StoredProcedure [dbo].[USP_Lock]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Lock]
@matk int
as
begin
	update TAIKHOAN set trangthaitk = 1 where mataikhoan =@matk
end
GO
/****** Object:  StoredProcedure [dbo].[USP_SuaThongTinTaiKhoan]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_SuaThongTinTaiKhoan]
        @mataikhoan int,
        @tendangnhap nvarchar(100),
        @matkhau nvarchar(100) , 
        @tennv nvarchar(100),
        @ngaysinh datetime,
        @gioitinh nvarchar(100),
        @cmnd nvarchar(100),
        @email nvarchar(100),
        @sdt nvarchar(100),
        @loaitk int,
        @trangthaitk int
        as 
	    begin 
		update dbo.TAIKHOAN set tendangnhap = @tendangnhap , matkhau = @matkhau , tennv = @tennv , ngaysinh = @ngaysinh ,
		gioitinh = @gioitinh , cmnd = @cmnd, email = @email , sdt = @sdt , loaitk = @loaitk , trangthaitk = @trangthaitk
        where mataikhoan = @mataikhoan
        end   
GO
/****** Object:  StoredProcedure [dbo].[USP_ThongKe]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_ThongKe]
@giolapfrom date,
@giolapto date
as
SELECT b.mahoadon as 'Mã Hoá Đơn', d.tenban as 'Tên Bàn', a.tendouong as 'Tên đồ uống', b.soluong as 'Số lượng',b.giatien as 'Giá tiền', c.giolap as 'Giờ lập', e.tennv as 'Tên nhân viên' 
FROM dbo.DOUONG as a, dbo.CHITIETHOADON as b, dbo.HOADON as c, dbo.BAN as d, dbo.TAIKHOAN as e 
WHERE  c.mataikhoan = e.mataikhoan and c.maban = d.maban and b.mahoadon = c.mahoadon and b.madouong = a.madouong and c.mataikhoan = e.mataikhoan and c.giolap >= @giolapfrom and c.giolap <= @giolapto and c.trangthaihoadon = 1


GO
/****** Object:  StoredProcedure [dbo].[USP_ThongKeBanChay]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_ThongKeBanChay]
as
select c.tendouong as 'Tên đồ uống', sum(a.soluong) as 'Số lượng', sum(a.giatien) as 'Tổng', d.tendanhmuc as 'Tên danh mục' 
from dbo.CHITIETHOADON as a, dbo.HOADON as b , dbo.DOUONG as c, dbo.DANHMUCDOUONG as d 
where a.mahoadon = b.mahoadon and a.madouong = c.madouong and c.madanhmuc = d.madanhmuc and b.trangthaihoadon = 1 
group by c.tendouong, d.tendanhmuc 
order by sum(a.soluong) desc
GO
/****** Object:  StoredProcedure [dbo].[USP_ThongKeTheoDanhMuc]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_ThongKeTheoDanhMuc]
@id int
as
SELECT b.mahoadon as 'Mã Hoá Đơn', d.tenban as 'Tên Bàn', a.tendouong as 'Tên đồ uống', b.soluong as 'Số lượng',b.giatien as 'Giá tiền', c.giolap as 'Giờ lập', e.tennv as 'Tên nhân viên' 
FROM dbo.DOUONG as a, dbo.CHITIETHOADON as b, dbo.HOADON as c, dbo.BAN as d, dbo.TAIKHOAN as e 
WHERE  c.mataikhoan = e.mataikhoan and c.maban = d.maban and b.mahoadon = c.mahoadon and b.madouong = a.madouong and a.madanhmuc = @id and c.trangthaihoadon = 1;
GO
/****** Object:  StoredProcedure [dbo].[USP_ThongKeTheoNhanVien]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_ThongKeTheoNhanVien]
@id int,
@giolapfrom date,
@giolapto date
as
SELECT b.mahoadon as 'Mã Hoá Đơn', d.tenban as 'Tên Bàn', a.tendouong as 'Tên đồ uống', b.soluong as 'Số lượng',b.giatien as 'Giá tiền', c.giolap as 'Giờ lập', e.tennv as 'Tên nhân viên' 
FROM dbo.DOUONG as a, dbo.CHITIETHOADON as b, dbo.HOADON as c, dbo.BAN as d, dbo.TAIKHOAN as e 
WHERE  c.mataikhoan = e.mataikhoan and c.maban = d.maban and b.mahoadon = c.mahoadon and b.madouong = a.madouong and c.mataikhoan = @id and c.giolap >= @giolapfrom and c.giolap <= @giolapto and c.trangthaihoadon = 1


GO
/****** Object:  StoredProcedure [dbo].[USP_TongTienHD]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_TongTienHD] 
@mahd int
as
select Sum(giatien)
from CHITIETHOADON
where mahoadon = @mahd
GO
/****** Object:  StoredProcedure [dbo].[USP_UnLock]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UnLock]
@matk int
as
begin
	update TAIKHOAN set trangthaitk = 0 where mataikhoan =@matk
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Update_Category]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Update_Category]
		@madanhmuc int,
		@tendanhmucnew nvarchar(100)
		as
		begin
		update DANHMUCDOUONG SET tendanhmuc = @tendanhmucnew WHERE madanhmuc = @madanhmuc
		end
GO
/****** Object:  StoredProcedure [dbo].[USP_Update_Food]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Update_Food]
		@madouong int,
		@tendouongnew nvarchar(100),		
		@dongianew float
		as
		begin
		update DOUONG SET tendouong = @tendouongnew, dongia = @dongianew WHERE madouong = @madouong
		end
GO
/****** Object:  StoredProcedure [dbo].[USP_Update_Table]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Update_Table]
		@maban int,
		@tenbannew nvarchar(100)
		as
		begin
		update BAN SET tenban = @tenbannew WHERE maban = @maban
		end
GO
/****** Object:  StoredProcedure [dbo].[USP_XoaBill]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_XoaBill]
@mahoadon int
as
begin
    declare @maban int
	delete from CHITIETHOADON where mahoadon=@mahoadon
	select @maban = maban from HOADON where mahoadon=@mahoadon	 
	delete from HOADON where mahoadon = @mahoadon
	update Ban set trangthaiban = 0 where maban = @maban
end
GO
/****** Object:  StoredProcedure [dbo].[USP_XoaTaiKhoan]    Script Date: 10/20/2022 12:38:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_XoaTaiKhoan]
        @mataikhoan int
        as
        begin
        delete from dbo.TAIKHOAN where mataikhoan = @mataikhoan
        end 
GO
USE [master]
GO
ALTER DATABASE [QLCF] SET  READ_WRITE 
GO
