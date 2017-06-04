USE [QL_ThuVien]
GO
create proc LopUpdate
@MaLop nvarchar(50),
@TenLop nvarchar(50),
@Khoa nvarchar(50)
as


UPDATE [dbo].[Lop]
   SET [MaLop] = @MaLop
      ,[TenLop] = @TenLop
      ,[Khoa] = @Khoa
 WHERE [MaLop] = @MaLop
GO


