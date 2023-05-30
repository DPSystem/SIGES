/*
   jueves, 4 de agosto de 202200:12:22
   Usuario: 
   Servidor: diego-lenovo
   Base de datos: sindicato
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EventosAño ADD
	Linea1 varchar(MAX) NULL
GO
ALTER TABLE dbo.EventosAño SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
