use InfiniteDB

--creating emp table

create table Employees(empid int primary key,
						name varchar(20),
						salary int, 
						doj date)

--inserting into emp table

insert into Employees values(1, 'Yogesh', 60000 ,'2020/01/03'),
							(2, 'Rahul', 50000 ,'2018/06/05'),
							(3, 'Ravi', 55000 ,'2024/07/04'),
							(4, 'Anbu', 40000 ,'2017/10/06'),
							(5, 'Hema', 65000 ,'2025/11/09')


--Displaying emp

select * from Employees
								

--q1 : Write a query to display your birthday(day of week)

select datename(WEEKDAY, '2004/06/03') as 'BirthDay Week'


--q2 : Write a query to display your age in days

select DATEDIFF(DAY, '2006/06/03', GETDATE()) as 'Age in Days'


--q3 : Write a query to display all employees information those who joined before 5 years in the current month

select * from Employees 
where DATEDIFF(year, doj, GETDATE()) >= 5 and month(doj) = month(getdate())


--q4 : 			

create table Employees1(empid int primary key,
						name varchar(20),
						salary int, 
						doj date)


begin transaction

insert into Employees1 values(1, 'Yogesh', 60000 ,'2020/01/03'),
							(2, 'Rahul', 50000 ,'2018/06/05'),
							(3, 'Ravi', 55000 ,'2024/07/04')
save transaction t1

update Employees1 set salary = salary * 1.15 where empid = 2
select * from Employees1
save transaction t2

delete from Employees1 where empid =1 
select * from Employees1
rollback transaction t2

select * from Employees1
commit


-- q5 : Create a user defined function calculate Bonus for all employees of a  given dept 

create or alter function calculateBonus (@empno int)
returns varchar(100)
as
begin
  declare @bonus int, @sal int, @deptno int

  select @sal = salary, @deptno = deptno from emp where empno = @empno

  set @bonus = 
		case 
			when @deptno = 10 then  @sal * 0.15
			when @deptno = 20 then  @sal * 0.20
			else @sal * 0.05
		end
	return @bonus
 end

select empno, ename, job, salary, deptno, dbo.calculateBonus(empno) as 'Bonus' from emp


--q6 : Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500

create or alter procedure updateSal
as
 begin
	update e set e.salary = e.salary + 500 from emp e join dept d on e.deptno = d.deptno where d.dname = 'sales' and e.salary <1500
 end

 --executing procedure
 exec updateSal

 select * from emp
 




