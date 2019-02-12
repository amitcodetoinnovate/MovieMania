
CREATE PROCEDURE [dbo].[uspGetActors]
	
	@Success BIT OUT
	,@Message VARCHAR(50) OUT
AS
	BEGIN TRY
		SELECT * FROM Actors ORDER BY 1 DESC
		SET @Success = 1
		SET @Message = ERROR_MESSAGE()
	END TRY
		
	BEGIN CATCH
		SET @Success = 0
		SET @Message ='Actors found.'
	END CATCH




	
GO
CREATE PROCEDURE [dbo].[uspGetProducer]
	
	@Success BIT OUT
	,@Message VARCHAR(50) OUT
AS
	BEGIN TRY
		SELECT * FROM Producers ORDER BY 1 DESC
		SET @Success = 1
		SET @Message = 'Producers found.'
	END TRY
		
	BEGIN CATCH
		SET @Success = 0
		SET @Message = ERROR_MESSAGE()
	END CATCH




	
GO
