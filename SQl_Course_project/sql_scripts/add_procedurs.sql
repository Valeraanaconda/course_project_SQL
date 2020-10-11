create procedure Add_apartment
	@area_ap float,
	@number_of_rooms int,
	@price float,
	@owner_ap char(30),
	@address_ap char(20),
	@number_of_balconies int,
	@cadastral_number int
as
insert into apartment (area_ap,number_of_rooms,price,owner_ap,address_ap,number_of_balconies,cadastral_number)
values (@area_ap,@number_of_rooms,@price,@owner_ap,@address_ap,@number_of_balconies,@cadastral_number)


create procedure Add_client
	@Full_name char(30),
	@passport_ID char(8),
	@issued_by char(20),
	@year_of_birth int,
	@date_of_birth int,
	@month_of_birth int,
	@place_of_residence char(20)
as
insert into client (Full_name,passport_ID,issued_by,year_of_birth,date_of_birth,month_of_birth,place_of_residence)
values (@Full_name,@passport_ID,@issued_by,@year_of_birth,@date_of_birth,@month_of_birth,@place_of_residence)

create procedure Add_deal_with_appartent
	@cadastral_number int,
	@area_ap float,
	@number_of_balcones int,
	@number_of_rooms int,
	@customer char(30),
	@saller char(30),
	@price float
as
insert into deal_with_appartment (cadastral_number,area_ap,number_of_balconies,number_of_rooms,customer,saller,price)
values (@cadastral_number,@area_ap,@number_of_balcones,@number_of_rooms,@customer,@saller,@price)

create procedure Add_deal_with_house
	@cadastral_number int,
	@number_of_rooms int,
	@number_of_floor int,
	@area_h float,
	@customer char(30),
	@saller char(30),
	@price float
as
insert into deal_with_house (cadastral_number,number_of_rooms,number_of_floor,area_h,customer,saller,price)
values (@cadastral_number,@number_of_rooms,@number_of_floor,@area_h,@customer,@saller,@price)

create procedure Add_house
	@number_of_rooms int,
	@number_of_floor int,
	@area_h int,
	@area_plot float,
	@owner_h char(30),
	@address_h char(20),
	@cadastral_number int
as
insert into house (number_of_rooms,number_of_floor,area_h,area_plot,owner_h,address_h,cadastral_number)
values (@number_of_rooms,@number_of_floor,@area_h,@area_plot,@owner_h,@address_h,@cadastral_number)

create procedure Add_worker
	@position char(10),
	@password int
as
insert into worker(position,password_w)
values (@position,@password)