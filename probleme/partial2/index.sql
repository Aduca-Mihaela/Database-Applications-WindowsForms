use PracticS4;
go
--create index Facturi_Adresa_Plata on Facturi(total_plata, adresa_factura);
select  total_plata, adresa_factura from Facturi order by total_plata;