USE SCOALASGBD;
GO

CREATE PROCEDURE InsertDataWithPartialRollback2
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

    DECLARE @CursID INT;
    DECLARE @ElevID INT;
    DECLARE @InsertCursuriSuccess BIT = 0;
    DECLARE @InsertEleviSuccess BIT = 0;

    BEGIN TRANSACTION;

    BEGIN TRY
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

        -- Inserare în tabela Cursuri
        INSERT INTO Cursuri (nume_curs, descriere)
        VALUES (@NumeCurs, @Descriere);

        -- Obținerea ID-ului cursului inserat
        SET @CursID = SCOPE_IDENTITY();
        SET @InsertCursuriSuccess = 1;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Logare eroare
        INSERT INTO LogErrors (error_message, error_datetime)
        VALUES (ERROR_MESSAGE(), GETDATE());
    END CATCH;

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Validare parametri
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

        -- Inserare în tabela Elevi
        INSERT INTO Elevi (nume, prenume, data_nasterii, adresa)
        VALUES (@Nume, @Prenume, @DataNasterii, @Adresa);

        -- Obținerea ID-ului elevului inserat
        SET @ElevID = SCOPE_IDENTITY();
        SET @InsertEleviSuccess = 1;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Logare eroare
        INSERT INTO LogErrors (error_message, error_datetime)
        VALUES (ERROR_MESSAGE(), GETDATE());
    END CATCH;

    IF @InsertCursuriSuccess = 1 AND @InsertEleviSuccess = 1
    BEGIN
        BEGIN TRANSACTION;

        BEGIN TRY
            -- Inserare în tabela intermediară Absente
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
    END
END;