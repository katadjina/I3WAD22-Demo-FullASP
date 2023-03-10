USE [master]
GO
/****** Object:  Database [ASP_DB]    Script Date: 10-03-23 16:53:08 ******/
CREATE DATABASE [ASP_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ASP_DB', FILENAME = N'C:\Users\k.drzazgowska\ASP_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ASP_DB_log', FILENAME = N'C:\Users\k.drzazgowska\ASP_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ASP_DB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ASP_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ASP_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ASP_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ASP_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ASP_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ASP_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ASP_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ASP_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ASP_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ASP_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ASP_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ASP_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ASP_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ASP_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ASP_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ASP_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ASP_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ASP_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ASP_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ASP_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ASP_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ASP_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ASP_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ASP_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ASP_DB] SET  MULTI_USER 
GO
ALTER DATABASE [ASP_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ASP_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ASP_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ASP_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ASP_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ASP_DB] SET QUERY_STORE = OFF
GO
USE [ASP_DB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ASP_DB]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 10-03-23 16:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Client_Id] [int] IDENTITY(1,1) NOT NULL,
	[Prenom] [nchar](20) NOT NULL,
	[Nom] [nchar](20) NOT NULL,
	[Pays] [nchar](10) NOT NULL,
	[Email] [nchar](50) NOT NULL,
	[Telephone] [int] NOT NULL,
	[Pass] [nchar](55) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Client_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logement]    Script Date: 10-03-23 16:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logement](
	[Logement_Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nchar](20) NOT NULL,
	[Rue] [nchar](30) NOT NULL,
	[DescriptionCourte] [nchar](200) NOT NULL,
	[NombrePieces] [int] NOT NULL,
	[Prix] [nchar](10) NOT NULL,
	[Client_Id] [int] NOT NULL,
	[date_add] [date] NOT NULL,
 CONSTRAINT [PK_Logement_Id] PRIMARY KEY CLUSTERED 
(
	[Logement_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Propriétaire]    Script Date: 10-03-23 16:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Propriétaire](
	[Client_Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Proprio_Id] PRIMARY KEY CLUSTERED 
(
	[Client_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 10-03-23 16:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[Reservation_Id] [int] IDENTITY(1,1) NOT NULL,
	[CheckIn] [datetime] NOT NULL,
	[CheckOut] [datetime] NOT NULL,
	[NomAdultes] [int] NOT NULL,
	[NomEnfants] [int] NOT NULL,
	[PrixTotal] [money] NOT NULL,
	[Client_Id] [int] NOT NULL,
	[Logement_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Reservation_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeLogement]    Script Date: 10-03-23 16:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeLogement](
	[Type_Id] [int] NOT NULL,
	[Nom] [nchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Client_Id], [Prenom], [Nom], [Pays], [Email], [Telephone], [Pass]) VALUES (1, N'Katarzyna           ', N'Drzazgowska         ', N'polska    ', N'kata.drzazgowska@gma                              ', 4587854, N'ᦲ毴襾䘈㔲麘뷒�놆渄쨐듂㖭䀔栣ᵨ↙⨴橖僊劎؟˄铴瘢쐓ቖ                       ')
INSERT [dbo].[Client] ([Client_Id], [Prenom], [Nom], [Pays], [Email], [Telephone], [Pass]) VALUES (2, N'Tata                ', N'Toto                ', N'belgium   ', N'kata.drzazgowska@gma                              ', 123456, N'⵶죑ᯖ愼ﲒ赀浍ᅟ큶釂뱩㼜䨧習壍댑혓廥ⷀ푳즙啔떶傻켺佗辺藾                       ')
INSERT [dbo].[Client] ([Client_Id], [Prenom], [Nom], [Pays], [Email], [Telephone], [Pass]) VALUES (3, N'Polette             ', N'Pola                ', N'Belgium   ', N'polette@gmail.com                                 ', 1010, N'⵶죑ᯖ愼ﲒ赀浍ᅟ큶釂뱩㼜䨧習壍댑혓廥ⷀ푳즙啔떶傻켺佗辺藾                       ')
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Logement] ON 

INSERT [dbo].[Logement] ([Logement_Id], [Nom], [Rue], [DescriptionCourte], [NombrePieces], [Prix], [Client_Id], [date_add]) VALUES (1, N'Pineapple           ', N'Bikin Bottom                  ', N'nice place                                                                                                                                                                                              ', 2, N'100       ', 1, CAST(N'2023-03-10' AS Date))
INSERT [dbo].[Logement] ([Logement_Id], [Nom], [Rue], [DescriptionCourte], [NombrePieces], [Prix], [Client_Id], [date_add]) VALUES (2, N'BestStay            ', N'Brussels                      ', N'really nice place                                                                                                                                                                                       ', 2, N'100000    ', 1, CAST(N'2023-03-10' AS Date))
INSERT [dbo].[Logement] ([Logement_Id], [Nom], [Rue], [DescriptionCourte], [NombrePieces], [Prix], [Client_Id], [date_add]) VALUES (3, N'SunnyPalaca         ', N'Brussels                      ', N'nice                                                                                                                                                                                                    ', 2, N'100       ', 2, CAST(N'2023-03-10' AS Date))
INSERT [dbo].[Logement] ([Logement_Id], [Nom], [Rue], [DescriptionCourte], [NombrePieces], [Prix], [Client_Id], [date_add]) VALUES (4, N'Villa BXHELL        ', N'Hell                          ', N'Best rooms in Bxhell                                                                                                                                                                                    ', 6, N'666       ', 3, CAST(N'2023-03-10' AS Date))
INSERT [dbo].[Logement] ([Logement_Id], [Nom], [Rue], [DescriptionCourte], [NombrePieces], [Prix], [Client_Id], [date_add]) VALUES (5, N'kata                ', N'Brussels                      ', N'nice one                                                                                                                                                                                                ', 3, N'444       ', 3, CAST(N'2023-03-10' AS Date))
INSERT [dbo].[Logement] ([Logement_Id], [Nom], [Rue], [DescriptionCourte], [NombrePieces], [Prix], [Client_Id], [date_add]) VALUES (6, N'DODO town           ', N'zzz                           ', N'dfff                                                                                                                                                                                                    ', 5, N'5         ', 3, CAST(N'2023-03-10' AS Date))
SET IDENTITY_INSERT [dbo].[Logement] OFF
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([Reservation_Id], [CheckIn], [CheckOut], [NomAdultes], [NomEnfants], [PrixTotal], [Client_Id], [Logement_Id]) VALUES (1, CAST(N'2888-01-11T00:00:00.000' AS DateTime), CAST(N'2889-01-01T00:00:00.000' AS DateTime), 0, 0, 2.0000, 3, 1)
INSERT [dbo].[Reservation] ([Reservation_Id], [CheckIn], [CheckOut], [NomAdultes], [NomEnfants], [PrixTotal], [Client_Id], [Logement_Id]) VALUES (3, CAST(N'2030-01-01T00:00:00.000' AS DateTime), CAST(N'2031-01-01T00:00:00.000' AS DateTime), 1, 1, 0.0000, 3, 1)
INSERT [dbo].[Reservation] ([Reservation_Id], [CheckIn], [CheckOut], [NomAdultes], [NomEnfants], [PrixTotal], [Client_Id], [Logement_Id]) VALUES (4, CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime), 2, 0, 100.0000, 3, 3)
SET IDENTITY_INSERT [dbo].[Reservation] OFF
ALTER TABLE [dbo].[Logement]  WITH CHECK ADD  CONSTRAINT [FK_Logement_Client] FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Client] ([Client_Id])
GO
ALTER TABLE [dbo].[Logement] CHECK CONSTRAINT [FK_Logement_Client]
GO
ALTER TABLE [dbo].[Propriétaire]  WITH CHECK ADD  CONSTRAINT [FK_Client_Id] FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Client] ([Client_Id])
GO
ALTER TABLE [dbo].[Propriétaire] CHECK CONSTRAINT [FK_Client_Id]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Client_reserv_Id] FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Client] ([Client_Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Client_reserv_Id]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Logement_reserv_Id] FOREIGN KEY([Logement_Id])
REFERENCES [dbo].[Logement] ([Logement_Id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Logement_reserv_Id]
GO
/****** Object:  StoredProcedure [dbo].[SP_CientReservation]    Script Date: 10-03-23 16:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CientReservation]
	@id  int

AS
BEGIN

SELECT [Reservation_id], [checkIn], [checkOut], [PrixTotal], [nomAdultes], [nomEnfants], [Reservation].[Logement_id],[nom],[DescriptionCourte], [Reservation].[Client_id] FROM [Reservation],[Logement] WHERE [Reservation].[Logement_id]=[Logement].[Logement_id] AND [Reservation].[Client_id] = @id

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ClientAdd]    Script Date: 10-03-23 16:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ClientAdd]
	@nom  VARCHAR(20),
	@prenom  VARCHAR(20),
    @email VARCHAR(20),
	@telephone VARCHAR(20),
	@pays VARCHAR(20),
    @pass varchar(20)
AS
BEGIN

INSERT INTO [Client] ([nom], [prenom], [email], [pass], [telephone], [pays])
                                            OUTPUT [inserted].[Client_id]
                                            VALUES (@nom, @prenom, @email, HASHBYTES('SHA2_512',@pass), @telephone, @pays)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ClientCheck]    Script Date: 10-03-23 16:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ClientCheck]
    @email VARCHAR(20),
    @pass varchar(20)
AS
BEGIN

SET NOCOUNT ON

IF EXISTS(SELECT * FROM [ASP_DB].dbo.Client WHERE email = @email AND pass = HASHBYTES('SHA2_512',@pass))
    SELECT  Client_Id FROM [ASP_DB].dbo.Client WHERE email = @email AND pass = HASHBYTES('SHA2_512',@pass)
ELSE
    SELECT NULL

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ClientUpdate]    Script Date: 10-03-23 16:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ClientUpdate]
	@id int,
	@nom  VARCHAR(20),
	@prenom  VARCHAR(20),
    @email VARCHAR(20),
	@telephone VARCHAR(20),
	@pays VARCHAR(20),
    @pass varchar(20)
AS
BEGIN

UPDATE [Client]
                                            SET [nom] = @nom,
                                                [prenom] = @prenom,
                                                [email] = @email,
												[pays] = @pays,
												[pass]= HASHBYTES('SHA2_512',@pass),
                                                [telephone] = @telephone
                                            WHERE [Client_Id] = @id


END







GO
/****** Object:  StoredProcedure [dbo].[SP_LogementMonth]    Script Date: 10-03-23 16:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LogementMonth]
	@month  int
AS
BEGIN

SELECT * 
FROM logement,client
WHERE logement.Client_Id = Client.Client_Id
AND MONTH(ASP_DB.dbo.Logement.date_add) = @month

END



GO
/****** Object:  StoredProcedure [dbo].[SP_LogementTwoDate]    Script Date: 10-03-23 16:53:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LogementTwoDate]
	@date_deb  date,
	@date_fin  date

AS
BEGIN

SELECT * 
FROM logement,client
WHERE logement.Client_Id = Client.Client_Id
AND logement.logement_id NOT IN (
   SELECT logement_id 
  FROM Reservation 
  WHERE checkIn <= @date_fin AND checkOut >= @date_deb
)

END
GO
USE [master]
GO
ALTER DATABASE [ASP_DB] SET  READ_WRITE 
GO
