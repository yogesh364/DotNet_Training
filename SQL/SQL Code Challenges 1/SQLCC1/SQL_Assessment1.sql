create database Assessment



--Creating Table Books
create table Books (id int primary key,
					title varchar(20),
					author varchar(20),
					isbn bigint unique,
					published_date date)

--Inserting into Book Table
insert into Books(id,title,author,isbn,published_date)
				values(1,'My First SQL Book', 'Mary Parker', 981483029127, '2012-02-22'),
					  (2, 'My Second SQL Book', 'John Mayer', 857300923713, '1972-07-03'),
					  (3, 'My Third SQL book', 'Cary Flint', 523120967812, '2015-10-18')


--Creating Review Table
create table Review(id int primary keybook_id intreviewer_name varchar(20),
					content varchar(20),
					rating int,
					published_date date,
					constraint id_fk  foreign key (book_id) references Books(id))

					
--inserting into review Table
insert into Review (id, book_id, reviewer_name, content, rating, published_date)
				values (1,1, 'John Smith', 'My First Review', 4, '2017-12-10'),
					   (2,2, 'John Smith', 'My Second Review', 5, '2017-10-13'),
					   (3,2, 'Alice Walker', 'Another Review', 1, '2017-10-22')

--Displaying review
select * from review

--creating customer table
create table Customer (ID int primary key,
					  Name varchar(20),
					  Age int,
					  Address varchar(20),
					  Salary float)

--inserting into customer table
insert into customer(ID, Name, Age, Address,Salary)
			values(1,'Ramesh',32,'Ahmedabad',2000.00),
				  (2, 'Khilan', 25, 'Delhi', 1500.00),
				  (3, 'Kaushik', 23, 'Kota', 2000.00),
				  (4, 'Chaitali', 25, 'Mumbai', 6500.00),
				  (5, 'Hardik', 27, 'Bhopal', 8500.00),
				  (6, 'Komal', 22, 'MP', 4500.00),
				  (7, 'Muffy', 24, 'Indore', 10000.00)

--displaying customer
select * from customer

--Creating orders Table
create table Orders(OID int primary key, Order_Date Date,
					Customer_ID int,
					Amount float,
					constraint CID_fk foreign key (Customer_ID) references Customer(ID))
					
--Inserting into orders table
insert into Orders(OID, Order_Date, Customer_ID, Amount)
			values(102, '2009-10-08', 3, 3000),
				  (100, '2009-10-08', 3, 1500),
				  (101, '2009-11-20', 2, 1560),
				  (103, '2008-05-20', 4, 2060)

--Displaying Orders Tables
select * from Orders


--creating table employee
create table Employee (ID int primary key,
					  Name varchar(20),
					  Age int,
					  Address varchar(20),
					  Salary int )
					  drop table Employee

--inserting into employee
insert into Employee values(1,'Ramesh',32,'Ahmedabad',2000.00),
				  (2, 'Khilan', 25, 'Delhi', 1500.00),
				  (3, 'Kaushik', 23, 'Kota', 2000.00),
				  (4, 'Chaitali', 25, 'Mumbai', 6500.00),
				  (5, 'Hardik', 27, 'Bhopal', 8500.00),
				  (6, 'Komal', 22, 'MP',Null),
				  (7, 'Muffy', 24, 'Indore', Null )

--Displaying Employee Table
select * from Employee


--Creating StudentDetails
create table StudentDetails(RegisterNo int primary key,
							Name varchar(30),
							Age int,
							Qualification varchar(30)
							,MobileNo bigint,
							Mail_id varchar(30),
							Location varchar(20),
							Gender varchar(2))

--inserting into studentDetails
insert into StudentDetails values(2,'Sai',22,'B.E',9952836777,'Sai@gmail.com','Chennai','M'),
								(3,'Kumar',20,'B.SC',7890125648,'Kumar@gmail.com','Madurai','M'),
								(4,'Selvi',22,'B.Tech',890467342,'selvi@gmail.com','Salem','F'),
								(5,'Nisha',25,'M.E',7834672310,'Nisha@gmail.com','Theni','F'),
								(6,'SaiSaran',21,'B.A',7890345678,'saran@gmail.com','Madurai','F'),
								(7,'Tom',23,'BCA',8901234675,'Tom@gmail.com','Pune','M')

--Displaying student details Table
select * from StudentDetails

--Query 1 : fetch the details of the books written by author whose name ends with er
select * from Books where author like '%er'


--Query 2 : Display the Title ,Author and ReviewerName for all the books from the above table
select b.title, b.author , r.reviewer_name from books as b, Review as r 
where r.book_id = b.id


--Query 3 : 
select reviewer_name,count(book_id) as 'Books Reviewed' from review 
group by reviewer_name 
having count(book_id) >1


--Query 4: Display the Name for the customer from above customer table who live in same address which has character o anywhere in address
select name, address from customer 
where Address like '%o%'


--Query 5 : Write a query to display the Date,Total no of customer placed order on same Date
select Order_Date, Count(Customer_ID) as 'Total Customers' from Orders
group by order_date
having count(customer_ID) > 1


--Query 6 : Display the Names of the Employee in lower case, whose salary is null
select LOWER(Name) as 'Lower Case Name' from Employee
where Salary is null


--Query 7 : sql server query to display the Gender,Total no of male and female from the above relation
select gender, count(*) as 'Gender Count' from StudentDetails
group by gender