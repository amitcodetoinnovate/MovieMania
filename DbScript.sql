USE [master]
GO
/****** Object:  Database [AmitMovie]    Script Date: 2/12/2019 7:47:04 AM ******/
CREATE DATABASE [AmitMovie]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DeltaXMovie', FILENAME = N'D:\MSServer\MSSQL\DATA\DeltaXMovie.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DeltaXMovie_log', FILENAME = N'D:\MSServer\MSSQL\DATA\DeltaXMovie_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AmitMovie] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AmitMovie].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AmitMovie] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AmitMovie] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AmitMovie] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AmitMovie] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AmitMovie] SET ARITHABORT OFF 
GO
ALTER DATABASE [AmitMovie] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AmitMovie] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AmitMovie] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AmitMovie] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AmitMovie] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AmitMovie] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AmitMovie] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AmitMovie] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AmitMovie] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AmitMovie] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AmitMovie] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AmitMovie] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AmitMovie] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AmitMovie] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AmitMovie] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AmitMovie] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AmitMovie] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AmitMovie] SET RECOVERY FULL 
GO
ALTER DATABASE [AmitMovie] SET  MULTI_USER 
GO
ALTER DATABASE [AmitMovie] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AmitMovie] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AmitMovie] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AmitMovie] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AmitMovie] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AmitMovie] SET QUERY_STORE = OFF
GO
USE [AmitMovie]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [AmitMovie]
GO
/****** Object:  UserDefinedTableType [dbo].[UT_ActorMovie]    Script Date: 2/12/2019 7:47:04 AM ******/
CREATE TYPE [dbo].[UT_ActorMovie] AS TABLE(
	[ActorId] [int] NOT NULL,
	[MovieId] [int] NULL
)
GO
/****** Object:  Table [dbo].[ActorMovie]    Script Date: 2/12/2019 7:47:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActorMovie](
	[ActorId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 2/12/2019 7:47:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Sex] [bit] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Bio] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieProducer]    Script Date: 2/12/2019 7:47:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieProducer](
	[MovieId] [int] NOT NULL,
	[ProducerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 2/12/2019 7:47:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieName] [varchar](30) NOT NULL,
	[YearOfRelease] [tinyint] NOT NULL,
	[Plot] [varchar](max) NULL,
	[Poster] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producers]    Script Date: 2/12/2019 7:47:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Sex] [bit] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Bio] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actors] ([Id])
GO
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[MovieProducer]  WITH CHECK ADD FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[MovieProducer]  WITH CHECK ADD FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producers] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[uspInsertActor]    Script Date: 2/12/2019 7:47:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspInsertActor]
	@ActorName VARCHAR(30)
	,@Sex BIT
	,@DateOfBirth Date
	,@Bio VARCHAR(MAX)
	,@Success BIT OUT
	,@Message VARCHAR(50) OUT
AS
	BEGIN TRY
		IF NOT EXISTS(SELECT 1 FROM Actors WHERE Name =@ActorName)
			BEGIN
				INSERT INTO Actors WITH (ROWLOCK) (Name,Sex,DateOfBirth,Bio)
							VALUES(@ActorName,@Sex,@DateOfBirth,@Bio)
				SET @Success = 1
				SET @Message = 'Actor added successfully.'
			END
		ELSE 
			BEGIN
				SET @Success = 0
				SET @Message = 'Actor already exists.'
			END
	END TRY
		
	BEGIN CATCH
		SET @Success = 0
		SET @Message = ERROR_MESSAGE()
	END CATCH




	
GO
/****** Object:  StoredProcedure [dbo].[uspInsertProducer]    Script Date: 2/12/2019 7:47:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspInsertProducer]
	@ProducerName VARCHAR(30)
	,@Sex BIT
	,@DateOfBirth Date
	,@Bio VARCHAR(MAX)
	,@Success BIT OUT
	,@Message VARCHAR(50) OUT
AS
	BEGIN TRY
		IF NOT EXISTS(SELECT 1 FROM Producers WHERE Name =@ProducerName)
			BEGIN
				INSERT INTO Producers WITH (ROWLOCK) (Name,Sex,DateOfBirth,Bio)
							VALUES(@ProducerName,@Sex,@DateOfBirth,@Bio)
				SET @Success = 1
				SET @Message = 'Producer added successfully.'
			END
		ELSE 
			BEGIN
				SET @Success = 0
				SET @Message = 'Producer already exists.'
			END
	END TRY
		
	BEGIN CATCH
		SET @Success = 0
		SET @Message = ERROR_MESSAGE()
	END CATCH




	
GO
/****** Object:  StoredProcedure [dbo].[uspMovieManagement]    Script Date: 2/12/2019 7:47:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMovieManagement]
	@Mode TINYINT
	,@MovieId INT
	,@MovieName VARCHAR(30)
	,@YearOfRelease TINYINT
	,@Plot VARCHAR(MAX)
	,@Poster VARCHAR(MAX)
	,@ProducerId INT
	,@InputActorMovie dbo.[UT_ActorMovie] READONLY
	,@Success BIT OUT
	,@Message VARCHAR(50) OUT
AS
	BEGIN TRY
		BEGIN TRANSACTION
			IF @Mode = 1
				BEGIN
					DECLARE @TempTable AS UT_ActorMovie
					INSERT INTO @TempTable (ActorId,MovieId)
						SELECT * FROM @InputActorMovie
					
					INSERT INTO Movies WITH (ROWLOCK) (MovieName,YearOfRelease,Plot,Poster)
						VALUES(@MovieName,@YearOfRelease,@Plot,@Poster)
					SET @MovieId  = SCOPE_IDENTITY()
					UPDATE @TempTable SET MovieId = @MovieId
					INSERT INTO ActorMovie  
						SELECT * FROM @InputActorMovie
					INSERT INTO MovieProducer WITH (ROWLOCK) (MovieId,ProducerId)
						VALUES(@MovieId,@ProducerId)
					SET @Success = 1
					SET @Message = 'Movie successfully inserted.'
				END
			ELSE
				BEGIN
					UPDATE Movies SET MovieName = @MovieName , YearOfRelease = @YearOfRelease,Plot =@Plot,Poster=@Poster 
						WHERE Id = @MovieId
					UPDATE MovieProducer SET ProducerId = @ProducerId
						WHERE MovieId = @MovieId
					DELETE FROM ActorMovie 
						WHERE MovieId = @MovieId
					INSERT INTO ActorMovie 
						SELECT * FROM @InputActorMovie
					SET @Success = 1
					SET @Message = 'Movie successfully updated.'
				END
		COMMIT TRANSACTION
	END TRY
		
	BEGIN CATCH
		IF XACT_STATE() <> 0
			BEGIN
				ROLLBACK TRANSACTION
			END
		SET @Success = 0
		SET @Message = ERROR_MESSAGE()
	END CATCH




	
GO
USE [master]
GO
ALTER DATABASE [AmitMovie] SET  READ_WRITE 
GO
