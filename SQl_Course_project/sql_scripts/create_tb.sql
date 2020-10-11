create database Estate_agancy

use Estate_agancy
go

create table apartment(
	ID_apartment int identity,
	area_ap float,
	number_of_rooms int,
	price float,
	state_p int,
	owner_ap char(30),
	address_ap char(20),
	number_of_balconies int,
	cadastral_number int,
	primary key(ID_apartment)
);


create table house(
	ID_house int identity,
	number_of_rooms int,
	number_of_floor int,
	area_h float,
	area_plot float,
	owner_h char(30),
	address_h char(20),
	cadastral_number int,
	price float,
	state_h int
	primary key(ID_house)
);


create table deal_with_appartment(
	ID_deal int identity,
	cadastral_number int,
	area_ap float,
	number_of_balconies int,
	number_of_rooms int,
	customer char(30),
	saller char(30),
	price float,
	primary key(ID_deal)
);
create table deal_with_house(
	ID_deal int identity,
	cadastral_number int,
	number_of_rooms int,
	number_of_floor int,
	area_h float,
	customer char(30),
	saller char(30),
	price float,
	primary key(ID_deal)
);
create table client(
	ID_client int identity,
	Full_name char(30),
	passport_ID char(8),
	issued_by char (20),
	year_of_birth int,
	date_of_birth int,
	month_of_birth int,
	place_of_residence char(20)
	primary key(ID_client)
);
create table worker(
	ID_worker int identity,
	position char(10),
	password_w int,
	primary key(ID_worker)
);

create procedure Add_apartment
	@area_ap float,
	@number_of_rooms int,
	@price float,
	@owner_ap char(30),
	@address_ap char(20),
	@number_of_balconies int,
	@cadastral_number int,
	@state int
as
insert into apartment(area_ap,number_of_rooms,price,owner_ap,address_ap,number_of_balconies,cadastral_number,state_p)
values (@area_ap,@number_of_rooms,@price,@owner_ap,@address_ap,@number_of_balconies,@cadastral_number,@state)