use master
go

drop DATABASE if exists QUANLYTIEMCHUNG
go

CREATE DATABASE QUANLYTIEMCHUNG
go

use QUANLYTIEMCHUNG
go

CREATE TABLE QuyenTruyCap (
    idQuyen INTEGER PRIMARY KEY NOT NULL,
    mucTruyCap NVARCHAR(20) NOT NULL,
	moTa NTEXT
);
GO

CREATE TABLE TaiKhoan (
    idTK INTEGER PRIMARY KEY NOT NULL,
    userName VARCHAR(100) NOT NULL,
    passWord VARCHAR(100) NOT NULL,
	idQuyen INTEGER FOREIGN KEY REFERENCES QuyenTruyCap(idQuyen)
		on delete
			cascade
		on update
			cascade
);
GO

CREATE TABLE DonVi (
    idDonVi INTEGER PRIMARY KEY NOT NULL,
    tenDonVi NVARCHAR(100) NOT NULL,
    moTa NTEXT
);
GO

CREATE TABLE ChucVu (
    idChucVu INTEGER PRIMARY KEY NOT NULL,
    tenChucVu NVARCHAR(100) NOT NULL,
    moTa NTEXT
);
GO

CREATE TABLE ThongTinCanBo (
    idCanBo INTEGER PRIMARY KEY,
    hoTen NVARCHAR(30) NOT NULL,
    SDT CHAR(10) NOT NULL,
    eMail VARCHAR(50) NOT NULL,
    CCCD CHAR(15) NOT NULL,
    diaChi NTEXT,
    gioiTinh NVARCHAR(5),
    idChucVu INTEGER FOREIGN KEY REFERENCES ChucVu(idChucVu)
		on delete
			cascade
		on update
			cascade,
    idTaiKhoan INTEGER FOREIGN KEY REFERENCES TaiKhoan(idTK)
		on delete
			cascade
		on update
			cascade,
    idDonVi INTEGER FOREIGN KEY REFERENCES DonVi(idDonVi)
		on delete
			cascade
		on update
			cascade
);
GO

CREATE TABLE Vaccine (
    idVaccine INTEGER PRIMARY KEY,
    tenVaccine NVARCHAR(100) NOT NULL,
	nuocSanXuat NVARCHAR(100) NOT NULL,
	nhaSanXuat NVARCHAR(100) NOT NULL,
	moTaBenh NTEXT,
	kyTiem INTEGER DEFAULT 0,
	soLuongMuiTiem INTEGER DEFAULT 0,
    soLuongConLai INTEGER DEFAULT 0
);
GO

CREATE TABLE PhieuNhap (
    idPhieuNhap INTEGER PRIMARY KEY,
    ngayNhap DATE NOT NULL,
	tongSoLuongNhap INTEGER DEFAULT 0,
	ghiChu NTEXT,
	idCanBo INTEGER FOREIGN KEY REFERENCES ThongTinCanBo(idCanBo)
		on delete
			cascade
		on update
			cascade
);
GO

CREATE TABLE ChiTietPhieuNhap (
    idPhieuNhap INTEGER FOREIGN KEY REFERENCES PhieuNhap(idPhieuNhap)
		on delete
			cascade
		on update
			cascade,
	idVaccine INTEGER FOREIGN KEY REFERENCES Vaccine(idVaccine)
		on delete
			cascade
		on update
			cascade,
    ngaySanXuat DATE NOT NULL,
	ngayHetHan DATE NOT NULL,
    soLuongNhap INTEGER NOT NULL DEFAULT 0,
	loSanXuat INTEGER DEFAULT 0,
	PRIMARY KEY(idPhieuNhap, idVaccine)
);
GO

CREATE TABLE PhieuXuat (
    idPhieuXuat INTEGER PRIMARY KEY,
    ngayXuat DATE NOT NULL,
	tongSoLuongXuat INTEGER DEFAULT 0,
	ghiChu NTEXT,
	idCanBo INTEGER FOREIGN KEY REFERENCES ThongTinCanBo(idCanBo)
		on delete
			cascade
		on update
			cascade
);
GO

CREATE TABLE ChiTietPhieuXuat (
    idPhieuXuat INTEGER FOREIGN KEY REFERENCES PhieuXuat(idPhieuXuat)
		on delete
			cascade
		on update
			cascade,
	idVaccine INTEGER FOREIGN KEY REFERENCES Vaccine(idVaccine)
		on delete
			cascade
		on update
			cascade,
    soLuongXuat INTEGER NOT NULL DEFAULT 0,
	PRIMARY KEY(idPhieuXuat, idVaccine)
);
GO

CREATE TABLE QuanHuyen (
    idQuanHuyen INTEGER PRIMARY KEY,
    tenQuanHuyen NVARCHAR(50) NOT NULL,
	moTa TEXT
);
GO

CREATE TABLE PhuongXa (
    idPhuongXa INTEGER PRIMARY KEY,
	idQuanHuyen INTEGER FOREIGN KEY REFERENCES QuanHuyen(idQuanHuyen)
		on delete
			cascade
		on update
			cascade,
    tenPhuongXa NVARCHAR(50) NOT NULL,
	moTa NTEXT
);
GO

CREATE TABLE NguoiGiamHo (
    idNguoiGiamHo VARCHAR(10) PRIMARY KEY,
    hoTen NVARCHAR(50) NOT NULL,
	moiQuanHe NVARCHAR(20) NOT NULL,
	SDT NVARCHAR(10) NOT NULL,
	soNha NVARCHAR(50),
	idPhuongXa INTEGER FOREIGN KEY REFERENCES PhuongXa(idPhuongXa)
		on delete
			cascade
		on update
			cascade
);
GO

CREATE TABLE Tre (
    idTre VARCHAR(10) PRIMARY KEY,
    idNguoiGiamHo VARCHAR(10) FOREIGN KEY REFERENCES NguoiGiamHo(idNguoiGiamHo)
		on delete
			cascade
		on update
			cascade,
	hoTen NVARCHAR(50) NOT NULL,
	ngaySinh DATE NOT NULL,
	chieuCao VARCHAR(3),
	canNang VARCHAR(3)
);
GO

CREATE TABLE ChiTietTiemChung (
  idMuiTiem INTEGER PRIMARY KEY,
  idTre VARCHAR(10) FOREIGN KEY REFERENCES Tre(idTre)
		on delete
			cascade
		on update
			cascade, 
  idVaccine INTEGER FOREIGN KEY REFERENCES Vaccine(idVaccine)
		on delete
			cascade
		on update
			cascade,
  ngayTiem DATE NOT NULL,
  tinhTrang NVARCHAR(100),
  thuTuMuiTiem INTEGER DEFAULT 0,
  idCanBo INTEGER FOREIGN KEY REFERENCES ThongTinCanBo(idCanBo)
		on delete
			cascade
		on update
			cascade
);
GO



--insert dữ liệu 
-- bảng quyền truy cập
INSERT INTO QuyenTruyCap (idQuyen, mucTruyCap, moTa) VALUES
(1, 'Thành Phố', 'Cấp Thành Phố'),
(2, 'Phường,Xã', 'Cấp Phường,Xã');


-- bảng tài khoản 
INSERT INTO TaiKhoan (idTK, userName, passWord, idQuyen) VALUES
(1, 'phuongxa', 'phuongxa123', 1),
(2, 'thanhpho', 'thanhpho123', 2);

-- bảng đơn vị
INSERT INTO DonVi (idDonVi, tenDonVi, moTa) VALUES
(1, 'Phòng Kế toán', 'Quản lý tài chính và kế toán'),
(2, 'Phòng Hành chính', 'Quản lý hành chính và văn thư'),
(3, 'Phòng Nhân sự', 'Quản lý nhân sự và đào tạo'),
(4, 'Phòng Y tế', 'Quản lý y tế và sức khỏe'),
(5, 'Phòng IT', 'Quản lý hệ thống và công nghệ thông tin'),
(6, 'Phòng Marketing', 'Quản lý marketing và quảng cáo'),
(7, 'Phòng Kinh doanh', 'Quản lý kinh doanh và bán hàng'),
(8, 'Phòng Kỹ thuật', 'Quản lý kỹ thuật và sản xuất'),
(9, 'Phòng Dịch vụ Khách hàng', 'Quản lý dịch vụ khách hàng'),
(10, 'Phòng Nghiên cứu và Phát triển', 'Quản lý nghiên cứu và phát triển sản phẩm');

-- bảng chức vụ
INSERT INTO ChucVu (idChucVu, tenChucVu, moTa) VALUES
(1, N'Giám đốc', N'Người quản lý toàn bộ công ty'),
(2, N'Phó giám đốc', N'Người hỗ trợ giám đốc'),
(3, N'Trưởng phòng', N'Người đứng đầu một phòng ban'),
(4, N'Phó phòng', N'Người hỗ trợ trưởng phòng'),
(5, N'Nhân viên', N'Nhân viên bình thường'),
(6, N'Kế toán trưởng', N'Người quản lý công việc kế toán'),
(7, N'Trưởng nhóm', N'Người đứng đầu một nhóm làm việc'),
(8, N'Chuyên viên', N'Người có chuyên môn cao trong một lĩnh vực cụ thể'),
(9, N'Trợ lý', N'Người hỗ trợ trong các công việc hành chính và chuyên môn'),
(10, N'Kỹ sư', N'Người làm các công việc liên quan đến kỹ thuật và công nghệ');

-- bảng thông tin cán bộ
INSERT INTO ThongTinCanBo (idCanBo, hoTen, SDT, eMail, CCCD, diaChi, gioiTinh, idChucVu, idTaiKhoan, idDonVi) VALUES
(1, N'Nguyễn Văn A', '0123456789', 'nguyenvana@example.com', '123456789012345', N'123 Đường A, Quận 1, TP.HCM', N'Nam', 1, 1, 1),
(2, N'Trần Thị B', '0987654321', 'tranthib@example.com', '987654321098765', N'456 Đường B, Quận 2, TP.HCM', N'Nữ', 2, 2, 2),
(3, N'Lê Văn C', '0123456781', 'levanc@example.com', '123456789012346', N'789 Đường C, Quận 3, TP.HCM', N'Nam', 3, 1, 3),
(4, N'Phạm Thị D', '0987654322', 'phamthid@example.com', '987654321098766', N'321 Đường D, Quận 4, TP.HCM', N'Nữ', 4, 2, 4),
(5, N'Hoàng Văn E', '0123456782', 'hoangvane@example.com', '123456789012347', N'654 Đường E, Quận 5, TP.HCM', N'Nam', 5, 1, 5),
(6, N'Vũ Thị F', '0987654323', 'vuthif@example.com', '987654321098767', N'987 Đường F, Quận 6, TP.HCM', N'Nữ', 6, 2, 6),
(7, N'Đỗ Văn G', '0123456783', 'dovang@example.com', '123456789012348', N'111 Đường G, Quận 7, TP.HCM', N'Nam', 7, 1, 7),
(8, N'Bùi Thị H', '0987654324', 'buithih@example.com', '987654321098768', N'222 Đường H, Quận 8, TP.HCM', N'Nữ', 8, 2, 8),
(9, N'Ngô Văn I', '0123456784', 'ngovani@example.com', '123456789012349', N'333 Đường I, Quận 9, TP.HCM', N'Nam', 9, 1, 9),
(10, N'Đào Thị J', '0987654325', 'daothij@example.com', '987654321098769', N'444 Đường J, Quận 10, TP.HCM', N'Nữ', 10, 2, 10);

-- Insert dữ liệu vào bảng Vaccine với tên Vaccine và số liệu phù hợp cho trẻ dưới 6 tuổi
-- Insert dữ liệu vào bảng Vaccine với tên Vaccine và số liệu phù hợp cho trẻ dưới 6 tuổi
INSERT INTO Vaccine (idVaccine, tenVaccine, nuocSanXuat, nhaSanXuat, moTaBenh, kyTiem, soLuongMuiTiem,soLuongConLai)
VALUES
(2, N'Flu dành cho trẻ dưới 6 tuổi', N'Pháp', N'Sanofi Pasteur', N'Phòng chống cúm cho trẻ em', 1, 1,100),
(3, N'Polio dành cho trẻ dưới 6 tuổi', N'Mỹ', N'Centers for Disease Control and Prevention', N'Phòng chống bệnh bại liệt cho trẻ em', 1, 2,200),
(4, N'Rotavirus dành cho trẻ dưới 6 tuổi', N'Hoa Kỳ', N'Merck & Co.', N'Phòng chống bệnh viêm ruột do Rotavirus cho trẻ em', 2, 2,250),
(5, N'Haemophilus influenzae type b (Hib) dành cho trẻ dưới 6 tuổi', N'Anh', N'GlaxoSmithKline', N'Phòng chống bệnh viêm nhiễm đường hô hấp cho trẻ em', 1, 3,300),
(6, N'Measles dành cho trẻ dưới 6 tuổi', N'Hoa Kỳ', N'Merck & Co.', N'Phòng chống bệnh sởi cho trẻ em', 1, 2,300),
(7, N'Mumps dành cho trẻ dưới 6 tuổi', N'Hoa Kỳ', N'Merck & Co.', N'Phòng chống bệnh quai bị cho trẻ em', 1, 2,500),
(8, N'Chickenpox dành cho trẻ dưới 6 tuổi', N'Hoa Kỳ', N'Merck & Co.', N'Phòng chống bệnh thủy đậu cho trẻ em', 1, 2,300),
(9, N'Typhoid dành cho trẻ dưới 6 tuổi', N'Ấn Độ', N'Bharat Biotech', N'Phòng chống bệnh sốt thương hàn cho trẻ em', 1, 2,259),
(10, N'Diphtheria dành cho trẻ dưới 6 tuổi', N'Pháp', N'Sanofi Pasteur', N'Phòng chống bệnh bạch hầu cho trẻ em', 1, 2,159);

-- Insert dữ liệu vào bảng PhieuNhap với các giá trị ngày tháng
INSERT INTO PhieuNhap (idPhieuNhap, ngayNhap, tongSoLuongNhap, ghiChu, idCanBo)
VALUES
(11, '2024-08-20', 800, N'Nhập vaccine mới cho đợt tiêm chủng', 3),
(12, '2024-08-25', 1000, N'Nhập thêm vaccine dự trữ', 4),
(13, '2024-09-05', 1200, N'Nhập vaccine cần thiết', 5),
(14, '2024-09-10', 1500, N'Nhập thêm vaccine cho đợt tiêm chủng', 6),
(15, '2024-09-15', 900, N'Nhập vaccine dự trữ', 7),
(16, '2024-09-20', 1100, N'Nhập vaccine mới', 8),
(17, '2024-09-25', 1300, N'Nhập thêm vaccine cho đợt tiêm chủng', 9),
(18, '2024-10-05', 800, N'Nhập vaccine cần thiết', 10),
(19, '2024-10-10', 1000, N'Nhập thêm vaccine dự trữ', 2),
(20, '2024-10-15', 1200, N'Nhập vaccine mới', 1);

-- Insert dữ liệu vào bảng ChiTietPhieuNhap
INSERT INTO ChiTietPhieuNhap (idPhieuNhap, idVaccine, ngaySanXuat, ngayHetHan, soLuongNhap, loSanXuat)
VALUES
(11, 2, '2024-08-01', '2024-12-01', 200, 1),
(12, 3, '2024-08-05', '2024-12-05', 300, 2),
(13, 4, '2024-09-01', '2024-12-01', 400, 1),
(14, 5, '2024-09-05', '2024-12-05', 500, 2),
(15, 6, '2024-09-10', '2024-12-10', 600, 1),
(16, 7, '2024-09-15', '2024-12-15', 700, 2),
(17, 8, '2024-09-20', '2024-12-20', 800, 1),
(18, 9, '2024-10-01', '2024-12-01', 900, 2),
(19, 10, '2024-10-05', '2024-12-05', 1000, 1),
(20, 2, '2024-10-10', '2024-12-10', 1100, 2);

-- Insert dữ liệu vào bảng PhieuXuat
INSERT INTO PhieuXuat (idPhieuXuat, ngayXuat, tongSoLuongXuat, ghiChu, idCanBo)
VALUES
(1, '2024-08-20', 200, N'Xuất vaccine cho đợt tiêm chủng', 1),
(2, '2024-08-25', 300, N'Xuất vaccine cho đợt tiêm chủng', 2),
(3, '2024-09-05', 400, N'Xuất vaccine cho đợt tiêm chủng', 3),
(4, '2024-09-10', 500, N'Xuất vaccine cho đợt tiêm chủng', 4),
(5, '2024-09-15', 600, N'Xuất vaccine cho đợt tiêm chủng', 5),
(6, '2024-09-20', 700, N'Xuất vaccine cho đợt tiêm chủng', 6),
(7, '2024-09-25', 800, N'Xuất vaccine cho đợt tiêm chủng', 7),
(8, '2024-10-05', 900, N'Xuất vaccine cho đợt tiêm chủng', 8),
(9, '2024-10-10', 1000, N'Xuất vaccine cho đợt tiêm chủng', 9),
(10, '2024-10-15', 1100, N'Xuất vaccine cho đợt tiêm chủng', 10);

-- Insert dữ liệu vào bảng ChiTietPhieuXuat
INSERT INTO ChiTietPhieuXuat (idPhieuXuat, idVaccine, soLuongXuat)
VALUES
(1, 2, 10000),
(2, 3, 20000),
(3, 4, 30000),
(4, 5, 40000),
(5, 6, 30000),
(6, 7, 20000),
(7, 8, 10000),
(8, 9, 17880),
(9, 10, 77777),
(10, 2,66663);

-- Insert dữ liệu vào bảng QuanHuyen
INSERT INTO QuanHuyen (idQuanHuyen, tenQuanHuyen, moTa) VALUES
(1, N'Quận 1', N'Quận trung tâm thành phố'),
(2, N'Quận 2', N'Quận ven sông sài gòn'),
(3, N'Quận 3', N'Quận trung tâm thành phố'),
(4, N'Quận 4', N'Quận ven sông sài gòn'),
(5, N'Quận 5', N'Quận trung tâm thành phố'),
(6, N'Quận 6', N'Quận ngoại ô'),
(7, N'Quận 7', N'Quận ngoại ô'),
(8, N'Quận 8', N'Quận ven sông sài gòn'),
(9, N'Quận 9', N'Quận ngoại ô'),
(10, N'Quận 10', N'Quận trung tâm thành phố');

INSERT INTO PhuongXa (idPhuongXa, idQuanHuyen, tenPhuongXa, moTa) VALUES
(1, 1, N'Phường Bến Nghé', N'Phường trung tâm'),
(2, 1, N'Phường Cầu Kho', N'Phường trung tâm'),
(3, 1, N'Phường Cô Giang', N'Phường trung tâm'),
(4, 2, N'Phường Thảo Điền', N'Phường ven sông sài gòn'),
(5, 2, N'Phường An Phú', N'Phường ven sông sài gòn'),
(6, 2, N'Phường Bình An', N'Phường ven sông sài gòn'),
(7, 3, N'Phường Bến Thành', N'Phường trung tâm'),
(8, 3, N'Phường Cầu Ông Lãnh', N'Phường trung tâm'),
(9, 3, N'Phường Cầu Kho', N'Phường trung tâm'),
(10, 4, N'Phường Cô Giang', N'Phường ven sông sài gòn');

-- Insert dữ liệu vào bảng NguoiGiamHo
INSERT INTO NguoiGiamHo (idNguoiGiamHo, hoTen, moiQuanHe, SDT, soNha, idPhuongXa)
VALUES
('NGH001', N'Nguyễn Văn Parent', N'Bố', '0123456789', N'123 Đường A, Quận 1', 1),
('NGH002', N'Nguyễn Thị Guardian', N'Mẹ', '0987654321', N'456 Đường B, Quận 2', 2),
('NGH003', N'Nguyễn Văn Custodian', N'Giám hộ', '0123456781', N'789 Đường C, Quận 3', 3),
('NGH004', N'Nguyễn Thị Foster', N'Người nuôi dưỡng', '0987654322', N'321 Đường D, Quận 4', 4),
('NGH005', N'Nguyễn Văn Caretaker', N'Người chăm sóc', '0123456782', N'654 Đường E, Quận 5', 5),
('NGH006', N'Nguyễn Thị Guardian', N'Người giám hộ', '0987654323', N'987 Đường F, Quận 6', 6),
('NGH007', N'Nguyễn Văn Warden', N'Người bảo quản', '0123456783', N'111 Đường G, Quận 7', 7),
('NGH008', N'Nguyễn Thị Guardian', N'Bố mẹ nuôi', '0987654324', N'222 Đường H, Quận 8', 8),
('NGH009', N'Nguyễn Văn Keeper', N'Người giữ gìn', '0123456784', N'333 Đường I, Quận 9', 9),
('NGH010', N'Nguyễn Thị Guardian', N'Người giám hộ', '0987654325', N'444 Đường J, Quận 10', 10);

-- Insert dữ liệu vào bảng Tre
INSERT INTO Tre (idTre, idNguoiGiamHo, hoTen, ngaySinh, chieuCao, canNang)
VALUES
('T001', 'NGH001', N'Nguyễn Văn Child', '2019-01-01', '75', '10'),
('T002', 'NGH002', N'Nguyễn Thị Infant', '2020-02-02', '65', '9'),
('T003', 'NGH003', N'Nguyễn Văn Toddler', '2021-03-03', '80', '12'),
('T004', 'NGH004', N'Nguyễn Thị Kid', '2022-04-04', '85', '14'),
('T005', 'NGH005', N'Nguyễn Văn Baby', '2023-05-05', '70', '11'),
('T006', 'NGH006', N'Nguyễn Thị Boy', '2019-01-01', '75', '10'),
('T007', 'NGH007', N'Nguyễn Văn Girl', '2020-02-02', '65', '9'),
('T008', 'NGH008', N'Nguyễn Thị Child', '2021-03-03', '80', '12'),
('T009', 'NGH009', N'Nguyễn Văn Infant', '2022-04-04', '85', '14'),
('T010', 'NGH010', N'Nguyễn Thị Baby', '2023-05-05', '70', '11');

-- Insert dữ liệu vào bảng ChiTietTiemChung
INSERT INTO ChiTietTiemChung (idMuiTiem, idTre, idVaccine, ngayTiem, tinhTrang, thuTuMuiTiem, idCanBo)
VALUES
(1, 'T001', 2, '2024-08-20', N'Bình thường', 1, 1),
(2, 'T002', 3, '2024-08-25', N'Bình thường', 1, 2),
(3, 'T003', 4, '2024-09-05', N'Bình thường', 1, 3),
(4, 'T004', 5, '2024-09-10', N'Bình thường', 1, 4),
(5, 'T005', 6, '2024-09-15', N'Bình thường', 1, 5),
(6, 'T006', 7, '2024-09-20', N'Bình thường', 1, 6),
(7, 'T007', 8, '2024-09-25', N'Bình thường', 1, 7),
(8, 'T008', 9, '2024-10-05', N'Bình thường', 1, 8),
(9, 'T009', 10, '2024-10-10', N'Bình thường', 1, 9),
(10, 'T010', 2, '2024-10-15', N'Bình thường', 1, 10);


--trigger

CREATE TRIGGER trgAfterInsertChiTietTiemChung
ON ChiTietTiemChung
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Vaccine
    SET soLuongConLai = soLuongConLai - 1
    FROM Vaccine v
    JOIN inserted i ON v.idVaccine = i.idVaccine;
END;
GO

CREATE TRIGGER trgAfterUpdateChiTietTiemChung
ON ChiTietTiemChung
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @oldIdVaccine INT, @newIdVaccine INT;

    SELECT @oldIdVaccine = d.idVaccine FROM deleted d;
    SELECT @newIdVaccine = i.idVaccine FROM inserted i;

    -- Nếu idVaccine thay đổi, cập nhật số lượng của vaccine cũ và mới
    IF @oldIdVaccine <> @newIdVaccine
    BEGIN
        UPDATE Vaccine
        SET soLuongConLai = soLuongConLai + 1
        WHERE idVaccine = @oldIdVaccine;

        UPDATE Vaccine
        SET soLuongConLai = soLuongConLai - 1
        WHERE idVaccine = @newIdVaccine;
    END
END;
GO


CREATE TRIGGER trgAfterDeleteChiTietTiemChung
ON ChiTietTiemChung
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Vaccine
    SET soLuongConLai = soLuongConLai + 1
    FROM Vaccine v
    JOIN deleted d ON v.idVaccine = d.idVaccine;
END;
GO

-- vaccine va chitietphieuxuat
CREATE TRIGGER trgAfterInsertVaccine
ON Vaccine
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @idVaccine INT, @soLuongConLai INT;
    
    SELECT @idVaccine = idVaccine, @soLuongConLai = soLuongConLai
    FROM inserted;

    UPDATE ChiTietPhieuXuat
    SET soLuongXuat = soLuongXuat - @soLuongConLai
    WHERE idVaccine = @idVaccine;
END;
GO

CREATE TRIGGER trgAfterUpdateVaccine
ON Vaccine
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @idVaccine INT, @oldSoLuongConLai INT, @newSoLuongConLai INT;
    
    SELECT @idVaccine = i.idVaccine, @oldSoLuongConLai = d.soLuongConLai, @newSoLuongConLai = i.soLuongConLai
    FROM inserted i
    JOIN deleted d ON i.idVaccine = d.idVaccine;

    UPDATE ChiTietPhieuXuat
    SET soLuongXuat = soLuongXuat - (@newSoLuongConLai - @oldSoLuongConLai)
    WHERE idVaccine = @idVaccine;
END;
GO

CREATE TRIGGER trgAfterDeleteVaccine
ON Vaccine
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @idVaccine INT, @soLuongConLai INT;

    SELECT @idVaccine = idVaccine, @soLuongConLai = soLuongConLai
    FROM deleted;

    UPDATE ChiTietPhieuXuat
    SET soLuongXuat = soLuongXuat - @soLuongConLai
    WHERE idVaccine = @idVaccine;
END;
GO

--triger phieuxuat,chitietphieuxuat


select * from ChiTietTiemChung
select * from Vaccine
select * from ChiTietPhieuXuat
select * from PhieuXuat


CREATE PROCEDURE TongTreTiemTatCaVaccine
AS
BEGIN
    SELECT v.idVaccine, v.tenVaccine, COUNT(DISTINCT c.idTre) AS SoLuongTreTiem
    FROM Vaccine v
    LEFT JOIN ChiTietTiemChung c ON v.idVaccine = c.idVaccine
    GROUP BY v.idVaccine, v.tenVaccine;
END;
EXEC TongTreTiemTatCaVaccine;