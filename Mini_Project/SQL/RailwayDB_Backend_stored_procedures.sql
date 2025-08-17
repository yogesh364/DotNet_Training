use InfiniteDB


--Stored procedure for Train Details

create or alter procedure sp_train_detail
as
begin


	select t.TrainID, t.TrainName, t.Source, t.Destination, t.Departure_time, s.Class, s.AvailableSeats, s.Price
	from trains t join seats s 
	on t.trainID = s.trainID
	where s.availableseats > 0
	order by  t.departure_time
end

--Executing Procedure

exec sp_train_detail

--Deleting procedure

drop procedure sp_train_details

--Creating Procedure sp_train_detail_admin

create or alter procedure sp_train_detail_admin
as
begin
	select t.TrainID, t.TrainName, t.Source, t.Destination, t.Departure_time, s.Class, s.AvailableSeats, s.Price
	from trains t join seats s 
	on t.trainID = s.trainID
	order by  t.departure_time
end

--stored procedure for sp_get_train_details

create or alter procedure sp_get_train_details @tsource varchar(100), @tdestination varchar(100)
as
begin
	select t.TrainID, t.TrainName, t.Source, t.Destination, t.Departure_time, s.Class, s.AvailableSeats, s.Price
	from trains t join seats s 
	on t.trainID = s.trainID
	where (t.Source = @tsource and t.Destination = @tdestination)
	order by  t.departure_time
end

exec sp_get_train_details 'Chennai', 'Mysore'

--Executing procedure

exec sp_get_train_details 'chennai','mysore', 

--Deleting Procedure 

drop procedure sp_get_train_details

--Creating procedure sp_view_reservation

create or alter procedure sp_view_reseration  @uid int
as
begin
	select r.ReservationID, t.TrainName, t.Source, t.Destination, r.TravelDate, r.Class, r.SeatNo, r.status, r.BookingTime, p.PassengerID, p.Name, p.Age, p.Gender, p.mobile, p.status  as 'Passenger Status'                                  
	from Reservation r join Trains t on r.TrainID = t.TrainID
	join Passengers p on r.ReservationID = p.ReservationID
	where r.userID = @uid and r.status in('CONFIRMED','PARTIALLY_CANCELLED')
	order by r.reservationID, p.PassengerID

	select w.waitingID, t.TrainName, t.Source, t.Destination, w.TravelDate, w.Class, w.SeatNo, w.status, w.BookingTime, p.PassengerID, p.Name, p.Age, p.Gender, p.mobile, p.status as 'Passenger Status'                                   
	from WaitingList w join Trains t on w.TrainID = t.TrainID
	join Passengers p on w.waitingID = p.WaitingID
	where w.userID = @uid
	order by w.waitingID, p.PassengerID		
end

--Executing sp_view_reservation

exec sp_view_reseration 1


--Creating stored procedure sp_Reservation_Details

create or alter procedure sp_Reservation_Details @rid int
as
begin
	select  r.travelDate, r.Class, (select count(*) from passengers p where p.reservationID = r.reservationID and p.status = 'CONFIRMED') as 'TotalSeats', s.price, r.trainID from reservation r 
	inner join seats s on r.class = s.Class and r.trainID = s.TrainID
	where reservationID = @rid
end

--Executing sp_Reservation_Details

exec sp_Reservation_Details 8001

--creating stored procedure sp_cancel_reservation

create or alter procedure sp_cancel_reservation @rid int, @pid int = null, @refund float
as
begin
	declare @trainID int, @travelDate date, @class nvarchar(20), @seatsToRelease int, @pricePerSeat float

	begin try
		begin transaction

			select @trainID = trainId, @travelDate = travelDate, @class = class from reservation where reservationID = @rid

			if @pid is null
			begin
				select @seatsToRelease = count(*) from passengers where reservationID = @rid and status = 'CONFIRMED'

				set @pricePerSeat = @refund / @seatsToRelease

				insert into cancellation (reservationID, PassengerID, Name, TrainID, TravelDate, Class, Refund)
				select reservationID, PassengerID, Name, @trainID, @travelDate, @class, @pricePerSeat 
				from passengers where reservationID = @rid and status = 'CONFIRMED'

				update reservation set status = 'CANCELLED' where reservationID = @rid 

				update passengers set status = 'CANCELLED' where reservationID = @rid
			end	
			else
			begin
				select @seatsToRelease = count(*) from passengers where reservationID = @rid and passengerID = @pid and status = 'CONFIRMED'

				set @pricePerSeat = @refund / @seatsToRelease

				insert into cancellation (reservationID, PassengerID, Name, TrainID, TravelDate, Class, Refund)
				select reservationID, PassengerID, Name, @trainID, @travelDate, @class, @pricePerSeat 
				from passengers where passengerID = @pid and status = 'CONFIRMED'

				update Passengers set status = 'CANCELLED' where  reservationID = @rid and passengerID = @pid and status = 'CONFIRMED'

				update reservation set status = 'PARTIALLY_CANCELLED' where reservationID = @rid	
			end

			update seats set AvailableSeats = AvailableSeats + @seatsToRelease where TrainID = @trainID and Class = @class

			if not exists (select 1 from passengers where reservationID = @rid and status = 'CONFIRMED')
				begin
					update reservation set status = 'CANCELLED' where reservationID = @rid
				end

		commit transaction
	end try

	begin catch
		rollback transaction
		throw
	end catch
end

--creating stored procedure sp_cancel_waiting

create or alter procedure sp_cancel_waiting  @wid int, @refund float
as 
begin
	declare @trainID int, @travelDate date, @class nvarchar(20), @totalSeats int, @pricePerSeat float
	begin try
		begin transaction

			select @trainID = trainId, @travelDate = travelDate, @class = class from waitingList where waitingID = @wid

				select @totalSeats = count(*) from passengers where waitingID = @wid

				set @pricePerSeat = @refund / @totalSeats

				insert into cancellation (waitingID, PassengerID, Name, TrainID, TravelDate, Class, Refund)
				select waitingID, PassengerID, Name, @trainID, @travelDate, @class, @pricePerSeat 
				from passengers where waitingID = @wid

				update waitingList set status = 'CANCELLED' where waitingID = @wid
				
				update passengers set status = 'CANCELLED' where waitingID = @wid

		commit transaction
	end try

	begin catch
		rollback transaction
		throw
	end catch
end

--creating stored procedure sp_tranfer_to_reservation

create or alter procedure sp_tranfer_to_reservation @trainID int, @travelDate date, @class nvarchar(20)
as
begin
	declare @wid int, @seats int,@price float, @rid int
	begin try
		begin transaction
			while exists ( select 1 from waitingList w
							where w.trainID = @trainID and w.travelDate = @travelDate and w.class = @class
							and w.seatNo <= (select AvailableSeats from seats 
							where TrainID = @trainID and Class = @class))

			begin

				select top 1 @wid = waitingID, @seats = seatNo from waitingList 
				where trainID = @trainID and travelDate = @travelDate and class = @class
				and seatNo <= (select AvailableSeats from seats 
				where TrainID = @trainID and Class = @class)
				order by waitingID

				select @price = Price from seats where TrainID = @trainID and Class = @class

				insert into reservation (UserID, TrainID, TravelDate, Class, SeatNo, Status, TotalPrice)
				select userID, TrainID, TravelDate, Class, SeatNo, 'CONFIRMED', @price from waitingList where waitingID = @wid

				set @rid = SCOPE_IDENTITY()

				update passengers set reservationID = @rid, waitingID = null, status = 'CONFIRMED' where waitingID = @wid 
				
				delete from waitingList where waitingID = @wid

				update seats set AvailableSeats = AvailableSeats - @seats where TrainID = @trainID and Class = @class
			end
		commit transaction
	end try
	begin catch
		rollback transaction
		throw
	end catch
end

exec sp_tranfer_to_reservation 103, '2025-08-25', 'Sleeper'


--creating procedure sp_insert_train

create or alter procedure sp_insert_train @trainID int, @trainName varchar(100), @source varchar(20), @destination varchar(20), @dep_time time 
as
begin
	begin try
		begin transaction
			insert into Trains values(@trainID, @trainName, @source, @destination, @dep_time)

			insert into seats (trainID,  Class, TotalSeats, AvailableSeats, Price)
						values(@trainID,  'Sleeper', 10, 10, 500),
								(@trainID,  '2nd-Ac', 10, 10, 1000),
								(@trainID,  '3rd-AC', 10, 10, 1500)
		commit transaction
	end try
	begin catch
		rollback transaction
		throw
	end catch
end

--Creating procedure sp_get_reservation_details

create or alter procedure sp_get_reservation_details @start date, @end date
as
begin
	select r.ReservationID, t.TrainName, t.Source, t.Destination, r.TravelDate, r.Class, r.SeatNo, r.status, r.BookingTime, p.PassengerID, p.Name, p.Age, p.Gender, p.mobile, p.status  as 'Passenger Status'                                  
	from Reservation r join Trains t on r.TrainID = t.TrainID
	join Passengers p on r.ReservationID = p.ReservationID
	where  r.status in('CONFIRMED','PARTIALLY_CANCELLED') and r.travelDate between @start and @end
	order by r.reservationID, p.PassengerID
end

--creating procedure sp_get_waiting_details

create or alter procedure sp_get_waiting_details @start date, @end date
as
begin
select w.waitingID, t.TrainName, t.Source, t.Destination, w.TravelDate, w.Class, w.SeatNo, w.status, w.BookingTime, p.PassengerID, p.Name, p.Age, p.Gender, p.mobile, p.status as 'Passenger Status'                                   
	from WaitingList w join Trains t on w.TrainID = t.TrainID
	join Passengers p on w.waitingID = p.WaitingID
	where w.travelDate between @start and @end
	order by w.waitingID, p.PassengerID		
end

--Creating procedure sp_get_cancel_details

create or alter procedure sp_get_cancel_details @start date, @end date
as 
begin
	select c.CancellationID, c.ReservationID, c.waitingID,  t.TrainName, t.Source, t.Destination, c.TravelDate, c.Class, p.PassengerID, p.Name, p.Age, p.Gender, p.mobile, p.status as 'Passenger Status'
	from Cancellation c join Trains t on c.TrainID = t.TrainID
	join Passengers p on C.PassengerID = p.PassengerID
	where c.travelDate between @start and @end
	order by C.CancellationID, p.PassengerID
end
