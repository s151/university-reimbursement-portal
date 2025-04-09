create database claimsdb
go

use claimsdb
go

create table members(
id int primary key identity,
mname varchar(100) not null,
address varchar(255),
gender varchar(20),
phone varchar(10),
email varchar(50) not null unique,
pwd varchar(50) not null,
isadmin bit not null default 0
)
go
--insert into members(mname,email,pwd,isadmin) values('Administrator','admin','admin',1)
go
create table claims (
id int primary key identity,
vno varchar(20) not null,
vtype varchar(20) not null,
model varchar(20) not null,
insurance_amount int not null,
claim_amount int,
final_amount int,
req_date date default getdate(),
reason varchar(255),
process_date date,
status varchar(20) default 'Pending',
rej_reason varchar(255),
memberid int foreign key references members(id)
)
go
create table documents(
id int primary key identity,
claim_id int foreign key references claims(id),
doctype varchar(50),
docfile varchar(100)
)

go

select * from members
select * from claims
select * from documents

delete from claims
delete from documents

