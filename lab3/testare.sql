use SCOALASGBD;
go

-- Executăm procedura stocată cu un set de date de test
/*
EXEC InsertDataWithoutIDs
      @NumeCurs = 'Matehdbmatica',
      @Descriere = 'Curs de matematica',
      @Nume = 'Popebdscu',
      @Prenume = 'Isbaon',
      @DataNasterii = '2025-01-01',
      @Adresa = 'Str. Principală nr. 10',
      @DataAbsenta = '2024-05-15';
*/


EXEC InsertDataWithPartialRollback2
    @NumeCurs = 'matematica',
    @Descriere = 'Curs de matematica',
    @Nume = 'AAAAAA',
    @Prenume = 'AAAAAAAA',
    @DataNasterii = '2002-01-01',
    @Adresa = 'Str. Principală nr. 10',
    @DataAbsenta = '2024-05-15';

-- Verificăm dacă datele au fost inserate corect
SELECT * FROM Cursuri;
SELECT * FROM Elevi;
SELECT * FROM Absente;
SELECT * FROM LogErrors;
