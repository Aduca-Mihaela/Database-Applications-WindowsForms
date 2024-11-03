use SCOALASGBD;
GO
--NonRepeatableReads T2: select + delay + select
--Isolation level: Read Committed(problem) / Repeatable Read (solution)
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ-- PROBLEM : READ COMMITTED
BEGIN TRAN
	print '1'
	SELECT * FROM Elevi;
	INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('SELECT', 'Elevi', CURRENT_TIMESTAMP)
	WAITFOR DELAY '00:00:10'
	print '2'
	SELECT * FROM Elevi;
	INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('SELECT', 'Elevi', CURRENT_TIMESTAMP)
COMMIT TRAN;

select * from Elevi;