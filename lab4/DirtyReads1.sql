use SCOALASGBD;
go
-- Dirty Reads Transaction 1: update + delay + rollback

BEGIN TRANSACTION
	UPDATE Elevi SET
	adresa='New Adress' WHERE prenume = 'Ion'
	INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Elevi', CURRENT_TIMESTAMP)
	WAITFOR DELAY '00:00:10'
ROLLBACK TRANSACTION