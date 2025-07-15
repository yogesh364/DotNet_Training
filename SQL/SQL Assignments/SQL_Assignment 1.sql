create database Assignment1

-- 1. Clients Table

-- Creating Clients Table

create table Clients (Client_ID int primary key, Cname varchar(40) not null, Address varchar(30),
Email varchar(30) Unique, Phone bigint, Business varchar(20) not null)

--Displaying Clients Table

select * from Clients

--Inserting values in Clients Table 

insert into Clients(Client_ID,Cname,Address,Email,Phone,Business) 
values(1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', 9567880032, 'Manufacturing'),
		(1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', 8734210090, 'Consultant'),
		(1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', 7799886655, 'Reseller'),
		(1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', 9210342219, 'Professional')

--Drop Table from Clients

Drop table Clients



--2. Employees Table

--Creating Employees Table

create table Employees (Empno int primary key, Ename varchar(20) not null, job varchar(15),
salary int check (salary > 0),Deptno int foreign key references Departments(Deptno))

--Displaying Employees Table

select * from Employees

--Inserting into Employees Table

insert into Employees values (7001, 'Sandeep', 'Analyst', 25000, 10),
							 (7002, 'Rajesh', 'Designer', 30000, 10),
							 (7003, 'Madhav', 'Developer', 40000, 20),
							 (7004, 'Manoj', 'Developer', 40000, 20),
							 (7005, 'Abhay', 'Designer', 35000, 10),
							 (7006, 'Uma', 'Tester', 30000, 30),
							 (7007, 'Gita', 'Tech. Writer', 30000, 40),
							 (7008, 'Priya', 'Tester', 35000, 30),
							 (7009, 'Nutan', 'Developer', 45000, 20),
							 (7010, 'Smita', 'Analyst', 20000, 10),
							 (7011, 'Anand', 'Project Mgr', 65000, 10)

--Drop Employees Table

Drop table Employees



--3. Departments Table

--Creating Departments Table

create table Departments (Deptno int primary key, Dname varchar(15) not null, Loc varchar(20))

--Displaying Departments Table

select * from Departments

--Inserting into Departments Table

insert into Departments values(10, 'Design', 'Pune'),
							  (20, 'Development', 'Pune'),
							  (30, 'Testing', 'Mumbai'),
							  (40, 'Document', 'Mumbai')

--Drop Departments Tables

Drop table Departments



--4. Projects

--Creating Projects Table 

Create table Projects (Project_ID int primary key,Descr varchar(30) not null,
					   Start_Date Date, Planned_End_Date Date, Actual_End_Date Date,
					   Budget bigint check (Budget > 0),
					   Client_ID int foreign key references Clients(Client_ID))

--Altering Projects Table

alter table Projects
add Constraint Check_Actual_End_Date check (Actual_End_Date > Planned_End_Date)

--Displaying Projects Table 

select * from Projects

--Inserting into projects Table 

insert into Projects values(401, 'Inventory', '01-Apr-11', '01-Oct-11', '31-Oct-11', 150000, 1001),
						   (402, 'Accounting', '01-Aug-11', '01-Jan-12', Null, 500000, 1002),
						   (403, 'Payroll', '01-Oct-11', '31-Dec-11', NUll, 75000, 1003),
						   (404, 'Contact Mgmt', '01-Nov-11', '31-Dec-11', Null, 50000, 1004)

--Drop Projects Table

Drop table Projects




--5. EmpProjectTasks

--Creating EmpProjectTasks Table

create table EmpProjectTasks (Project_ID int,
						      Empno int,
							  Start_Date Date,
							  End_Date Date,
							  Task varchar(25),
							  Status varchar(15),
							  constraint composite_pk primary key(Project_ID, Empno),
							  constraint prj_fk foreign key (Project_ID) references Projects(Project_ID),
							  constraint emp_fk foreign key (Empno) references Employees(Empno))

--Displaying EmpProjectsTasks

select * from EmpProjectTasks

--Insert into EmpProjectTasks

insert into EmpProjectTasks values(401, 7001, '01-Apr-11', '20-Apr-11', 'System Analysis', 'Completed'),
									(401, 7002, '21-Apr-11', '30-May-11', 'System Design', 'Completed'),
									(401, 7003, '01-Jun-11', '15-Jul-11', 'Coding', 'Completed'),	
									(401, 7004, '18-Jul-11', '01-Sep-11', 'Coding', 'Completed'),
									(401, 7006, '03-Sep-11', '15-Sep-11', 'Testing', 'Completed'),
									(401, 7009, '18-Sep-11', '05-Oct-11', 'Code Change', 'Completed'),
									(401, 7008, '06-Oct-11', '16-Oct-11', 'Testing', 'Completed'),
									(401, 7007, '06-Oct-11', '22-Oct-11', 'Documentation', 'Completed'),
									(401, 7011, '22-Oct-11', '31-Oct-11', 'Sign off', 'Completed'),
									(402, 7010, '01-Aug-11', '20-Aug-11', 'System Analysis', 'Completed'),
									(402, 7002, '22-Aug-11', '30-Sep-11', 'System Design', 'Completed'),
									(402, 7004, '01-Oct-11', Null, 'Coding', 'In Progress')
							  
--Drop EmpProjectTasks 

Drop table EmpProjectTasks