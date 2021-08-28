--CREATE DATABASE prueba;

--USE prueba;

---DataTables

--CREATE TABLE usuarios (
--    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
--    Nombres VARCHAR(255),
--    ApellidoPaterno VARCHAR(255),
--    ApellidoMaterno VARCHAR(255),
--    Usuario VARCHAR(255),
--	Password VARCHAR(255),
--	Email VARCHAR(50),
--	Tipo VARCHAR(50),
--	Rol VARCHAR(50),
--	Telefono VARCHAR(50)
--);

--CREATE TABLE DetalleLlamadas (
--    CallDetailId INT PRIMARY KEY IDENTITY(1,1),
--	MobileLine INT,
--	CalledPartyNumber INT,
--	CalledPartyDescription VARCHAR(255),
--	DateTime DATETIME,
--	Duration INT, 
--	TotalCost FLOAT
--);

--CREATE TABLE LineasCelulares (
--MobileLineId INT PRIMARY KEY IDENTITY(1,1),
--MobileLine INT,
--Description VARCHAR(255)
--);

---DataTables

---STORED PROCEDURE

--CREATE PROCEDURE LoginUsuario @usuario varchar(255)
--AS
-- USE prueba
-- SELECT * FROM [prueba].[dbo].[usuarios] as usuario where usuario.usuario =@usuario
--GO	

--EXEC LoginUsuario 'ixban';


--CREATE PROCEDURE getLineasCelulares
--AS
-- SELECT * FROM [prueba].[dbo].[LíneasCelulares]
--GO	

--EXEC getLineasCelulares ;


--CREATE PROCEDURE [dbo].[getDetallesDeLlamadas] @MobileLine Varchar(50), @Descripcion Varchar(50)
--AS

--if (@MobileLine = '')
--begin
-- 
	--  DECLARE @TEMP TABLE ( MobileLine FLOAT, Descripcion VARCHAR(255))
	  
	--  INSERT  INTO @TEMP SELECT MobileLine, Description  FROM [prueba].[dbo].[LíneasCelulares] WHERE Description = @Descripcion
	
	--DECLARE @a INT
	--SELECT @a = COUNT(*) FROM @TEMP

	--IF(@a > 0)
	--begin

	--  SELECT Detalle.CallDetailId ,Detalle.MobileLine, Detalle.CalledPartyNumber, Detalle.CalledPartyDescription, Detalle.DateTime, Detalle.Duration, Detalle.TotalCost, Linea.Description FROM [prueba].[dbo].[DetalleDeLlamadas] AS Detalle INNER JOIN [prueba].[dbo].[LíneasCelulares] AS Linea ON Linea.MobileLine = Detalle.MobileLine WHERE Detalle.MobileLine IN (SELECT MobileLine FROM @TEMP)

	--end
--  end
--else 
--  begin
--     SELECT * FROM [prueba].[dbo].[DetalleDeLlamadas] AS Detalle WHERE Detalle.MobileLine = @MobileLine
--  end 

--EXEC getDetallesDeLlamadas 6241574688;

--CREATE PROCEDURE getUsuarios
--AS
-- SELECT * FROM [prueba].[dbo].[usuarios]
--GO	

--exec getUsuarios


--CREATE PROCEDURE userDelete @Id int
--AS
-- DELETE FROM [prueba].[dbo].[usuarios] WHERE IdUsuario = @Id;
--GO	

--CREATE PROCEDURE UsuarioAdd @Nombres VARCHAR(255), @ApellidoPaterno VARCHAR(255), @ApellidoMaterno VARCHAR(255), @UsuarioName VARCHAR(255), @Email VARCHAR(50), @Telefono VARCHAR(50)
--AS
-- INSERT INTO [prueba].[dbo].[usuarios]
--           ([Nombres]
--           ,[ApellidoPaterno]
--           ,[ApellidoMaterno]
--           ,[Usuario]
--           ,[Password]
--           ,[Email]
--           ,[Tipo]
--           ,[Rol]
--           ,[Telefono])
--     VALUES
--           (@Nombres
--           ,@ApellidoPaterno
--           ,@ApellidoMaterno
--           ,@UsuarioName
--           ,CONVERT(varchar(255), NEWID())
--           ,@Email
--           ,1
--           ,'Normal' 
--           ,@Telefono)
--GO

--CREATE PROCEDURE GetUsuarioId @id int
--AS
--	SELECT TOP (1000) [IdUsuario]
--      ,[Nombres]
--      ,[ApellidoPaterno]
--      ,[ApellidoMaterno]
--      ,[Usuario]
--      ,[Password]
--      ,[Email]
--      ,[Tipo]
--      ,[Rol]
--      ,[Telefono]
--  FROM [prueba].[dbo].[usuarios] WHERE usuarios.IdUsuario = @id
--GO

--CREATE PROCEDURE UpdateUsuario @IdUsuario INT, @Nombres VARCHAR(255), @ApellidoPaterno VARCHAR(255), @ApellidoMaterno VARCHAR(255), @UsuarioName VARCHAR(255), @Email VARCHAR(50), @Telefono VARCHAR(50)
--AS

--UPDATE [prueba].[dbo].[usuarios]
--   SET [Nombres] = @Nombres
--      ,[ApellidoPaterno] = @ApellidoPaterno
--      ,[ApellidoMaterno] = @ApellidoMaterno
--      ,[Usuario] = @UsuarioName
--      ,[Email] = @Email
--      ,[Telefono] = @Telefono
-- WHERE usuarios.IdUsuario = @IdUsuario

--GO




---STORED PROCEDURE

