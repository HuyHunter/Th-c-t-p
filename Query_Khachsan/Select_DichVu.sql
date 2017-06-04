USE [QL_KhachSan]
GO
create proc Load_Dodung
as

SELECT [MaDD]
      ,[TenDD]
      ,[SoLuong]
      ,[DonViTinh]
	  ,[GiaMua]
  FROM [dbo].[DoDung]
GO


