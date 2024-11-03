CREATE PROCEDURE InsertDataWithoutIDs
(
    @NumeCurs NVARCHAR(100),
    @Descriere NVARCHAR(MAX),
    @Nume NVARCHAR(100),
    @Prenume NVARCHAR(100),
    @DataNasterii DATE,
    @Adresa NVARCHAR(100),
    @DataAbsenta DATE
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Validare parametri
        IF dbo.IsValidNumeCurs(@NumeCurs) = 0
        BEGIN
            RAISERROR('Numele cursului trebuie să înceapă cu literă mare.', 16, 1);
            RETURN;
        END;

        IF dbo.IsValidDescriere(@Descriere) = 0
        BEGIN
            RAISERROR('Descrierea cursului nu poate fi null.', 16, 1);
            RETURN;
        END;

        IF dbo.IsValidNume(@Nume) = 0
        BEGIN
            RAISERROR('Numele trebuie să înceapă cu literă mare.', 16, 1);
            RETURN;
        END;

        IF dbo.IsValidPrenume(@Prenume) = 0
        BEGIN
            RAISERROR('Prenumele trebuie să înceapă cu literă mare.', 16, 1);
            RETURN;
        END;

        IF dbo.IsValidDataNasterii(@DataNasterii) = 0
        BEGIN
            RAISERROR('Data nașterii trebuie să fie în trecut și nu poate fi null.', 16, 1);
            RETURN;
        END;

        -- Inserare în tabelele principale
        INSERT INTO Cursuri (nume_curs, descriere)
        VALUES (@NumeCurs, @Descriere);

        -- Obținerea ID-ului cursului inserat
        DECLARE @CursID INT;
        SET @CursID = SCOPE_IDENTITY();

        INSERT INTO Elevi (nume, prenume, data_nasterii, adresa)
        VALUES (@Nume, @Prenume, @DataNasterii, @Adresa);

        -- Obținerea ID-ului elevului inserat
        DECLARE @ElevID INT;
        SET @ElevID = SCOPE_IDENTITY();

        -- Inserare în tabela intermediară
        INSERT INTO Absente (cursID, elevID, data_absenta)
        VALUES (@CursID, @ElevID, @DataAbsenta);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Logare eroare
        INSERT INTO LogErrors (error_message, error_datetime)
        VALUES (ERROR_MESSAGE(), GETDATE());
    END CATCH;
END;


