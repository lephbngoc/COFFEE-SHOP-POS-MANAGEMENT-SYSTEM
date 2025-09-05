
USE CafeShopManagement;
GO

-- Bảng khách hàng
CREATE TABLE KhachHang (
    KhachHangID INT IDENTITY(1,1) PRIMARY KEY,
    TenKhachHang NVARCHAR(100),
    SoDienThoai NVARCHAR(20) UNIQUE,
    DiemTichLuy INT DEFAULT 0
);

-- Bảng buzzer
CREATE TABLE Buzzer (
    BuzzerID INT IDENTITY(1,1) PRIMARY KEY,
    SoBuzzer NVARCHAR(10) UNIQUE,
    TrangThai BIT DEFAULT 0 -- 0: rảnh, 1: đang sử dụng
);

INSERT INTO Buzzer (SoBuzzer, TrangThai) VALUES ('01', 0);
INSERT INTO Buzzer (SoBuzzer, TrangThai) VALUES ('02', 0);
INSERT INTO Buzzer (SoBuzzer, TrangThai) VALUES ('03', 0);
INSERT INTO Buzzer (SoBuzzer, TrangThai) VALUES ('04', 0);
INSERT INTO Buzzer (SoBuzzer, TrangThai) VALUES ('05', 0);

-- Bảng hóa đơn
CREATE TABLE HoaDon (
    HoaDonID INT IDENTITY(1,1) PRIMARY KEY,
    MaHoaDon NVARCHAR(20) UNIQUE,
    NgayGio DATETIME DEFAULT GETDATE(),
    LoaiHoaDon NVARCHAR(20), -- 'TaiCho', 'MangDi'
    KhachHangID INT NULL, -- Có thể null nếu là shipper hoặc khách lạ
    BuzzerID INT NULL, -- Chỉ dùng cho tại chỗ
    GiamGia FLOAT DEFAULT 0, -- %
    TongTien MONEY,
    FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID),
    FOREIGN KEY (BuzzerID) REFERENCES Buzzer(BuzzerID)
);

CREATE TABLE NhomMon (
    NhomMonID INT IDENTITY(1,1) PRIMARY KEY,
    TenNhom NVARCHAR(50)
);
INSERT INTO NhomMon (TenNhom) VALUES (N'Đồ uống');
INSERT INTO NhomMon (TenNhom) VALUES (N'Đồ ăn');

DELETE FROM NhomMon WHERE NhomMonID = 3;
DELETE FROM NhomMon WHERE NhomMonID = 4;
-- Giả sử: Đồ uống = 1, Đồ ăn = 2

-- Bảng món ăn/đồ uống
CREATE TABLE Mon (
    MonID INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100),
    DonGia MONEY
);

ALTER TABLE Mon ADD NhomMonID INT;
ALTER TABLE Mon ADD CONSTRAINT FK_Mon_NhomMon FOREIGN KEY (NhomMonID) REFERENCES NhomMon(NhomMonID);
ALTER TABLE Mon ADD HangTon INT DEFAULT 0;

INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Cà phê sữa', 25000, 1, 50);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Cà phê đen', 20000, 1, 60);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Trà đào', 30000, 1, 40);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Trà sữa', 35000, 1, 35);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Sinh tố bơ', 40000, 1, 20);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Nước cam', 30000, 1, 25);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Nước chanh', 25000, 1, 30);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Soda chanh', 28000, 1, 15);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Lipton đá', 22000, 1, 18);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Bạc xỉu', 27000, 1, 22);

INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Bánh mì trứng', 20000, 2, 40);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Bánh ngọt', 25000, 2, 35);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Xôi mặn', 30000, 2, 25);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Bánh bao', 18000, 2, 30);
INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon) VALUES (N'Bánh flan', 15000, 2, 28);

-- Bảng chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    ChiTietID INT IDENTITY(1,1) PRIMARY KEY,
    HoaDonID INT,
    MonID INT,
    SoLuong INT,
    ThanhTien MONEY,
	GhiChu NVARCHAR(200) NULL,
    FOREIGN KEY (HoaDonID) REFERENCES HoaDon(HoaDonID),
    FOREIGN KEY (MonID) REFERENCES Mon(MonID)
);

ALTER TABLE ChiTietHoaDon
DROP COLUMN GhiChu;

ALTER TABLE HoaDon
DROP COLUMN LoaiHoaDon;

ALTER TABLE HoaDon
ADD GhiChu NVARCHAR(200) NULL;

-- Bảng loại khách (phân biệt khách hàng, shipper)
CREATE TABLE LoaiKhach (
    LoaiKhachID INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(20) -- 'KhachHang', 'Shipper'
);

INSERT INTO LoaiKhach (TenLoai) VALUES (N'Tại chỗ');
INSERT INTO LoaiKhach (TenLoai) VALUES (N'Shipper');
INSERT INTO LoaiKhach (TenLoai) VALUES (N'Mang đi');




CREATE TABLE KhuyenMai (
    KhuyenMaiID INT IDENTITY(1,1) PRIMARY KEY,
    TenKhuyenMai NVARCHAR(100),
    PhanTramGiam FLOAT,
    NgayBatDau DATETIME,
    NgayKetThuc DATETIME,
    DieuKien NVARCHAR(200)
);

ALTER TABLE HoaDon
ADD KhuyenMaiID INT NULL
FOREIGN KEY (KhuyenMaiID) REFERENCES KhuyenMai(KhuyenMaiID);

CREATE TABLE LichSuDiem (
    LichSuDiemID INT IDENTITY(1,1) PRIMARY KEY,
    KhachHangID INT,
    NgayGio DATETIME DEFAULT GETDATE(),
    DiemThayDoi INT,
    LyDo NVARCHAR(200),
    FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID)
);
CREATE TABLE NhanVien (
    NhanVienID INT IDENTITY(1,1) PRIMARY KEY,
    MaNhanVien NVARCHAR(50) UNIQUE,
    TenNhanVien NVARCHAR(100),
    MatKhau NVARCHAR(100),
    VaiTro NVARCHAR(50)
);

INSERT INTO NhanVien (MaNhanVien, TenNhanVien, MatKhau, VaiTro)
VALUES 
('NV1', N'Nguyễn Văn A', '1', N'Quản lý'),
('NV2', N'Lê Thị B', '2', N'Nhân viên'),
('NV3', N'Bùi Ngọc C', '3', N'Nhân viên');

ALTER TABLE HoaDon
ADD NhanVienID INT,
FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID);

ALTER TABLE ChiTietHoaDon
ADD NhanVienID INT,
FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID);



SELECT 
    Mon.MonID, 
    Mon.TenMon, 
    Mon.DonGia, 
    NhomMon.TenNhom, 
    Mon.HangTon
FROM 
    Mon
JOIN 
    NhomMon ON Mon.NhomMonID = NhomMon.NhomMonID

SELECT CAST(DonGia AS float) AS DonGia FROM Mon

select * from NhomMon
select * from HoaDon

-- Sửa kiểu dữ liệu của cột TongTien trong bảng HoaDon
ALTER TABLE HoaDon
ALTER COLUMN TongTien DECIMAL(18,0);

-- Sửa kiểu dữ liệu của cột DonGia trong bảng Mon
ALTER TABLE Mon
ALTER COLUMN DonGia DECIMAL(18,0);

-- Sửa kiểu dữ liệu của cột ThanhTien trong bảng ChiTietHoaDon
ALTER TABLE ChiTietHoaDon
ALTER COLUMN ThanhTien DECIMAL(18,0);

SELECT MaHoaDon, NgayGio 
FROM HoaDon 
ORDER BY NgayGio DESC


-- Kiểm tra các bảng hiện có
SELECT * FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

-- Kiểm tra các stored procedures hiện có
SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_TYPE = 'PROCEDURE';
-----------NÂNG CAO:-------------------






----------FORM LOGIN-------------------------
GO
CREATE PROCEDURE sp_DangNhap
    @MaNhanVien NVARCHAR(50),
    @MatKhau NVARCHAR(100)
AS
BEGIN
    SELECT NhanVienID, MaNhanVien, TenNhanVien, VaiTro
    FROM NhanVien
    WHERE MaNhanVien = @MaNhanVien 
    AND MatKhau = @MatKhau;
END
GO
-- Test thử cái đầu tiên
EXEC sp_DangNhap @MaNhanVien = 'NV1', @MatKhau = '1';
----------FORM THU NGÂN-------------------------

-- Form Thu Ngân - Phần 1: Quản lý Hóa đơn
GO
CREATE PROCEDURE sp_TaoMaHoaDon
AS
BEGIN
    DECLARE @NextNumber INT;
    DECLARE @LastMaHoaDon NVARCHAR(20);
    
    SELECT TOP 1 @LastMaHoaDon = MaHoaDon
    FROM HoaDon
    ORDER BY HoaDonID DESC;
    
    IF @LastMaHoaDon IS NULL
        SET @NextNumber = 1;
    ELSE
        SET @NextNumber = CAST(RIGHT(@LastMaHoaDon, 4) AS INT) + 1;
    
    SELECT 'HD' + RIGHT('0000' + CAST(@NextNumber AS VARCHAR(4)), 4) AS MaHoaDon;
END
GO

CREATE PROCEDURE sp_ThemHoaDon
    @MaHoaDon NVARCHAR(20),
    @KhachHangID INT = NULL,
    @BuzzerID INT = NULL,
    @GiamGia FLOAT = 0,
    @TongTien DECIMAL(18,0),
    @NhanVienID INT,
    @GhiChu NVARCHAR(200) = NULL,
    @KhuyenMaiID INT = NULL
AS
BEGIN
    INSERT INTO HoaDon (
        MaHoaDon, 
        NgayGio, 
        KhachHangID, 
        BuzzerID, 
        GiamGia, 
        TongTien, 
        NhanVienID,
        GhiChu,
        KhuyenMaiID
    )
    VALUES (
        @MaHoaDon, 
        GETDATE(), 
        @KhachHangID,
        @BuzzerID, 
        @GiamGia, 
        @TongTien, 
        @NhanVienID,
        @GhiChu,
        @KhuyenMaiID
    )

    SELECT SCOPE_IDENTITY() as HoaDonID
END
GO

CREATE PROCEDURE sp_ThemChiTietHoaDon
    @HoaDonID INT,
    @MonID INT,
    @SoLuong INT,
    @ThanhTien DECIMAL(18,0),
    @NhanVienID INT
AS
BEGIN
    -- Kiểm tra và cập nhật hàng tồn
    UPDATE Mon
    SET HangTon = HangTon - @SoLuong
    WHERE MonID = @MonID AND HangTon >= @SoLuong

    INSERT INTO ChiTietHoaDon (
        HoaDonID, 
        MonID, 
        SoLuong, 
        ThanhTien,
        NhanVienID
    )
    VALUES (
        @HoaDonID, 
        @MonID, 
        @SoLuong, 
        @ThanhTien,
        @NhanVienID
    )
END
GO

-- Test thử
EXEC sp_TaoMaHoaDon;

-- Form Thu Ngân - Phần 2: Quản lý Menu và Buzzer
GO
CREATE PROCEDURE sp_LayDanhSachMenu
AS
BEGIN
    SELECT 
        m.MonID,
        m.TenMon,
        m.DonGia,
        nm.TenNhom,
        m.HangTon
    FROM Mon m
    JOIN NhomMon nm ON m.NhomMonID = nm.NhomMonID
    ORDER BY nm.TenNhom, m.TenMon
END
GO

CREATE PROCEDURE sp_LayBuzzerTrong
AS
BEGIN
    SELECT BuzzerID, SoBuzzer
    FROM Buzzer
    WHERE TrangThai = 0
    ORDER BY SoBuzzer
END
GO

CREATE PROCEDURE sp_CapNhatTrangThaiBuzzer
    @BuzzerID INT,
    @TrangThai BIT
AS
BEGIN
    UPDATE Buzzer
    SET TrangThai = @TrangThai
    WHERE BuzzerID = @BuzzerID
END
GO

CREATE PROCEDURE sp_LayMonTheoNhom
    @NhomMonID INT
AS
BEGIN
    SELECT 
        m.MonID,
        m.TenMon,
        m.DonGia,
        m.HangTon
    FROM Mon m
    WHERE m.NhomMonID = @NhomMonID
END
GO

-- Form Thu Ngân - Phần 3: Quản lý Khách hàng
CREATE PROCEDURE sp_TimKhachHang
    @SoDienThoai NVARCHAR(20)
AS
BEGIN
    SELECT 
        KhachHangID,
        TenKhachHang,
        SoDienThoai,
        DiemTichLuy
    FROM KhachHang
    WHERE SoDienThoai = @SoDienThoai
END
GO

CREATE PROCEDURE sp_CapNhatDiemTichLuy
    @KhachHangID INT,
    @DiemTang INT
AS
BEGIN
    UPDATE KhachHang
    SET DiemTichLuy = DiemTichLuy + @DiemTang
    WHERE KhachHangID = @KhachHangID
END
GO

-- Test thử
EXEC sp_LayDanhSachMenu;
EXEC sp_LayBuzzerTrong;
EXEC sp_TimKhachHang @SoDienThoai = '0123456789';

-- Form Thu Ngân - Phần 4: Xử lý thanh toán và báo cáo
GO
CREATE PROCEDURE sp_ThanhToanHoaDon
    @HoaDonID INT,
    @KhachHangID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION
            -- Cập nhật tổng tiền từ chi tiết hóa đơn
            DECLARE @TongTien DECIMAL(18,0)
            SELECT @TongTien = SUM(ThanhTien)
            FROM ChiTietHoaDon
            WHERE HoaDonID = @HoaDonID

            -- Cập nhật hóa đơn
            UPDATE HoaDon
            SET TongTien = @TongTien
            WHERE HoaDonID = @HoaDonID

            -- Nếu có khách hàng thành viên, cập nhật điểm tích lũy
            IF @KhachHangID IS NOT NULL
            BEGIN
                DECLARE @DiemTang INT = CAST(@TongTien/10000 AS INT) -- Cứ 10,000đ = 1 điểm
                EXEC sp_CapNhatDiemTichLuy @KhachHangID, @DiemTang
            END

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_LayThongTinHoaDon
    @HoaDonID INT
AS
BEGIN
    -- Thông tin hóa đơn
    SELECT 
        h.HoaDonID,
        h.MaHoaDon,
        h.NgayGio,
        h.TongTien,
        h.GiamGia,
        k.TenKhachHang,
        k.SoDienThoai,
        k.DiemTichLuy,
        b.SoBuzzer,
        n.TenNhanVien
    FROM HoaDon h
    LEFT JOIN KhachHang k ON h.KhachHangID = k.KhachHangID
    LEFT JOIN Buzzer b ON h.BuzzerID = b.BuzzerID
    LEFT JOIN NhanVien n ON h.NhanVienID = n.NhanVienID
    WHERE h.HoaDonID = @HoaDonID

    -- Chi tiết hóa đơn
    SELECT 
        ct.MonID,
        m.TenMon,
        ct.SoLuong,
        m.DonGia,
        ct.ThanhTien
    FROM ChiTietHoaDon ct
    JOIN Mon m ON ct.MonID = m.MonID
    WHERE ct.HoaDonID = @HoaDonID
END
GO

CREATE PROCEDURE sp_KiemTraHangTon
    @MonID INT,
    @SoLuong INT
AS
BEGIN
    DECLARE @HangTon INT

    SELECT @HangTon = HangTon
    FROM Mon
    WHERE MonID = @MonID

    IF @HangTon >= @SoLuong
        SELECT 1 AS KetQua -- Đủ hàng
    ELSE
        SELECT 0 AS KetQua -- Không đủ hàng
END
GO

CREATE PROCEDURE sp_HuyHoaDon
    @HoaDonID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            -- Hoàn lại số lượng hàng tồn
            UPDATE m
            SET m.HangTon = m.HangTon + ct.SoLuong
            FROM Mon m
            JOIN ChiTietHoaDon ct ON m.MonID = ct.MonID
            WHERE ct.HoaDonID = @HoaDonID

            -- Xóa chi tiết hóa đơn
            DELETE FROM ChiTietHoaDon WHERE HoaDonID = @HoaDonID

            -- Xóa hóa đơn
            DELETE FROM HoaDon WHERE HoaDonID = @HoaDonID

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        THROW;
    END CATCH
END
GO

-- Thêm kiểm tra NULL trong stored procedure
-- Xóa procedure sp_ThemHoaDon cũ vì đang bị lỗi
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_ThemHoaDon')
    DROP PROCEDURE sp_ThemHoaDon
GO

-- Tạo lại procedure sp_ThemHoaDon với đầy đủ tham số
CREATE PROCEDURE sp_ThemHoaDon
    @MaHoaDon NVARCHAR(20),
    @KhachHangID INT = NULL,
    @BuzzerID INT = NULL,
    @GiamGia FLOAT = 0,
    @TongTien DECIMAL(18,0),
    @NhanVienID INT,
    @GhiChu NVARCHAR(200) = NULL,
    @KhuyenMaiID INT = NULL
AS
BEGIN
    -- Kiểm tra NULL
    IF @TongTien IS NULL
        THROW 50001, N'Tổng tiền không được để trống', 1;
        
    IF @GiamGia IS NULL
        SET @GiamGia = 0;
        
    -- Kiểm tra tồn tại
    IF @BuzzerID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Buzzer WHERE BuzzerID = @BuzzerID)
        THROW 50002, N'Buzzer không tồn tại', 1;
        
    IF @KhachHangID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM KhachHang WHERE KhachHangID = @KhachHangID)
        THROW 50003, N'Khách hàng không tồn tại', 1;

    -- Thêm hóa đơn
    INSERT INTO HoaDon (
        MaHoaDon, 
        NgayGio, 
        KhachHangID, 
        BuzzerID, 
        GiamGia, 
        TongTien, 
        NhanVienID,
        GhiChu,
        KhuyenMaiID
    )
    VALUES (
        @MaHoaDon, 
        GETDATE(), 
        @KhachHangID,
        @BuzzerID, 
        @GiamGia, 
        @TongTien, 
        @NhanVienID,
        @GhiChu,
        @KhuyenMaiID
    );

    SELECT SCOPE_IDENTITY() as HoaDonID;
END
GO

-- Test tạo mã hóa đơn
EXEC sp_TaoMaHoaDon;

-- Test thêm hóa đơn hoàn chỉnh
DECLARE @MaHD NVARCHAR(20)

-- Lấy mã hóa đơn mới
EXEC sp_TaoMaHoaDon
SELECT @MaHD = (SELECT 'HD' + RIGHT('0000' + CAST(
    CASE 
        WHEN NOT EXISTS (SELECT TOP 1 MaHoaDon FROM HoaDon) THEN 1
        ELSE (SELECT CAST(RIGHT(MAX(MaHoaDon), 4) AS INT) + 1 FROM HoaDon)
    END 
AS VARCHAR(4)), 4));

-- Thêm hóa đơn với mã vừa tạo
EXEC sp_ThemHoaDon 
    @MaHoaDon = @MaHD,
    @TongTien = 50000,
    @GiamGia = 0,
    @NhanVienID = 1;

-- Kiểm tra kết quả
SELECT TOP 5 * FROM HoaDon ORDER BY HoaDonID DESC;

-- Kiểm tra Log hiện có
SELECT * FROM Log;

-- Xóa toàn bộ dữ liệu trong bảng Log
TRUNCATE TABLE Log;

-- Kiểm tra lại sau khi xóa
SELECT * FROM Log;
-- Kiểm tra và xóa bảng Log nếu đã tồn tại
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Log')
    DROP TABLE Log
GO
-- Xóa procedure sp_ThemHoaDon cũ vì đang bị lỗi
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_ThemHoaDon')
    DROP PROCEDURE sp_ThemHoaDon
GO

-- Tạo lại procedure sp_ThemHoaDon với đầy đủ tham số
CREATE PROCEDURE sp_ThemHoaDon
    @MaHoaDon NVARCHAR(20),
    @KhachHangID INT = NULL,
    @BuzzerID INT = NULL,
    @GiamGia FLOAT = 0,
    @TongTien DECIMAL(18,0),
    @NhanVienID INT,
    @GhiChu NVARCHAR(200) = NULL,
    @KhuyenMaiID INT = NULL
AS
BEGIN
    -- Kiểm tra NULL
    IF @TongTien IS NULL
        THROW 50001, N'Tổng tiền không được để trống', 1;
        
    IF @GiamGia IS NULL
        SET @GiamGia = 0;
        
    -- Kiểm tra tồn tại
    IF @BuzzerID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Buzzer WHERE BuzzerID = @BuzzerID)
        THROW 50002, N'Buzzer không tồn tại', 1;
        
    IF @KhachHangID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM KhachHang WHERE KhachHangID = @KhachHangID)
        THROW 50003, N'Khách hàng không tồn tại', 1;

    -- Thêm hóa đơn
    INSERT INTO HoaDon (
        MaHoaDon, 
        NgayGio, 
        KhachHangID, 
        BuzzerID, 
        GiamGia, 
        TongTien, 
        NhanVienID,
        GhiChu,
        KhuyenMaiID
    )
    VALUES (
        @MaHoaDon, 
        GETDATE(), 
        @KhachHangID,
        @BuzzerID, 
        @GiamGia, 
        @TongTien, 
        @NhanVienID,
        @GhiChu,
        @KhuyenMaiID
    );

    SELECT SCOPE_IDENTITY() as HoaDonID;
END
GO

-- 1. Xóa bảng Log nếu tồn tại
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Log')
    DROP TABLE Log
GO

-- 2. Tạo bảng Log
CREATE TABLE Log
(
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    StoredProcedure NVARCHAR(50),
    ThaoTac NVARCHAR(50),
    NoiDung NVARCHAR(MAX),
    NhanVienThucHien INT,
    TrangThai BIT,
    LoiNeuCo NVARCHAR(MAX),
    ThoiGian DATETIME DEFAULT GETDATE()
)
GO

-- 3. Xóa procedure sp_ThemHoaDon cũ
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_ThemHoaDon')
    DROP PROCEDURE sp_ThemHoaDon
GO

-- 4. Tạo lại procedure sp_ThemHoaDon
CREATE PROCEDURE sp_ThemHoaDon
    @MaHoaDon NVARCHAR(20),
    @TongTien DECIMAL(18,0),
    @GiamGia DECIMAL(18,0) = 0,
    @KhachHangID INT = NULL,
    @BuzzerID INT = NULL,
    @NhanVienID INT,
    @GhiChu NVARCHAR(200) = NULL,
    @KhuyenMaiID INT = NULL
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra NULL
        IF @TongTien IS NULL
            THROW 50001, N'Tổng tiền không được để trống', 1;
            
        IF @GiamGia IS NULL
            SET @GiamGia = 0;
            
        -- Kiểm tra tồn tại
        IF @BuzzerID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Buzzer WHERE BuzzerID = @BuzzerID)
            THROW 50002, N'Buzzer không tồn tại', 1;
            
        IF @KhachHangID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM KhachHang WHERE KhachHangID = @KhachHangID)
            THROW 50003, N'Khách hàng không tồn tại', 1;

        -- Thêm hóa đơn
        INSERT INTO HoaDon(MaHoaDon, NgayGio, KhachHangID, BuzzerID, GiamGia, TongTien, NhanVienID, GhiChu, KhuyenMaiID)
        VALUES (@MaHoaDon, GETDATE(), @KhachHangID, @BuzzerID, @GiamGia, @TongTien, @NhanVienID, @GhiChu, @KhuyenMaiID);

        DECLARE @HoaDonID INT = SCOPE_IDENTITY();

        -- Log thành công
        INSERT INTO Log(StoredProcedure, ThaoTac, NoiDung, NhanVienThucHien, TrangThai)
        VALUES('sp_ThemHoaDon', N'Thêm', CONCAT(N'Đã thêm hóa đơn: ', @MaHoaDon), @NhanVienID, 1);

        -- Trả về ID
        SELECT @HoaDonID AS HoaDonID;
    END TRY
    BEGIN CATCH
        -- Log lỗi
        INSERT INTO Log(StoredProcedure, ThaoTac, NoiDung, NhanVienThucHien, TrangThai, LoiNeuCo)
        VALUES('sp_ThemHoaDon', N'Lỗi', ERROR_MESSAGE(), @NhanVienID, 0, ERROR_MESSAGE());
        
        THROW;
    END CATCH
END
GO

-- Lấy danh sách nhóm món
SELECT NhomMonID, TenNhom FROM NhomMon

-- Lấy tất cả món (không phân nhóm)
SELECT MonID, TenMon, DonGia, HangTon 
FROM Mon 
WHERE HangTon > 0
ORDER BY TenMon

-- Tìm kiếm món theo tên
SELECT MonID, TenMon, DonGia, HangTon 
FROM Mon 
WHERE TenMon LIKE N'%cà phê%'

-- Thêm khách hàng mới
GO
INSERT INTO KhachHang(TenKhachHang, SoDienThoai, DiemTichLuy)
VALUES (N'Nguyễn B', '012345', 0)

-- Cập nhật thông tin khách hàng
UPDATE KhachHang 
SET TenKhachHang = N'Nguyễn Văn A Updated'
WHERE SoDienThoai = '01234567898'

-- Lấy hóa đơn trong ngày
SELECT HoaDonID, MaHoaDon, TongTien, NgayGio
FROM HoaDon
WHERE CAST(NgayGio AS DATE) = CAST(GETDATE() AS DATE)
ORDER BY NgayGio DESC

-- Tính tổng doanh thu trong ngày
SELECT SUM(TongTien) AS DoanhThu
FROM HoaDon
WHERE CAST(NgayGio AS DATE) = CAST(GETDATE() AS DATE)

-- Lấy chi tiết món trong hóa đơn
SELECT m.TenMon, ct.SoLuong, m.DonGia, ct.ThanhTien
FROM ChiTietHoaDon ct
JOIN Mon m ON ct.MonID = m.MonID;

-- Lấy số buzzer đang sử dụng
SELECT b.SoBuzzer, h.MaHoaDon
FROM Buzzer b
JOIN HoaDon h ON b.BuzzerID = h.BuzzerID
WHERE b.TrangThai = 1

-- Đếm số buzzer còn trống
SELECT COUNT(*) AS BuzzerTrong
FROM Buzzer
WHERE TrangThai = 0

-- Lấy khuyến mãi đang áp dụng
SELECT KhuyenMaiID, TenKhuyenMai, PhanTramGiam
FROM KhuyenMai
WHERE NgayBatDau <= GETDATE() 
AND NgayKetThuc >= GETDATE()

-- Kiểm tra món sắp hết
SELECT MonID, TenMon, HangTon
FROM Mon
WHERE HangTon <= 10
ORDER BY HangTon

-- Thống kê món bán chạy trong ngày
SELECT m.TenMon, SUM(ct.SoLuong) AS TongSoLuong
FROM ChiTietHoaDon ct
JOIN Mon m ON ct.MonID = m.MonID
JOIN HoaDon h ON ct.HoaDonID = h.HoaDonID
WHERE CAST(h.NgayGio AS DATE) = CAST(GETDATE() AS DATE)
GROUP BY m.TenMon
ORDER BY TongSoLuong DESC

-- Kiểm tra món sắp hết
SELECT MonID, TenMon, HangTon
FROM Mon
WHERE HangTon <= 10
ORDER BY HangTon

-- Thống kê món bán chạy trong ngày
SELECT m.TenMon, SUM(ct.SoLuong) AS TongSoLuong
FROM ChiTietHoaDon ct
JOIN Mon m ON ct.MonID = m.MonID
JOIN HoaDon h ON ct.HoaDonID = h.HoaDonID
WHERE CAST(h.NgayGio AS DATE) = CAST(GETDATE() AS DATE)
GROUP BY m.TenMon
ORDER BY TongSoLuong DESC


-- Trigger kiểm tra hàng tồn khi thêm chi tiết hóa đơn
CREATE TRIGGER tr_KiemTraHangTon
ON ChiTietHoaDon
FOR INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted i
        JOIN Mon m ON i.MonID = m.MonID
        WHERE i.SoLuong > m.HangTon
    )
    BEGIN
        RAISERROR(N'Số lượng món vượt quá hàng tồn!', 16, 1)
        ROLLBACK
    END
END
GO

-- Trigger cập nhật tổng tiền hóa đơn khi thêm/sửa/xóa chi tiết
CREATE TRIGGER tr_CapNhatTongTien
ON ChiTietHoaDon
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE h
    SET TongTien = (
        SELECT SUM(ThanhTien) 
        FROM ChiTietHoaDon 
        WHERE HoaDonID = h.HoaDonID
    )
    FROM HoaDon h
    JOIN (
        SELECT HoaDonID FROM inserted
        UNION
        SELECT HoaDonID FROM deleted
    ) t ON h.HoaDonID = t.HoaDonID
END
GO

-- View thống kê doanh thu theo ngày
CREATE VIEW v_DoanhThuNgay
AS
SELECT 
    CAST(NgayGio AS DATE) AS Ngay,
    COUNT(HoaDonID) AS SoHoaDon,
    SUM(TongTien) AS DoanhThu
FROM HoaDon
GROUP BY CAST(NgayGio AS DATE)
GO

-- View thống kê món bán chạy
CREATE VIEW v_MonBanChay
AS
SELECT 
    m.TenMon,
    SUM(ct.SoLuong) AS TongSoLuong,
    SUM(ct.ThanhTien) AS TongDoanhThu
FROM ChiTietHoaDon ct
JOIN Mon m ON ct.MonID = m.MonID
GROUP BY m.TenMon
GO

-- View thống kê doanh thu theo ngày
CREATE VIEW view_DoanhThuNgay
AS
SELECT 
    CAST(NgayGio AS DATE) AS Ngay,
    COUNT(HoaDonID) AS SoHoaDon,
    SUM(TongTien) AS DoanhThu
FROM HoaDon
GROUP BY CAST(NgayGio AS DATE)
GO

-- View thống kê món bán chạy
CREATE VIEW view_MonBanChay
AS
SELECT 
    m.TenMon,
    SUM(ct.SoLuong) AS TongSoLuong,
    SUM(ct.ThanhTien) AS TongDoanhThu
FROM ChiTietHoaDon ct
JOIN Mon m ON ct.MonID = m.MonID
GROUP BY m.TenMon
GO

-- Function tính điểm tích lũy từ tổng tiền
CREATE FUNCTION fn_TinhDiem
(
    @TongTien DECIMAL(18,0)
)
RETURNS INT
AS
BEGIN
    RETURN CAST(@TongTien/10000 AS INT)
END
GO

-- Function kiểm tra khuyến mãi có hiệu lực
CREATE FUNCTION fn_KiemTraKhuyenMai
(
    @KhuyenMaiID INT
)
RETURNS BIT
AS
BEGIN
    DECLARE @KetQua BIT = 0
    
    IF EXISTS (
        SELECT 1 FROM KhuyenMai 
        WHERE KhuyenMaiID = @KhuyenMaiID
        AND NgayBatDau <= GETDATE()
        AND NgayKetThuc >= GETDATE()
    )
        SET @KetQua = 1
    
    RETURN @KetQua
END
GO

-- Index cho tìm kiếm hóa đơn
CREATE INDEX IX_HoaDon_NgayGio ON HoaDon(NgayGio)
CREATE INDEX IX_HoaDon_MaHoaDon ON HoaDon(MaHoaDon)

-- Index cho tìm kiếm khách hàng
CREATE INDEX IX_KhachHang_SoDienThoai ON KhachHang(SoDienThoai)

-- Index cho thống kê món
CREATE INDEX IX_ChiTietHoaDon_MonID ON ChiTietHoaDon(MonID)




go
----------FORM ADMIN-------------------------
USE CafeShopManagement
GO
SELECT * FROM hoadon

ALTER TABLE HoaDon 
ALTER COLUMN KhachHangID INT NULL;

INSERT INTO HoaDon (MaHoaDon, NgayGio, BuzzerID, TongTien)  
VALUES ('HD0010', GETDATE(), 1, 50000);

UPDATE Buzzer
SET TrangThai = 0;

-- Bước 1: Xóa ràng buộc UNIQUE hiện tại
ALTER TABLE KhachHang
DROP CONSTRAINT UQ__KhachHan__0389B7BD4BCF8E4D;

-- Bước 2: Thay đổi độ dài cột
ALTER TABLE KhachHang
ALTER COLUMN SoDienThoai NVARCHAR(10);

-- Bước 3: Thêm lại ràng buộc UNIQUE
ALTER TABLE KhachHang
ADD CONSTRAINT UQ_SoDienThoai UNIQUE (SoDienThoai);

DECLARE @KhachHangID INT;
DECLARE @TongTien DECIMAL(18, 2);
DECLARE @HoaDonID INT;

-- Gán giá trị cho các biến
SET @KhachHangID = 1; -- Gán giá trị thực tế
SET @TongTien = 100000; -- Gán giá trị thực tế
SET @HoaDonID = 1; -- Gán giá trị thực tế

UPDATE HoaDon
SET KhachHangID = @KhachHangID, TongTien = @TongTien
WHERE HoaDonID = @HoaDonID;

CREATE TABLE GiaoCa (
    GiaoCaID INT IDENTITY(1,1) PRIMARY KEY,
    NhanVienID INT,
    ThoiGianBatDau DATETIME,
    ThoiGianKetThuc DATETIME,
    TongSoHoaDon INT,
    TongDoanhThu DECIMAL(18,0),
    TienMatThucTe DECIMAL(18,0),
    ChenhLech DECIMAL(18,0),
    GhiChu NVARCHAR(200)
);

SELECT Mon.MonID, Mon.TenMon, Mon.DonGia, NhomMon.TenNhom, Mon.HangTon, Mon.NhomMonID
FROM Mon
JOIN NhomMon ON Mon.NhomMonID = NhomMon.NhomMonID

go
CREATE PROCEDURE sp_ThemMon
    @TenMon NVARCHAR(100),
    @DonGia DECIMAL(18,0),
    @NhomMonID INT,
    @HangTon INT
AS
BEGIN
    INSERT INTO Mon (TenMon, DonGia, NhomMonID, HangTon)
    VALUES (@TenMon, @DonGia, @NhomMonID, @HangTon)
END
GO

CREATE PROCEDURE sp_SuaMon
    @MonID INT,
    @TenMon NVARCHAR(100),
    @DonGia DECIMAL(18,0),
    @NhomMonID INT,
    @HangTon INT
AS
BEGIN
    UPDATE Mon
    SET TenMon = @TenMon, DonGia = @DonGia, NhomMonID = @NhomMonID, HangTon = @HangTon
    WHERE MonID = @MonID
END
GO

CREATE PROCEDURE sp_XoaMon
    @MonID INT
AS
BEGIN
    DELETE FROM Mon WHERE MonID = @MonID
END
GO

-- Lấy danh sách nhân viên
ALTER PROCEDURE sp_LayDanhSachNhanVien
AS
BEGIN
	SELECT *
    FROM NhanVien
    WHERE TrangThai = 1
END
GO


-- Sửa nhân viên
CREATE PROCEDURE sp_SuaNhanVien
    @NhanVienID INT,
    @TenNhanVien NVARCHAR(100),
    @MatKhau NVARCHAR(100),
    @VaiTro NVARCHAR(50)
AS
BEGIN
    UPDATE NhanVien
    SET TenNhanVien = @TenNhanVien, MatKhau = @MatKhau, VaiTro = @VaiTro
    WHERE NhanVienID = @NhanVienID
END
GO

-- Xóa nhân viên
CREATE PROCEDURE sp_XoaNhanVien
    @NhanVienID INT
AS
BEGIN
    DELETE FROM NhanVien WHERE NhanVienID = @NhanVienID
END
GO


----------HÓA ĐƠN------------------


CREATE PROCEDURE sp_XoaHoaDon
    @HoaDonID INT
AS
BEGIN
    DELETE FROM ChiTietHoaDon WHERE HoaDonID = @HoaDonID
    DELETE FROM HoaDon WHERE HoaDonID = @HoaDonID
END
GO

-- Tạo mã hóa đơn tự động
CREATE PROCEDURE sp_TaoMaHoaDon
AS
BEGIN
    DECLARE @LastNumber INT
    SELECT @LastNumber = ISNULL(MAX(CAST(SUBSTRING(MaHoaDon, 3, 4) AS INT)), 0)
    FROM HoaDon
    
    DECLARE @NewNumber INT = @LastNumber + 1
    SELECT 'HD' + RIGHT('0000' + CAST(@NewNumber AS VARCHAR(4)), 4)
END
go

-- Thêm hóa đơn mới
CREATE PROCEDURE sp_ThemHoaDon
    @MaHoaDon VARCHAR(10),
    @KhachHangID INT,
    @BuzzerID INT,
    @GiamGia DECIMAL(5,2),
    @TongTien DECIMAL(18,2),
    @NhanVienID INT,
    @GhiChu NVARCHAR(MAX),
    @KhuyenMaiID INT
AS
BEGIN
    INSERT INTO HoaDon (MaHoaDon, NgayGio, KhachHangID, BuzzerID, GiamGia, TongTien, NhanVienID, GhiChu, KhuyenMaiID)
    VALUES (@MaHoaDon, GETDATE(), @KhachHangID, @BuzzerID, @GiamGia, @TongTien, @NhanVienID, @GhiChu, @KhuyenMaiID)
    
    SELECT SCOPE_IDENTITY()
END
go

-- Thêm chi tiết hóa đơn
CREATE PROCEDURE sp_ThemChiTietHoaDon
    @HoaDonID INT,
    @MonID INT,
    @SoLuong INT,
    @ThanhTien DECIMAL(18,2),
    @NhanVienID INT
AS
BEGIN
    INSERT INTO ChiTietHoaDon (HoaDonID, MonID, SoLuong, ThanhTien, NhanVienID)
    VALUES (@HoaDonID, @MonID, @SoLuong, @ThanhTien, @NhanVienID)
END
go
-- Cập nhật hóa đơn
CREATE PROCEDURE sp_CapNhatHoaDon
    @HoaDonID INT,
    @KhachHangID INT,
    @TongTien DECIMAL(18,2)
AS
BEGIN
    UPDATE HoaDon 
    SET KhachHangID = @KhachHangID,
        TongTien = @TongTien
    WHERE HoaDonID = @HoaDonID
END
go
CREATE PROCEDURE sp_LayDanhSachHoaDon
    @TuNgay DATETIME = NULL,
    @DenNgay DATETIME = NULL
AS
BEGIN
    SELECT h.HoaDonID, h.MaHoaDon, h.NgayGio, h.KhachHangID, k.TenKhachHang, h.BuzzerID, h.GiamGia, h.TongTien, h.KhuyenMaiID, h.NhanVienID, n.TenNhanVien, h.GhiChu
    FROM HoaDon h
    LEFT JOIN KhachHang k ON h.KhachHangID = k.KhachHangID
    LEFT JOIN NhanVien n ON h.NhanVienID = n.NhanVienID
    WHERE (@TuNgay IS NULL OR h.NgayGio >= @TuNgay)
      AND (@DenNgay IS NULL OR h.NgayGio <= @DenNgay)
    ORDER BY h.NgayGio DESC
END
GO
-- Lấy chi tiết hóa đơn
CREATE PROCEDURE sp_LayChiTietHoaDon
    @HoaDonID INT
AS
BEGIN
    SELECT ct.*, m.TenMon, m.DonGia
    FROM ChiTietHoaDon ct
    JOIN Mon m ON ct.MonID = m.MonID
    WHERE ct.HoaDonID = @HoaDonID
END
----------DOANH THU--------------
GO
CREATE PROCEDURE sp_ThongKeDoanhThu
    @FromDate DATETIME,
    @ToDate DATETIME
AS
BEGIN
    SELECT HoaDonID, MaHoaDon, NgayGio, TongTien
    FROM HoaDon
    WHERE NgayGio BETWEEN @FromDate AND @ToDate
    ORDER BY NgayGio
END

ALTER TABLE NhanVien ADD TrangThai BIT DEFAULT 1 -- 1: Đang hoạt động, 0: Đã nghỉ

go
CREATE PROCEDURE sp_XoaNhanVien
    @NhanVienID INT
AS
BEGIN
    UPDATE NhanVien SET TrangThai = 0 WHERE NhanVienID = @NhanVienID
END

UPDATE NhanVien
SET TrangThai = 1

INSERT INTO NhanVien (MaNhanVien, TenNhanVien, MatKhau, VaiTro, TrangThai)
VALUES ('NV4', N'Nguyễn Văn D', '4', N'Nhân viên', 1)

SELECT * FROM NhanVien 

ALTER PROCEDURE sp_XoaNhanVien
    @NhanVienID INT
AS
BEGIN
    UPDATE NhanVien
    SET TrangThai = 0
    WHERE NhanVienID = @NhanVienID
END
GO


ALTER PROCEDURE sp_DangNhap
    @MaNhanVien NVARCHAR(50),
    @MatKhau NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM NhanVien
    WHERE MaNhanVien = @MaNhanVien
      AND MatKhau = @MatKhau
      AND TrangThai = 1
END
GO

ALTER PROCEDURE sp_ThemNhanVien
    @MaNhanVien NVARCHAR(50),
    @TenNhanVien NVARCHAR(100),
    @MatKhau NVARCHAR(100),
    @VaiTro NVARCHAR(50)
AS
BEGIN
    INSERT INTO NhanVien (MaNhanVien, TenNhanVien, MatKhau, VaiTro, TrangThai)
    VALUES (@MaNhanVien, @TenNhanVien, @MatKhau, @VaiTro, 1)
END

EXEC sp_ThemNhanVien 
    @MaNhanVien = N'NV999', 
    @TenNhanVien = N'Test', 
    @MatKhau = N'123', 
    @VaiTro = N'Quản lý'

	-- Thêm cột TrangThai vào bảng NhanVien
ALTER TABLE NhanVien ADD TrangThai BIT DEFAULT 1;


CREATE PROCEDURE sp_ThemNhanVien
    @MaNhanVien NVARCHAR(50),
    @TenNhanVien NVARCHAR(100),
    @MatKhau NVARCHAR(100),
    @VaiTro NVARCHAR(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM NhanVien WHERE MaNhanVien = @MaNhanVien)
        THROW 50001, N'Mã nhân viên đã tồn tại', 1;
        
    INSERT INTO NhanVien (MaNhanVien, TenNhanVien, MatKhau, VaiTro, TrangThai)
    VALUES (@MaNhanVien, @TenNhanVien, @MatKhau, @VaiTro, 1)
END

CREATE PROCEDURE sp_NhapHang
    @TenMon NVARCHAR(100),
    @SoLuongThem INT
AS
BEGIN
    UPDATE Mon 
    SET HangTon = HangTon + @SoLuongThem 
    WHERE TenMon = @TenMon
END

CREATE PROCEDURE sp_ThemNhanVien
    @TenNhanVien NVARCHAR(100),
    @MatKhau NVARCHAR(100),
    @VaiTro NVARCHAR(50),
    @TrangThai BIT,
    @NhanVienID INT OUTPUT
AS
BEGIN
    INSERT INTO NhanVien (TenNhanVien, MatKhau, VaiTro, TrangThai)
    VALUES (@TenNhanVien, @MatKhau, @VaiTro, @TrangThai)

    SET @NhanVienID = SCOPE_IDENTITY()
END
go
select *from buzzer

CREATE PROCEDURE sp_LayBuzzerDangSuDung
AS
BEGIN
    SELECT BuzzerID, SoBuzzer FROM Buzzer WHERE TrangThai = 1
END
GO

CREATE PROCEDURE sp_CapNhatTrangThaiBuzzer
    @BuzzerID INT,
    @TrangThai BIT
AS
BEGIN
    UPDATE Buzzer
    SET TrangThai = @TrangThai
    WHERE BuzzerID = @BuzzerID
END

SELECT * FROM Buzzer

   UPDATE Buzzer SET TrangThai = 1 WHERE SoBuzzer = '02'

INSERT INTO KhuyenMai (TenKhuyenMai, PhanTramGiam, NgayBatDau, NgayKetThuc, DieuKien)
VALUES 
(N'Happy Hour 15%', 15, '2025-05-10 14:00', '2025-05-10 17:00', N'Từ 14h-17h mỗi ngày'),
(N'Khách thành viên giảm 5%', 5, '2025-05-01', '2025-12-31', N'Chỉ áp dụng cho thành viên'),
(N'Combo ăn sáng giảm 20%', 20, '2025-05-01', '2025-05-31', N'Áp dụng cho combo ăn sáng'),
(N'Giảm 50k cho hóa đơn trên 500k', 10, '2025-05-01', '2025-06-30', N'Hóa đơn từ 500,000đ');

