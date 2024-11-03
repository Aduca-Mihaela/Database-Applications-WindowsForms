USE master
GO
IF(EXISTS(SELECT * FROM sys.databases WHERE name='PracticS4'))
	DROP DATABASE PracticS4;
GO
CREATE DATABASE PracticS4;
GO
USE PracticS4;
GO


CREATE TABLE Servicii
(
cod_serviciu INT PRIMARY KEY IDENTITY,
nume VARCHAR(50),
descriere varchar(50)
);
CREATE TABLE Oferte
(
cod_oferta INT PRIMARY KEY IDENTITY,
nume_companie VARCHAR(200),
data_inceput date,
data_sfarsit date,
pret_unitate real,
cod_serviciu INT FOREIGN KEY REFERENCES Servicii(cod_serviciu)
ON UPDATE CASCADE ON DELETE CASCADE
);
CREATE TABLE Clienti
(
cod_client INT PRIMARY KEY IDENTITY,
nume VARCHAR(200),
adresa varchar(200)
);
CREATE TABLE Facturi
(
cod_factura INT PRIMARY KEY IDENTITY,
data_emitere date,
data_scadenta date,
total_plata real,
adresa_factura varchar(100),
cod_client INT FOREIGN KEY REFERENCES Clienti(cod_client)
ON UPDATE CASCADE ON DELETE CASCADE
);
CREATE TABLE DetaliiFacturi
(
cod_factura INT FOREIGN KEY REFERENCES Facturi(cod_factura)
ON UPDATE CASCADE ON DELETE CASCADE,
cod_oferta INT FOREIGN KEY REFERENCES Oferte(cod_oferta)
ON UPDATE CASCADE ON DELETE CASCADE,
cantitate int
CONSTRAINT pk_Detalii PRIMARY KEY (cod_factura, cod_oferta)
);
--Servicii
INSERT INTO Servicii(nume, descriere) VALUES
('Internet', 'Servicii de internet fix'), 
('Date mobile', 'Servicii de internet mobil'),
('Roamind', 'Servicii de date mobile in roaming');
--Oferte
INSERT INTO Oferte(nume_companie, data_inceput, data_sfarsit, pret_unitate, cod_serviciu) VALUES
('Digi', '2024-01-01', '2024-03-31', 0.02, 1),
('Telekom', '2024-01-01', '2024-06-30', 0.03, 1),
('Vodafone', '2024-03-01', '2014-05-31', 0.05, 1),
('Vodafone', '2024-01-01', '2014-12-31', 0.07, 2),
('Orange', '2024-01-01', '2014-12-31', 0.06, 2),
('Digi', '2024-01-01', '2014-06-30', 0.05, 2),
('Digi', '2024-01-01', '2024-03-31', 0.10, 3),
('Orange', '2024-01-01', '2014-12-31', 0.12, 3),
('Vodafone', '2024-01-01', '2014-12-31', 0.14, 3);
--Clienti
INSERT INTO Clienti(nume, adresa) VALUES 
('Andrei Popescu', 'Str. Gheorghe Lazăr nr. 23, București'),
('Maria Ionescu', 'Bd. Republicii nr. 56, Cluj-Napoca'),
('Ion Mihai', 'Str. Vasile Alecsandri nr. 10, Timișoara');
--Facturi 
INSERT INTO Facturi(data_emitere, data_scadenta, total_plata, adresa_factura, cod_client) VALUES
('2024-06-01', '2024-07-01', 150.50, 'Bucharest, Strada Victoriei 12, Romania', 1),
('2024-06-05', '2024-07-05', 220.75, 'Cluj-Napoca, Piața Unirii 5, Romania', 1),
('2024-06-10', '2024-07-10', 180.00, 'Timișoara, Strada Mărășești 8, Romania', 1),
('2024-06-15', '2024-07-15', 300.25, 'Iași, Strada Palat 3, Romania', 2),
('2024-06-20', '2024-07-20', 270.80, 'Constanța, Bulevardul Mamaia 20, Romania', 2),
('2024-06-25', '2024-07-25', 190.35, 'Sibiu, Piața Mare 10, Romania', 2),
('2024-06-30', '2024-07-30', 210.00, 'Brașov, Piața Sfatului 15, Romania', 3),
('2024-07-05', '2024-08-04', 180.50, 'Oradea, Strada Independenței 30, Romania', 3),
('2024-07-10', '2024-08-09', 250.75, 'Craiova, Strada Brestei 7, Romania', 3);

--Detalii
INSERT INTO DetaliiFacturi(cod_factura, cod_oferta, cantitate) VALUES
(1, 6, 2000),
(1, 1, 2525),
(2, 8, 1839.59);





