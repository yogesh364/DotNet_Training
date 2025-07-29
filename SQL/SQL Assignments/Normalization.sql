--creating clientrental table

--1NF
create table clientrental
	(clientno varchar(20) not null,
    cname varchar(50) not null,
    propertyno varchar(20) not null,
    paddress varchar(50) not null,
    rentstart date not null,
    rentfinish date not null,
    rent int not null,
    ownerno varchar(20) not null,
    oname varchar(50) not null
)

insert into clientrental values
('CR76', 'John Kay', 'PG4', '6 Lawrence St, Glasgow', '2000-07-01', '2001-08-31', 350, 'C040', 'Tina Murphy'),
('CR76', 'John Kay', 'PG16', '5 Novar Dr, Glasgow', '2002-09-01', '2002-09-01', 450, 'C093', 'Tony Shaw'),
('CR86', 'Aline Stewart', 'PG4', '6 Lawrence St, Glasgow', '1999-09-01', '2000-06-10', 350, 'C040', 'Tina Murphy'),
('CR86', 'Aline Stewart', 'PG36', '2 Manor Rd, Glasgow', '2000-10-10', '2001-12-01', 370, 'C093', 'Tony Shaw'),
('CR86', 'Aline Stewart', 'PG16', '5 Novar Dr, Glasgow', '2002-11-01', '2003-08-01', 450, 'C093', 'Tony Shaw')

--2NF
-- creating client table
create table client (
    clientno varchar(20) primary key,
    cname varchar(50) not null
)

-- creating owner table
create table owner (
    ownerno varchar(20) primary key,
    oname varchar(50) not null
)

-- creating property table
create table property (
    propertyno varchar(20) primary key,
    paddress varchar(50) not null,
    ownerno varchar(20) not null
)

-- creating rental table
create table rental (
    clientno varchar(20) not null,
    propertyno varchar(20) not null,
    rentstart date not null,
    rentfinish date not null,
    rent int not null,
    primary key (clientno, propertyno, rentstart)
)

-- insert into client
insert into client values('CR76', 'John Kay'),('CR86', 'Aline Stewart')

-- insert into owner
insert into owner values('C040', 'Tina Murphy'),('C093', 'Tony Shaw')

-- insert into property
insert into property values('PG4', '6 Lawrence St, Glasgow', 'C040'),
							('PG16', '5 Novar Dr, Glasgow', 'C093'),
							('PG36', '2 Manor Rd, Glasgow', 'C093')

-- insert into rental
insert into rental values('CR76', 'PG4', '2000-07-01', '2001-08-31', 350),
						('CR76', 'PG16', '2002-09-01', '2002-09-01', 450),
						('CR86', 'PG4', '1999-09-01', '2000-06-10', 350),
						('CR86', 'PG36', '2000-10-10', '2001-12-01', 370),
						('CR86', 'PG16', '2002-11-01', '2003-08-01', 450)


--3NF
alter table property
add constraint fk_po foreign key (ownerno) references owner(ownerno)