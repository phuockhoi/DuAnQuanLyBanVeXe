
Create database QuanLyBanVeXe
Go
Use QuanLyBanVeXe
Go

create table NguoiDung
(
	IdNguoiDung varchar(30) not null,
	PassND varchar(30),
	HoTen nvarchar(30) not null,
	NgaySinh date,
	GioiTinh nvarchar(3) not null,
	DiaChi nvarchar(100),
	SoDT varchar(15),
	IdLoaiND varchar(30) not null
)

create table LoaiNguoiDung
(
	IdLoaiND varchar(30) not null,
	TenLoaiND nvarchar(30) not null
)

create table Xe
(
	So_Xe varchar(8) not null,
	Hieu_Xe varchar(50),
	Doi_Xe varchar(4),
	So_Cho_Ngoi int
)

create table TuyenXe
(
	IdTuyen varchar(30) not null,
	TenTuyen nvarchar(30) unique,
	DiaDiemDi nvarchar(30),
	DiaDiemDen nvarchar(30)
)

create table ThoiDiem
(
	IdThoiDiem varchar(30) not null,
	Ngay date not null,
	Gio varchar(10) not null,
)

create table ChiTietTuyen
(
	IdTuyen varchar(30) not null,
	IdThoiDiem varchar(30) not null
)

create table ChuyenXe
(
	IdChuyen varchar(30) not null,
	IdTuyen varchar(30),
	NgayDi date,
	Gio varchar(10),
	So_Xe varchar(8)
)


create table BanVe
(
	IdVe varchar(30) not null,
	IdChuyen varchar(30),
	TenHanhKhach nvarchar(30),
	SDTHanhKhach varchar(20),
	SoLuongMua int,
	GiaVe int,
	ThanhTien int
)

---------------------------------------------------------------------------



-----------------------------------Tao Rang Buoc Toan Ven---------------------------------

------------------------------------Tao Khoa Chinh----------------------------------------
------------------------------------------------------------------------------------------
Alter table NguoiDung 
Add constraint pk_NguoiDung primary key(IdNguoiDung)

Alter table LoaiNguoiDung 
Add constraint pk_LoaiNguoiDung primary key(IdLoaiND)


Alter table Xe 
Add constraint pk_Xe primary key(So_Xe)

Alter table TuyenXe 
Add constraint pk_TuyenXe primary key(IdTuyen)

Alter table ThoiDiem
Add constraint pk_ThoiDiem primary key(IdThoiDiem)

Alter table ChiTietTuyen
Add constraint pk_ChiTietTuyen primary key(IdTuyen, IdThoiDiem)

Alter table ChuyenXe
Add constraint pk_ChuyenXe primary key(IdChuyen)

Alter table BanVe 
Add constraint pk_BanVe primary key(IdVe)

---------------------------------------Tao Khoa Ngoai------------------------------
-----------------------------------------------------------------------------------
Alter table NguoiDung 
Add constraint fk_NguoiDung_LoaiNguoiDung foreign key(IDLoaiND) references LoaiNguoiDung(IDLoaiND)
Go
Alter table ChiTietTuyen 
Add constraint fk_ChiTietTuyen_TuyenXe foreign key(IdTuyen) references TuyenXe(IdTuyen)

Alter table ChiTietTuyen 
Add constraint fk_ChiTietTuyen_ThoiDiem foreign key(IdThoiDiem) references ThoiDiem(IdThoiDiem)

Alter table ChuyenXe 
Add constraint fk_ChuyenXe_Xe foreign key(So_Xe) references Xe(So_Xe)

Alter table ChuyenXe 
Add constraint fk_ChuyenXe_TuyenXe foreign key(IdTuyen) references TuyenXe(IdTuyen)

Alter table BanVe
Add constraint fk_BanVe_ChuyenXe foreign key(IdChuyen) references ChuyenXe(IdChuyen)

-----------------------------------Them Du Lieu Cho Cac Bang---------------------------------

-----------------------------------Tabl.LoaiNguoiDung--------------------------------------------
---------------------------------------------------------------------------------------------
insert into LoaiNguoiDung values('Admin',N'Administrator')
insert into LoaiNguoiDung values('Nhan_Vien',N'Nhân Viên')

-----------------------------------Tabl.NguoiDung--------------------------------------------
---------------------------------------------------------------------------------------------
Insert into NguoiDung(IdNguoiDung, PassND, HoTen, NgaySinh, GioiTinh, DiaChi, SoDT, IdLoaiND) 
Values('lytieulong','aloneforever',N'Bùi Thanh Thoại','1990/06/26',N'Nam',N'1118, Tỉnh lộ 10, P.Tân Tạo, Q.Bình Tân','0922571760','Admin')

Insert into NguoiDung(IdNguoiDung, PassND, HoTen, NgaySinh, GioiTinh, DiaChi, SoDT, IdLoaiND) 
Values('vantoan','123456',N'Mai Văn Toàn','1990/10/01',N'Nam',N'123,Hai Bà Trưng, P.1, Q.1','0988101914','Nhan_Vien')

Insert into NguoiDung(IdNguoiDung, PassND, HoTen, NgaySinh, GioiTinh, DiaChi, SoDT, IdLoaiND) 
Values('toanh','123456',N'Trịnh Tố Anh','1990/10/04',N'Nữ',N'284, Lý Thường Kiệt, P.14, Q.10','01212117450','Nhan_Vien')

Insert into NguoiDung(IdNguoiDung, PassND, HoTen, NgaySinh, GioiTinh, DiaChi, SoDT, IdLoaiND) 
Values('mytien','123456',N'Quách Mỹ Tiên','1990/10/17',N'Nữ',N'56, Lý Thái Tổ, P.4, Q.10','0988296997','Nhan_Vien')

--Select * from NguoiDung 


-----------------------------------Tabl.Xe-------------------------------------------------
-------------------------------------------------------------------------------------------
---------------------------------------------------------------------
---------------------------------------------------------------------

insert into Xe(So_Xe, Hieu_Xe, Doi_Xe, So_Cho_Ngoi) 
values('55Y-7777', 'Ford Transit', '2010', '16')

insert into Xe(So_Xe, Hieu_Xe, Doi_Xe, So_Cho_Ngoi)
values('52N-3333', 'Huyndai Country', '2008', '30')

insert into Xe(So_Xe, Hieu_Xe, Doi_Xe, So_Cho_Ngoi)
values('50Y-3669', 'Toyota', '2009', '16')

insert into Xe(So_Xe, Hieu_Xe, Doi_Xe, So_Cho_Ngoi)
values('53Y-7788', 'Ford Everest', '2009', '7')

insert into Xe(So_Xe, Hieu_Xe, Doi_Xe, So_Cho_Ngoi) 
values('50S-2934', 'Hyundai Country', '2005', '25')

insert into Xe(So_Xe, Hieu_Xe, Doi_Xe, So_Cho_Ngoi)  
values('54H-1234', 'Hyundai Country', '2008', '30')

insert into Xe(So_Xe, Hieu_Xe, Doi_Xe, So_Cho_Ngoi)  
values('50S-9999', 'Huyndai', '2003', '45')


-----------------------------------Table.TuyenXe--------------------------------------------
-------------------------------------------------------------------------------------------

insert into TuyenXe values('107',N'Sài Gòn - Nha Trang', N'Sài Gòn', N'Nha Trang')
insert into TuyenXe values('23',N'Sài Gòn - Đà Lạt', N'Sài Gòn', N'Đà Lạt')
insert into TuyenXe values('250',N'Sài Gòn - Cần Thơ', N'Sài Gòn', N'Cần Thơ')
insert into TuyenXe values('303',N'Sài Gòn - Tây Ninh', N'Sài Gòn', N'Tây Ninh')
insert into TuyenXe values('547',N'Sài Gòn - Phan Thiết', N'Sài Gòn', N'Phan Thiết')
insert into TuyenXe values('503',N'Sài Gòn - Kon Tum', N'Sài Gòn', N'Kon Tom')
insert into TuyenXe values('284',N'Sài Gòn - Bình Thuận', N'Sài Gòn', N'Bình Thuận')
insert into TuyenXe values('153',N'Sài Gòn - Kiên Giang', N'Sài Gòn', N'Kiên Giang')
insert into TuyenXe values('173',N'Sài Gòn - Bạc Liêu', N'Sài Gòn', N'Bạc Liêu')
insert into TuyenXe values('602',N'Sài Gòn - Vũng Tàu', N'Sài Gòn', N'Vũng Tàu')

-----------------------------------Tabl.ThoiDiem-------------------------------------------
-------------------------------------------------------------------------------------------


-----------------------------------Tabl.ChiTietTuyen---------------------------------------
-------------------------------------------------------------------------------------------


-----------------------------------Tabl.ChuyenXe---------------------------------------
-------------------------------------------------------------------------------------------


-----------------------------------------Table.BanVe-------------------------------------------
-----------------------------------------------------------------------------------------------






