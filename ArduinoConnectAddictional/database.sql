USE [master]
GO
/****** Object:  Database [ArduinoConnect]    Script Date: 19.11.2020 21:42:58 ******/
CREATE DATABASE [ArduinoConnect]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArduinoConnect', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ArduinoConnect.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ArduinoConnect_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ArduinoConnect_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ArduinoConnect] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArduinoConnect].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArduinoConnect] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArduinoConnect] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArduinoConnect] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArduinoConnect] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArduinoConnect] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArduinoConnect] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ArduinoConnect] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArduinoConnect] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArduinoConnect] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArduinoConnect] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArduinoConnect] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArduinoConnect] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArduinoConnect] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArduinoConnect] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArduinoConnect] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ArduinoConnect] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArduinoConnect] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArduinoConnect] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArduinoConnect] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArduinoConnect] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArduinoConnect] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ArduinoConnect] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArduinoConnect] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ArduinoConnect] SET  MULTI_USER 
GO
ALTER DATABASE [ArduinoConnect] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArduinoConnect] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArduinoConnect] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArduinoConnect] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ArduinoConnect] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ArduinoConnect] SET QUERY_STORE = OFF
GO
USE [ArduinoConnect]
GO
/****** Object:  User [user]    Script Date: 19.11.2020 21:42:58 ******/
CREATE USER [user] FOR LOGIN [dbuser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[DataTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataTables](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TableID] [int] NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[Data] [varchar](max) NOT NULL,
 CONSTRAINT [PK_DataTables] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExchangeTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeTables](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OwnerID] [int] NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[ReceiverID] [int] NOT NULL,
	[Command] [varchar](max) NOT NULL,
	[ReceiverDevice] [varchar](50) NULL,
 CONSTRAINT [PK_ExchangeTables] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receivers]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receivers](
	[ReceiverID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Receivers] PRIMARY KEY CLUSTERED 
(
	[ReceiverID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokens](
	[TokenID] [int] IDENTITY(1,1) NOT NULL,
	[Token] [char](50) NOT NULL,
 CONSTRAINT [PK_Tokens] PRIMARY KEY CLUSTERED 
(
	[TokenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTables](
	[TableID] [int] IDENTITY(1,1) NOT NULL,
	[OwnerID] [int] NOT NULL,
	[TableName] [varchar](30) NOT NULL,
	[TableDescription] [varchar](100) NULL,
	[TableSchema] [varchar](max) NULL,
 CONSTRAINT [PK_UserTables] PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Tokens]    Script Date: 19.11.2020 21:42:58 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tokens] ON [dbo].[Tokens]
(
	[TokenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DataTables] ADD  CONSTRAINT [DF_DataTables_AddTime]  DEFAULT (sysdatetime()) FOR [AddTime]
GO
ALTER TABLE [dbo].[ExchangeTables] ADD  CONSTRAINT [DF_ExchangeTables_AddTime]  DEFAULT (sysdatetime()) FOR [AddTime]
GO
ALTER TABLE [dbo].[DataTables]  WITH CHECK ADD  CONSTRAINT [FK_DataTables_UserTables] FOREIGN KEY([TableID])
REFERENCES [dbo].[UserTables] ([TableID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DataTables] CHECK CONSTRAINT [FK_DataTables_UserTables]
GO
ALTER TABLE [dbo].[ExchangeTables]  WITH CHECK ADD  CONSTRAINT [FK_ExchangeTables_Receivers] FOREIGN KEY([ReceiverID])
REFERENCES [dbo].[Receivers] ([ReceiverID])
GO
ALTER TABLE [dbo].[ExchangeTables] CHECK CONSTRAINT [FK_ExchangeTables_Receivers]
GO
ALTER TABLE [dbo].[ExchangeTables]  WITH CHECK ADD  CONSTRAINT [FK_ExchangeTables_Tokens] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Tokens] ([TokenID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExchangeTables] CHECK CONSTRAINT [FK_ExchangeTables_Tokens]
GO
ALTER TABLE [dbo].[UserTables]  WITH CHECK ADD  CONSTRAINT [FK_UserTables_Tokens] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Tokens] ([TokenID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTables] CHECK CONSTRAINT [FK_UserTables_Tokens]
GO
/****** Object:  StoredProcedure [dbo].[ClearExchange]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ClearExchange]
	@token char(50) = null,
	@receiverDevice varchar(50) = null,
	@receiverID int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

	IF(@token IS NULL OR (SELECT COUNT(*) FROM Tokens WHERE Tokens.Token = @token) = 0)
		RETURN
	ELSE IF(@receiverDevice IS NULL AND (@receiverID = -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		WHERE ExchangeTables.ID IN (
			SELECT ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token));
	ELSE IF(@receiverDevice IS NOT NULL AND (@receiverID = -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		WHERE ExchangeTables.ID IN (
			SELECT ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverDevice = @receiverDevice);
	ELSE IF(@receiverDevice IS NULL AND (@receiverID <> -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		WHERE ExchangeTables.ID IN (
			SELECT ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverID = @receiverID);
	ELSE IF(@receiverDevice IS NOT NULL AND (@receiverID <> -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		WHERE ExchangeTables.ID IN (
			SELECT ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverDevice = @receiverDevice
					AND ExchangeTables.ReceiverID = @receiverID);
	ELSE RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[CreateDataTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateDataTables]
	-- Add the parameters for the stored procedure here
	@token char(50) = null,
	@tableId int = -1,
	@data varchar(max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF((SELECT COUNT(*) FROM UserTables JOIN Tokens ON UserTables.OwnerID = Tokens.TokenID WHERE Tokens.Token = @token AND UserTables.TableID = @tableId) = 0
	   OR @token IS NULL
	   OR @data IS NULL
	   OR @tableId IS NULL
	   OR @tableId = -1)
	   SELECT * FROM DataTables WHERE DataTables.ID IS NULL; -- Return empty set
	ELSE
		INSERT INTO [dbo].[DataTables]
           ([TableID]
           ,[Data])

		OUTPUT INSERTED.ID, INSERTED.TableID, INSERTED.AddTime, INSERTED.Data

		VALUES
           (@tableId
           ,@data);
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[CreateExchange]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateExchange]
	-- Add the parameters for the stored procedure here
	@receiverID int = -1,
	@receiverDevice varchar(50) = null,
	@command varchar(MAX) = null,
	@token char(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF(@receiverID IS NULL 
		OR (SELECT COUNT(*) FROM Receivers WHERE Receivers.ReceiverID = @receiverID) = 0 
		OR (SELECT COUNT(*) FROM Tokens WHERE Tokens.Token = @token) = 0
		OR @command IS NULL
		OR @token IS NULL)
		SELECT * FROM ExchangeTables WHERE ExchangeTables.ID IS NULL; -- RETURN EMPTY SET
	ELSE
		INSERT INTO [dbo].[ExchangeTables]
			   ([OwnerID]
			   ,[ReceiverID]
			   ,[Command]
			   ,[ReceiverDevice])

		OUTPUT INSERTED.ID, INSERTED.OwnerID, INSERTED.ReceiverID, INSERTED.ReceiverDevice, INSERTED.Command, INSERTED.AddTime

		VALUES
			   ((SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
			   ,@receiverID
			   ,@command
			   ,@receiverDevice);

	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUniqueToken]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateUniqueToken]
AS
BEGIN
	SET NOCOUNT ON;

    -- Declare vars
	DECLARE @token VARCHAR(50)
	SET @token = (SELECT substring(replace(CONCAT(newid(),newid()), '-', ''), 1, 50))

	-- Check if avaible, if not - generate new
	WHILE((SELECT COUNT(*) FROM Tokens WHERE Token = @token) > 0)
		BEGIN
			SET @token = (SELECT substring(replace(CONCAT(newid(),newid()), '-', ''), 1, 50)) 
		END

	-- Add token to list
	INSERT INTO [dbo].[Tokens] ([Token]) VALUES (@token)

	-- Return new record
	SELECT * FROM Tokens WHERE Token = @token
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUserTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateUserTables]
	-- Add the parameters for the stored procedure here
	@tableName varchar(30) = null,
	@tableDescription varchar(100) = null,
	@tableSchema varchar(MAX) = null,
	@token char(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF(@tableName IS NULL OR (SELECT COUNT(*) FROM Tokens WHERE Tokens.Token = @token) = 0)
		SELECT * FROM UserTables WHERE TableName IS NULL; -- RETURN EMPTY SET
	ELSE
		INSERT INTO [dbo].[UserTables] (
		[OwnerID],
		[TableName],
		[TableDescription],
		[TableSchema])

		OUTPUT INSERTED.TableID, INSERTED.OwnerID, INSERTED.TableName, INSERTED.TableDescription, INSERTED.TableSchema

		VALUES
		((SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
		,@tableName
		,@tableDescription
		,@tableSchema);
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDataTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDataTables]
	-- Add the parameters for the stored procedure here
	@token char(50) = null,
	@tableId int = -1,
	@id int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	IF((SELECT COUNT(*) FROM UserTables JOIN Tokens ON UserTables.OwnerID = Tokens.TokenID WHERE Tokens.Token = @token AND UserTables.TableID = @tableId) <> 0)
	BEGIN
		IF(@id IS NOT NULL AND @id <> -1)
			DELETE FROM DataTables WHERE DataTables.TableID = @tableId AND DataTables.ID = @id;
		ELSE
			DELETE FROM DataTables WHERE DataTables.TableID = @tableId;
	END
		
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteToken]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteToken]
	-- Add the parameters for the stored procedure here
	@token char(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	DELETE FROM Tokens WHERE Tokens.Token = @token;
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUserTables]
	-- Add the parameters for the stored procedure here
	@token char(50) = null,
	@tableId int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	DELETE FROM UserTables WHERE UserTables.TableID = @tableId AND UserTables.OwnerID = (SELECT TOP(1) Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token);
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllExchange]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllExchange]
	@token char(50) = null,
	@receiverDevice varchar(50) = null,
	@receiverID int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@token IS NULL OR (SELECT COUNT(*) FROM Tokens WHERE Tokens.Token = @token) = 0)
		SELECT * FROM ExchangeTables WHERE ExchangeTables.ID = 0; -- Empty set
	ELSE IF(@receiverDevice IS NULL AND (@receiverID = -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID IN (
			SELECT ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token));
	ELSE IF(@receiverDevice IS NOT NULL AND (@receiverID = -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID IN (
			SELECT ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverDevice = @receiverDevice);
	ELSE IF(@receiverDevice IS NULL AND (@receiverID <> -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID IN (
			SELECT ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverID = @receiverID);
	ELSE IF(@receiverDevice IS NOT NULL AND (@receiverID <> -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID IN (
			SELECT ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverDevice = @receiverDevice
					AND ExchangeTables.ReceiverID = @receiverID);
	ELSE SELECT * FROM ExchangeTables WHERE ExchangeTables.ID = 0; -- Empty set
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[GetDataTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDataTables]
	-- Add the parameters for the stored procedure here
	@token char(50) = null,
	@tableId int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF(@tableId IS NULL OR @tableId = -1)
		SELECT DataTables.* 
		FROM DataTables 
		JOIN UserTables ON UserTables.TableID = DataTables.TableID 
		JOIN Tokens ON UserTables.OwnerID = Tokens.TokenID 
		WHERE Tokens.Token = @token
		ORDER BY ID DESC;
	ELSE
		SELECT DataTables.* 
		FROM DataTables 
		JOIN UserTables ON UserTables.TableID = DataTables.TableID 
		JOIN Tokens ON UserTables.OwnerID = Tokens.TokenID 
		WHERE Tokens.Token = @token AND UserTables.TableID = @tableId
		ORDER BY ID DESC;
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[GetDataTablesOffset]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDataTablesOffset]
	-- Add the parameters for the stored procedure here
	@token char(50) = null,
	@tableId int = -1,
	@offset int = 0,
	@fetch int = 25
AS
BEGIN
	SET NOCOUNT ON;

	IF(@offset < 0 OR @offset IS NULL) SET @offset = 0;
	IF(@fetch < 0 OR @fetch IS NULL) SET @fetch = 25;

	IF(@tableId IS NULL OR @tableId = -1)
		SELECT DataTables.* 
		FROM DataTables 
		JOIN UserTables ON UserTables.TableID = DataTables.TableID 
		JOIN Tokens ON UserTables.OwnerID = Tokens.TokenID 
		WHERE Tokens.Token = @token
		ORDER BY ID DESC
		OFFSET @offset ROWS 
		FETCH NEXT @fetch ROWS ONLY;
	ELSE
		SELECT DataTables.* 
		FROM DataTables 
		JOIN UserTables ON UserTables.TableID = DataTables.TableID 
		JOIN Tokens ON UserTables.OwnerID = Tokens.TokenID 
		WHERE Tokens.Token = @token AND UserTables.TableID = @tableId
		ORDER BY ID DESC
		OFFSET @offset ROWS 
		FETCH NEXT @fetch ROWS ONLY;
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[GetNewestExchange]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetNewestExchange]
	@token char(50) = null,
	@receiverDevice varchar(50) = null,
	@receiverID int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@token IS NULL OR (SELECT COUNT(*) FROM Tokens WHERE Tokens.Token = @token) = 0)
		SELECT * FROM ExchangeTables WHERE ExchangeTables.ID = 0; -- Empty set
	ELSE IF(@receiverDevice IS NULL AND (@receiverID = -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID = (
			SELECT TOP(1) ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
			ORDER BY ExchangeTables.AddTime DESC);
	ELSE IF(@receiverDevice IS NOT NULL AND (@receiverID = -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID = (
			SELECT TOP(1) ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverDevice = @receiverDevice
			ORDER BY ExchangeTables.AddTime DESC);
	ELSE IF(@receiverDevice IS NULL AND (@receiverID <> -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID = (
			SELECT TOP(1) ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverID = @receiverID
			ORDER BY ExchangeTables.AddTime DESC);
	ELSE IF(@receiverDevice IS NOT NULL AND (@receiverID <> -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID = (
			SELECT TOP(1) ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverDevice = @receiverDevice
					AND ExchangeTables.ReceiverID = @receiverID
			ORDER BY ExchangeTables.AddTime DESC);
	ELSE SELECT * FROM ExchangeTables WHERE ExchangeTables.ID = 0; -- Empty set
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[GetNoOfDataTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetNoOfDataTables]
	-- Add the parameters for the stored procedure here
	@token char(50) = null,
	@tableId int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF((SELECT COUNT(*) FROM Tokens WHERE Token=@token) = 0)
	BEGIN
		SELECT -1;
		RETURN
	END

	IF(@tableId IS NULL OR @tableId = -1)
		SELECT COUNT(DataTables.ID)
		FROM DataTables 
		JOIN UserTables ON UserTables.TableID = DataTables.TableID 
		JOIN Tokens ON UserTables.OwnerID = Tokens.TokenID 
		WHERE Tokens.Token = @token;
	ELSE
	BEGIN
		IF((SELECT COUNT(*) FROM UserTables JOIN Tokens ON UserTables.OwnerID = Tokens.TokenID WHERE Token=@token AND TableID = @tableId) = 0)
		BEGIN
			SELECT -1;
			RETURN
		END
		ELSE
			SELECT COUNT(DataTables.ID) 
			FROM DataTables 
			JOIN UserTables ON UserTables.TableID = DataTables.TableID 
			JOIN Tokens ON UserTables.OwnerID = Tokens.TokenID 
			WHERE Tokens.Token = @token AND UserTables.TableID = @tableId;
	END
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[GetNoOfExchange]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetNoOfExchange]
	@token char(50) = null,
	@receiverDevice varchar(50) = null,
	@receiverID int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@token IS NULL OR (SELECT COUNT(*) FROM Tokens WHERE Tokens.Token = @token) = 0)
		SELECT -1;
	ELSE IF(@receiverDevice IS NULL AND (@receiverID = -1 OR @receiverID IS NULL))
		SELECT COUNT(*) FROM ExchangeTables WHERE ExchangeTables.OwnerID = (SELECT TOP(1) Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token);
	ELSE IF(@receiverDevice IS NOT NULL AND (@receiverID = -1 OR @receiverID IS NULL))
		SELECT COUNT(*) FROM ExchangeTables WHERE ExchangeTables.OwnerID = (SELECT TOP(1) Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
													AND ExchangeTables.ReceiverDevice = @receiverDevice;
	ELSE IF(@receiverDevice IS NULL AND (@receiverID <> -1 OR @receiverID IS NULL))
		SELECT COUNT(*) FROM ExchangeTables WHERE ExchangeTables.OwnerID = (SELECT TOP(1) Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
													AND ExchangeTables.ReceiverID = @receiverID;
	ELSE IF(@receiverDevice IS NOT NULL AND (@receiverID <> -1 OR @receiverID IS NULL))
		SELECT COUNT(*) FROM ExchangeTables WHERE ExchangeTables.OwnerID = (SELECT TOP(1) Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
													AND ExchangeTables.ReceiverDevice = @receiverDevice
													AND ExchangeTables.ReceiverID = @receiverID;
	ELSE SELECT -1;
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[GetNoOfUserTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetNoOfUserTables]
	-- Add the parameters for the stored procedure here
	@token char(50) = null,
	@tableId int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF((SELECT COUNT(*) FROM Tokens WHERE Token=@token) = 0)
	BEGIN
		SELECT -1;
		RETURN
	END

	IF(@tableId IS NULL OR @tableId < 0)
		SELECT COUNT(*) FROM UserTables JOIN Tokens ON Tokens.TokenID = UserTables.OwnerID WHERE Tokens.Token = @token;
	ELSE
		SELECT COUNT(*) FROM UserTables JOIN Tokens ON Tokens.TokenID = UserTables.OwnerID WHERE Tokens.Token = @token AND UserTables.TableID = @tableId;
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[GetOldestExchange]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetOldestExchange]
	@token char(50) = null,
	@receiverDevice varchar(50) = null,
	@receiverID int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@token IS NULL OR (SELECT COUNT(*) FROM Tokens WHERE Tokens.Token = @token) = 0)
		SELECT * FROM ExchangeTables WHERE ExchangeTables.ID = 0; -- Empty set
	ELSE IF(@receiverDevice IS NULL AND (@receiverID = -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID = (
			SELECT TOP(1) ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
			ORDER BY ExchangeTables.AddTime ASC);
	ELSE IF(@receiverDevice IS NOT NULL AND (@receiverID = -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID = (
			SELECT TOP(1) ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverDevice = @receiverDevice
			ORDER BY ExchangeTables.AddTime ASC);
	ELSE IF(@receiverDevice IS NULL AND (@receiverID <> -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID = (
			SELECT TOP(1) ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverID = @receiverID
			ORDER BY ExchangeTables.AddTime ASC);
	ELSE IF(@receiverDevice IS NOT NULL AND (@receiverID <> -1 OR @receiverID IS NULL))
		DELETE FROM ExchangeTables
		OUTPUT DELETED.ID, DELETED.OwnerID, DELETED.ReceiverID, DELETED.AddTime, DELETED.Command, DELETED.ReceiverDevice
		WHERE ExchangeTables.ID = (
			SELECT TOP(1) ExchangeTables.ID 
			FROM ExchangeTables 
			WHERE ExchangeTables.OwnerID = (SELECT Tokens.TokenID FROM Tokens WHERE Tokens.Token = @token)
					AND ExchangeTables.ReceiverDevice = @receiverDevice
					AND ExchangeTables.ReceiverID = @receiverID
			ORDER BY ExchangeTables.AddTime ASC);
	ELSE SELECT * FROM ExchangeTables WHERE ExchangeTables.ID = 0; -- Empty set
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[GetReceivers]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetReceivers]
	-- Add the parameters for the stored procedure here
	@receiverId int = -1,
	@description varchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF(@description IS NULL AND (@receiverId IS NOT NULL OR @receiverId <> -1))
		SELECT * FROM Receivers WHERE ReceiverID = @receiverId;
	ELSE IF(@description IS NOT NULL AND (@receiverId IS NULL OR @receiverId = -1))
		SELECT * FROM Receivers WHERE Receivers.Description = @description;
	ELSE IF(@description IS NOT NULL AND (@receiverId IS NOT NULL OR @receiverId <> -1))
		SELECT * FROM Receivers WHERE ReceiverID = @receiverId AND Receivers.Description = @description;
	ELSE
		SELECT * FROM Receivers;
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[TokenUserTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TokenUserTables]
	-- Add the parameters for the stored procedure here
	@token char(50) = null,
	@tableId int = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@tableId = -1 OR @tableId IS NULL)
		SELECT UserTables.* 
		FROM UserTables 
		INNER JOIN Tokens ON UserTables.OwnerID = Tokens.TokenID 
		WHERE Tokens.Token = @token AND @token IS NOT NULL;
	ELSE
		SELECT UserTables.* 
		FROM UserTables 
		INNER JOIN Tokens ON UserTables.OwnerID = Tokens.TokenID 
		WHERE Tokens.Token = @token AND @token IS NOT NULL AND UserTables.TableID = @tableId;
	RETURN
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserTables]    Script Date: 19.11.2020 21:42:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUserTables]
	-- Add the parameters for the stored procedure here
	@token char(50) = null,
	@tableId int = null,
	@tableName varchar(30) = null,
	@tableDescription varchar(100) = null,
	@tableSchema varchar(MAX) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF(@tableName IS NULL OR (SELECT COUNT(*) FROM UserTables JOIN Tokens ON Tokens.TokenID = UserTables.OwnerID WHERE Tokens.Token = @token AND UserTables.TableID = @tableId) = 0)
	BEGIN
		SELECT * FROM UserTables WHERE UserTables.TableID IS NULL; -- RETURN EMPTY SET
		RETURN
	END

	UPDATE UserTables 
	SET UserTables.TableName = @tableName,
		UserTables.TableDescription = @tableDescription,
		UserTables.TableSchema = @tableSchema
	WHERE UserTables.TableID = @tableId;

	SELECT * FROM UserTables WHERE UserTables.TableID = @tableId;
	RETURN;
END
GO
USE [master]
GO
ALTER DATABASE [ArduinoConnect] SET  READ_WRITE 
GO
