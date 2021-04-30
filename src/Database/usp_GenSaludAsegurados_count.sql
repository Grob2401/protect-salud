
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
	@argErrorCode int OUTPUT
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT		COUNT(*) AS [Cantidad]
	FROM		SaludAsegurados
	WHERE		CodigoCliente = '000494';
    
END
GO
