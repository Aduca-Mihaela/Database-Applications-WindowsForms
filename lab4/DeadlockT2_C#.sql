USE SCOALASGBD;
GO

CREATE PROCEDURE DeadlockT2_C# AS
BEGIN
	--SET DEADLOCK_PRIORITY HIGH
	--SET DEADLOCK_PRIORITY LOW
	BEGIN TRAN
	update Elevi set nume = 'Transaction 2' where prenume = 'Mihai123';
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Elevi', CURRENT_TIMESTAMP)
	WAITFOR DELAY '00:00:05'
	update Profesori set specializare = 'Transaction 2' where varsta = 25;
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Profesori', CURRENT_TIMESTAMP)
	COMMIT TRAN
END
/*
SELECT * FROM Elevi
insert into Magazin(denumire, numarOrase) values ('Deadlock Store', 1)
insert into Elevi(idManager, nume, prenume, dataOcuparePost) values (459855, 'Deadlock', 'Manager', '2021-05-18')
*/