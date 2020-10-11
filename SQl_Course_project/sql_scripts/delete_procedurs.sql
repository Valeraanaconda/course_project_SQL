create procedure Delete_apaetament
	@cadastral_number int
as
delete apartment where cadastral_number = @cadastral_number

create procedure Delete_client
	@id int
as
delete client where ID_client = @id

create procedure Delete_deal_with_appartment
	@id int
as
delete deal_with_appartment where ID_deal = @id

create procedure Delete_deal_with_house
	@id int
as
delete deal_with_house where ID_deal = @id

create procedure Delete_house
	@id int
as
delete house where ID_house = @id

create procedure Delete_worker
	@id int
as
delete worker where ID_worker = @id