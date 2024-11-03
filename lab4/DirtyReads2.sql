use SCOALASGBD;
go

-- Dirty Reads Transaction 2: select + delay + select
-- Order of the operations: update - select - rollback - select

SET TRANSACTION ISOLATION LEVEL READ COMMITTED 
--SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	BEGIN TRAN
	SELECT * FROM Elevi;
	INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('SELECT', 'Elevi', CURRENT_TIMESTAMP)
	WAITFOR DELAY '00:00:15'
	SELECT * FROM Elevi;
	INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('SELECT', 'Elevi', CURRENT_TIMESTAMP)
COMMIT TRAN