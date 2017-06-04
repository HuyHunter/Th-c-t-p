USE [QL_ThuVien]
GO
create proc LopDelete
 @MaLop nvarchar(50) as

DELETE FROM [dbo].[Lop]
      WHERE [MaLop] = @MaLop


