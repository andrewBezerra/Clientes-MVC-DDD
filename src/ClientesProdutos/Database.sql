USE [master]
GO
/****** Object:  Database [ClientesProdutosDB]    Script Date: 23/07/2020 11:38:31 ******/
CREATE DATABASE [ClientesProdutosDB]
GO
USE [ClientesProdutosDB]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 23/07/2020 11:38:31 ******/
CREATE TABLE [Cliente](
	[ID] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](150) NOT NULL,
	[CPF] [char](11) NOT NULL,
	[CreatedBy] [varchar](150) NOT NULL,
	[Created] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](150) NULL,
	[LastModified] [datetime] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 23/07/2020 11:38:31 ******/
CREATE TABLE [Produto](
	[ID] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](150) NOT NULL,
	[CreatedBy] [varchar](150) NOT NULL,
	[Created] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](150) NULL,
	[LastModified] [datetime] NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteProdutos]    Script Date: 23/07/2020 11:38:31 ******/
CREATE TABLE [ClienteProdutos](
	[IDCliente] [uniqueidentifier] NOT NULL,
	[IDProduto] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ClienteProdutos] PRIMARY KEY CLUSTERED 
(
	[IDCliente] ASC,
	[IDProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



