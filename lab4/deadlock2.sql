USE SCOALASGBD;
GO

-- T2: update on table B + delay + update on table A 
-- SET DEADLOCK_PRIORITY HIGH
-- SET DEADLOCK_PRIORITY LOW

BEGIN TRANSACTION
	update Elevi set nume = 'Transaction 2'
	where prenume = 'Maria';
	INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Elevi', CURRENT_TIMESTAMP)

	WAITFOR DELAY '00:00:07';

	update Profesori set specializare = 'Transaction 2'
	where varsta = 25;
	INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Profesori', CURRENT_TIMESTAMP)
COMMIT TRAN;

select * from Profesori;
select * from Elevi;

/*
update Profesori set specializare = 'AAAABBBBBBBCCCCCCCCCCCC'
	where varsta = 35;
update Elevi set nume = 'AAAABbcd'
	where prenume = 'Maria';
	*/