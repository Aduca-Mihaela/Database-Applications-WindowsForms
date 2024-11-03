use Problema1;
go

BEGIN TRANSACTION
UPDATE Briose SET nume_briosa='briosica' where cod_briosa=1
WAITFOR DELAY '00:00:07';
ROLLBACK TRANSACTION;