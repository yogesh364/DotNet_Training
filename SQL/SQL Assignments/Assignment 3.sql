use Assignment2

select * from emp 

alter table emp 
alter column hire_date date

--1. Retrieve a list of MANAGERS. 

select * from emp
where job = 'Manager'

--2. Find out the names and salaries of all employees earning more than 1000 per month. 

select ename, salary from emp 
where salary > 1000

--3. Display the names and salaries of all employees except JAMES.

select * from emp except ( select * from emp where ename = 'james')

--4. Find out the details of employees whose names begin with ‘S’.

select * from emp where ename like 's%'

--5. Find out the names of all employees that have ‘A’ anywhere in their name. 

select * from emp where ename like '%a%'

--6. Find out the names of all employees that have ‘L’ as their third character in their name. 

select * from emp where ename like '__l%'

--7. Compute daily salary of JONES. 

select ename , (salary / 30) as 'Daiy Salary' from emp where ename = 'Jones'

--8. Calculate the total monthly salary of all employees. 

select sum(salary) as 'Total Monthly Salary' from emp

--9. Print the average annual salary . 

select avg(salary * 12) as 'Average Annual Salary' from emp

--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 

select ename, job, salary, deptno from emp except 
(select ename, job, salary, deptno from emp where deptno = 30 and job = 'salesman')
order by deptno

--11. List unique departments of the EMP table. 

select distinct deptno from emp

--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. 
--Label the columns Employee and Monthly Salary respectively.

select ename as 'Employee', salary as 'Monthly Salary' from emp 
where salary > 1500 and (deptno = 10 or deptno = 30)

--13. Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000. 

select ename , job , salary from emp where (job = 'manager' or job = 'analyst') and salary not in (1000, 3000, 5000)

--14. Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 

select ename, salary, comm from emp
where comm > (salary + (salary * 0.1))

--15. Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782. 

select ename from emp where ename like '%l%l%' and (deptno = 30 or mgr_id = 7782)

--16. Display the names of employees with experience of over 30 years and under 40 yrs.

select ename, DATEDIFF(year, hire_date, GETDATE()) as 'Experience' from emp
where DATEDIFF(year, hire_date, GETDATE()) between 31 and 39

-- Count the total number of employees.

select count(*) as 'Experience' from emp
where DATEDIFF(year, hire_date, GETDATE()) between 31 and 39

--17. Retrieve the names of departments in ascending order and their employees descending 

select d.dname, e.ename from dept d join emp e on d.deptno = e.deptno
order by d.dname , e.ename desc

--18. Find out experience of MILLER. 

select ename , DATEDIFF(year, hire_date, getdate()) as 'Experience' from emp 
where ename = 'Miller'