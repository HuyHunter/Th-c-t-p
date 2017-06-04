USE [QL_ThuVien]
GO
create proc NXBDelete
@MaNXB nvarchar(10)
as
DELETE FROM [dbo].[NXB]
      WHERE [MaNXB] = @MaNXB

GO


