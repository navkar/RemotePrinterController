use EAS

create table printer
(
	printer_guid uniqueidentifier DEFAULT NEWID(),
	area_code varchar(20), 
	printer_id varchar(20),
	printer_status char(1) default '0' not null,
	printer_status_date datetime DEFAULT (getdate()),
	manufacturer varchar(30),
	model varchar(20) not null,
	type char(1) not null,
	color char(1) not null,
	duplex char(1) not null,
	deregister varchar(5) default 'false' not null,
	creation_date datetime DEFAULT (getdate()),
	deregister_date datetime DEFAULT (getdate()),
	ept_host_ip char(15) not null,
	ept_host_portno char(5) not null,
	constraint PK_PRINTER primary key (area_code, printer_id)
)


create table paperinfo
(
	area_code varchar(20), 
	printer_id varchar(20),
	paper_size varchar(10),
	paper_width varchar(7) default '0',
	paper_height varchar(7) default '0',
	constraint PK_PAPERINFO PRIMARY KEY (area_code, printer_id, paper_size),
	constraint FK_PAPERINFO FOREIGN KEY (area_code, printer_id) 
	REFERENCES printer (area_code, printer_id)
)

insert into jobinfo (area_code,printer_id,job_id,copies,cost) values
( 'JBH','104','12121',1,12 )

select * from jobinfo

create table jobinfo
(
	area_code varchar(20), 
	printer_id varchar(20),
	job_id varchar(20),
	job_status char(1) default '2' not null,
	job_filename varchar(255) not null,
	job_filesize numeric(10) not null,
	copies tinyint not null,
	cost numeric(7,2) not null,	
	job_date datetime DEFAULT (getdate()),
	constraint PK_JOBINFO primary key (job_id) ,
	constraint FK_JOBINFO FOREIGN KEY (area_code, printer_id) 
	REFERENCES printer (area_code, printer_id)
)

drop table paperinfo
drop table jobinfo
drop table printer



sp_tables


update printer set printer_status='5' ,printer_status_date = getDate() 
where epc_id='HM1234'

update printer set deregister = 'true' , deregister_date = getDate() 
where  epc_id='HM1234' and printer_id='001'

select max(printer_id) from printer where area_code='JaH'

select * from paperinfo where printer_id='129'
select job_status from jobinfo

select j1.job_id, j1.cost, j1.copies, j1.job_filename, j1.job_filesize, p1.ept_host_ip, p1.ept_host_portno from printer p1, jobinfo j1
where p1.area_code = 'PUN' 
and p1.printer_id = '101' 
and j1.area_code = 'PUN' 
and j1.printer_id = '101'
and j1.job_status = '4' 

select * from jobinfo order by job_date

insert printer (area_code, printer_id, manufacturer, model, type, color, duplex, ept_host_ip, ept_host_portno) 
values ('PUN', '104', 'TVSE', 'DMP-100', '2', '1', '1','localhost','8080')


insert into paperinfo (area_code, printer_id, paper_size, paper_width, paper_height) 
values ( 'HM1234' , '003', 'B4', '100', '200')

insert into jobinfo (area_code, printer_id, job_id, copies, cost) 
values ( 'HM1234' , '001', '123133', '1', 12.45)


update jobinfo set job_status = '5' where job_id = '974355870'

select * from printer

delete from jobinfo
select * from jobinfo

select * from jobinfo where job_status not in ( '1','5')
