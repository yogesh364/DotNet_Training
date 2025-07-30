create database ADO_CC_DB

use ADO_CC_DB
drop table employee
create table employee(EmpID int identity(1,1),
					  EmpName varchar(40),
					  Gender varchar(10),
					  Salary float,
					  NetSalary float)

--creating stored procedure
create procedure sp_insert_employee @name varchar(40), @gender varchar(10), @salary float, @netsalary float out , @empid int out 
as 
begin 
	set @netsalary = @salary - (@salary * 0.10)

	insert into employee (EmpName, Gender, Salary, NetSalary) values(@name, @gender, @salary, @netsalary)

	set @empid = SCOPE_IDENTITY()

	select EmpID, EmpName, Gender, Salary, NetSalary
    from employee
    where EmpID = @empid;
end



--executing procedure 

declare @netsalary float
declare @empid int

exec sp_insert_employee 
    @name = 'Yogesh', 
    @gender = 'Male', 
    @salary = 60000, 
  @netsalary = @netsalary output,
  @empid = @empid output


  --creating producure to update salary 

  create or alter procedure sp_update_salary  @empid int, @salary float output, @netsalary float output
  as 
  begin
  update employee set salary = salary + 100, netsalary = (salary + 100) - ((salary + 100) * 0.10)
  where empid = @empid

  select @salary = salary, @netsalary = netsalary from employee where empid = @empid

  select * from employee where empid = @empid
  end


  --executing procedures

declare @salary float, @netsalary float

exec sp_update_salary 
    @empid = 1,
    @salary = @salary output,
    @netsalary = @netsalary output







						