create database S1
go
use S1
go

create table TipuriArticole(
Tid int primary key identity,
Tip varchar(50),
Categorie varchar(50) CHECK(Categorie IN ('A', 'B', 'C', 'D', 'BDI', 'N')),
Descriere varchar(50))

create table Articole(
Aid int primary key identity,
Titlu varchar(50) NOT NULL,
NrAutori int,
NrPagini int,
AnPublicare int,
Tid int foreign key references TipuriArticole(Tid))

insert into TipuriArticole values('Cercetare', 'A', 'Fizica moleculara'), 
('Inovatie', 'B', 'Cuantica')

insert into Articole values('Abordarea moleculara din principii de baza', 4, 12, 2018, 1), 
('Cuantica fluidelor in aplicatii de laborator', 2, 9, 2009, 2)