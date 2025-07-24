--misc functions 

--isnull()
select ISNULL('Hello','replace value of null') as 'isnull'
select ISNULL(null,'replace value of null') as 'is null'

create table nullFunctionCheck
(serialno int, name varchar(30), loc varchar(20),
age int, occupation varchar(20))

insert into nullFunctionCheck values(1, 'Yogesh', 'India', 22, 'Software Engineer'),
								(2, 'Shankar', 'UK', null, 'Manager'),
								(3, 'Hema', 'USA', 22, 'TL'),
								(4, 'Naveen', 'India', null, 'Developer')

select * from nullFunctionCheck

select *, ISNULL(age, 30) as 'New Age' from nullFunctionCheck

update nullFunctionCheck set age = ISNULL(age, 30)

insert into nullFunctionCheck values(5, 'Syam', 'Canada', ISNULL(null, 25), 'Banker')


--coalesce 

declare @str1 char, @str2 char, @str3 char
--all values are null

select coalesce(@str1, @str2) as 'Coalesce Results',
case 
	when @str1 is not null then @str1
	when @str2 is null then 'is a null value'
	end as 'Case Result'

	select coalesce(null,null,null,5,null,null)
	--to apply the above using isnull
	select isnull(null, isnull(null, isnull(null, isnull(5, null))))

