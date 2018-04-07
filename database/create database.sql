create database PizzaOrderWebApp

use PizzaOrderWebApp

create table Category (
	CategoryID int IDENTITY(1,1) primary key,
	CategoryName nvarchar(50) not null,
	CategoryDescription varchar(200)
)

create table Food (
	FoodID varchar(10) primary key,
	FoodName nvarchar(50) not null,
	Ingredients nvarchar(MAX) not null,
	CategoryID int not null foreign key references Category(CategoryID),
	ImageString varchar(100)
)

create table Dish (
	FoodID varchar(10) foreign key references Food(FoodID),
	Size varchar(10),
	Price float not null,
	CONSTRAINT PK_Dish primary key (FoodID, Size)
)

create table Orders (
	OrderID int identity(1,1) primary key,
	OrderDate datetime not null,
	ShippedDate datetime not null,
	CustomerName nvarchar(100) not null,
	CustomerAddress nvarchar(MAX) not null,
	Phone varchar(20) not null,
	Note nvarchar(MAX) not null
)

create table OrderDetail (
	OrderID int foreign key references Orders(OrderID),
	FoodID varchar(10),
	Size varchar(10),
	Discount float not null,
	Quantity int not null,
	CONSTRAINT PK_Order primary key (OrderID, FoodID, Size),
	CONSTRAINT FK_Order foreign key (FoodID, Size) references Dish (FoodID, Size)
)

create table Contact (
	ContactName nvarchar(200) not null,
	Email varchar(50) primary key,
	Phone varchar(20),
	ContactMessage nvarchar(MAX) not null
)

create table Account (
	[User] nchar(50) primary key,
	[Password] nchar(50) not null
)