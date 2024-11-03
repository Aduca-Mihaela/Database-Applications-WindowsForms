USE SCOALASGBD;
GO
--DEADLOCK - T1: update on table A + delay + update on table B

-- SET DEADLOCK_PRIORITY HIGH
-- SET DEADLOCK_PRIORITY LOW

BEGIN TRANSACTION
	update Profesori set specializare = 'Transaction 1'
	where varsta = 25;
	INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Profesori', CURRENT_TIMESTAMP)

	WAITFOR DELAY '00:00:07';

	update Elevi set nume = 'Transaction 1'
	where prenume = 'Maria';
	INSERT INTO LogTable(operationType, tableName, executionTime) VALUES ('UPDATE', 'Elevi', CURRENT_TIMESTAMP)
COMMIT TRAN;

select * from Profesori;
select * from Elevi;
/*
update Profesori set specializare = 'AAAABBBBBBBCCCCCCCCCCCC'
	where varsta = 35;
update Elevi set nume = 'AAAABbcd'
	where prenume = 'Maria';
*/
