create database StudentManagement;

use StudentManagement;

create table LopSH (
	ID_Lop int IDENTITY(1,1),
	NameLop nvarchar(100)
)

alter table LopSH add constraint PK_LopSH primary key(ID_Lop)

create table SV (
	MSSV int IDENTITY(1,1),
	NameSV nvarchar(100),
	Gender bit,
	NS Date,
	ID_Lop int
)

alter table SV add constraint PK_SV primary key(MSSV);
alter table SV add constraint FK_SV_LopSH foreign key (ID_Lop) references LopSH(ID_Lop);