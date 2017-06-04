USE [QL_ThuVien]
GO
create proc NXBUpdate
@MaNXB nvarchar(10),
@TenNXB nvarchar(50),
@QuocGia nvarchar(50),
@Email nvarchar(50),
@DiaChi nvarchar(50),
@DienThoai nvarchar(20)

as
UPDATE [dbo].[NXB]
   SET [MaNXB] = @MaNXB
      ,[TenNXB] = @TenNXB
      ,[QuocGia] = @QuocGia
      ,[Email] = @Email
      ,[DiaChi] = @DiaChi
      ,[DienThoai] = @DienThoai
 WHERE [MaNXB] = @MaNXB
GO


