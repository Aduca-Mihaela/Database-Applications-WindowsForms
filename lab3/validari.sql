use SCOALASGBD;
GO

CREATE FUNCTION dbo.IsValidNumeCurs(@NumeCurs NVARCHAR(100))
RETURNS BIT
AS
BEGIN
    DECLARE @IsValid BIT = 0;

    -- Verifică dacă numele cursului nu este nul
    IF @NumeCurs IS NULL
        RETURN 0;

    -- Verifică dacă primul caracter este o literă mare
    IF LEFT(@NumeCurs, 1) COLLATE Latin1_General_CS_AS <> UPPER(LEFT(@NumeCurs, 1))
        RETURN 0;

    -- Toate condițiile de validare sunt îndeplinite
    RETURN 1;
END;
GO

CREATE FUNCTION dbo.IsValidDescriere(@Descriere NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
    DECLARE @IsValid BIT = 0;
    IF @Descriere IS NOT NULL
        SET @IsValid = 1;
    RETURN @IsValid;
END;
GO

CREATE FUNCTION dbo.IsValidElevID(@ElevID INT)
RETURNS BIT
AS
BEGIN
    DECLARE @IsValid BIT = 0;
    IF EXISTS (SELECT 1 FROM Elevi WHERE elevID = @ElevID)
        SET @IsValid = 1;
    RETURN @IsValid;
END;
GO

CREATE FUNCTION dbo.IsValidCursID(@CursID INT)
RETURNS BIT
AS
BEGIN
    DECLARE @IsValid BIT = 0;
    IF EXISTS (SELECT 1 FROM Cursuri WHERE cursID = @CursID)
        SET @IsValid = 1;
    RETURN @IsValid;
END;
GO

CREATE FUNCTION dbo.IsValidDataAbsenta(@DataAbsenta DATE)
RETURNS BIT
AS
BEGIN
    DECLARE @IsValid BIT = 0;
    IF @DataAbsenta IS NOT NULL AND @DataAbsenta <= GETDATE()
        SET @IsValid = 1;
    RETURN @IsValid;
END;
GO

CREATE FUNCTION dbo.IsValidNume(@Nume NVARCHAR(100))
RETURNS BIT
AS
BEGIN
    DECLARE @IsValid BIT = 0;

    -- Verifică dacă numele nu este null și începe cu literă mare
    IF @Nume IS NOT NULL AND LEFT(@Nume, 1) COLLATE Latin1_General_CS_AS = UPPER(LEFT(@Nume, 1))
        SET @IsValid = 1;

    RETURN @IsValid;
END;
GO

CREATE FUNCTION dbo.IsValidPrenume(@Prenume NVARCHAR(100))
RETURNS BIT
AS
BEGIN
    DECLARE @IsValid BIT = 0;

    -- Verifică dacă prenumele nu este null și începe cu literă mare
    IF @Prenume IS NOT NULL AND LEFT(@Prenume, 1) COLLATE Latin1_General_CS_AS = UPPER(LEFT(@Prenume, 1))
        SET @IsValid = 1;

    RETURN @IsValid;
END;
GO

CREATE FUNCTION dbo.IsValidDataNasterii(@DataNasterii DATE)
RETURNS BIT
AS
BEGIN
    DECLARE @IsValid BIT = 0;
    IF @DataNasterii IS NOT NULL AND @DataNasterii <= GETDATE()
        SET @IsValid = 1;
    RETURN @IsValid;
END;
GO