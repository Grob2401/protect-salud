USE [BDIAFAS]
GO
/****** Object:  StoredProcedure [dbo].[usp_GenSaludAsegurados_count]    Script Date: 30/4/2021 05:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Billy Arredondo
-- Create date: 29-abr-2021
-- Description:	Devuelve número de asegurados
-- =============================================
ALTER PROCEDURE [dbo].[usp_GenSaludAsegurados_count]
	@keywords NVARCHAR(MAX) = '',
	@argErrorCode INT OUTPUT
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT		COUNT(*) AS [Cantidad]
	FROM		SaludAsegurados
	WHERE		CodigoCliente = '000494' AND
				CONCAT([ApellidoPaterno], [ApellidoMaterno], [Nombres]) LIKE CONCAT('%', @keywords, '%');
    
END
