
--Stored procedure for Train Details

create or alter procedure sp_train_details
as
begin
	select t.TrainID, t.TrainName, t.Source, t.Destination, t.Departure_Date, t.Departure_time, s.Class, s.AvailableSeats, s.Price
	from trains t join seats s 
	on t.trainID = s.trainID
	where s.availableseats > 0
	order by t.departure_date, t.departure_time
end

--Executing Procedure

exec sp_train_details

--Deleting procedure

drop procedure sp_train_details