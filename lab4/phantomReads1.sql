USE SCOALASGBD;
GO
--PHANTOM READS – T1: delay + insert + commit

BEGIN TRANSACTION
	WAITFOR DELAY '00:00:07'
	INSERT INTO Elevi(nume, prenume, data_nasterii, adresa) VALUES ('Mircea','Maria', '2002-03-03', 'adress');
	INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('INSERT', 'Elevi', CURRENT_TIMESTAMP)
COMMIT TRAN;

/*
select * from Elevi;
delete from Elevi where nume = 'Mircea';
select * from Elevi;
*/