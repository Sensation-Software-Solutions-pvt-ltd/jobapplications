CREATE DATABASE [Jobapplications]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Jobapplications', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Jobapplications.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Jobapplications_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Jobapplications_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Jobapplications] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Jobapplications].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Jobapplications] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Jobapplications] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Jobapplications] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Jobapplications] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Jobapplications] SET ARITHABORT OFF 
GO
ALTER DATABASE [Jobapplications] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Jobapplications] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Jobapplications] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Jobapplications] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Jobapplications] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Jobapplications] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Jobapplications] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Jobapplications] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Jobapplications] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Jobapplications] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Jobapplications] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Jobapplications] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Jobapplications] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Jobapplications] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Jobapplications] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Jobapplications] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Jobapplications] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Jobapplications] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Jobapplications] SET  MULTI_USER 
GO
ALTER DATABASE [Jobapplications] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Jobapplications] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Jobapplications] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Jobapplications] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Jobapplications] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Jobapplications] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Jobapplications] SET QUERY_STORE = OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Resume](
	[ResumeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[DOB] [datetime] NULL,
	[BirthPlace] [nvarchar](50) NULL,
	[DocumentBytes] [nvarchar](max) NULL,
	[JobId] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Resume] PRIMARY KEY CLUSTERED 
(
	[ResumeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [JobApp_HelpForFrontendInput]
	(                              
 @FrontEndInputJson NVARCHAR(100) ,                
 @BackEndInputJson NVARCHAR(1000)                           
) 
AS
BEGIN
	 Declare @ProcedureName nvarchar(50)=  (Select JSON_VALUE(@FrontEndInputJson,'$.ProcedureName'));      
	 
	  if @ProcedureName = 'sp_ApplyForJob'                
	select '{"FirstName":"rahul","LastName":"Kumar","LastName":"Kumar","EmailId":"ashish@Kumar.com","DOB":"22-07-1997","BirthPlace":"Haryana","JobId":12334,"DocumentData":"" }'

END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [SP_ApplyForJob] 
(              
 @FrontEndInputJson NVARCHAR(MAX) ,                    
 @BackEndInputJson NVARCHAR(MAX)     
)
AS
BEGIN
	DECLARE @FirstName varchar(200) = (Select JSON_VALUE(@FrontEndInputJson,'$.FirstName')); 
	DECLARE @LastName varchar(200) = (Select JSON_VALUE(@FrontEndInputJson,'$.LastName')); 
    DECLARE @EmailId varchar(200) = (Select JSON_VALUE(@FrontEndInputJson,'$.EmailId')); 
	DECLARE @JobId int = IsNull((Select JSON_VALUE(@FrontEndInputJson,'$.JobId')),0); 
	DECLARE @DocumentData nvarchar(max) = (Select JSON_VALUE(@FrontEndInputJson,'$.DocumentBytes')); 
	DECLARE @DOB varchar(200) = (Select JSON_VALUE(@FrontEndInputJson,'$.DOB')); 
	DECLARE @BirthPlace varchar(200) = (Select JSON_VALUE(@FrontEndInputJson,'$.BirthPlace')); 
DECLARE @StatusCode int=404;
DECLARE @Message VARCHAR(MAX)='Already applied for this email.';


  IF NOT EXISTS(SELECT TOP(1) 1 FROM [Resume] where EmailId = @EmailId)    
  BEGIN    
	  INSERT INTO [Resume](
	  FirstName,
	  LastName,
	  EmailId
	  ,DOB
	  ,BirthPlace
	  ,DocumentBytes
	  ,JobId
	  ,IsDeleted
	  ) Values
	  (
	  @FirstName
	  ,@LastName
	  ,@EmailId
	  ,@DOB
	  ,@BirthPlace
	  ,@DocumentData
	  ,@JobId
	  ,0
	  )

	set @StatusCode =200;
	set @Message ='Applied successfully.';
	END

	SELECT(select @StatusCode AS StatusCode,@Message AS [Message],'' as userId FOR JSON PATH, INCLUDE_NULL_VALUES,WITHOUT_ARRAY_WRAPPER) AS JsonResult
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [SP_DeleteJob]
	(              
 @FrontEndInputJson NVARCHAR(MAX) ,                    
 @BackEndInputJson NVARCHAR(MAX)     
)
AS
BEGIN
		DECLARE @ResumeId int = IsNull((Select JSON_VALUE(@FrontEndInputJson,'$.ResumeId')),0); 
		DECLARE @StatusCode int=404;
		DECLARE @Message VARCHAR(MAX)='Error deleting job application.';

		IF(@ResumeId is not null)
		BEGIN
			update [Resume] set IsDeleted = 1   WHERE ResumeId = @ResumeId
			set @StatusCode =200;
		set @Message ='Job application deleted successfully.';
		END

		SELECT(select @StatusCode AS StatusCode,@Message AS [Message],'' as userId FOR JSON PATH, INCLUDE_NULL_VALUES,WITHOUT_ARRAY_WRAPPER) AS JsonResult
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [SP_DownloadResume]
(              
 @FrontEndInputJson NVARCHAR(MAX) ,                    
 @BackEndInputJson NVARCHAR(MAX)     
)
AS
BEGIN
		DECLARE @ResumeId int = IsNull((Select JSON_VALUE(@FrontEndInputJson,'$.ResumeId')),0); 

		DECLARE @StatusCode int=404;
		DECLARE @Message VARCHAR(MAX)='No resume found.';

		declare @DocumentFile nvarchar(Max)

  IF EXISTS(SELECT TOP(1) 1 FROM [Resume] where ResumeId = @ResumeId)   
  BEGIN

  SET @DocumentFile = (SELECT DocumentBytes FROM [Resume] WHERE ResumeId = @ResumeId);

  		SET @StatusCode =200;
		SET @Message ='Resume downloaded successfully.';
  END

  	SELECT(select @StatusCode AS StatusCode,@Message AS [Message],@DocumentFile AS Response FOR JSON PATH, INCLUDE_NULL_VALUES,WITHOUT_ARRAY_WRAPPER) AS JsonResult
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [SP_GetResumeList]
	(              
 @FrontEndInputJson NVARCHAR(MAX) ,                    
 @BackEndInputJson NVARCHAR(MAX)     
)
AS
BEGIN

SELECT
ISNULL((

select 
ISNULL((SELECT
		FirstName
		,LastName
		,ResumeId
		,JobId
		,DocumentBytes
		,EmailId
		,DOB
		,BirthPlace
	FROM 
		[Resume] where IsDeleted = 0
		FOR JSON PATH, INCLUDE_NULL_VALUES),'[]') AS Response
	
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER),'[]') AS JsonResult

END
GO
ALTER DATABASE [Jobapplications] SET  READ_WRITE 
GO
