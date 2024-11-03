USE SCOALASGBD;
GO

CREATE PROCEDURE DeadlockT1_C# AS
BEGIN
	BEGIN TRAN
	update Profesori set specializare = 'Transaction 1' where varsta = 25;
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Profesori', CURRENT_TIMESTAMP)
	WAITFOR DELAY '00:00:05'
	update Elevi set nume = 'Transaction 1' where prenume = 'Mihai123';
		INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Elevi', CURRENT_TIMESTAMP)
	COMMIT TRAN
END