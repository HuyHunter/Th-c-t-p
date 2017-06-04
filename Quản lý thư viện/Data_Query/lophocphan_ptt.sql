create table lophocphan(

	ma varchar(20) primary key not null,
	tengiaovien nvarchar(50),
	giangduong varchar(10),
	thoigian nvarchar(20),
	siso int,
	monhocma varchar(10) foreign key 
	references monhoc(ma) not null ,
	giaovienma varchar(10) foreign key 
	references giaovien(ma) not null,
)
insert into lophocphan(monhocma,ma, tengiaovien,giangduong,siso,thoigian, giaovienma)
       values
	('MH0001','000101', N'Bùi Thu Lâm', 'H9201',50,'T4(1-3)','GV001'),
	('MH0001','000102',N'Bùi Thu Lâm', 'H9201',50,'T4(4-6)','GV001'),
	('MH0002','000201', N'Bùi Thu Lâm', 'H9301',50,'T2(1-3)','GV001')
insert into lophocphan(monhocma,ma,tengiaovien,giangduong,siso ,thoigian,giaovienma)
values('MH0003','000203',N'Ngô Thành Long','H5 406',46,'T3(2-3)','GV002')
	select * from lophocphan
	select *from monhoc
	select lophocphan.tengiaovien ,monhoc.ten from lophocphan , monhoc 
	where lophocphan.monhocma=monhoc.ma
