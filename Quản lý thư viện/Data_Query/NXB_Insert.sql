USE [QL_ThuVien]
GO
create proc NXBInsert
@MaNXB nvarchar(10),
@TenNXB nvarchar(50),
@QuocGia nvarchar(50),
@Email nvarchar(50),
@DiaChi nvarchar(50),
@DienThoai nvarchar(20)
as

INSERT INTO [dbo].[NXB]
           ([MaNXB]
           ,[TenNXB]
           ,[QuocGia]
           ,[Email]
           ,[DiaChi]
           ,[DienThoai])
     VALUES
           (@MaNXB
           ,@TenNXB
           ,@QuocGia
           ,@Email
           ,@DiaChi
           ,@DienThoai)
GO


