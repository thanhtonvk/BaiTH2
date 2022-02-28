create table TaiKhoan(
	TenTK varchar(50) primary key,
	MatKhau varchar(50) not null,
	MoTa ntext
)
go
create table NhanVien(
	MaNV varchar(50) primary key,
	TenNV nvarchar(50) not null,
	GioiTinh nvarchar(50) default N'Nam',
	NgaySinh date,
	Email varchar(30),
	SDT char(30)
)
go
create table Sach(
	MaSH varchar(30) primary key,
	TenSach nvarchar(100),
	TacGia nvarchar(100),
	NhaXB nvarchar(100),
	NamXB int
)
go
create table SinhVien(
	MaSV varchar(30) PRIMARY KEY,
	TenSV nvarchar(50) NOT NULL,
	GioiTinh nvarchar(30) default N'Nam',
	DiaChi nvarchar(50),
	NgaySinh date
)