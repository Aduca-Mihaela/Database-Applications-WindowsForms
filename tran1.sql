/*
-- Dirty Reads

-- Transaction 1 (T1)

BEGIN TRANSACTION;
UPDATE Profesori SET specializare = 'New Specialization' WHERE profesorID = 5;
WAITFOR DELAY '00:00:03';
ROLLBACK TRANSACTION;

SELECT * FROM Profesori;

-- Transaction 2 (T2)

BEGIN TRANSACTION;
SELECT * FROM Profesori WHERE profesorID = 5;
WAITFOR DELAY '00:00:04';
SELECT * FROM Profesori;
COMMIT;
*/


/*
-- Non-Repeatable Reads



-- Transaction 1 (T1)

INSERT INTO Profesori (numeProfesor, specializare, varsta, email) 
VALUES ('New Professor', 'New Specialization', 25, 'newprof@example.com');
BEGIN TRANSACTION;
WAITFOR DELAY '00:00:05';
UPDATE Profesori SET varsta = 40 WHERE profesorID = 10;
COMMIT;



SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
SELECT * FROM Profesori;
WAITFOR DELAY '00:00:01'
SELECT * FROM Profesori;
COMMIT TRAN

*/
--PHANTOM READS
/*
-- Transaction 1 (T1)
BEGIN TRANSACTION;
WAITFOR DELAY '00:00:05'; -- Introduce delay
INSERT INTO Profesori (numeProfesor, specializare, varsta, email) 
VALUES ('New Professor', 'New Specialization', 25, 'newprof@example.com');
COMMIT;

-- Transaction 2 (T2)
BEGIN TRANSACTION;
SELECT * FROM Profesori; -- See the initial state before T1 commit
WAITFOR DELAY '00:00:10';
SELECT * FROM Profesori; -- See the inserted value after T1 commit
COMMIT;
*/