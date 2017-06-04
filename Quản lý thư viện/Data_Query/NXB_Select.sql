USE [QL_ThuVien]
GO
create proc NXBSelect
as

SELECT [MaNXB]
      ,[TenNXB]
      ,[QuocGia]
      ,[Email]
      ,[DiaChi]
      ,[DienThoai]
  FROM [dbo].[NXB]
GO


