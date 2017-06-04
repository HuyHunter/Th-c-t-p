USE [QL_KhachSan]
GO
create proc Insert_DichVu
@MaDV nvarchar(10),
@TenDV nvarchar(50),
@Gia float,
@DonViTinh nvarchar(10)
as

INSERT INTO [dbo].[tblDichVu]
           ([MaDV]
           ,[TenDV]
           ,[Gia]
           ,[DonViTinh])
     VALUES
           (@MaDV,@TenDV,@Gia,@DonViTinh)
GO


