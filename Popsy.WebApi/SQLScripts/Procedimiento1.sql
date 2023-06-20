USE [BDSIPDV]
GO

/****** Object:  StoredProcedure [dbo].[SeguimientoPDV_BDSIPDV]    Script Date: 06/06/2023 16:27:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SeguimientoPDV_BDSIPDV]

AS
BEGIN
		DELETE FROM [BDSIPDV].[dbo].[SeguimientoPDV]
		-----------------------ECP----------------------------------------
		INSERT INTO [BDSIPDV].[dbo].[SeguimientoPDV]
		SELECT 'ECP' AS COMPAÑIA,
				[PdV],
				[ULTIMA ACTUALIZACION DEL SISTEMA],
				[T_EN_COLA],
				[T_HOY]
		FROM [192.168.2.245].[BDPERU_JV].[dbo].[OK_SEGUIMIENTO_PDV]
		-----------------FUP----------------------------------------------
		INSERT INTO [BDSIPDV].[dbo].[SeguimientoPDV]
		SELECT 'FUP' AS COMPAÑIA,
				[PdV],
				[ULTIMA ACTUALIZACION DEL SISTEMA],
				[T_EN_COLA],
				[T_HOY]
		FROM [192.168.2.245].[BDPERU].[dbo].[OK_SEGUIMIENTO_PDV]
		------------------CA---------------------------------------------
		INSERT INTO [BDSIPDV].[dbo].[SeguimientoPDV]
		SELECT 'CA' AS COMPAÑIA,
				[PdV],
				[ULTIMA ACTUALIZACION DEL SISTEMA],
				[T_EN_COLA],
				[T_HOY]
		FROM [192.168.2.245].[BDPOPSYCA].[dbo].[OK_SEGUIMIENTO_PDV]
		-------------------ECC--------------------------------------------
		INSERT INTO [BDSIPDV].[dbo].[SeguimientoPDV]
		SELECT 'ECC' AS COMPAÑIA,
				[PdV],
				[ULTIMA ACTUALIZACION DEL SISTEMA],
				[T_EN_COLA],
				[T_HOY]
		FROM [192.168.2.244].[EXPERTOSCAFE].[dbo].[OK_SEGUIMIENTO_PDV]
		-------------------PH--------------------------------------------
		INSERT INTO [BDSIPDV].[dbo].[SeguimientoPDV]
		SELECT 'PH' AS COMPAÑIA,
				[PdV],
				[ULTIMA ACTUALIZACION DEL SISTEMA],
				[T_EN_COLA],
				[T_HOY]
		FROM [BDPANAMA].[dbo].[OK_SEGUIMIENTO_PDV]

END
GO


