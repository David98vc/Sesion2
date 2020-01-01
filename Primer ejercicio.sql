CREATE DATABASE EjercicioSemanaDos
GO

USE EjercicioSemanaDos
CREATE TABLE tblCalificacion
(
	Codigo				CHAR(4)		PRIMARY KEY,
	NombreBreve			VARCHAR(30)	NOT NULL,
	NombreCompleto		VARCHAR(60)	NOT NULL,
	Descripcion			VARCHAR(50) NOT NULL,
	FechaHoraRegistro	DATETIME	NOT NULL
)
GO

SET DATEFORMAT DMY
INSERT INTO tblCalificacion
(Codigo,NombreBreve,NombreCompleto,Descripcion,FechaHoraRegistro)
VALUES
('0000','Melina','De La Cruz','Dama','05/10/2020')
GO

CREATE PROC usp_Calificacion_Insertar
@parCodigo CHAR(4),
@parNombreBreve VARCHAR(30),
@parNombreCompleto VARCHAR(60),
@parDescripcion VARCHAR(50)
AS
INSERT INTO tblCalificacion
(Codigo,NombreBreve,NombreCompleto,Descripcion,FechaHoraRegistro)
VALUES
(@parCodigo,@parNombreBreve,@parNombreCompleto,@parDescripcion,GETDATE())
GO



CREATE PROC usp_Calificaion_Listar_Todo
AS
SELECT Codigo,NombreBreve,NombreCompleto,Descripcion,FechaHoraRegistro
FROM tblCalificacion
ORDER BY NombreBreve
GO