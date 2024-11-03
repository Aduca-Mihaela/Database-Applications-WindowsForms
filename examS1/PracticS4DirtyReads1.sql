use PracticS4;
go
BEGIN TRANSACTION
	UPDATE Facturi SET
	adresa_factura='New Adress' WHERE total_plata = 180
	WAITFOR DELAY '00:00:10'
ROLLBACK TRANSACTION