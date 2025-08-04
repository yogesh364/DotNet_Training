create database RailwayDB

--Creating users table

create table users (UserID int primary key identity(1,1),
					UserName nvarchar(100) unique not null,
					Password nvarchar(200) not null,
					Phone bigint not null,
					Email nvarchar(100))

--Display User Table

select * from users

--Drop User Table

drop table users
					
					
--Creating Admin Table

create table admin (AdminID int primary key identity(1,1),
					AdminName nvarchar(100) unique not null,
					Password nvarchar(200) not null,
					Phone bigint not null,
					Email nvarchar(100))

--Display Admin Table

select * from admin

--Drop Admin Table

drop table admin

--inserting into Admin Table

insert into admin(AdminName, Password, Phone, Email)
			values('Rahul', 'admin_rahul@123', 98844010145, 'admin123@gmail.com')


--Creating Train Table

Create Table Trains (TrainID int primary key,
						TrainName varchar(100) not null,
						Source varchar(100) not null,
						Destination varchar(100) not null,
						Departure_Date Date not null,
						Departure_Time Time not null)

--Inserting into Train Table

insert into Trains values(101, 'Chennai Express', 'Chennai', 'Visakhapatnam', '2025-08-25', '6:30'),
							(102, 'Chennai Express', 'Visakhapatnam', 'Chennai', '2025-08-25', '16:45'),
							(103, 'Mysore Express', 'Chennai', 'Mysore', '2025-08-25', '7:30'),
							(104, 'Mysore Express', 'Mysore', 'Chennai', '2025-08-25', '14:30')
							

--Displaying Train Table 

select * from Trains

--Drop Trains Table

drop table Trains


--Creating Seats Table

create table seats (SeatID int primary key identity(1,1),
					TrainID int foreign key references Trains(TrainID),
					TravelDate date not null,
					Class nvarchar(100) not null,
					TotalSeats int not null,
					AvailableSeats int not null,
					Price float not null)

--Inserting into Seats Table

insert into seats(TrainID, TravelDate, Class, TotalSeats, AvailableSeats, Price)
			values(101, '2025-08-25', 'Sleeper', 100, 100, 500),
					(101, '2025-08-25', '3rd-AC', 100, 100, 1000),
					(101, '2025-08-25', '2nd-AC', 100, 100, 1500),
					(102, '2025-08-25', 'Sleeper', 100, 100, 500),
					(102, '2025-08-25', '3rd-AC', 100, 100, 1000),
					(102, '2025-08-25', '2nd-AC', 100, 100, 1500),
					(103, '2025-08-25', 'Sleeper', 100, 100, 500),
					(103, '2025-08-25', '3rd-AC', 100, 100, 1000),
					(103, '2025-08-25', '2nd-AC', 100, 100, 1500),
					(104, '2025-08-25', 'Sleeper', 100, 100, 500),
					(104, '2025-08-25', '3rd-AC', 100, 100, 1000),
					(104, '2025-08-25', '2nd-AC', 100, 100, 1500)

--Displaying Seats Table 

select * from trains
select * from seats

--Drop Seats Table

Drop table seats

