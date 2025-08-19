create database ElectricityBillDB

--Creating Table Admin

create table admin (AdminID int primary key,
					AdminName nvarchar(30),
					Password nvarchar(20),
					Email nvarchar(20),
					Phone nvarchar(20))

--Inserting into Admin

insert into admin values (1, 'Admin', 'Admin@123', 'AdminEB@gmail.com', '9876543210')

--Display Admin

select * from admin

--Create table Customer

create table customer ( Bill_ID int identity primary key,
						Customer_number nvarchar(20),
						Customer_name varchar(50),
						Units_consumed int,
						Bill_amount float,
						Billing_date date default getdate())

--Drop Customer

drop table customer

--Displaying Customer Table

select * from customer

--Create Table Exceptions

create table exceptions (count int identity primary key,
							Ex_message nvarchar(100),
							Ex_Type nvarchar(200),
							Ex_Source nvarchar(max),
							Ex_URL nvarchar(100))



create or alter procedure sp_ExceptionLogging_DB @exceptionmsg nvarchar(100), @exceptiontype nvarchar(200), @exceptionsource nvarchar(max), @exceptionurl nvarchar(100)
as
begin
	insert into exceptions (Ex_message, Ex_Type, Ex_Source, Ex_URL) values (@exceptionmsg, @exceptionmsg, @exceptionsource, @exceptionurl)
end



SELECT COUNT(*) FROM customer WHERE Customer_number = 'EB00001'

