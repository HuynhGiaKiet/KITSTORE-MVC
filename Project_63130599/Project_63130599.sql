create database Project_63130599
go 
use Project_63130599
go

CREATE TABLE DanhMuc(
	Id varchar(20) PRIMARY KEY,
	Ten nvarchar(255) NULL,
)

CREATE TABLE DonHang(
	Id varchar(20) PRIMARY KEY,
	IdKH varchar(20) NOT NULL,
	IdPT varchar(20) NULL,
	Ten nvarchar(50) NULL,
	TrangThai varchar(50) NULL,
	DienThoai varchar(50) NULL,
	GhiChuDonHang nchar(500) NULL,
	DiaChi nchar(500) NULL,
	TongTienThanhToan decimal (18, 0) NULL,
	NgayTaoDon datetime NULL,
)

CREATE TABLE GioHang(
	Id varchar(20) PRIMARY KEY,
	IdKH varchar(20) NULL,
	NgayCapNhat datetime NULL,
	TongTien decimal(18, 0) NULL,
)

CREATE TABLE KhachHang(
	Id varchar(20) PRIMARY KEY,
	MatKhau varchar(50) NOT NULL,
	TaiKhoan varchar(50) NOT NULL,
	Ho varchar(50) NULL,
	Ten nvarchar(255) NOT NULL,
	NgaySinh date NULL,
	GioiTinh bit NULL,
	DiaChi nvarchar(255) NULL,
	Sdt varchar(15) NULL,
	NgayTao date NULL,
)

CREATE TABLE MoTaSanPham(
	Id int IDENTITY(1,1) PRIMARY KEY,
	IdSP varchar(20) NULL,
	Anh nvarchar(200) NULL,
	MoTa nvarchar(max) NULL,
)

CREATE TABLE PhuongThuc(
	Id varchar(20) PRIMARY KEY,
	TenPT nvarchar(50) NULL,
	PhiVanChuyen decimal(18, 0) NULL,
)

CREATE TABLE SanPham(
	Id varchar(20) PRIMARY KEY,
	TenSP nvarchar(255) NOT NULL,
	MoTa nvarchar(1000) NULL,
	Gia decimal(10, 0) NOT NULL,
	SoLuong int NOT NULL,
	IdDanhMuc varchar(20) NOT NULL,
	Anh varchar(200) NULL,
	NgayNhap datetime NULL,
)

CREATE TABLE SanPhamDonHang(
	Id int IDENTITY(1,1) PRIMARY KEY,
	IdSP varchar(20) NULL,
	IdDonHang varchar(20) NOT NULL,
	TenSP nvarchar(500) NOT NULL,
	Anh varchar(500) NULL,
	SoLuong int NULL,
	DanhMuc nvarchar(50) NULL,
	Gia decimal(18, 0) NULL,
)

CREATE TABLE SanPhamGioHang(
	Id int IDENTITY(1,1) PRIMARY KEY,
	IdGH varchar(20) NULL,
	IdSP varchar(20) NULL,
	SoLuong int NULL,
	Gia decimal(18, 0) NULL,
	NgayThem datetime NULL,
)

CREATE TABLE TaiKhoanAdmin(
	TaiKhoan nchar(20) ,
	MatKhau nchar(20) NOT NULL,
	Ho nvarchar(50) NOT NULL,
	Ten nchar(10) NULL,
	HinhAnh nvarchar(200) NULL,
)

insert into PhuongThuc(Id,TenPT,PhiVanChuyen)
values
('GHN',N'1',N'Giao Hàng Nhanh',23000),
('VNEXPRESS',N'VNEXPRESS',N'Thầy',35000)

insert into TaiKhoanAdmin(Taikhoan,MatKhau,Ho,Ten,HinhAnh)
values
(N'Admin1',N'1',N'Huỳnh Gia',N'Kiệt',NULL),
(N'Admin2',N'2',N'Thầy',N'Giáo',NULL)

insert into DanhMuc(Id, Ten)
values
('BMC001',N'Bo Mạch Chủ'),
('BVXL002',N'Bộ Vi Xử Lý'),
('CMH003',N'Card Màn Hình'),
('NMT004',N'Nguồn Máy Tính'),
('R005',N'Ram'),
('TN006',N'Tản Nhiệt'),
('HDD007',N'Ổ Cứng HDD'),
('SSD008',N'Ổ Cứng SSD'),
('SPK009',N'Sản Phẩm Khác')

insert into SanPham(Id,TenSP,MoTa,Gia,SoLuong,IdDanhMuc,Anh,NgayNhap)
values
('LKPC001',N'Bo mạch chủ MSI MAG B760M MORTAR II WIFI DDR5','NULL',4190000,5,'BMC001','NULL','2023-12-11'),
('LKPC002',N'Bo mạch chủ MSI PRO B760M-A WIFI DDR4','NULL',3790000,5,'BMC001','NULL','2023-12-11'),
('LKPC003',N'Bo mạch chủ ASUS PRIME B650M-A-CSM DDR5','NULL',4690000,5,'BMC001','NULL','2023-12-11'),
('LKPC004',N'Bo mạch chủ ASUS ROG MAXIMUS Z790 DARK HERO','NULL',17990000,5,'BMC001','NULL','2023-12-11'),
('LKPC005',N'Bo mạch chủ ASUS ROG MAXIMUS Z790 FORMULA','NULL',19590000,5,'BMC001','NULL','2023-12-11'),
('LKPC006',N'Bộ vi xử lý Intel Core i5 14600KF/Turbo up to 5.3GHz/14 Nhân 20 Luồng/24MB/LGA 1700','NULL',8290000,5,'BVXL002','NULL','2023-12-11'),
('LKPC007',N'Bộ vi xử lý Intel Core i5 14600K/Turbo up to 5.3GHz/14 Nhân 20 Luồng/24MB/LGA 1700','NULL',8990000,5,'BVXL002','NULL','2023-12-11'),
('LKPC008',N'Bộ vi xử lý Intel Core i7 14700KF/Turbo up to 5.6GHz/20 Nhân 28 Luồng/33MB/LGA 1700','NULL',11190000,5,'BVXL002','NULL','2023-12-11'),
('LKPC009',N'Bộ vi xử lý Intel Core i7 14700K/Turbo up to 5.6GHz/20 Nhân 28 Luồng/33MB/LGA 1700','NULL',11890000,5,'BVXL002','NULL','2023-12-11'),
('LKPC010',N'Bộ vi xử lý Intel Core i9 14900KF/Turbo up to 6.0GHz/24 Nhân 32 Luồng/36MB/LGA 1700','NULL',11890000,5,'BVXL002','NULL','2023-12-11'),
('LKPC011',N'Card màn hình GIGABYTE GeForce RTX 4060 Ti AERO OC 16G','NULL',15990000,5,'CMH003','NULL','2023-12-11'),
('LKPC012',N'Card màn hình MSI GeForce GTX 1650 4GB D6 VENTUS XS OCV3','NULL',3890000,5,'CMH003','NULL','2023-12-11'),
('LKPC013',N'Card màn hình ASUS TUF Gaming GeForce GTX 1650 V2 OC Edition 4GB GDDR6','NULL',3890000,5,'CMH003','NULL','2023-12-11'),
('LKPC014',N'Card màn hình GIGABYTE GeForce RTX 4060 Ti GAMING OC 16G','NULL',14990000,5,'CMH003','NULL','2023-12-11'),
('LKPC015',N'Card màn hình ASUS ProArt GeForce RTX 4060 OC edition 8GB','NULL',10990000,5,'CMH003','NULL','2023-12-11'),
('LKPC016',N'Nguồn máy tính MSI MAG A750GL PCIE5 - 80 Plus Gold (750W)','NULL',2690000,5,'NMT004','NULL','2023-12-11'),
('LKPC017',N'Nguồn máy tính MSI MAG A750BN PCIE5 - 80 Plus Bronze (750W)','NULL',1690000,5,'NMT004','NULL','2023-12-11'),
('LKPC018',N'Nguồn máy tính Corsair RM1200x SHIFT ATX 3.0 - 80 Plus Gold - Full Modular (1200W)','NULL',6690000,5,'NMT004','NULL','2023-12-11'),
('LKPC019',N'Nguồn máy tính ASUS ROG Thor 1000P2 EVA Edition - 80 Plus Platinum - Full Modular (1000W)','NULL',9990000,5,'NMT004','NULL','2023-12-11'),
('LKPC020',N'Nguồn máy tính Corsair RM750e ATX 3.0 - 80 Plus Gold - Full Modular (750W)','NULL',2890000,5,'NMT004','NULL','2023-12-11'),
('LKPC021',N'RAM Corsair Dominator Titanium White 32GB (2x16GB) RGB 60000 DDR5','NULL',5590000,5,'R005','NULL','2023-12-11'),
('LKPC022',N'RAM Corsair Dominator Titanium Black 32GB (2x16GB) RGB 60000 DDR5 ','NULL',5590000,5,'R005','NULL','2023-12-11'),
('LKPC023',N'RAM PNY XLR8 MAKO 2x16GB 6000 RGB White D5','NULL',3590000,5,'R005','NULL','2023-12-11'),
('LKPC024',N'RAM G.Skill Trident Z5 RGB 64GB (2x32GB) 6000 DDR5 Silver','NULL',7490000,5,'R005','NULL','2023-12-11'),
('LKPC025',N'RAM G.Skill Ripjaws V 1x8G 3600','NULL',650000,5,'R005','NULL','2023-12-11'),
('LKPC026',N'Thiết bị tản nhiệt MSI MAG CORELIQUID E360 BLACK','NULL',3290000,5,'TN006','NULL','2023-12-11'),
('LKPC027',N'Thiết bị tản nhiệt MSI MAG CORELIQUID E240 BLACK','NULL',2690000,5,'TN006','NULL','2023-12-11'),
('LKPC028',N'Tản nhiệt nước Lian Li Galahad II LCD Trinity 360 SL-INF White','NULL',7990000,5,'TN006','NULL','2023-12-11'),
('LKPC029',N'Tản nhiệt nước Lian Li Galahad II LCD Trinity 360 SL-INF Black','NULL',7990000,5,'TN006','NULL','2023-12-11'),
('LKPC030',N'Tản nhiệt nước Corsair iCUE LINK H150i RGB White','NULL',6250000,5,'TN006','NULL','2023-12-11'),
('LKPC031',N'Ổ Cứng HDD WD 4TB Blue','NULL',2690000,5,'HDD007','NULL','2023-12-11'),
('LKPC032',N'Ổ Cứng HDD WD Red Plus 6TB 5400RPM','NULL',5190000,5,'HDD007','NULL','2023-12-11'),
('LKPC033',N'Ổ Cứng HDD WD 2TB Black','NULL',3390000,5,'HDD007','NULL','2023-12-11'),
('LKPC034',N'Ổ Cứng HDD WD 1TB Blue','NULL',1290000,5,'HDD007','NULL','2023-12-11'),
('LKPC035',N'Ổ Cứng HDD Seagate 1TB 2.5" for Laptop - ST1000LM048','NULL',1390000,5,'HDD007','NULL','2023-12-11'),
('LKPC036',N'Ổ cứng SSD Corsair MP600 CORE XT 2TB PCIe 4.0 Gen4','NULL',3490000,5,'SSD008','NULL','2023-12-11'),
('LKPC037',N'Ổ cứng SSD Corsair MP600 CORE XT 1TB PCIe 4.0 Gen4','NULL',1790000,5,'SSD008','NULL','2023-12-11'),
('LKPC038',N'Ổ cứng SSD MSI SPATIUM M480 PRO PCIe 4.0 NVMe M.2 1TB','NULL',2190000,5,'SSD008','NULL','2023-12-11'),
('LKPC039',N'Ổ cứng SSD MSI Spatium S270 960GB SATA3','NULL',1190000,5,'SSD008','NULL','2023-12-11'),
('LKPC040',N'Ổ cứng SSD MSI Spatium M450 500GB M.2 PCIe NVMe Gen 4.0','NULL',990000,5,'SSD008','NULL','2023-12-11'),
('LKPC041',N'Vỏ máy tính NZXT H6 Flow Black','NULL',2590000,5,'SPK009','NULL','2023-12-11'),
('LKPC042',N'Phụ kiện USB SanDisk Ultra Flair CZ73 32GB','NULL',119000,5,'SPK009','NULL','2023-12-11'),
('LKPC043',N'Mic Razer Seiren X Microphone for PS4','NULL',3490000,5,'SPK009','NULL','2023-12-11'),
('LKPC044',N'Webcam Logitech Brio 4k','NULL',4500000,5,'SPK009','NULL','2023-12-11'),
('LKPC045',N'Đèn thông minh Nanoleaf Canvas Vuông 4 miếng (Bộ mở rộng)','NULL',1790000,5,'SPK009','NULL','2023-12-11')

