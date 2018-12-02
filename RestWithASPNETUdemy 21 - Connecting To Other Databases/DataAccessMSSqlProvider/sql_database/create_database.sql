USE [rest_with_asp_net_udemy]

CREATE TABLE [dbo].[books] (
  [id] [bigint] IDENTITY(1,1) NOT NULL,
  [author] [varchar](150),
  [launchdate] [DateTime] NOT NULL,
  [price] [decimal](8,2) NOT NULL,
  [title] [varchar](250)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[persons](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[address] [varchar](50) NULL,
	[gender] [varchar](50) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[users] (
  [id] [bigint] IDENTITY(1,1) NOT NULL,
  [login] [varchar](50) UNIQUE NOT NULL,
  [accesskey] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

INSERT INTO dbo.persons(firstname, lastname, address, gender)
VALUES ('LEANDRO', 'COSTA', 'UBERLANDIA', 'MALE'),
		('FLÁVIO', 'COSTA', 'PATOS DE MINAS', 'MALE');

