use Assignment2

--Creating student Table

create table Student (sid int primary key,sname varchar(20))

--Inserting into student table

insert into Student values(1,'Jack'),
							(2,'Rithvik'),
							(3,'Jaspreeth'),
							(4,'Praveen'),
							(5,'Bisa'),
							(6,'Suraj')

--Displaying Student Table

select * from Student

--Creating Marks Table

create table Marks (Mid int primary key,
					Sid int references Student(sid),
					Score int not null)

--Inserting into Marks Table

insert into Marks Values(1,1,23),
						(2,6,95),
						(3,4,98),
						(4,2,17),
						(5,3,53),
						(6,5,13)

--Displaying Marks Table

Select * from Marks

--q1 : Write a T-SQL Program to find the factorial of a given number.

declare @n int = 5, @num int
set @num = @n
declare @result int = 1

while(@n > 0)
	begin 
		set @result = @result * @n
		set @n = @n -1
	end

print 'Factorial of ' + cast(@num as varchar(20)) + ' is ' + cast(@result as varchar(20))
select @num as Number, @result as 'Factorial'


--q2 : Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number.

create or alter proc sp_MultyTable @num int
as
begin
declare @i int = 1, @val int
	while(@i <=10)
		begin
		set @val = @num * @i
		print cast(@num as varchar(10)) + ' * ' + cast(@i as varchar(10)) + ' = ' + cast(@val as varchar(10))
		set @i = @i + 1
		end
end

--executing procedure
declare @n int = 5
print 'The Multiplication Table is :'
exec sp_MultyTable @n

--q3: Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data

create or alter function Calculate(@score int)
returns varchar(100)
as
begin
return (case 
		when @score >= 50 then 'Pass'
		else 'Fail'
		end)
end

--Executing function

select s.sid, s.sname, m.score, dbo.Calculate(m.score) as 'Result' from student s
join marks m on s.sid = m.mid
		
		

