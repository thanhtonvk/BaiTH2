create database BaiTH2
go
use BaiTH2
go
create table TaiKhoan
(
    TenTK   varchar(50) primary key,
    MatKhau varchar(50) not null,
    MoTa    ntext
)
go
create table NhanVien
(
    MaNV     varchar(50) primary key,
    TenNV    nvarchar(50) not null,
    GioiTinh nvarchar(50) default N'Nam',
    NgaySinh date,
    Email    varchar(30),
    SDT      char(30)
)
go
create table Sach
(
    MaSH    varchar(30) primary key,
    TenSach nvarchar(100),
    TacGia  nvarchar(100),
    NhaXB   nvarchar(100),
    NamXB   int
)
go
create table SinhVien
(
    MaSV     varchar(30) PRIMARY KEY,
    TenSV    nvarchar(50) NOT NULL,
    GioiTinh nvarchar(30) default N'Nam',
    DiaChi   nvarchar(50),
    NgaySinh date
)
go
create table DanhMuc
(
    MaDanhMuc  int identity (1000,1) primary key,
    TenDanhMuc nvarchar(100)
)
go
create table SanPham
(
    Ma int identity (1000,1) primary key,
    Ten nvarchar(100),
    DonGia int,
    MaDanhMuc int not null constraint  fk_1 foreign key(MaDanhMuc) references DanhMuc(MaDanhMuc)
)
go
create table LoaiHang(
    MaLoai int identity(1,1) primary key,
    TenLoai nvarchar(100) not null,
    MoTa nvarchar(100)
)
go
create table HangHoa(
    MaHang int identity(1,1) primary key,
    MaLoai int not null constraint fk_2 foreign key(MaLoai) references LoaiHang(MaLoai),
    TenHang nvarchar(50),
    SoLuong int,
    SoLuongCon int default 1,
)
go
create table GiaBan(
    MaGB int identity(1,1) primary key,
    MaHang int not null constraint fk_3 foreign key(MaHang) references HangHoa(MaHang),
    Gia int default 0,
    DVTinh nvarchar(30),
    NgayDB date default getdate(),
    NgayKT date default getdate()+10,

)