USE SCOALASGBD;
GO
-- NON-REPEATABLE READS – T1: delay + update + commit

INSERT INTO Elevi(nume, prenume, data_nasterii, adresa) VALUES
('Moldovan','Mihai', '2002-03-03', 'adress');

BEGIN TRANSACTION
	WAITFOR DELAY '00:00:07'
	UPDATE Elevi SET prenume = 'Mihai123'
	WHERE  nume = 'Moldovan'
	INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Elevi', CURRENT_TIMESTAMP);
COMMIT TRAN;
/*
select * from Elevi;
delete from Elevi where nume = 'Moldovan';
select * from Elevi;
*/