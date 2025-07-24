use InfiniteDB

--q1 : Write a T-Sql based procedure to generate complete payslip of a given employee

create or alter procedure payslip @empid int
as 
begin
	declare @empname varchar(100),
			@salary int,
			@hra float,
			@da float,
			@pf float,
			@it float,
			@deductions float,
			@gross float,
			@net float

	select @empname = empname, @salary = salary from employee where empid = @empid

	set @hra = 0.10 * @salary
	set @da = 0.20 * @salary
	set @pf = 0.08 * @salary
	set @it = 0.05 * @salary
	set @deductions = @pf + @it
	set @gross = @salary + @hra + @da
	set @net = @gross - @deductions

	print '*****************************************'
	print '            Employee Payslip             '
	print '*****************************************'
	print 'Employee ID      : ' + cast(@empid as varchar(20))  
	print 'Employee Name    : ' + @empname
	print '*****************************************'
	print 'Employee Salary  : ' + cast(@salary as varchar(20))
	print 'HRA              : ' + cast(@hra as varchar(20))
	print 'DA               : ' + cast(@da as varchar(20))
	print '*****************************************'
	print 'Gross            : ' + cast(@gross as varchar(20))
	print '*****************************************'
	print 'PF               : ' + cast(@pf as varchar(20))
	print 'IT               : ' + cast(@it as varchar(20))
	print 'Deductions       : ' + cast(@deductions as varchar(20))
	print '*****************************************'
	print 'Net Salary       : ' + cast(@net as varchar(20))
	print '*****************************************'
end

exec payslip 102

--q2 : Create a trigger to restrict data manipulation on EMP table during General holidays

create table holidays (hday int,
					   hmonth int,
					   hname varchar(100))

insert into holidays values(15, 8, 'Independence Day'),
							(14, 1, 'Pongal'),
							(15, 11, 'Diwali'),
							(25, 12, 'Christmas')

create or alter trigger restrictHolidays
on emp
for insert, update, delete
as
begin
	declare @hday int = day(getDate())
	declare @hmonth int = month(getDate())
	declare @hname varchar(30)
	declare @ans varchar(100)

	select @hname = hname from holidays where hday = @hday and hmonth = @hmonth
	set @ans = 'Due to ' + @hname + ' you cannot manipulate data'
	if(@hname is not null)
		begin
			raiserror(@ans,16,1)
			rollback transaction
		end
end

	







