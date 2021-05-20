USE [BDIAFAS]
GO
/****** Object:  StoredProcedure [dbo].[usp_GenSaludAsegurados_sel]    Script Date: 30/4/2021 02:26:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GenSaludAsegurados_sel]
	@page INT = 1,
	@rowsPerPage INT = 100,
	@keywords NVARCHAR(MAX) = '',
	@argErrorCode INT OUTPUT  
  
AS
	
	SELECT		(T.[RowNumber] - 1) / @rowsPerPage + 1 AS [Page],
				(T.[RowNumber] - 1) % @rowsPerPage + 1 AS [Order],
				T.*

	FROM		(
					SELECT		
								ROW_NUMBER() OVER(ORDER BY CodigoCliente, CodigoTitular, Categoria) AS [RowNumber],
								ApellidoMaterno,
								ApellidoPaterno,
								ApellidosNombres,
								CantidadCarnet,
								Categoria,
								Celular,
								CodigoCentroCosto,
								CodigoCliente,
								CodigoCotizacion,
								CodigoDocumentoIdentidad,
								CodigoParentesco,
								CodigoSexo,
								CodigoTipoTrabajador,
								CodigoTitular,
								CodigoTrabajador,
								CodigoUbigeo,
								Direccion,
								Email,
								Estado,
								FechaAlta,
								FechaBaja,
								FechaEmisionCarnet,
								FechaFinLatencia,
								FechaInicioLatencia,
								FechaNacimiento,
								FechaReemisionCarnet,
								Nombres,
								NumeroDocumentoIdentidad,
								Peso,
								RegAddDate,
								RegAddUser,
								RegEdtDate,
								RegEdtUser,
								SCTREstadoCivil,
								SCTRMoneda,
								SCTRPSCertificado,
								SCTRSueldo,
								SCTRTipoTrabajador,
								Talla,
								Telefono
				
					FROM		SaludAsegurados

					WHERE		[CodigoCliente] = '000494' AND
								CONCAT([ApellidoPaterno], [ApellidoMaterno], [Nombres]) LIKE CONCAT('%', @keywords, '%')

				) AS T
				
	WHERE		
				( (T.[RowNumber] - 1) / @rowsPerPage ) + 1 = @page; -- Filtra el número de página
   
	SET @argErrorCode = @@ERROR  

   