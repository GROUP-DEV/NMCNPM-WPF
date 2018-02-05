use master
go

if(DB_ID('QLVeMayBay')) is not null
	drop database QLVeMayBay
go

create database QLVeMayBay
go

use QLVeMayBay

create table USERS
(
	STT int identity(1,1),
	UserName varchar(255),
	Passwords varchar(255),
	Permission int

	constraint PK_USERS
	primary key (STT),

	constraint CK_USERS_STT
	check (STT >= 1)
)

create table SANBAYDI
(
	MaSB varchar(10),
	TenSB nvarchar(255)

	constraint PK_SANBAYDI
	primary key (MaSB)
)

create table SANBAYDEN
(
	MaSB varchar(10),
	TenSB nvarchar(255)

	constraint PK_SANBAYDEN
	primary key (MaSB)
)

create table SANBAYTRUNGGIAN
(
	MaSBTrungGian varchar(10),
	TenSB nvarchar(255),
	ThoiGianDung time,
	GhiChu nvarchar(255)

	constraint PK_SANBAYTRUNGGIAN
	primary key (MaSBTrungGian)
)

create table CHUYENBAY
(
	MaCB varchar(10),
	TenCB nvarchar(255),

	constraint PK_CHUYENBAY
	primary key (MaCB)
)

create table LICHBAY
(
	MaCB varchar(10),
	MaSanBayDi varchar(10),
	MaSanBayDen varchar(10),
	NgayGio datetime,
	ThoiGianBay time,
	SoLuongGheHang1 int,
	SoLuongGheHang2 int,
	MaSBTrungGian varchar(10)

	constraint PK_LICHBAY
	primary key (MaCB,MaSanBayDi,MaSanBayDen)
)


create table LOAIVE
(
	MaLoai varchar(10),
	DonGia int

	constraint PK_LOAIVE
	primary key (MaLoai)
)


create table PHIEUDATVE
(
	CMND varchar(10), 
	MaCB varchar(10),
	TenHanhKhach nvarchar(255),
	DienThoai varchar(11),
	MaLoai varchar(10),
	DonGia int,
	NgayDat datetime

	constraint PK_PHIEUDATVE
	primary key (CMND)
)

create table DANHSACHCHUYENBAY
(
	STT int identity(1,1),
	MaCB varchar(10),
	MaSanBayDi varchar(10),
	MaSanBayDen varchar(10),
	NgayKhoiHanh datetime,
	ThoiGian time,
	SoLuongGheTrong int,
	SoLuongGheDat int

	constraint PK_DANHSACHCHUYENBAY
	primary key (STT),

	constraint CK_DANHSACHCHUYENBAY_STT
	check (STT >= 1)
)

--Buoc 3
alter table LICHBAY
add
--
constraint FK_LICHBAY_CHUYENBAY
foreign key (MaCB)
references CHUYENBAY (MaCB),
--
constraint FK_LICHBAY_SANBAYDI
foreign key (MaSanBayDi)
references SANBAYDI (MaSB),
--
constraint FK_LICHBAY_SANBAYDEN
foreign key (MaSanBayDen)
references SANBAYDEN (MaSB),
--
constraint FK_LICHBAY_SANBAYTRUNGGIAN
foreign key (MaSBTrungGian)
references SANBAYTRUNGGIAN (MaSBTrungGian)


alter table DANHSACHCHUYENBAY
add
--
constraint FK_DANHSACHCHUYENBAY_LICHBAY
foreign key (MaCB,MaSanBayDi,MaSanBayDen)
references LICHBAY (MaCB,MaSanBayDi,MaSanBayDen)


alter table PHIEUDATVE
add
--
constraint FK_PHIEUDATVE_LOAIVE
foreign key (MaLoai)
references LOAIVE (MaLoai),
--
constraint FK_PHIEUDATVE_CHUYENBAY
foreign key (MaCB)
references CHUYENBAY (MaCB)


insert into SANBAYDI(MaSB, TenSB)
	values	('AG', N'An Giang'),
			('BL', N'Bạc Liêu'),
			('CM', N'Cà Mau'),
			('DB', N'Điện Biên'),
			('DN', N'Đồng Nai'),
			('GL', N'Gia Lai'),
			('HG', N'Hà Giang'),
			('BT', N'Bình Thuận'),
			('HCM', N'Tân Sơn Nhất'),
			('HN', N'Hà Nội')

insert into SANBAYDEN(MaSB, TenSB)
	values	('HK', N'Hong Kong'),
			('HQ', N'Hàn Quốc'),
			('EU', N'Châu Âu'),
			('USA', N'Mỹ'),
			('FR', N'Pháp'),
			('TQ', N'Trung Quốc'),
			('JP', N'Nhật'),
			('MO', N'Ma Cao'),
			('MX', N'Mexico'),
			('TG', N'ToGo')

insert into CHUYENBAY (MaCB, TenCB)
	values	('VN-HK',	N'Việt Nam - HongKong'),
			('VN-HQ',	N'Việt Nam - Hàn Quốc'),
			('VN-EU',	N'Việt Nam - Châu Âu'),
			('VN-USA',	N'Việt Nam - Mỹ'),
			('VN-FR',	N'Việt Nam - Pháp'),
			('VN-TQ',	N'Việt Nam - Trung Quốc'),
			('VN-JP',	N'Việt Nam - Nhật'),
			('VN-MO',	N'Việt Nam - Ma Cao'),
			('VN-MX',	N'Việt Nam - Mexico'),
			('VN-TG',	N'Việt Nam - ToGo')

insert into SANBAYTRUNGGIAN(MaSBTrungGian, TenSB, ThoiGianDung, GhiChu)
	values	('NT',	N'Nha Trang', NULL , N'Làm ơn, Sắp xếp thời gian đừng để trể chuyến bay'),
			('KH',	N'Khánh Hòa', NULL,N'Làm ơn, Sắp xếp thời gian đừng để trể chuyến bay')

insert into LICHBAY (MaCB, MaSanBayDi, MaSanBayDen, NgayGio, ThoiGianBay, SoLuongGheHang1, SoLuongGheHang2, MaSBTrungGian)
	values	('VN-HK', 'AG', 'HK',  '1/12/2017', '00:30:00', 20, 30, NULL),
			('VN-HQ', 'BL', 'HQ', '1/12/2017', '00:45:00', 15, 20 , NULL),
			('VN-EU', 'CM', 'EU', '1/12/2017', '00:45:00', 20, 30 , NULL),
			('VN-USA', 'DB', 'USA', '12/1/2017', '00:45:00', 20, 30 , NULL),
			('VN-FR', 'DN', 'FR', '2/16/2017', '00:45:00', 10, 30 , NULL),
			('VN-TQ', 'GL', 'TQ', '2/16/2017', '00:45:00', 20, 30 , NULL),
			('VN-JP', 'HG', 'JP', '2/16/2017', '00:45:00', 20, 30 , NULL),
			('VN-MO', 'BT', 'MO', '3/13/2017', '00:45:00', 20, 30 , NULL),
			('VN-MX', 'HCM', 'MX', '3/13/2017', '00:45:00', 20, 30 , NULL),
			('VN-TG', 'HN', 'TG', '3/13/2017', '00:45:00', 20, 30 , NULL)

insert into DANHSACHCHUYENBAY (MaCB, MaSanBayDi, MaSanBayDen, NgayKhoiHanh,ThoiGian, SoLuongGheTrong, SoLuongGheDat)
	values	('VN-HK', 'AG', 'HK',  '1/12/2017', '00:45:00', 30, 20),
			('VN-HQ', 'BL', 'HQ', '1/12/2017', '00:45:00', 15, 20),
			('VN-EU', 'CM', 'EU', '1/12/2017', '00:45:00', 20, 30),
			('VN-USA', 'DB', 'USA', '12/1/2017', '00:45:00', 20, 30),
			('VN-FR', 'DN', 'FR', '2/16/2017', '00:45:00', 10, 30),
			('VN-TQ', 'GL', 'TQ', '2/16/2017', '00:45:00', 20, 30),
			('VN-JP', 'HG', 'JP', '2/16/2017', '00:45:00', 20, 30),
			('VN-MO', 'BT', 'MO', '3/13/2017', '00:45:00', 20, 30),
			('VN-MX', 'HCM', 'MX', '3/13/2017', '00:45:00', 20, 30),
			('VN-TG', 'HN', 'TG', '3/13/2017', '00:45:00', 20, 30)

insert into LOAIVE (MaLoai, DonGia)
	values	('1',	100000),
			('2',	50000)

insert into PHIEUDATVE (CMND, MaCB, MaLoai, TenHanhKhach, DienThoai, DonGia, NgayDat)
	values	('123456789', 'VN-HK', '1', N'Nguyễn Thị Châu', '0123456789', 100000, '1/12/2017'),
			('123456788', 'VN-EU', '2', N'Nguyễn Thị Tiến Lên', '0123456788', 50000, '1/12/2017'),
			('123456777', 'VN-USA', '1', N'Nguyễn Thanh Trần', '0123456787', 100000, '1/12/2017'),
			('123456778', 'VN-USA', '2', N'Lê Doãn Chí Bình ', '0123456786', 50000, '1/12/2017'),
			('123456779', 'VN-EU', '1', N'Phan Thị Cẩm Nhung', '0123456785', 100000, '1/12/2017'),
			('123456780', 'VN-EU', '2', N'Tạ Biên Cương', '0123456784', 50000, '1/12/2017'),
			('123456781', 'VN-USA', '1', N'Châu Thanh Toàn', '0123456783', 100000, '1/12/2017'),
			('123456782', 'VN-HK', '2', N'Đơn Thị Lá', '0123456782', 50000, '1/12/2017'),
			('123456783', 'VN-HK', '1', N'Đôi Thị Hà', '0123456781', 100000, '1/12/2017')

insert into USERS (UserName, Passwords, Permission)
	values	('minhvuong', '123456', 1),
			('vanhau', '123456', 1),
			('nhung123', '123456', 0)
