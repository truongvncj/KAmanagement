USE [master]
GO

/****** Object:  Database [KAmanagement]    Script Date: 24/11/2015 6:12:30 AM ******/
CREATE DATABASE [KAmanagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KAmanagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\KAmanagement.mdf' , SIZE = 168128KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KAmanagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\KAmanagement_log.ldf' , SIZE = 434944KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [KAmanagement] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KAmanagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [KAmanagement] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [KAmanagement] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [KAmanagement] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [KAmanagement] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [KAmanagement] SET ARITHABORT OFF 
GO

ALTER DATABASE [KAmanagement] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [KAmanagement] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [KAmanagement] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [KAmanagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [KAmanagement] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [KAmanagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [KAmanagement] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [KAmanagement] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [KAmanagement] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [KAmanagement] SET  ENABLE_BROKER 
GO

ALTER DATABASE [KAmanagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [KAmanagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [KAmanagement] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [KAmanagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [KAmanagement] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [KAmanagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [KAmanagement] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [KAmanagement] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [KAmanagement] SET  MULTI_USER 
GO

ALTER DATABASE [KAmanagement] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [KAmanagement] SET DB_CHAINING OFF 
GO

ALTER DATABASE [KAmanagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [KAmanagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [KAmanagement] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [KAmanagement] SET  READ_WRITE 
GO
-------------------------
USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_ARdetalheaderRpt]    Script Date: 16/12/2015 2:06:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_ARdetalheaderRpt](
	[custcodeGRoup] [float] NULL,
	[customername] [nvarchar](225) NULL,
	[address] [nvarchar](225) NULL,
	[phone] [nvarchar](50) NULL,
	[code] [float] NULL,
	[region] [nchar](10) NULL,
	[dknuoc] [float] NULL,
	[psnuoc] [float] NULL,
	[cknuoc] [float] NULL,
	[dkvo] [float] NULL,
	[psvo] [float] NULL,
	[ckvo] [float] NULL,
	[Fromdate] [date] NULL,
	[Todate] [date] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[No] [int] NULL,
	[prt] [bit] NULL,
	[Hideprint] [bit] NULL,
 CONSTRAINT [PK_Rpt_ARdetalheader] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_ArletterdetailRpt]    Script Date: 16/12/2015 2:07:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_ArletterdetailRpt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PostingDate] [date] NULL,
	[DocNumber] [nvarchar](50) NULL,
	[InvoiceAmount] [float] NULL,
	[Paymentamount] [float] NULL,
	[Adjamount] [float] NULL,
	[Depositamount] [float] NULL,
	[customergroup] [float] NULL,
	[amountinloca] [float] NULL,
	[prt] [bit] NULL,
	[Hideprint] [bit] NULL,
 CONSTRAINT [PK_Arletterdetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_ArletterRpt]    Script Date: 16/12/2015 2:08:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_ArletterRpt](
	[custcodegRoup] [float] NULL,
	[customername] [nvarchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[phone] [nvarchar](255) NULL,
	[code] [float] NULL,
	[region] [nvarchar](255) NULL,
	[sumAmountfull] [float] NULL,
	[sumEmptydeposit] [float] NULL,
	[StringAmountEmpty] [nvarchar](255) NULL,
	[sumoffreeclass] [float] NULL,
	[toDate] [date] NULL,
	[fromdate] [date] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[No] [int] NULL,
	[returndate] [date] NULL,
	[prt] [bit] NULL,
	[Hideprint] [bit] NULL,
 CONSTRAINT [PK_tbl_ArletterRpt] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_checktemp]    Script Date: 16/12/2015 2:08:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_checktemp](
	[docnumber] [float] NULL,
	[code] [nchar](10) NULL,
	[name] [nvarchar](225) NULL,
	[region] [nchar](10) NULL,
	[CountValueinFBLandVAT] [float] NULL,
	[contvalueinEDLP] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tbl_checktemp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_ColdetailRpt]    Script Date: 16/12/2015 2:08:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_ColdetailRpt](
	[Account] [float] NULL,
	[Assignment] [nvarchar](255) NULL,
	[Postingdate] [date] NOT NULL,
	[Document Type] [nvarchar](255) NULL,
	[InvoiceNumber] [nvarchar](255) NULL,
	[Document Date] [date] NULL,
	[Business Area] [nvarchar](255) NULL,
	[Invoice Registration] [nvarchar](255) NULL,
	[Invoice Number] [nvarchar](255) NULL,
	[Invoice amount before VAT] [float] NULL,
	[Deposit amount] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codeGroup] [float] NULL,
	[SoDelivery] [nvarchar](255) NULL,
	[dkKetvothuong] [int] NULL,
	[Ketvothuong] [int] NULL,
	[dkChaivothuong] [int] NULL,
	[Chaivothuong] [int] NULL,
	[dkKetvolit] [int] NULL,
	[Ketvolit] [int] NULL,
	[dkChaivo1lit] [int] NULL,
	[Chaivo1lit] [int] NULL,
	[dkKetnhuathuong] [int] NULL,
	[Ketnhuathuong] [int] NULL,
	[dkKetnhua1lit] [int] NULL,
	[Ketnhua1lit] [int] NULL,
	[dkjoy20] [int] NULL,
	[joy20l] [int] NULL,
	[dkBinhpmicc02] [int] NULL,
	[Binhpmicc02] [int] NULL,
	[dkbinhpmix9l] [int] NULL,
	[binhpmix9l] [int] NULL,
	[dkpalletgo] [int] NULL,
	[palletgo] [int] NULL,
	[dkpaletnhua] [int] NULL,
	[paletnhua] [int] NULL,
	[prt] [bit] NULL,
	[Hideprint] [bit] NULL,
 CONSTRAINT [PK_Coldetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_Comboundtemp]    Script Date: 16/12/2015 2:08:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Comboundtemp](
	[Code] [float] NULL,
	[codeGroup] [float] NULL,
	[name] [nvarchar](225) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Region] [nchar](10) NULL,
 CONSTRAINT [PK_tbl_Comboundtemp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_CustomerGroup]    Script Date: 16/12/2015 2:08:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_CustomerGroup](
	[Customercode] [float] NULL,
	[Region] [nvarchar](50) NULL,
	[Customergropcode] [float] NULL,
	[Group Name] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AdressGroup] [nchar](225) NULL,
	[Phone] [nchar](10) NULL,
 CONSTRAINT [PK_tbl_CustomerGroup] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_CustomerGroupTemp]    Script Date: 16/12/2015 2:08:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_CustomerGroupTemp](
	[Customercode] [float] NULL,
	[Customergropcode] [float] NULL,
	[Group Name] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Region] [nvarchar](50) NULL,
	[AdressGroup] [nchar](225) NULL,
	[Phone] [nchar](10) NULL,
 CONSTRAINT [PK_tbl_CustomerGroupTemp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_detailTEMP]    Script Date: 16/12/2015 2:08:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_detailTEMP](
	[id] [int] NULL
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_EmptyGroup]    Script Date: 16/12/2015 2:08:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_EmptyGroup](
	[id] [int] NOT NULL,
	[Name Group Emptty] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_EmptyGroup] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_FreGlass]    Script Date: 16/12/2015 2:08:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_FreGlass](
	[CUSTOMER] [float] NULL,
	[SALORG] [nvarchar](255) NULL,
	[COLAMT] [float] NULL,
	[PERNO] [nvarchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CUSTOMERgroupcode] [float] NULL,
 CONSTRAINT [PK_tbl_FreGlass] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_LetterForlow]    Script Date: 16/12/2015 2:08:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_LetterForlow](
	[Fromdate] [date] NULL,
	[Todate] [date] NULL,
	[No] [float] NULL,
	[Code] [float] NULL,
	[Region] [nchar](10) NULL,
	[id] [int] NOT NULL,
	[Return] [bit] NULL,
	[Note] [nchar](225) NULL,
	[AgreeorNot] [bit] NULL,
 CONSTRAINT [PK_tbl_LetterForlow] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_Preriod]    Script Date: 16/12/2015 2:09:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Preriod](
	[customercodeGR] [float] NULL,
	[Region] [nchar](5) NULL,
	[Name] [nchar](225) NULL,
	[Realbalace] [float] NULL,
	[Deposit amount] [float] NULL,
	[EmptyString] [nchar](225) NULL,
	[LetterReturn] [date] NULL,
	[AgreeOrDisAgree] [bit] NULL,
	[CustomerFeedback] [nchar](225) NULL,
	[NoteByAR] [nchar](225) NULL,
	[fromdate] [date] NULL,
	[todate] [date] NULL,
	[No] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tbl_Preriod2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_Productlist]    Script Date: 16/12/2015 2:09:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Productlist](
	[Mat Number] [nvarchar](255) NOT NULL,
	[Mat Text] [nvarchar](255) NULL,
	[Mat Group] [float] NULL,
	[Mat Group Text] [nvarchar](255) NULL,
	[Empty Group] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tbl_Productlist] PRIMARY KEY CLUSTERED 
(
	[Mat Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tbl_Productlist]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Productlist_tbl_EmptyGroup] FOREIGN KEY([Empty Group])
REFERENCES [dbo].[tbl_EmptyGroup] ([id])
GO

ALTER TABLE [dbo].[tbl_Productlist] CHECK CONSTRAINT [FK_tbl_Productlist_tbl_EmptyGroup]
GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_ProductlistTMP]    Script Date: 16/12/2015 2:09:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_ProductlistTMP](
	[Mat Number] [nvarchar](255) NOT NULL,
	[Mat Text] [nvarchar](255) NULL,
	[Mat Group] [float] NULL,
	[Mat Group Text] [nvarchar](255) NULL,
	[Empty Group] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tbl_ProductlistTMP] PRIMARY KEY CLUSTERED 
(
	[Mat Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_Remark]    Script Date: 16/12/2015 2:09:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Remark](
	[DocumentNo] [float] NULL,
	[Customer] [float] NULL,
	[Remark] [nvarchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tbl_Remark] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_Temp]    Script Date: 16/12/2015 2:09:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Temp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [int] NULL,
	[server] [nchar](225) NULL,
	[username] [nchar](225) NULL,
	[password] [nchar](225) NULL,
	[signoffby] [nchar](225) NULL,
	[possition] [nchar](225) NULL,
	[phonecontact] [nchar](225) NULL,
	[userright] [int] NULL,
	[note] [nchar](225) NULL,
	[contactperson] [nchar](225) NULL,
	[nameofbarnch] [nchar](225) NULL,
	[addressofbarnch] [nchar](225) NULL,
 CONSTRAINT [PK_temp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tbl_Unsendlist]    Script Date: 16/12/2015 2:09:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Unsendlist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Sorg] [nchar](10) NULL,
	[Customer] [float] NULL,
	[Name] [nvarchar](225) NULL
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblCustomer]    Script Date: 16/12/2015 2:09:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCustomer](
	[Customer] [float] NULL,
	[SOrg] [nvarchar](255) NULL,
	[Name 1] [nvarchar](255) NULL,
	[Telephone 1] [nvarchar](255) NULL,
	[Cusromergroup] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Reportsend] [bit] NULL,
	[SendingGroup] [nchar](50) NULL,
 CONSTRAINT [PK_tblCustomer_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblCustomerTmp]    Script Date: 16/12/2015 2:09:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCustomerTmp](
	[Customer] [float] NULL,
	[SOrg] [nvarchar](255) NULL,
	[Name 1] [nvarchar](255) NULL,
	[Telephone 1] [nvarchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Reportsend] [bit] NULL,
	[SendingGroup] [nchar](50) NULL,
 CONSTRAINT [PK_tblCustomer2_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblEDLP]    Script Date: 16/12/2015 2:09:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEDLP](
	[Sold-to] [float] NULL,
	[Sales Org] [nvarchar](255) NULL,
	[Cust Name] [nvarchar](255) NULL,
	[Invoice Doc Nr] [float] NULL,
	[Outbound Delivery] [nvarchar](255) NULL,
	[Mat Number] [nvarchar](255) NULL,
	[Mat Text] [nvarchar](255) NULL,
	[Billed Qty] [float] NULL,
	[Cond Value] [float] NULL,
	[Mat Group] [nvarchar](255) NULL,
	[Mat Group Text] [nvarchar](255) NULL,
	[UoM] [nvarchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmpyGroup] [int] NULL,
 CONSTRAINT [PK_tblEDLP] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblEDLPfull]    Script Date: 16/12/2015 2:09:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEDLPfull](
	[Sold-to] [float] NULL,
	[Sales Org] [nvarchar](255) NULL,
	[Cust Name] [nvarchar](255) NULL,
	[Invoice Doc Nr] [float] NULL,
	[Outbound Delivery] [nvarchar](255) NULL,
	[Mat Number] [nvarchar](255) NULL,
	[Mat Text] [nvarchar](255) NULL,
	[Billed Qty] [float] NULL,
	[Cond Value] [float] NULL,
	[Mat Group] [nvarchar](255) NULL,
	[Mat Group Text] [nvarchar](255) NULL,
	[UoM] [nvarchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tblEDLPfull] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblFBL5beginbalace]    Script Date: 16/12/2015 2:10:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFBL5beginbalace](
	[Account] [float] NOT NULL,
	[Business Area] [nvarchar](255) NULL,
	[Amount in local currency] [float] NULL,
	[Fullgood amount] [float] NULL,
	[Deposit amount] [float] NULL,
	[Empty Amount] [float] NULL,
	[Empty Amount Notmach] [float] NULL,
	[Adjusted amount] [float] NULL,
	[Payment amount] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codeGroup] [float] NULL,
	[Ketvothuong] [int] NULL,
	[Chaivothuong] [int] NULL,
	[Ketvolit] [int] NULL,
	[Chaivo1lit] [int] NULL,
	[Ketnhuathuong] [int] NULL,
	[Ketnhua1lit] [int] NULL,
	[joy20l] [int] NULL,
	[Binhpmicc02] [int] NULL,
	[binhpmix9l] [int] NULL,
	[palletgo] [int] NULL,
	[paletnhua] [int] NULL,
 CONSTRAINT [PK_tblFBL5beginbalace] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblFBL5beginbalaceTemp]    Script Date: 16/12/2015 2:10:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFBL5beginbalaceTemp](
	[Account] [float] NOT NULL,
	[Business Area] [nvarchar](255) NULL,
	[Amount in local currency] [float] NULL,
	[Fullgood amount] [float] NULL,
	[Deposit amount] [float] NULL,
	[Empty Amount] [float] NULL,
	[Empty Amount Notmach] [float] NULL,
	[Adjusted amount] [float] NULL,
	[Payment amount] [float] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codeGroup] [float] NULL,
	[Ketvothuong] [int] NULL,
	[Chaivothuong] [int] NULL,
	[Ketvolit] [int] NULL,
	[Chaivo1lit] [int] NULL,
	[Ketnhuathuong] [int] NULL,
	[Ketnhua1lit] [int] NULL,
	[joy20l] [int] NULL,
	[Binhpmicc02] [int] NULL,
	[binhpmix9l] [int] NULL,
	[palletgo] [int] NULL,
	[paletnhua] [int] NULL,
 CONSTRAINT [PK_tblFBL5beginbalacetm] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblFBL5N]    Script Date: 16/12/2015 2:10:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFBL5N](
	[Fbl5nID] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](255) NULL,
	[Assignment] [nvarchar](255) NULL,
	[Posting Date] [date] NULL,
	[Document Type] [nvarchar](255) NULL,
	[Document Number] [float] NULL,
	[Business Area] [nvarchar](255) NULL,
	[Amount in local currency] [float] NULL,
	[Completed use] [bit] NULL,
 CONSTRAINT [PK_tblFBL5N] PRIMARY KEY CLUSTERED 
(
	[Fbl5nID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblFBL5Nnew]    Script Date: 16/12/2015 2:10:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFBL5Nnew](
	[Account] [float] NOT NULL,
	[Posting Date] [date] NULL,
	[Document Type] [nvarchar](255) NULL,
	[Document Number] [float] NULL,
	[Business Area] [nvarchar](255) NULL,
	[Invoice] [nvarchar](255) NULL,
	[Formula invoice date] [date] NULL,
	[Amount in local currency] [float] NULL,
	[Invoice Amount] [float] NULL,
	[Fullgood amount] [float] NULL,
	[Deposit amount] [float] NULL,
	[Empty Amount] [float] NULL,
	[Empty Amount Notmach] [float] NULL,
	[Payment amount] [float] NULL,
	[Adjusted amount] [float] NULL,
	[Assignment] [nvarchar](255) NULL,
	[Remark] [nvarchar](255) NULL,
	[codeGroup] [float] NULL,
	[SoDelivery] [nvarchar](255) NULL,
	[Ketvothuong] [int] NULL,
	[Chaivothuong] [int] NULL,
	[Ketvolit] [int] NULL,
	[Chaivo1lit] [int] NULL,
	[Ketnhuathuong] [int] NULL,
	[Ketnhua1lit] [int] NULL,
	[joy20l] [int] NULL,
	[Binhpmicc02] [int] NULL,
	[binhpmix9l] [int] NULL,
	[palletgo] [int] NULL,
	[paletnhua] [int] NULL,
	[userupdate] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Completed use] [bit] NULL,
	[name] [nchar](225) NULL,
 CONSTRAINT [PK_tblFBL5Nnew] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblFBL5Nnewthisperiod]    Script Date: 16/12/2015 2:10:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFBL5Nnewthisperiod](
	[Account] [float] NOT NULL,
	[Posting Date] [date] NULL,
	[Document Type] [nvarchar](255) NULL,
	[Document Number] [float] NULL,
	[Business Area] [nvarchar](255) NULL,
	[Invoice] [nvarchar](255) NULL,
	[Formula invoice date] [date] NULL,
	[Amount in local currency] [float] NULL,
	[Invoice Amount] [float] NULL,
	[Fullgood amount] [float] NULL,
	[Deposit amount] [float] NULL,
	[Empty Amount] [float] NULL,
	[Empty Amount Notmach] [float] NULL,
	[Payment amount] [float] NULL,
	[Adjusted amount] [float] NULL,
	[Assignment] [nvarchar](255) NULL,
	[Remark] [nvarchar](255) NULL,
	[codeGroup] [float] NULL,
	[SoDelivery] [nvarchar](255) NULL,
	[Ketvothuong] [int] NULL,
	[Chaivothuong] [int] NULL,
	[Ketvolit] [int] NULL,
	[Chaivo1lit] [int] NULL,
	[Ketnhuathuong] [int] NULL,
	[Ketnhua1lit] [int] NULL,
	[joy20l] [int] NULL,
	[Binhpmicc02] [int] NULL,
	[binhpmix9l] [int] NULL,
	[palletgo] [int] NULL,
	[paletnhua] [int] NULL,
	[userupdate] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Completed use] [bit] NULL,
	[name] [nvarchar](255) NULL,
	[COL value] [float] NULL,
 CONSTRAINT [PK_tblFBL5Nnewthis] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblFBL5NTempRPtview]    Script Date: 16/12/2015 2:10:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFBL5NTempRPtview](
	[Account] [float] NOT NULL,
	[Business Area] [nvarchar](255) NULL,
	[Amount in local currency] [float] NULL,
	[Invoice Amount] [float] NULL,
	[Fullgood amount] [float] NULL,
	[Deposit amount] [float] NULL,
	[Empty Amount] [float] NULL,
	[Payment amount] [float] NULL,
	[Adjusted amount] [float] NULL,
	[codeGroup] [float] NULL,
	[Ketvothuong] [int] NULL,
	[Chaivothuong] [int] NULL,
	[Ketvolit] [int] NULL,
	[Chaivo1lit] [int] NULL,
	[Ketnhuathuong] [int] NULL,
	[Ketnhua1lit] [int] NULL,
	[joy20l] [int] NULL,
	[Binhpmicc02] [int] NULL,
	[binhpmix9l] [int] NULL,
	[palletgo] [int] NULL,
	[paletnhua] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tblFBL5NnewthisTemp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblFBL5NthisperiodSum]    Script Date: 16/12/2015 2:10:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblFBL5NthisperiodSum](
	[Account] [float] NOT NULL,
	[Region] [nvarchar](255) NULL,
	[Customer_Name] [nvarchar](255) NULL,
	[FBL5N amountps] [float] NULL,
	[FBL5N amountdk] [float] NULL,
	[FBL5N amountbg] [float] NULL,
	[FBL5N amount] [float] NULL,
	[Payment amountps] [float] NULL,
	[Payment amountdk] [float] NULL,
	[Payment amountbg] [float] NULL,
	[Adj amountdk] [float] NULL,
	[Adj amountbg] [float] NULL,
	[Adj amountps] [float] NULL,
	[Fullgood amountps] [float] NULL,
	[Fullgood amountdk] [float] NULL,
	[Fullgood amountbg] [float] NULL,
	[Fullgood amount] [float] NULL,
	[Empty Amountps] [float] NULL,
	[Empty Amountdk] [float] NULL,
	[Empty Amountbg] [float] NULL,
	[Empty Amount] [float] NULL,
	[Deposit amountps] [float] NULL,
	[Deposit amountdk] [float] NULL,
	[Deposit amountbg] [float] NULL,
	[Deposit_amount] [float] NULL,
	[Ketvothuongdk] [int] NULL,
	[Ketvothuongbg] [int] NULL,
	[Ketvothuongps] [int] NULL,
	[Ketvothuong] [int] NULL,
	[Chaivothuong] [int] NULL,
	[Chaivothuongdk] [int] NULL,
	[Chaivothuongbg] [int] NULL,
	[Chaivothuongps] [int] NULL,
	[Ketvolitdk] [int] NULL,
	[Ketvolitbg] [int] NULL,
	[Ketvolitps] [int] NULL,
	[Ketvolit] [int] NULL,
	[Chaivo1lit] [int] NULL,
	[Chaivo1litdk] [int] NULL,
	[Chaivo1litbg] [int] NULL,
	[Chaivo1litps] [int] NULL,
	[Ketnhuathuong] [int] NULL,
	[Ketnhuathuongdk] [int] NULL,
	[Ketnhuathuongbg] [int] NULL,
	[Ketnhuathuongps] [int] NULL,
	[Ketnhua1lit] [int] NULL,
	[Ketnhua1litdk] [int] NULL,
	[Ketnhua1litbg] [int] NULL,
	[Ketnhua1litps] [int] NULL,
	[joy20l] [int] NULL,
	[joy20ldk] [int] NULL,
	[joy20lbg] [int] NULL,
	[joy20lps] [int] NULL,
	[Binhpmicc02] [int] NULL,
	[Binhpmicc02dk] [int] NULL,
	[Binhpmicc02bg] [int] NULL,
	[Binhpmicc02ps] [int] NULL,
	[binhpmix9ldk] [int] NULL,
	[binhpmix9lbg] [int] NULL,
	[binhpmix9l] [int] NULL,
	[binhpmix9lps] [int] NULL,
	[palletgo] [int] NULL,
	[palletgodk] [int] NULL,
	[palletgobg] [int] NULL,
	[palletgops] [int] NULL,
	[paletnhua] [int] NULL,
	[paletnhuadk] [int] NULL,
	[paletnhuabg] [int] NULL,
	[paletnhuaps] [int] NULL,
	[Reportsend] [bit] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RealBalance] [float] NULL,
	[Payment amount] [float] NULL,
	[Adj amount] [float] NULL,
 CONSTRAINT [PK_tblFBL5Nnewthissum] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [KAmanagement]
GO

/****** Object:  Table [dbo].[tblVat]    Script Date: 16/12/2015 2:10:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblVat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Invoice Registration Number] [nvarchar](255) NULL,
	[Invoice Number] [nvarchar](255) NULL,
	[SAP Delivery Number] [float] NULL,
	[SAP Invoice Number] [float] NULL,
	[Pro Forma Date] [date] NULL,
	[Invoice Amount Before VAT] [float] NULL,
	[VAT Amount] [float] NULL,
	[Customer Number] [float] NULL,
	[Customer Name] [nvarchar](255) NULL,
	[Street Address] [nvarchar](255) NULL,
	[Region] [nvarchar](50) NULL,
	[Statuscheck] [bit] NULL,
 CONSTRAINT [PK_tblVat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO






---------------------

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[ClearABbelanceZezo]    Script Date: 16/12/2015 2:10:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure  [dbo].[ClearABbelanceZezo]
as
begin
       begin
		update tblFBL5N
		set tblFBL5N.[Completed use] =0
		 FROM tblFBL5N 
 
	
		end




		begin
		update tblFBL5N
		set tblFBL5N.[Completed use] =1
		 FROM tblFBL5N 
 
		WHERE tblFBL5N.[Document Type] ='AB' and tblFBL5N.[Document Number] IN
		(SELECT tblFBL5N.[Document Number] FROM tblFBL5N where  tblFBL5N.[Document Type] ='AB' GROUP BY tblFBL5N.[Document Number],tblFBL5N.Account  HAVING sum(tblFBL5N.[Amount in local currency]) = 0)

		end


		begin

		delete  from tblFBL5N
		where tblFBL5N.[Completed use] =1

		end


end
GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[copyfromThismonthtoFbl5new]    Script Date: 16/12/2015 2:11:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

	
CREATE procedure [dbo].[copyfromThismonthtoFbl5new]
as
begin

begin
insert into tblFBL5Nnew (tblFBL5Nnew.Account,tblFBL5Nnew.name,tblFBL5Nnew.[Adjusted amount],tblFBL5Nnew.[Amount in local currency],tblFBL5Nnew.Assignment,tblFBL5Nnew.Binhpmicc02,tblFBL5Nnew.binhpmix9l,tblFBL5Nnew.[Business Area],tblFBL5Nnew.Chaivo1lit,tblFBL5Nnew.Chaivothuong,tblFBL5Nnew.[Deposit amount],tblFBL5Nnew.[Document Number],tblFBL5Nnew.[Document Type],tblFBL5Nnew.[Empty Amount],tblFBL5Nnew.[Empty Amount Notmach],tblFBL5Nnew.[Formula invoice date],tblFBL5Nnew.[Fullgood amount],tblFBL5Nnew.Invoice,tblFBL5Nnew.joy20l,tblFBL5Nnew.Ketnhua1lit,tblFBL5Nnew.Ketnhuathuong,tblFBL5Nnew.Ketvolit,tblFBL5Nnew.Ketvothuong,tblFBL5Nnew.paletnhua,tblFBL5Nnew.palletgo,tblFBL5Nnew.[Payment amount],tblFBL5Nnew.[Posting Date],tblFBL5Nnew.Remark,tblFBL5Nnew.SoDelivery,tblFBL5Nnew.userupdate,tblFBL5Nnew.[Invoice Amount])
select tblFBL5Nnewthisperiod.Account,tblFBL5Nnewthisperiod.name,tblFBL5Nnewthisperiod.[Adjusted amount],tblFBL5Nnewthisperiod.[Amount in local currency],tblFBL5Nnewthisperiod.Assignment,tblFBL5Nnewthisperiod.Binhpmicc02,tblFBL5Nnewthisperiod.binhpmix9l,tblFBL5Nnewthisperiod.[Business Area],tblFBL5Nnewthisperiod.Chaivo1lit,tblFBL5Nnewthisperiod.Chaivothuong,tblFBL5Nnewthisperiod.[Deposit amount],tblFBL5Nnewthisperiod.[Document Number],tblFBL5Nnewthisperiod.[Document Type],tblFBL5Nnewthisperiod.[Empty Amount],tblFBL5Nnewthisperiod.[Empty Amount Notmach],tblFBL5Nnewthisperiod.[Formula invoice date],tblFBL5Nnewthisperiod.[Fullgood amount],tblFBL5Nnewthisperiod.Invoice,tblFBL5Nnewthisperiod.joy20l,tblFBL5Nnewthisperiod.Ketnhua1lit,tblFBL5Nnewthisperiod.Ketnhuathuong,tblFBL5Nnewthisperiod.Ketvolit,tblFBL5Nnewthisperiod.Ketvothuong,tblFBL5Nnewthisperiod.paletnhua,tblFBL5Nnewthisperiod.palletgo,tblFBL5Nnewthisperiod.[Payment amount],tblFBL5Nnewthisperiod.[Posting Date],tblFBL5Nnewthisperiod.Remark,tblFBL5Nnewthisperiod.SoDelivery,tblFBL5Nnewthisperiod.userupdate,tblFBL5Nnewthisperiod.[Invoice Amount] from tblFBL5Nnewthisperiod

end

begin
delete from tblFBL5Nnewthisperiod
end


end

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[deleteLisColandEmptydifferentinThis]    Script Date: 16/12/2015 2:11:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[deleteLisColandEmptydifferentinThis]
as
begin

delete from tblFBL5Nnewthisperiod
where tblFBL5Nnewthisperiod.[COL value] <> tblFBL5Nnewthisperiod.[Empty Amount]

end


GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[DeleteVATEDLPandFBL5nDocexistinFbl5nthis]    Script Date: 16/12/2015 2:11:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[DeleteVATEDLPandFBL5nDocexistinFbl5nthis]
as
begin

delete from tblVat
where tblVat.[SAP Invoice Number] in (Select tblFBL5Nnewthisperiod.[Document Number] from tblFBL5Nnewthisperiod)

end

begin

delete from tblFBL5N
where tblFBL5N.[Document Number] in (Select tblFBL5Nnewthisperiod.[Document Number] from tblFBL5Nnewthisperiod)

end

begin

delete  from tblEDLP
where tblEDLP.[Invoice Doc Nr] in (Select tblFBL5Nnewthisperiod.[Document Number] from tblFBL5Nnewthisperiod)

end

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[insertFbl5nthisfromFBL5n]    Script Date: 16/12/2015 2:11:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure  [dbo].[insertFbl5nthisfromFBL5n]
as

begin

insert into tblFBL5Nnewthisperiod (tblFBL5Nnewthisperiod.Account,tblFBL5Nnewthisperiod.[Amount in local currency],tblFBL5Nnewthisperiod.Assignment,tblFBL5Nnewthisperiod.[Business Area],tblFBL5Nnewthisperiod.[Document Number],tblFBL5Nnewthisperiod.[Document Type],tblFBL5Nnewthisperiod.[Posting Date])
select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] from tblFBL5N

end
GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[insertFbl5nthisfromFBL5nSumRpt]    Script Date: 16/12/2015 2:11:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure  [dbo].[insertFbl5nthisfromFBL5nSumRpt]
as

Begin

		begin
		delete  from  tblFBL5NthisperiodSum

		end

		-- insert toongr vaof 
		begin

		insert into tblFBL5NthisperiodSum (tblFBL5NthisperiodSum.Region,tblFBL5NthisperiodSum.Account,tblFBL5NthisperiodSum.Binhpmicc02ps, tblFBL5NthisperiodSum.binhpmix9lps ,tblFBL5NthisperiodSum.Chaivo1litps, tblFBL5NthisperiodSum.Chaivothuongps,  tblFBL5NthisperiodSum.Customer_Name, tblFBL5NthisperiodSum.[Deposit amountps],tblFBL5NthisperiodSum.[Empty Amountps],tblFBL5NthisperiodSum.[FBL5N amountps], tblFBL5NthisperiodSum.[Fullgood amountps],tblFBL5NthisperiodSum.joy20lps, tblFBL5NthisperiodSum.Ketnhua1litps, tblFBL5NthisperiodSum.Ketnhuathuongps,tblFBL5NthisperiodSum.Ketvolitps,tblFBL5NthisperiodSum.Ketvothuongps,tblFBL5NthisperiodSum.paletnhuaps,  tblFBL5NthisperiodSum.palletgops, tblFBL5NthisperiodSum.[Payment amountps],tblFBL5NthisperiodSum.[Adj amountps],tblFBL5NthisperiodSum.Reportsend)
		select tblFBL5Nnewthisperiod.[Business Area],tblFBL5Nnewthisperiod.Account, isnull(sum(tblFBL5Nnewthisperiod.Binhpmicc02),0), isnull(sum(tblFBL5Nnewthisperiod.binhpmix9l),0), isnull( sum(tblFBL5Nnewthisperiod.Chaivo1lit),0), isnull(  sum(tblFBL5Nnewthisperiod.Chaivothuong),0) ,max(tblFBL5Nnewthisperiod.name),isnull(sum(tblFBL5Nnewthisperiod.[Deposit amount]),0), isnull(sum(tblFBL5Nnewthisperiod.[Empty Amount]),0),  isnull(  sum(tblFBL5Nnewthisperiod.[Amount in local currency]),0) , isnull(sum(tblFBL5Nnewthisperiod.[Fullgood amount]),0) ,isnull(sum(tblFBL5Nnewthisperiod.joy20l),0) ,isnull(sum(tblFBL5Nnewthisperiod.Ketnhua1lit),0), isnull(sum(tblFBL5Nnewthisperiod.Ketnhuathuong),0), isnull( sum(tblFBL5Nnewthisperiod.Ketvolit),0),isnull(sum(tblFBL5Nnewthisperiod.Ketvothuong),0) , isnull( sum(tblFBL5Nnewthisperiod.paletnhua),0) ,isnull(sum(tblFBL5Nnewthisperiod.palletgo),0),isnull(sum(tblFBL5Nnewthisperiod.[Payment amount]),0),isnull(sum(tblFBL5Nnewthisperiod.[Adjusted amount]),0), (select top 1 tblCustomer.Reportsend from  tblCustomer where tblCustomer.Customer = tblFBL5Nnewthisperiod.Account and  tblCustomer.SOrg = tblFBL5Nnewthisperiod.[Business Area] )  from tblFBL5Nnewthisperiod
		group by tblFBL5Nnewthisperiod.Account, tblFBL5Nnewthisperiod.[Business Area]

		end

		begin
		insert into tblFBL5NthisperiodSum (tblFBL5NthisperiodSum.Region,tblFBL5NthisperiodSum.Account,tblFBL5NthisperiodSum.Binhpmicc02ps, tblFBL5NthisperiodSum.binhpmix9lps ,tblFBL5NthisperiodSum.Chaivo1litps, tblFBL5NthisperiodSum.Chaivothuongps,  tblFBL5NthisperiodSum.Customer_Name, tblFBL5NthisperiodSum.[Deposit amountps],tblFBL5NthisperiodSum.[Empty Amountps],tblFBL5NthisperiodSum.[FBL5N amountps], tblFBL5NthisperiodSum.[Fullgood amountps],tblFBL5NthisperiodSum.joy20lps, tblFBL5NthisperiodSum.Ketnhua1litps, tblFBL5NthisperiodSum.Ketnhuathuongps,tblFBL5NthisperiodSum.Ketvolitps,tblFBL5NthisperiodSum.Ketvothuongps,tblFBL5NthisperiodSum.paletnhuaps,  tblFBL5NthisperiodSum.palletgops, tblFBL5NthisperiodSum.[Payment amountps],tblFBL5NthisperiodSum.[Adj amountps],tblFBL5NthisperiodSum.Reportsend)
		select tblFBL5beginbalace.[Business Area],tblFBL5beginbalace.Account, 0, 0, 0, 0 ,(select top 1 tblCustomer.[Name 1] from  tblCustomer where tblCustomer.Customer = tblFBL5beginbalace.Account and  tblCustomer.SOrg = tblFBL5beginbalace.[Business Area] ),0, 0, 0 , 0,0 ,0,0,0,0 ,0 ,0,0,0, (select top 1 tblCustomer.Reportsend from  tblCustomer where tblCustomer.Customer = tblFBL5beginbalace.Account and  tblCustomer.SOrg = tblFBL5beginbalace.[Business Area] )
		from tblFBL5beginbalace

		--  cast((convert(int,tblFBL5beginbalace.Account)) as varchar(50))
		where CONCAT( Rtrim(ltrim(cast((convert(int,tblFBL5beginbalace.Account)) as varchar(50)))) ,rtrim(ltrim(tblFBL5beginbalace.[Business Area]))) not in (select CONCAT( Rtrim(ltrim(cast((convert(int,tblFBL5NthisperiodSum.Account)) as varchar(50)))) ,rtrim(ltrim(tblFBL5NthisperiodSum.Region)))  from tblFBL5NthisperiodSum)
		group by tblFBL5beginbalace.Account, tblFBL5beginbalace.[Business Area]

		end
 --- update cuoi kyf vowis code cos so du dau ky
 
		begin
		insert into tblFBL5NthisperiodSum (tblFBL5NthisperiodSum.Region,tblFBL5NthisperiodSum.Account,tblFBL5NthisperiodSum.Binhpmicc02ps, tblFBL5NthisperiodSum.binhpmix9lps ,tblFBL5NthisperiodSum.Chaivo1litps, tblFBL5NthisperiodSum.Chaivothuongps,  tblFBL5NthisperiodSum.Customer_Name, tblFBL5NthisperiodSum.[Deposit amountps],tblFBL5NthisperiodSum.[Empty Amountps],tblFBL5NthisperiodSum.[FBL5N amountps], tblFBL5NthisperiodSum.[Fullgood amountps],tblFBL5NthisperiodSum.joy20lps, tblFBL5NthisperiodSum.Ketnhua1litps, tblFBL5NthisperiodSum.Ketnhuathuongps,tblFBL5NthisperiodSum.Ketvolitps,tblFBL5NthisperiodSum.Ketvothuongps,tblFBL5NthisperiodSum.paletnhuaps,  tblFBL5NthisperiodSum.palletgops, tblFBL5NthisperiodSum.[Payment amountps],tblFBL5NthisperiodSum.[Adj amountps],tblFBL5NthisperiodSum.Reportsend)
		select tblFBL5NTempRPtview.[Business Area],tblFBL5NTempRPtview.Account, 0, 0, 0, 0 ,(select top 1 tblCustomer.[Name 1] from  tblCustomer where tblCustomer.Customer = tblFBL5NTempRPtview.Account and  tblCustomer.SOrg = tblFBL5NTempRPtview.[Business Area] ),0, 0, 0 , 0,0 ,0,0,0,0 ,0 ,0,0,0, (select top 1 tblCustomer.Reportsend from  tblCustomer where tblCustomer.Customer = tblFBL5NTempRPtview.Account and  tblCustomer.SOrg = tblFBL5NTempRPtview.[Business Area] )
		from tblFBL5NTempRPtview

		--  cast((convert(int,tblFBL5NTempRPtview.Account)) as varchar(50))
		where CONCAT( Rtrim(ltrim(cast((convert(int,tblFBL5NTempRPtview.Account)) as varchar(50)))) ,rtrim(ltrim(tblFBL5NTempRPtview.[Business Area]))) not in (select CONCAT( Rtrim(ltrim(cast((convert(int,tblFBL5NthisperiodSum.Account)) as varchar(50)))) ,rtrim(ltrim(tblFBL5NthisperiodSum.Region)))  from tblFBL5NthisperiodSum)
		group by tblFBL5NTempRPtview.Account, tblFBL5NTempRPtview.[Business Area]

		end





         begin 
		         	update tblFBL5NthisperiodSum 
					set  tblFBL5NthisperiodSum.Binhpmicc02 = tblFBL5NthisperiodSum.Binhpmicc02ps, --+ tblFBL5NTempRPtview.Binhpmicc02,
					     tblFBL5NthisperiodSum.binhpmix9l = tblFBL5NthisperiodSum.binhpmix9lps, -- + tblFBL5NTempRPtview.binhpmix9l,
	    tblFBL5NthisperiodSum.Chaivo1lit = tblFBL5NthisperiodSum.Chaivo1litps,--+ tblFBL5NTempRPtview.Chaivo1lit,
		tblFBL5NthisperiodSum.Chaivothuong = tblFBL5NthisperiodSum.Chaivothuongps, --+ tblFBL5NTempRPtview.Chaivothuong,
		tblFBL5NthisperiodSum.Deposit_amount = tblFBL5NthisperiodSum.[Deposit amountps] ,--+ tblFBL5NTempRPtview.[Deposit amount],
		tblFBL5NthisperiodSum.[Empty Amount] = tblFBL5NthisperiodSum.[Empty Amountps] ,--+ tblFBL5NTempRPtview.[Empty Amount],
		tblFBL5NthisperiodSum.[FBL5N amount] = tblFBL5NthisperiodSum.[FBL5N amountps],-- + tblFBL5NTempRPtview.[Amount in local currency],
		tblFBL5NthisperiodSum.[Fullgood amount] = tblFBL5NthisperiodSum.[Fullgood amountps],-- + tblFBL5NTempRPtview.[Fullgood amount],
		tblFBL5NthisperiodSum.joy20l = tblFBL5NthisperiodSum.joy20lps,-- + tblFBL5NTempRPtview.joy20l,
		tblFBL5NthisperiodSum.Ketnhua1lit = tblFBL5NthisperiodSum.Ketnhua1litps,-- + tblFBL5NTempRPtview.Ketnhua1lit,
		tblFBL5NthisperiodSum.Ketnhuathuong = tblFBL5NthisperiodSum.Ketnhuathuongps,-- + tblFBL5NTempRPtview.Ketnhuathuong,
		tblFBL5NthisperiodSum.Ketvothuong = tblFBL5NthisperiodSum.Ketvothuongps ,--+ tblFBL5NTempRPtview.Ketvothuong,
		tblFBL5NthisperiodSum.paletnhua = tblFBL5NthisperiodSum.paletnhuaps ,--+ tblFBL5NTempRPtview.paletnhua,
		tblFBL5NthisperiodSum.palletgo = tblFBL5NthisperiodSum.palletgops, --+ tblFBL5NTempRPtview.palletgo
			tblFBL5NthisperiodSum.[Adj amount] = tblFBL5NthisperiodSum.[Adj amountps],  --+ tblFBL5NTempRPtview.[Empty Amount],
			tblFBL5NthisperiodSum.[Payment amount] = tblFBL5NthisperiodSum.[Payment amountps] -- tblFBL5NTempRPtview.[Empty Amount],
	--		tblFBL5NthisperiodSum.RealBalance = isnull(tblFBL5NthisperiodSum.[Deposit amountps],0) + isnull(tblFBL5NthisperiodSum.[Fullgood amountps],0) + isnull(tblFBL5NthisperiodSum.[Adj amountps],0) + isnull(tblFBL5NthisperiodSum.[Payment amountps],0) 
			
				from tblFBL5NthisperiodSum--,tblFBL5NTempRPtview
				-- where not(tblFBL5NthisperiodSum.Account = tblFBL5NTempRPtview.Account and tblFBL5NthisperiodSum.Region = tblFBL5NTempRPtview.[Business Area] )-- and  tblFBL5Nnewthisperiod.[Document Type] = 'RV'
			
		end
		-- bạo lực1

		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;

		CREATE TABLE #TempResults
			(
		Account float,
		Region Nvarchar(225),	
		  Binhpmicc02 int,
		  binhpmix9l int,
		  Chaivo1lit int,
		  Chaivothuong  int,
		  Deposit_amount float,
		  Empty_Amount float,
		  FBL5N_amount float,
		  Fullgood_amount float,
		  joy20l  int,
		  Ketnhua1lit  int,
		  Ketnhuathuong  int,
		  Ketvothuong  int,
		  paletnhua  int,
		  palletgo   int,
		  Adj_amount float,
		  Payment_amount float
			
			)

-- tạo group cộng được tổng tiền, inserto #TempResults

       insert into #TempResults (Account,Region, Binhpmicc02,binhpmix9l,Chaivo1lit,Chaivothuong,Deposit_amount,Empty_Amount,FBL5N_amount,Fullgood_amount,joy20l,Ketnhua1lit,Ketnhuathuong,Ketvothuong,paletnhua,palletgo,Adj_amount,Payment_amount)
		SELECT tblFBL5beginbalace.Account,Rtrim(ltrim(tblFBL5beginbalace.[Business Area])), sum(isnull(tblFBL5beginbalace.Binhpmicc02,0)),sum(isnull(tblFBL5beginbalace.binhpmix9l,0)),sum(isnull(tblFBL5beginbalace.Chaivo1lit,0)),sum(isnull(tblFBL5beginbalace.Chaivothuong,0)),sum(isnull(tblFBL5beginbalace.[Deposit amount],0)),sum(isnull(tblFBL5beginbalace.[Empty Amount],0)),sum(isnull(tblFBL5beginbalace.[Amount in local currency],0)),sum(isnull(tblFBL5beginbalace.[Fullgood amount],0)),sum(isnull(tblFBL5beginbalace.joy20l,0)),sum(isnull(tblFBL5beginbalace.Ketnhua1lit,0)),sum(isnull(tblFBL5beginbalace.Ketnhuathuong,0)),sum(isnull(tblFBL5beginbalace.Ketvothuong,0)),sum(isnull(tblFBL5beginbalace.paletnhua,0)),sum(isnull(tblFBL5beginbalace.palletgo,0)),sum(isnull(tblFBL5beginbalace.[Adjusted amount],0)),sum(isnull(tblFBL5beginbalace.[Payment amount],0))
	    FROM tblFBL5beginbalace 
	--	on tblEDLP.[Mat Number] = tbl_Productlist.[Mat Number]  
		group by  tblFBL5beginbalace.Account , tblFBL5beginbalace.[Business Area]
		ORDER BY tblFBL5beginbalace.Account
	
	--select * from #TempResults
	--go

	

	    begin -- update this by col value
					update tblFBL5NthisperiodSum 
					set 
					 tblFBL5NthisperiodSum.Binhpmicc02bg = #TempResults.Binhpmicc02,
					 tblFBL5NthisperiodSum.binhpmix9lbg = #TempResults.binhpmix9l,
				--	 tblFBL5NthisperiodSum.[Empty Amount] = #TempResults.[Col value]
					  tblFBL5NthisperiodSum.Chaivo1litbg = #TempResults.Chaivo1lit,
					 tblFBL5NthisperiodSum.Chaivothuongbg = #TempResults.Chaivothuong,
					   tblFBL5NthisperiodSum.[Deposit amountbg] = #TempResults.Deposit_amount,
					 tblFBL5NthisperiodSum.[Fullgood amountbg] = #TempResults.Fullgood_amount,
					  tblFBL5NthisperiodSum.[Empty Amountbg] = #TempResults.Empty_Amount,
					 tblFBL5NthisperiodSum.[FBL5N amountbg] = #TempResults.FBL5N_amount,
					 tblFBL5NthisperiodSum.joy20lbg = #TempResults.joy20l,
					 tblFBL5NthisperiodSum.Ketnhua1litbg = #TempResults.Ketnhua1lit,
					 tblFBL5NthisperiodSum.Ketnhuathuongbg = #TempResults.Ketnhuathuong,
					   tblFBL5NthisperiodSum.Ketvothuongbg = #TempResults.Ketvothuong,
					   tblFBL5NthisperiodSum.paletnhuabg = #TempResults.paletnhua,
tblFBL5NthisperiodSum.palletgobg = #TempResults.palletgo,
tblFBL5NthisperiodSum.[Adj amountbg] = #TempResults.Adj_amount,
tblFBL5NthisperiodSum.[Payment amountbg] = #TempResults.Payment_amount
	    
					from tblFBL5NthisperiodSum,#TempResults
					where tblFBL5NthisperiodSum.Account = #TempResults.Account and  rtrim(ltrim(tblFBL5NthisperiodSum.Region)) = rtrim(ltrim(#TempResults.Region))
		end

	--	 select * from  #TempResults 
		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;


		-- bạo lực1 end

		--	select * from tblFBL5NthisperiodSum
		-- bạo lực2

		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults2;

		CREATE TABLE #TempResults2
			(
		Account float,
		Region Nvarchar(225),	
		  Binhpmicc02 int,
		  binhpmix9l int,
		  Chaivo1lit int,
		  Chaivothuong  int,
		  Deposit_amount float,
		  Empty_Amount float,
		  FBL5N_amount float,
		  Fullgood_amount float,
		  joy20l  int,
		  Ketnhua1lit  int,
		  Ketnhuathuong  int,
		  Ketvothuong  int,
		  paletnhua  int,
		  palletgo   int,
		  Adj_amount float,
		  Payment_amount float
			
			)

-- tạo group cộng được tổng tiền, inserto #TempResults

       insert into #TempResults2 (Account,Region, Binhpmicc02,binhpmix9l,Chaivo1lit,Chaivothuong,Deposit_amount,Empty_Amount,FBL5N_amount,Fullgood_amount,joy20l,Ketnhua1lit,Ketnhuathuong,Ketvothuong,paletnhua,palletgo,Adj_amount,Payment_amount)
		SELECT tblFBL5NTempRPtview.Account,Rtrim(ltrim(tblFBL5NTempRPtview.[Business Area])), sum(isnull(tblFBL5NTempRPtview.Binhpmicc02,0)),sum(isnull(tblFBL5NTempRPtview.binhpmix9l,0)),sum(isnull(tblFBL5NTempRPtview.Chaivo1lit,0)),sum(isnull(tblFBL5NTempRPtview.Chaivothuong,0)),sum(isnull(tblFBL5NTempRPtview.[Deposit amount],0)),sum(isnull(tblFBL5NTempRPtview.[Empty Amount],0)),sum(isnull(tblFBL5NTempRPtview.[Amount in local currency],0)),sum(isnull(tblFBL5NTempRPtview.[Fullgood amount],0)),sum(isnull(tblFBL5NTempRPtview.joy20l,0)),sum(isnull(tblFBL5NTempRPtview.Ketnhua1lit,0)),sum(isnull(tblFBL5NTempRPtview.Ketnhuathuong,0)),sum(isnull(tblFBL5NTempRPtview.Ketvothuong,0)),sum(isnull(tblFBL5NTempRPtview.paletnhua,0)),sum(isnull(tblFBL5NTempRPtview.palletgo,0)),sum(isnull(tblFBL5NTempRPtview.[Adjusted amount],0)),sum(isnull(tblFBL5NTempRPtview.[Payment amount],0))
	    FROM tblFBL5NTempRPtview 
	--	on tblEDLP.[Mat Number] = tbl_Productlist.[Mat Number]  
		group by  tblFBL5NTempRPtview.Account , tblFBL5NTempRPtview.[Business Area]
		ORDER BY tblFBL5NTempRPtview.Account
	
	
	    begin -- update this by col value
					update tblFBL5NthisperiodSum 
					set 
					 tblFBL5NthisperiodSum.Binhpmicc02dk = #TempResults2.Binhpmicc02,
					 tblFBL5NthisperiodSum.binhpmix9ldk = #TempResults2.binhpmix9l,
					 tblFBL5NthisperiodSum.[Empty Amountdk] = #TempResults2.Empty_Amount,
					  tblFBL5NthisperiodSum.Chaivo1litdk = #TempResults2.Chaivo1lit,
					 tblFBL5NthisperiodSum.Chaivothuongdk = #TempResults2.Chaivothuong,
					   tblFBL5NthisperiodSum.[Deposit amountdk] = #TempResults2.Deposit_amount,
					 tblFBL5NthisperiodSum.[Fullgood amountdk] = #TempResults2.Fullgood_amount,
					 tblFBL5NthisperiodSum.[FBL5N amountdk] = #TempResults2.FBL5N_amount,
					 tblFBL5NthisperiodSum.joy20ldk = #TempResults2.joy20l,
					 tblFBL5NthisperiodSum.Ketnhua1litdk = #TempResults2.Ketnhua1lit,
					 tblFBL5NthisperiodSum.Ketnhuathuongdk = #TempResults2.Ketnhuathuong,
					   tblFBL5NthisperiodSum.Ketvothuongdk = #TempResults2.Ketvothuong,
					   tblFBL5NthisperiodSum.paletnhuadk = #TempResults2.paletnhua,
tblFBL5NthisperiodSum.palletgodk = #TempResults2.palletgo,
tblFBL5NthisperiodSum.[Adj amountdk] = #TempResults2.Adj_amount,
tblFBL5NthisperiodSum.[Payment amountdk] = #TempResults2.Payment_amount
	    
					from tblFBL5NthisperiodSum,#TempResults2
					where tblFBL5NthisperiodSum.Account = #TempResults2.Account and  rtrim(ltrim(tblFBL5NthisperiodSum.Region)) = rtrim(ltrim(#TempResults2.Region))
		end

	--	 select * from  #TempResults 
		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults2;


		-- bạo lực2end




		   begin 
		         	update tblFBL5NthisperiodSum 
				set  tblFBL5NthisperiodSum.Binhpmicc02 =    isnull(tblFBL5NthisperiodSum.Binhpmicc02bg,0) + isnull(tblFBL5NthisperiodSum.Binhpmicc02dk,0) + isnull(tblFBL5NthisperiodSum.Binhpmicc02ps,0),
					     tblFBL5NthisperiodSum.binhpmix9l = isnull(tblFBL5NthisperiodSum.binhpmix9lps,0) +  isnull(tblFBL5NthisperiodSum.binhpmix9ldk ,0) +isnull(tblFBL5NthisperiodSum.binhpmix9lbg,0),
	    tblFBL5NthisperiodSum.Chaivo1lit =  isnull(tblFBL5NthisperiodSum.Chaivo1litdk,0) + isnull(tblFBL5NthisperiodSum.Chaivo1litbg ,0)+ isnull( tblFBL5NthisperiodSum.Chaivo1litps,0),
		tblFBL5NthisperiodSum.Chaivothuong =  isnull(tblFBL5NthisperiodSum.Chaivothuongdk,0)  + isnull(tblFBL5NthisperiodSum.Chaivothuongbg,0) + isnull( tblFBL5NthisperiodSum.Chaivothuongps,0),
		tblFBL5NthisperiodSum.Deposit_amount =  isnull(tblFBL5NthisperiodSum.[Deposit amountdk],0) + isnull(tblFBL5NthisperiodSum.[Deposit amountbg],0) +  isnull(tblFBL5NthisperiodSum.[Deposit amountps],0),
		tblFBL5NthisperiodSum.[Empty Amount] =isnull(tblFBL5NthisperiodSum.[Empty Amountdk],0) + isnull(tblFBL5NthisperiodSum.[Empty Amountbg],0)+ isnull(tblFBL5NthisperiodSum.[Empty Amountps],0),
		tblFBL5NthisperiodSum.[FBL5N amount] =  isnull(tblFBL5NthisperiodSum.[FBL5N amountbg],0) + isnull(tblFBL5NthisperiodSum.[FBL5N amountdk],0)+ isnull(tblFBL5NthisperiodSum.[FBL5N amountps] ,0),
		tblFBL5NthisperiodSum.[Fullgood amount] =   isnull(tblFBL5NthisperiodSum.[Fullgood amountbg],0) +  isnull(tblFBL5NthisperiodSum.[Fullgood amountdk],0) + isnull( tblFBL5NthisperiodSum.[Fullgood amountps],0),
		tblFBL5NthisperiodSum.joy20l =isnull( tblFBL5NthisperiodSum.joy20ldk,0) + isnull(tblFBL5NthisperiodSum.joy20lbg,0) + isnull(tblFBL5NthisperiodSum.joy20lps,0),
		tblFBL5NthisperiodSum.Ketnhua1lit =   isnull(tblFBL5NthisperiodSum.Ketnhua1litdk,0) +isnull( tblFBL5NthisperiodSum.Ketnhua1litbg,0) + isnull(tblFBL5NthisperiodSum.Ketnhua1litps,0),
		tblFBL5NthisperiodSum.Ketnhuathuong = isnull(tblFBL5NthisperiodSum.Ketnhuathuongdk,0)  + isnull(tblFBL5NthisperiodSum.Ketnhuathuongbg ,0)+ isnull(tblFBL5NthisperiodSum.Ketnhuathuongps ,0),
		tblFBL5NthisperiodSum.Ketvothuong = isnull( tblFBL5NthisperiodSum.Ketvothuongdk ,0) + isnull(tblFBL5NthisperiodSum.Ketvothuongbg,0) +isnull( tblFBL5NthisperiodSum.Ketvothuongps,0) ,
		tblFBL5NthisperiodSum.paletnhua =isnull(tblFBL5NthisperiodSum.paletnhuadk ,0)+ isnull(tblFBL5NthisperiodSum.paletnhuabg ,0)+ isnull( tblFBL5NthisperiodSum.paletnhuaps,0),
		tblFBL5NthisperiodSum.palletgo =  isnull(tblFBL5NthisperiodSum.palletgodk,0) + isnull(tblFBL5NthisperiodSum.palletgobg,0) + isnull(tblFBL5NthisperiodSum.palletgops,0),
			tblFBL5NthisperiodSum.[Adj amount] = isnull(tblFBL5NthisperiodSum.[Adj amountdk],0)  + isnull(tblFBL5NthisperiodSum.[Adj amountbg],0) + isnull( tblFBL5NthisperiodSum.[Adj amountps],0),
					tblFBL5NthisperiodSum.[Payment amount] =  isnull(tblFBL5NthisperiodSum.[Payment amountdk] ,0) + isnull(tblFBL5NthisperiodSum.[Payment amountbg],0) + isnull(tblFBL5NthisperiodSum.[Payment amountps],0) 
		



		from tblFBL5NthisperiodSum
			end

		--	select * from tblFBL5NthisperiodSum
		---
		 begin 
		         	update tblFBL5NthisperiodSum 

			set tblFBL5NthisperiodSum.RealBalance = tblFBL5NthisperiodSum.[Adj amount] + tblFBL5NthisperiodSum.[Payment amount] + tblFBL5NthisperiodSum.Deposit_amount + tblFBL5NthisperiodSum.[Fullgood amount]
			from tblFBL5NthisperiodSum
			end


	

end
-- tih cuoi ky voi cac co moi phat sinh



GO

USE [KAmanagement]
GO



/****** Object:  StoredProcedure [dbo].[inserttblvatstatusfalseintblCustomerTmp]    Script Date: 16/12/2015 10:15:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure  [dbo].[inserttblvatstatusfalseintblCustomerTmp]
as

begin

insert into tblCustomerTmp(tblCustomerTmp.[Name 1],tblCustomerTmp.Customer,tblCustomerTmp.SOrg,tblCustomerTmp.Address)
select max(tblVat.[Customer Name]),tblVat.[Customer Number],tblVat.Region,max(tblVat.[Street Address]) from tblVat
where tblVat.Statuscheck= 1
group by tblVat.[Customer Number], tblVat.Region

end

GO



/****** Object:  StoredProcedure [dbo].[tbl_ARdetalheaderRptcaculationinserts]    Script Date: 16/12/2015 6:13:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[tbl_ARdetalheaderRptcaculationinserts]
( @returndate date,
@fromdate date,
@todate date,
@byregion int
-- @Document_Number float
)

as

Begin

    
	
		begin

		insert into tbl_ARdetalheaderRpt (tbl_ARdetalheaderRpt.[address],tbl_ARdetalheaderRpt.custcodeGRoup, tbl_ARdetalheaderRpt.customername,tbl_ARdetalheaderRpt.Fromdate, tbl_ARdetalheaderRpt.Todate,tbl_ARdetalheaderRpt.region,tbl_ARdetalheaderRpt.phone,tbl_ARdetalheaderRpt.code,tbl_ARdetalheaderRpt.No)
		select 	max(tblCustomer.[Address]),tblCustomer.Cusromergroup,max(tblCustomer.[Name 1]),@fromdate,@todate,'VN',max(tblCustomer.[Telephone 1]),max(tblCustomer.Customer), isnull((select max(tbl_ArletterRpt.No) from tbl_ArletterRpt where tbl_ArletterRpt.custcodegRoup = tblCustomer.Cusromergroup),-1)
	    from    tblCustomer
		where  tblCustomer.Reportsend = 'True' and @byregion = 0 and tblCustomer.Customer not in (select tbl_CustomerGroup.Customercode from tbl_CustomerGroup)
		group by tblCustomer.Cusromergroup-- , tblCustomer.SOrg
		end


		
		begin

		insert into tbl_ARdetalheaderRpt (tbl_ARdetalheaderRpt.[address],tbl_ARdetalheaderRpt.custcodeGRoup, tbl_ARdetalheaderRpt.customername,tbl_ARdetalheaderRpt.Fromdate, tbl_ARdetalheaderRpt.Todate,tbl_ARdetalheaderRpt.region,tbl_ARdetalheaderRpt.phone,tbl_ARdetalheaderRpt.code,tbl_ARdetalheaderRpt.No)
		select 	max(tbl_CustomerGroup.AdressGroup),tbl_CustomerGroup.Customergropcode,max(tbl_CustomerGroup.[Group Name]),@fromdate,@todate,'VN',max(tbl_CustomerGroup.Phone),max(tbl_CustomerGroup.Customercode), isnull((select max(tbl_ArletterRpt.No) from tbl_ArletterRpt where tbl_ArletterRpt.custcodegRoup = tbl_CustomerGroup.Customergropcode),-1)
	    from    tbl_CustomerGroup
		where   @byregion = 0 --and tbl_CustomerGroup.Customercode  in (select tblCustomer.Customer from tblCustomer where  tblCustomer.Reportsend = 'True')
		group by tbl_CustomerGroup.Customergropcode-- , tbl_CustomerGroup.SOrg
		end

			
		begin

		insert into tbl_ARdetalheaderRpt (tbl_ARdetalheaderRpt.[address],tbl_ARdetalheaderRpt.custcodeGRoup, tbl_ARdetalheaderRpt.customername,tbl_ARdetalheaderRpt.Fromdate, tbl_ARdetalheaderRpt.Todate,tbl_ARdetalheaderRpt.region,tbl_ARdetalheaderRpt.phone,tbl_ARdetalheaderRpt.code,tbl_ARdetalheaderRpt.No)
		select 	max(tbl_CustomerGroup.AdressGroup),tbl_CustomerGroup.Customergropcode,max(tbl_CustomerGroup.[Group Name]),@fromdate,@todate,max(tbl_CustomerGroup.Region),max(tbl_CustomerGroup.Phone),max(tbl_CustomerGroup.Customercode), isnull((select max(tbl_ArletterRpt.No) from tbl_ArletterRpt where tbl_ArletterRpt.custcodegRoup = tbl_CustomerGroup.Customergropcode),-1)
	    from    tbl_CustomerGroup
		where   @byregion = 1-- and tbl_CustomerGroup.Customercode  in (select tblCustomer.Customer from tblCustomer where  tblCustomer.Reportsend = 'True')
		group by tbl_CustomerGroup.Customergropcode-- , tbl_CustomerGroup.SOrg
		end

		
		begin

		insert into tbl_ARdetalheaderRpt (tbl_ARdetalheaderRpt.[address],tbl_ARdetalheaderRpt.custcodeGRoup, tbl_ARdetalheaderRpt.customername,tbl_ARdetalheaderRpt.Fromdate, tbl_ARdetalheaderRpt.Todate,tbl_ARdetalheaderRpt.region,tbl_ARdetalheaderRpt.phone,tbl_ARdetalheaderRpt.code,tbl_ARdetalheaderRpt.No)
		select 	max(tblCustomer.[Address]),tblCustomer.Cusromergroup,max(tblCustomer.[Name 1]),@fromdate,@todate,tblCustomer.SOrg,max(tblCustomer.[Telephone 1]),max(tblCustomer.Customer), isnull((select max(tbl_ArletterRpt.No) from tbl_ArletterRpt where tbl_ArletterRpt.custcodegRoup = tblCustomer.Cusromergroup),-1)
	    from    tblCustomer
		where  tblCustomer.Reportsend = 'True' and @byregion = 1 and tblCustomer.Customer not in (select tbl_CustomerGroup.Customercode from tbl_CustomerGroup)
		group by tblCustomer.Cusromergroup , tblCustomer.SOrg
		end
	-- iif((len(cast(convert(int,tblCustomer.Cusromergroup) as VArchar(20))) >len(cast(convert(int,max(tblCustomer.Customer))as VArchar(20)))),'VN',MAX(tblCustomer.SOrg))
	--	len(convert(int,tblCustomer.Customer)as VArchar(20))

	    begin
		
	    update tbl_ARdetalheaderRpt 
	
		set 
		  tbl_ARdetalheaderRpt.dknuoc =isnull((select sum(isnull(tblFBL5Nnew.[Invoice Amount],0)) +  sum(isnull(tblFBL5Nnew.[Adjusted amount],0)) +  sum(isnull(tblFBL5Nnew.[Payment amount],0)) +  sum(isnull(tblFBL5Nnew.[Deposit amount],0))  from tblFBL5Nnew where tblFBL5Nnew.codeGroup = tbl_ARdetalheaderRpt.custcodegRoup and tblFBL5Nnew.[Posting Date] < @fromdate group by tblFBL5Nnew.codeGroup),0)+
	                                	isnull((select sum(isnull(tblFBL5beginbalace.[Adjusted amount],0))+sum(isnull(tblFBL5beginbalace.[Deposit amount],0))+sum(isnull(tblFBL5beginbalace.[Fullgood amount],0))+sum(isnull(tblFBL5beginbalace.[Payment amount],0)) from tblFBL5beginbalace where tblFBL5beginbalace.codeGroup = tbl_ARdetalheaderRpt.custcodegRoup group by  tblFBL5beginbalace.codeGroup ),0),
	  
		  tbl_ARdetalheaderRpt.dkvo= isnull((select sum(isnull(tblFBL5Nnew.[Deposit amount],0)) from tblFBL5Nnew where tblFBL5Nnew.codeGroup = tbl_ARdetalheaderRpt.custcodegRoup and tblFBL5Nnew.[Posting Date] < @fromdate group by tblFBL5Nnew.codeGroup),0)+
	                                	isnull((select sum(isnull(tblFBL5beginbalace.[Deposit amount],0)) from tblFBL5beginbalace where tblFBL5beginbalace.codeGroup = tbl_ARdetalheaderRpt.custcodegRoup group by  tblFBL5beginbalace.codeGroup ),0),

          tbl_ARdetalheaderRpt.psnuoc =isnull((select sum(isnull(tblFBL5Nnew.[Invoice Amount],0)) +  sum(isnull(tblFBL5Nnew.[Adjusted amount],0)) +  sum(isnull(tblFBL5Nnew.[Payment amount],0)) +  sum(isnull(tblFBL5Nnew.[Deposit amount],0)) from tblFBL5Nnew where tblFBL5Nnew.codeGroup = tbl_ARdetalheaderRpt.custcodegRoup and tblFBL5Nnew.[Posting Date] >= @fromdate  and tblFBL5Nnew.[Posting Date] <= @todate group by tblFBL5Nnew.codeGroup),0),
         tbl_ARdetalheaderRpt.psvo = isnull((select sum(isnull(tblFBL5Nnew.[Deposit amount],0)) from tblFBL5Nnew where tblFBL5Nnew.codeGroup = tbl_ARdetalheaderRpt.custcodegRoup and tblFBL5Nnew.[Posting Date] >= @fromdate  and tblFBL5Nnew.[Posting Date] <= @todate group by tblFBL5Nnew.codeGroup),0)
        
		
	    from tbl_ARdetalheaderRpt
	--	where tblFBL5Nnew.codeGroup = tbl_ARdetalheaderRpt.custcodegRoup

		end


		 begin
		
	    update tbl_ARdetalheaderRpt 
	
		set 

		 tbl_ARdetalheaderRpt.cknuoc =tbl_ARdetalheaderRpt.dknuoc + tbl_ARdetalheaderRpt.psnuoc,
		  tbl_ARdetalheaderRpt.ckvo = tbl_ARdetalheaderRpt.dkvo + tbl_ARdetalheaderRpt.psvo

        from tbl_ARdetalheaderRpt

		end



	  


end

GO




USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[tbl_ArletterdetailRptcaculationinserts]    Script Date: 16/12/2015 2:11:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[tbl_ArletterdetailRptcaculationinserts]
( @returndate date,
@fromdate date,
@todate date

-- @Document_Number float
)

as

Begin

  
	
		begin

		

		insert into tbl_ArletterdetailRpt (tbl_ArletterdetailRpt.DocNumber,tbl_ArletterdetailRpt.customergroup,tbl_ArletterdetailRpt.Depositamount,tbl_ArletterdetailRpt.InvoiceAmount,tbl_ArletterdetailRpt.Adjamount,tbl_ArletterdetailRpt.Paymentamount,tbl_ArletterdetailRpt.PostingDate)
		select isnull(tblFBL5Nnew.Invoice, iif(tblFBL5Nnew.[Document Type] ='RV',  tblFBL5Nnew.Assignment,iif(tblFBL5Nnew.[Document Type] ='DZ',cast(convert(int,tblFBL5Nnew.[Document Number])as VArchar(20)), tblFBL5Nnew.Assignment)) ) ,tblFBL5Nnew.codeGroup, isnull(tblFBL5Nnew.[Deposit amount],0),isnull(tblFBL5Nnew.[Invoice Amount],0),isnull(tblFBL5Nnew.[Adjusted amount],0),isnull(tblFBL5Nnew.[Payment amount],0),tblFBL5Nnew.[Posting Date]
	    from    tblFBL5Nnew
		where   tblFBL5Nnew.[Posting Date] >= @fromdate and  tblFBL5Nnew.[Posting Date] <= @todate  and (isnull(tblFBL5Nnew.[Deposit amount],0)+ isnull(tblFBL5Nnew.[Invoice Amount],0)+isnull(tblFBL5Nnew.[Adjusted amount],0)+isnull(tblFBL5Nnew.[Payment amount],0))<>0
	
		end




end

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[tbl_ArletterRptcaculationinserts]    Script Date: 16/12/2015 2:12:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[UpdateFbl5n]    Script Date: 07/12/2015 1:34:54 PM ******/


CREATE procedure [dbo].[tbl_ArletterRptcaculationinserts]
( @returndate date,
@fromdate date,
@todate date,
@byregion int
-- @Document_Number float
)

as

Begin

     DECLARE 

	     @stt int =0,
	   @sttc int =0,
	    @fulldk float,
        @fullbg float,
	    @depositdk float,
        @depositbg float
--		@false bit
	 --    @region nvarchar
		begin

		insert into tbl_ArletterRpt (tbl_ArletterRpt.returndate,tbl_ArletterRpt.[address],tbl_ArletterRpt.custcodeGRoup, tbl_ArletterRpt.customername,tbl_ArletterRpt.Fromdate, tbl_ArletterRpt.Todate,tbl_ArletterRpt.region,tbl_ArletterRpt.phone,tbl_ArletterRpt.code)
		select 	@returndate,max(tblCustomer.[Address]),tblCustomer.Cusromergroup,max(tblCustomer.[Name 1]),@fromdate,@todate,'VN',max(tblCustomer.[Telephone 1]),max(tblCustomer.Customer)--
	    from    tblCustomer
		where  tblCustomer.Reportsend = 'True' and @byregion = 0 and tblCustomer.Customer not in (select tbl_CustomerGroup.Customercode from tbl_CustomerGroup)
		group by tblCustomer.Cusromergroup-- , tblCustomer.SOrg
		end

		begin
		insert into tbl_ArletterRpt (tbl_ArletterRpt.returndate,tbl_ArletterRpt.[address],tbl_ArletterRpt.custcodeGRoup, tbl_ArletterRpt.customername,tbl_ArletterRpt.Fromdate, tbl_ArletterRpt.Todate,tbl_ArletterRpt.region,tbl_ArletterRpt.phone,tbl_ArletterRpt.code)
		select 	@returndate,max(tbl_CustomerGroup.AdressGroup),tbl_CustomerGroup.Customergropcode,max(tbl_CustomerGroup.[Group Name]),@fromdate,@todate,'VN',max(tbl_CustomerGroup.Phone),max(tbl_CustomerGroup.Customercode)--
	    from    tbl_CustomerGroup
		where   @byregion = 0 --and tbl_CustomerGroup.Customercode  in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
		group by tbl_CustomerGroup.Customergropcode-- , tbl_CustomerGroup.SOrg
		end

		begin
		insert into tbl_ArletterRpt (tbl_ArletterRpt.returndate,tbl_ArletterRpt.[address],tbl_ArletterRpt.custcodeGRoup, tbl_ArletterRpt.customername,tbl_ArletterRpt.Fromdate, tbl_ArletterRpt.Todate,tbl_ArletterRpt.region,tbl_ArletterRpt.phone,tbl_ArletterRpt.code)
		select 	@returndate,max(tbl_CustomerGroup.AdressGroup),tbl_CustomerGroup.Customergropcode,max(tbl_CustomerGroup.[Group Name]),@fromdate,@todate,max(tbl_CustomerGroup.Region),max(tbl_CustomerGroup.Phone),max(tbl_CustomerGroup.Customercode)--
	    from    tbl_CustomerGroup
		where   @byregion = 1 --and tbl_CustomerGroup.Customercode -- in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
		group by tbl_CustomerGroup.Customergropcode-- , tbl_CustomerGroup.SOrg
		end



			begin

		insert into tbl_ArletterRpt (tbl_ArletterRpt.returndate,tbl_ArletterRpt.[address],tbl_ArletterRpt.custcodeGRoup, tbl_ArletterRpt.customername,tbl_ArletterRpt.Fromdate, tbl_ArletterRpt.Todate,tbl_ArletterRpt.region,tbl_ArletterRpt.phone,tbl_ArletterRpt.code)
		select 	@returndate,max(tblCustomer.[Address]),tblCustomer.Cusromergroup,max(tblCustomer.[Name 1]),@fromdate,@todate,tblCustomer.SOrg,max(tblCustomer.[Telephone 1]),max(tblCustomer.Customer)--
	    from    tblCustomer
		where  tblCustomer.Reportsend = 'True' and @byregion = 1 and tblCustomer.Customer not in (select tbl_CustomerGroup.Customercode from tbl_CustomerGroup)
		group by tblCustomer.Cusromergroup , tblCustomer.SOrg
		end



		begin
		update tbl_ArletterRpt 
		set  
	
		tbl_ArletterRpt.sumoffreeclass = isnull((select sum(isnull(tbl_FreGlass.COLAMT,0)) from tbl_FreGlass where tbl_FreGlass.CUSTOMERgroupcode = tbl_ArletterRpt.custcodegRoup),0)
	   

		from tbl_ArletterRpt,tblCustomer
		
		where  tblCustomer.Reportsend = 'True' and tbl_ArletterRpt.custcodegRoup =tblCustomer.Cusromergroup
	 	end



		begin

	--	set @StringAmountEmpty =''
	
		update tbl_ArletterRpt 
		set  
	


		 @fulldk =  isnull((select sum(isnull(tblFBL5Nnew.[Adjusted amount],0))+sum(isnull(tblFBL5Nnew.[Deposit amount],0))+sum(isnull(tblFBL5Nnew.[Invoice Amount],0))+sum(isnull(tblFBL5Nnew.[Payment amount],0)) from tblFBL5Nnew where tblFBL5Nnew.codeGroup = tbl_ArletterRpt.custcodegRoup and tblFBL5Nnew.[Posting Date] <= @todate group by tblFBL5Nnew.codeGroup),0),
	       @fullbg = isnull((select sum(isnull(tblFBL5beginbalace.[Adjusted amount],0))+sum(isnull(tblFBL5beginbalace.[Deposit amount],0))+sum(isnull(tblFBL5beginbalace.[Fullgood amount],0))+sum(isnull(tblFBL5beginbalace.[Payment amount],0)) from tblFBL5beginbalace where tblFBL5beginbalace.codeGroup = tbl_ArletterRpt.custcodegRoup group by  tblFBL5beginbalace.codeGroup ),0),
	  
	  @depositdk  = isnull((select sum(isnull(tblFBL5Nnew.[Deposit amount],0)) from tblFBL5Nnew where tblFBL5Nnew.codeGroup = tbl_ArletterRpt.custcodegRoup and tblFBL5Nnew.[Posting Date] <= @todate group by tblFBL5Nnew.codeGroup),0),
	        @depositbg =  isnull((select sum(isnull(tblFBL5beginbalace.[Deposit amount],0)) from tblFBL5beginbalace where tblFBL5beginbalace.codeGroup = tbl_ArletterRpt.custcodegRoup group by  tblFBL5beginbalace.codeGroup ),0),
	   
	    tbl_ArletterRpt.sumAmountfull =  @fulldk + @fullbg,
	    tbl_ArletterRpt.sumEmptydeposit =  @depositdk +  @depositbg
	
	 
	   from tbl_ArletterRpt--tblFBL5beginbalace,tblFBL5Nnew
		

	    begin
		set @sttc = (select isnull(max(tbl_Preriod.No),0)  from tbl_Preriod where tbl_Preriod.fromdate =@fromdate and  tbl_Preriod.todate = @todate)  --,--and tbl_Preriod. = tbl_ArletterRpt.custcodegRoup 
	    update tbl_ArletterRpt
	  

		set 
	
    	@stt =  (select tbl_Preriod.No  from tbl_Preriod where tbl_Preriod.fromdate =@fromdate and  tbl_Preriod.todate = @todate and tbl_Preriod.customercodeGR = tbl_ArletterRpt.custcodegRoup)  ,
	    @sttc = @sttc +1,
		tbl_ArletterRpt.No = isnull( @stt,@sttc)
		from tbl_ArletterRpt
		end

		
	    begin
	   
	    insert into tbl_Preriod (tbl_Preriod.No,tbl_Preriod.fromdate,tbl_Preriod.todate,tbl_Preriod.customercodeGR,tbl_Preriod.Realbalace,tbl_Preriod.[Deposit amount],tbl_Preriod.Name,tbl_Preriod.Region)
		select tbl_ArletterRpt.No, @fromdate,@todate,tbl_ArletterRpt.custcodegRoup,tbl_ArletterRpt.sumAmountfull,tbl_ArletterRpt.sumEmptydeposit,tbl_ArletterRpt.customername,tbl_ArletterRpt.region
	    from    tbl_ArletterRpt  where tbl_ArletterRpt.No not in( select tbl_Preriod.No from tbl_Preriod where tbl_Preriod.fromdate =@fromdate and  tbl_Preriod.todate = @todate and  tbl_Preriod.customercodeGR = tbl_ArletterRpt.custcodegRoup)
	
		end


		
			end
		




end



GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[tbl_ColdetailRptcaculationinserts]    Script Date: 16/12/2015 2:12:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[tbl_ColdetailRptcaculationinserts]
( @returndate date,
@fromdate date,
@todate date

-- @Document_Number float
)

as

Begin
 DECLARE 
	 @vothuong nvarchar(225),
              @Chaivothuong nvarchar(225),
        @Chaivo1lit nvarchar(225),
       @Ketvolit nvarchar(225),
           @Ketnhuathuong nvarchar(225),
              @Ketnhua1lit nvarchar(225),
                @joy20l nvarchar(225),
                @Binhpmicc02 nvarchar(225),
                @binhpmix9l nvarchar(225),
                @palletgo nvarchar(225),
                @paletnhua nvarchar(225),
	

     	 @StringAmountEmpty nvarchar(225)

	


	
		begin

		insert into tbl_ColdetailRpt (tbl_ColdetailRpt.Postingdate, tbl_ColdetailRpt.codeGroup,tbl_ColdetailRpt.SoDelivery,tbl_ColdetailRpt.dkBinhpmicc02,tbl_ColdetailRpt.dkbinhpmix9l,tbl_ColdetailRpt.dkChaivo1lit,tbl_ColdetailRpt.dkChaivothuong,tbl_ColdetailRpt.dkjoy20,tbl_ColdetailRpt.dkKetnhua1lit,tbl_ColdetailRpt.dkKetnhuathuong,tbl_ColdetailRpt.dkKetvolit,tbl_ColdetailRpt.dkKetvothuong,tbl_ColdetailRpt.dkpaletnhua,tbl_ColdetailRpt.dkpalletgo)
		select 	@fromdate,max(tblFBL5beginbalace.codeGroup),'x',isnull(sum(tblFBL5beginbalace.Binhpmicc02),0),isnull(sum(tblFBL5beginbalace.binhpmix9l),0),isnull(sum(tblFBL5beginbalace.Chaivo1lit),0),isnull(sum(tblFBL5beginbalace.Chaivothuong),0),isnull(sum(tblFBL5beginbalace.joy20l),0),isnull(sum(tblFBL5beginbalace.Ketnhua1lit),0),isnull(sum(tblFBL5beginbalace.Ketnhuathuong),0),isnull(sum(tblFBL5beginbalace.Ketvolit),0),isnull(sum(tblFBL5beginbalace.Ketvothuong),0),isnull(sum(tblFBL5beginbalace.paletnhua),0),isnull(sum(tblFBL5beginbalace.palletgo),0)
	    from    tblFBL5beginbalace
		where   tblFBL5beginbalace.codeGroup in (select tblCustomer.Cusromergroup from tblCustomer where tblCustomer.Reportsend = 'True' )-- and (isnull(tblFBL5Nnew.[Deposit amount],0)+isnull(tblFBL5Nnew.[Invoice Amount],0)+isnull(tblFBL5Nnew.[Adjusted amount],0)+isnull(tblFBL5Nnew.[Payment amount],0))>0 --and  tblFBL5Nnew.[Posting Date] >= @fromdate and  tblFBL5Nnew.[Posting Date] <= @todate and (isnull(tblFBL5Nnew.[Deposit amount],0)+isnull(tblFBL5Nnew.[Invoice Amount],0)+isnull(tblFBL5Nnew.[Adjusted amount],0)+isnull(tblFBL5Nnew.[Payment amount],0))>0
        group by tblFBL5beginbalace.codeGroup
		end




	    begin
		
	    update tbl_ColdetailRpt 
	
		set 
	
		tbl_ColdetailRpt.dkBinhpmicc02 = isnull(tbl_ColdetailRpt.dkBinhpmicc02,0) + isnull((select sum(tblFBL5Nnew.Binhpmicc02) from  tblFBL5Nnew where tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup and  tblFBL5Nnew.[Posting Date] < @fromdate  group by tblFBL5Nnew.codeGroup),0),
		tbl_ColdetailRpt.dkbinhpmix9l= isnull(tbl_ColdetailRpt.dkbinhpmix9l,0)  + isnull((select sum(tblFBL5Nnew.binhpmix9l) from  tblFBL5Nnew where tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup and  tblFBL5Nnew.[Posting Date] < @fromdate  group by tblFBL5Nnew.codeGroup),0),
		tbl_ColdetailRpt.dkChaivo1lit = isnull(tbl_ColdetailRpt.dkChaivo1lit,0) + isnull((select sum(tblFBL5Nnew.Chaivo1lit) from  tblFBL5Nnew where tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup and  tblFBL5Nnew.[Posting Date] < @fromdate  group by tblFBL5Nnew.codeGroup),0),
		tbl_ColdetailRpt.dkChaivothuong = isnull(tbl_ColdetailRpt.dkChaivothuong,0) + isnull((select sum(tblFBL5Nnew.Chaivothuong) from  tblFBL5Nnew where tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup and  tblFBL5Nnew.[Posting Date] < @fromdate  group by tblFBL5Nnew.codeGroup),0),
		tbl_ColdetailRpt.dkjoy20 = isnull(tbl_ColdetailRpt.dkjoy20,0) + isnull((select sum(tblFBL5Nnew.joy20l) from  tblFBL5Nnew where tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup and  tblFBL5Nnew.[Posting Date] < @fromdate  group by tblFBL5Nnew.codeGroup),0),
		tbl_ColdetailRpt.dkKetnhua1lit = isnull(tbl_ColdetailRpt.dkKetnhua1lit,0) + isnull((select sum(tblFBL5Nnew.Ketnhua1lit) from  tblFBL5Nnew where tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup and  tblFBL5Nnew.[Posting Date] < @fromdate  group by tblFBL5Nnew.codeGroup),0),
		tbl_ColdetailRpt.dkKetnhuathuong = isnull(tbl_ColdetailRpt.dkKetnhuathuong,0)  + isnull((select sum(tblFBL5Nnew.Ketnhuathuong) from  tblFBL5Nnew where tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup and  tblFBL5Nnew.[Posting Date] < @fromdate  group by tblFBL5Nnew.codeGroup),0),
		tbl_ColdetailRpt.dkKetvolit = isnull(tbl_ColdetailRpt.dkKetvolit,0)  + isnull((select sum(tblFBL5Nnew.Ketvolit) from  tblFBL5Nnew where tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup and  tblFBL5Nnew.[Posting Date] < @fromdate  group by tblFBL5Nnew.codeGroup),0),
		tbl_ColdetailRpt.dkKetvothuong = isnull(tbl_ColdetailRpt.dkKetvothuong,0)   + isnull((select sum(tblFBL5Nnew.Ketvothuong) from  tblFBL5Nnew where tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup and  tblFBL5Nnew.[Posting Date] < @fromdate  group by tblFBL5Nnew.codeGroup),0),
		tbl_ColdetailRpt.dkpaletnhua = isnull(tbl_ColdetailRpt.dkpaletnhua,0)   + isnull((select sum(tblFBL5Nnew.paletnhua) from  tblFBL5Nnew where tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup and  tblFBL5Nnew.[Posting Date] < @fromdate  group by tblFBL5Nnew.codeGroup),0),
        tbl_ColdetailRpt.dkpalletgo = isnull(tbl_ColdetailRpt.dkpalletgo,0)   + isnull((select sum(tblFBL5Nnew.palletgo) from  tblFBL5Nnew where tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup and  tblFBL5Nnew.[Posting Date] < @fromdate  group by tblFBL5Nnew.codeGroup),0)

		
		from tbl_ColdetailRpt,tblFBL5Nnew
		where tbl_ColdetailRpt.SoDelivery = 'x' and tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup --and  tblFBL5Nnew.[Posting Date] < @fromdate -- and  tblFBL5Nnew.[Posting Date] <= @todate and tblFBL5Nnew.[Document Type] = 'RV'
	--	 group by tblFBL5Nnew.codeGroup
		end

		-- insert chi tieets col
	    begin
		
	    

		insert into tbl_ColdetailRpt (tbl_ColdetailRpt.InvoiceNumber ,tbl_ColdetailRpt.codeGroup,tbl_ColdetailRpt.SoDelivery, tbl_ColdetailRpt.Postingdate,tbl_ColdetailRpt.Account,tbl_ColdetailRpt.Binhpmicc02,tbl_ColdetailRpt.binhpmix9l,tbl_ColdetailRpt.Chaivo1lit,tbl_ColdetailRpt.Chaivothuong,tbl_ColdetailRpt.joy20l,tbl_ColdetailRpt.Ketnhua1lit,tbl_ColdetailRpt.Ketnhuathuong,tbl_ColdetailRpt.Ketvolit,tbl_ColdetailRpt.Ketvothuong,tbl_ColdetailRpt.paletnhua,tbl_ColdetailRpt.palletgo)
		select isnull(tblFBL5Nnew.Invoice,tblFBL5Nnew.Assignment),tblFBL5Nnew.codeGroup, tblFBL5Nnew.SoDelivery,tblFBL5Nnew.[Posting Date],tblFBL5Nnew.Account,isnull(tblFBL5Nnew.Binhpmicc02,0),isnull(tblFBL5Nnew.binhpmix9l,0),isnull(tblFBL5Nnew.Chaivo1lit,0),isnull(tblFBL5Nnew.Chaivothuong,0),isnull(tblFBL5Nnew.joy20l,0),isnull(tblFBL5Nnew.Ketnhua1lit,0),isnull(tblFBL5Nnew.Ketnhuathuong,0),isnull(tblFBL5Nnew.Ketvolit,0),isnull(tblFBL5Nnew.Ketvothuong,0),isnull(tblFBL5Nnew.paletnhua,0), isnull(tblFBL5Nnew.palletgo,0)
	    from    tblFBL5Nnew,tbl_ColdetailRpt
		where   tblFBL5Nnew.[Posting Date] >= @fromdate and  tblFBL5Nnew.[Posting Date] <= @todate and tblFBL5Nnew.[Document Type] = 'RV' and ( isnull(tblFBL5Nnew.Binhpmicc02,0) + isnull(tblFBL5Nnew.binhpmix9l,0) + isnull(tblFBL5Nnew.Chaivo1lit,0) + isnull(tblFBL5Nnew.Chaivothuong,0) + isnull(tblFBL5Nnew.joy20l,0)+isnull(tblFBL5Nnew.Ketnhua1lit,0)+isnull(tblFBL5Nnew.Ketnhuathuong,0)+isnull(tblFBL5Nnew.Ketvolit,0)+isnull(tblFBL5Nnew.Ketvothuong,0)+ isnull(tblFBL5Nnew.paletnhua,0)+ isnull(tblFBL5Nnew.palletgo,0)) <>0 and tbl_ColdetailRpt.codeGroup = tblFBL5Nnew.codeGroup-- tblFBL5Nnew.codeGroup in (select tblCustomer.Cusromergroup from tblCustomer where tblCustomer.Reportsend = 'True' )-- and (isnull(tblFBL5Nnew.[Deposit amount],0)+isnull(tblFBL5Nnew.[Invoice Amount],0)+isnull(tblFBL5Nnew.[Adjusted amount],0)+isnull(tblFBL5Nnew.[Payment amount],0))>0 --and  tblFBL5Nnew.[Posting Date] >= @fromdate and  tblFBL5Nnew.[Posting Date] <= @todate and (isnull(tblFBL5Nnew.[Deposit amount],0)+isnull(tblFBL5Nnew.[Invoice Amount],0)+isnull(tblFBL5Nnew.[Adjusted amount],0)+isnull(tblFBL5Nnew.[Payment amount],0))>0 --and  tblFBL5Nnew.[Posting Date] <> null
   
		end


		
	 
	    begin
		set  @StringAmountEmpty =''

		
	     update tbl_ArletterRpt 
	    set @vothuong = ltrim(rtrim(iif( (select sum(isnull(tbl_ColdetailRpt.dkKetvothuong,0)) +  sum(isnull(tbl_ColdetailRpt.Ketvothuong,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup ) <>0, CONCAT(convert(Nvarchar,(select sum(isnull(tbl_ColdetailRpt.dkKetvothuong,0)) + sum(isnull(tbl_ColdetailRpt.Ketvothuong,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup )), N' két vỏ thường; '),''))),
			@Chaivothuong = ltrim(rtrim(iif( (select sum(isnull(tbl_ColdetailRpt.dkChaivothuong,0)) + sum(isnull(tbl_ColdetailRpt.Chaivothuong,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup ) <>0, CONCAT(convert(Nvarchar,(select sum(isnull(tbl_ColdetailRpt.dkChaivothuong,0)) + sum(isnull(tbl_ColdetailRpt.Chaivothuong,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup )),  N' chai vỏ thường; '),''))),
			 @Chaivo1lit = ltrim(rtrim(iif( (select sum(isnull(tbl_ColdetailRpt.dkChaivo1lit,0)) + sum(isnull(tbl_ColdetailRpt.Chaivo1lit,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup ) <>0, CONCAT(convert(Nvarchar,(select sum(isnull(tbl_ColdetailRpt.dkChaivo1lit,0)) + sum(isnull(tbl_ColdetailRpt.Chaivo1lit,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup )),N' chai vỏ 1 lít; '),''))),
			 @Ketvolit  = ltrim(rtrim(iif( (select sum(isnull(tbl_ColdetailRpt.dkKetvolit,0)) + sum(isnull(tbl_ColdetailRpt.Ketvolit,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup ) <>0, CONCAT(convert(Nvarchar,(select sum(isnull(tbl_ColdetailRpt.dkKetvolit,0)) + sum(isnull(tbl_ColdetailRpt.Ketvolit,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup )), N' Két vỏ 1 lít; '),''))),
			 @Ketnhuathuong = ltrim(rtrim(iif( (select sum(isnull(tbl_ColdetailRpt.dkKetnhuathuong,0)) + sum(isnull(tbl_ColdetailRpt.Ketnhuathuong,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup ) <>0, CONCAT(convert(Nvarchar,(select sum(isnull(tbl_ColdetailRpt.dkKetnhuathuong,0)) + sum(isnull(tbl_ColdetailRpt.Ketnhuathuong,0)) from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup )),  N' Két nhựa; '),''))),
			 @Ketnhua1lit = ltrim(rtrim(iif( (select sum(isnull(tbl_ColdetailRpt.dkKetnhua1lit,0))+sum(isnull(tbl_ColdetailRpt.Ketnhua1lit,0)) from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup ) <>0, CONCAT(convert(Nvarchar,(select sum(isnull(tbl_ColdetailRpt.dkKetnhua1lit,0)) + sum(isnull(tbl_ColdetailRpt.Ketnhua1lit,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup )), N' Két nhựa 1 lít; '),''))),
			 @joy20l  = ltrim(rtrim(iif( (select sum(isnull(tbl_ColdetailRpt.dkjoy20,0)) + sum(isnull(tbl_ColdetailRpt.joy20l,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup ) <>0,CONCAT( convert(Nvarchar,(select sum(isnull(tbl_ColdetailRpt.dkjoy20,0)) + sum(isnull(tbl_ColdetailRpt.joy20l,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup )), N' Bình joy 20l; '),''))),
		 @Binhpmicc02  = ltrim(rtrim(iif( (select sum(isnull(tbl_ColdetailRpt.dkBinhpmicc02,0)) + sum(isnull(tbl_ColdetailRpt.Binhpmicc02,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup ) <>0,CONCAT( convert(Nvarchar,(select sum(isnull(tbl_ColdetailRpt.dkBinhpmicc02,0)) + sum(isnull(tbl_ColdetailRpt.Binhpmicc02,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup )), N' Bình Postmix/CO2; '),''))),
			 @binhpmix9l = ltrim(rtrim(iif( (select sum(isnull(tbl_ColdetailRpt.dkbinhpmix9l,0)) + sum(isnull(tbl_ColdetailRpt.binhpmix9l,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup ) <>0,CONCAT( convert(Nvarchar,(select sum(isnull(tbl_ColdetailRpt.dkbinhpmix9l,0)) + sum(isnull(tbl_ColdetailRpt.binhpmix9l,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup )),N' Bình Postmix9l; '),''))),
			   @palletgo = ltrim(rtrim(iif( (select sum(isnull(tbl_ColdetailRpt.dkpalletgo,0)) + sum(isnull(tbl_ColdetailRpt.palletgo,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup ) <>0,CONCAT( convert(Nvarchar,(select sum(isnull(tbl_ColdetailRpt.dkpalletgo,0)) + sum(isnull(tbl_ColdetailRpt.palletgo,0) ) from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup )), N' Pallet gỗ; '),''))),
			 @paletnhua  = ltrim(rtrim(iif( (select sum(isnull(tbl_ColdetailRpt.dkpaletnhua,0)) + sum(isnull(tbl_ColdetailRpt.paletnhua,0))  from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup ) <>0, CONCAT(convert(Nvarchar,(select sum(isnull(tbl_ColdetailRpt.dkpaletnhua,0)) + sum(isnull(tbl_ColdetailRpt.paletnhua ,0)) from tbl_ColdetailRpt where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup  group by tbl_ColdetailRpt.codeGroup )),N' Pallet nhựa; '),''))),
			@StringAmountEmpty = CONCAT(@vothuong,@Chaivothuong,@Chaivo1lit,@Ketvolit,@Ketnhuathuong,@Ketnhua1lit,@joy20l,@Binhpmicc02,@binhpmix9l,@palletgo,@paletnhua), 
			
			@StringAmountEmpty = iif(@StringAmountEmpty ='',N' Không nợ vỏ; ',@StringAmountEmpty),
		    tbl_ArletterRpt.StringAmountEmpty = ltrim(rtrim(@StringAmountEmpty))




	     from tbl_ColdetailRpt
		 where tbl_ColdetailRpt.codeGroup = tbl_ArletterRpt.custcodegRoup


			end

			begin
		     update tbl_Preriod
			 set  tbl_Preriod.EmptyString = tbl_ArletterRpt.StringAmountEmpty,
			 tbl_Preriod.[Deposit amount] = tbl_ArletterRpt.sumEmptydeposit,
			 tbl_Preriod.Realbalace = tbl_ArletterRpt.sumAmountfull
			 from  tbl_ArletterRpt
			 where tbl_ArletterRpt.fromdate = tbl_Preriod.fromdate and tbl_ArletterRpt.toDate = tbl_Preriod.todate and  tbl_ArletterRpt.custcodegRoup = tbl_Preriod.customercodeGR
			 end


		

end

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updaFBL5nreportsBalacegroupRegion]    Script Date: 16/12/2015 2:12:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure  [dbo].[updaFBL5nreportsBalacegroupRegion]
(-- @fromdate date,
  @todate datetime
)

as
begin
        begin 
		update tblFBL5Nnew 
		set tblFBL5Nnew.codeGroup =  Rtrim(cast((convert(int,tblFBL5Nnew.Account)) as varchar(50)))  + right(tblFBL5Nnew.[Business Area],2)-- tblFBL5Nnew.Account + Right(tblFBL5Nnew.[Business Area],2) 
		--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
		from tblFBL5Nnew,tbl_CustomerGroup
		where tblFBL5Nnew.Account in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tblFBL5Nnew.Account <> tbl_CustomerGroup.Customercode 
			   and tblFBL5Nnew.[Posting Date] <= @todate


		end
		begin 
		update tblFBL5Nnew 
		set tblFBL5Nnew.codeGroup =  Rtrim(cast((convert(int,tbl_CustomerGroup.Customergropcode)) as varchar(50)))  + right(tblFBL5Nnew.[Business Area],2)--- tbl_CustomerGroup.Customergropcode + Right(tblFBL5Nnew.[Business Area],2)
		--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
		from tblFBL5Nnew,tbl_CustomerGroup
		where tblFBL5Nnew.Account in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tblFBL5Nnew.Account = tbl_CustomerGroup.Customercode 
			      and tblFBL5Nnew.[Posting Date] <= @todate
		end

		
end
	

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updaFBL5nreportsBalacegroupVN]    Script Date: 16/12/2015 2:12:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure  [dbo].[updaFBL5nreportsBalacegroupVN]
(-- @fromdate date,
  @todate datetime
)

as
begin
        begin 
		update tblFBL5Nnew 
		set tblFBL5Nnew.codeGroup = tblFBL5Nnew.Account
		--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
		from tblFBL5Nnew,tbl_CustomerGroup
		where tblFBL5Nnew.Account in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tblFBL5Nnew.Account <> tbl_CustomerGroup.Customercode 
			   and tblFBL5Nnew.[Posting Date] <= @todate


		end
		begin 
		update tblFBL5Nnew 
		set tblFBL5Nnew.codeGroup = tbl_CustomerGroup.Customergropcode
		--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
		from tblFBL5Nnew,tbl_CustomerGroup
		where tblFBL5Nnew.Account in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tblFBL5Nnew.Account = tbl_CustomerGroup.Customercode
			      and tblFBL5Nnew.[Posting Date] <= @todate
		end

		
end
	

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updatebeginBalacegruop]    Script Date: 16/12/2015 2:12:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure  [dbo].[updatebeginBalacegruop]
as
begin
        begin 
		update tblFBL5beginbalace 
		set tblFBL5beginbalace.codeGroup = tblFBL5beginbalace.Account
		--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
		from tblFBL5beginbalace,tbl_CustomerGroup
		where tblFBL5beginbalace.Account in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tblFBL5beginbalace.Account <> tbl_CustomerGroup.Customercode

		end
		begin 
		update tblFBL5beginbalace 
		set tblFBL5beginbalace.codeGroup = tbl_CustomerGroup.Customergropcode
		--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
		from tblFBL5beginbalace,tbl_CustomerGroup
		where tblFBL5beginbalace.Account in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tblFBL5beginbalace.Account = tbl_CustomerGroup.Customercode

		end

		
end
	

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updatebeginBalacegruopRegion]    Script Date: 16/12/2015 2:12:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure  [dbo].[updatebeginBalacegruopRegion]
as


begin
        begin 
		update tblFBL5beginbalace 
		set tblFBL5beginbalace.codeGroup = Rtrim(cast((convert(int,tblFBL5beginbalace.Account)) as varchar(50)))  +RIGHT( tblFBL5beginbalace.[Business Area],2)
	-- Rtrim(cast((convert(int,tblFBL5beginbalace.Account)) as varchar(50)))  + right(tblFBL5Nnew.[Business Area],2)-- tblFBL5Nnew.Account + Right(tblFBL5Nnew.[Business Area],2) 
		from tblFBL5beginbalace,tbl_CustomerGroup
		where tblFBL5beginbalace.Account in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tblFBL5beginbalace.Account <> tbl_CustomerGroup.Customercode

		end
		begin 
		update tblFBL5beginbalace 
		set tblFBL5beginbalace.codeGroup = Rtrim(cast((convert(int,tbl_CustomerGroup.Customergropcode)) as varchar(50)))   +RIGHT( tblFBL5beginbalace.[Business Area],2)
	
		from tblFBL5beginbalace,tbl_CustomerGroup
		where tblFBL5beginbalace.Account in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tblFBL5beginbalace.Account = tbl_CustomerGroup.Customercode

		end

		
end
	
GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateComountemp]    Script Date: 16/12/2015 2:12:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure  [dbo].[updateComountemp]
as
begin

insert into tbl_Comboundtemp (tbl_Comboundtemp.Code,tbl_Comboundtemp.codeGroup,tbl_Comboundtemp.Region,tbl_Comboundtemp.name) -- tbl_Comboundtemp.name,
select DISTINCT  tblFBL5Nnewthisperiod.Account,tblFBL5Nnewthisperiod.codeGroup,tblFBL5Nnewthisperiod.[Business Area],tblFBL5Nnewthisperiod.name   from tblFBL5Nnewthisperiod --tblFBL5Nnewthisperiod.name




end
GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateCustgoupinListcustmakeRptRegion]    Script Date: 16/12/2015 2:12:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure  [dbo].[updateCustgoupinListcustmakeRptRegion]
as
begin
        begin 
		update tblCustomer 
		set tblCustomer.Cusromergroup = Rtrim(cast((convert(int,tblCustomer.CUSTOMER)) as varchar(50)))  + right(tblCustomer.SOrg,2)
		from tblCustomer,tbl_CustomerGroup
		where tblCustomer.Reportsend = 'True' and tblCustomer.CUSTOMER <> tbl_CustomerGroup.Customercode

		end

		select * from tblCustomer

		where tblCustomer.Reportsend ='True'



		begin 
		update tblCustomer 
		set tblCustomer.Cusromergroup = Rtrim(cast((convert(int,tbl_CustomerGroup.Customergropcode)) as varchar(50)))    + right(tblCustomer.SOrg,2)
		from tblCustomer,tbl_CustomerGroup
		where tblCustomer.Reportsend ='True' and tblCustomer.CUSTOMER = tbl_CustomerGroup.Customercode

		end

		
end
	

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateCustgoupinListcustmakeRptVN]    Script Date: 16/12/2015 2:12:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure  [dbo].[updateCustgoupinListcustmakeRptVN]
as
begin
        begin 
		update tblCustomer 
		set tblCustomer.Cusromergroup = tblCustomer.CUSTOMER
		from tblCustomer,tbl_CustomerGroup
		where tblCustomer.CUSTOMER in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tblCustomer.CUSTOMER <> tbl_CustomerGroup.Customercode

		end
		begin 
		update tblCustomer 
		set tblCustomer.Cusromergroup = tbl_CustomerGroup.Customergropcode
		from tblCustomer,tbl_CustomerGroup
		where tblCustomer.CUSTOMER in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tblCustomer.CUSTOMER = tbl_CustomerGroup.Customercode

		end

		
end
	

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateCustgoupThistable]    Script Date: 16/12/2015 2:12:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure  [dbo].[updateCustgoupThistable]
as
begin
         begin

        update tblFBL5Nnewthisperiod 
		set tblFBL5Nnewthisperiod.codeGroup = tblFBL5Nnewthisperiod.Account
	
	
		end



		begin
        update tblFBL5Nnewthisperiod 
		set tblFBL5Nnewthisperiod.codeGroup = tbl_CustomerGroup.Customergropcode
	
		from tblFBL5Nnewthisperiod,tbl_CustomerGroup
		where tblFBL5Nnewthisperiod.Account = tbl_CustomerGroup.Customercode and  tblFBL5Nnewthisperiod.[Business Area] = tbl_CustomerGroup.Region
		end
		
end


GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateCustListnotsend]    Script Date: 16/12/2015 2:13:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure  [dbo].[updateCustListnotsend]
as
begin

begin


update tblCustomer 
set tblCustomer.Reportsend = 'True'
from tblCustomer
end
	
begin
update tblCustomer 
set tblCustomer.Reportsend = 'false'
--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
from tblCustomer,tbl_Unsendlist
where tblCustomer.Customer = tbl_Unsendlist.Customer and  tblCustomer.SOrg = tbl_Unsendlist.Sorg
end

end	

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateCustListsend]    Script Date: 16/12/2015 2:13:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure  [dbo].[updateCustListsend]
as
begin


update tblCustomer 
set tblCustomer.Reportsend = 'true'
--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
from tblCustomer,tbl_Unsendlist
where tblCustomer.Customer = tbl_Unsendlist.Customer and  tblCustomer.SOrg = tbl_Unsendlist.Sorg
end
	

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateEdlp]    Script Date: 16/12/2015 2:13:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure  [dbo].[updateEdlp]
as
		
		
		begin   --update edlp

		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;

		CREATE TABLE #TempResults
			(
			  [Invoice Doc Nr] float,
			  [Col value] float
			
			)

-- tạo group cộng được tổng tiền, inserto #TempResults

       insert into #TempResults ([Invoice Doc Nr],[Col value])
		SELECT  tblEDLP.[Invoice Doc Nr], sum(tblEDLP.[Cond Value]) AS [Col value]--,tbl_Productlist.[Empty Group]--tblEDLP.UoM ,sum(tblEDLP.[Billed Qty]),
	    FROM tblEDLP inner join tbl_Productlist
		on tblEDLP.[Mat Number] = tbl_Productlist.[Mat Number]  
		group by  tblEDLP.[Invoice Doc Nr]
		ORDER BY tblEDLP.[Invoice Doc Nr]
	
	
	    begin -- update this by col value
					update tblFBL5Nnewthisperiod 
					set  tblFBL5Nnewthisperiod.[Empty Amount] = #TempResults.[Col value]
	    
					from tblFBL5Nnewthisperiod,#TempResults
					where tblFBL5Nnewthisperiod.[Document Number] = #TempResults.[Invoice Doc Nr]-- and  tblFBL5Nnewthisperiod.[Document Type] = 'RV'
		end

		 --- select * from  #TempResults 
		IF OBJECT_ID(N'tempdb..#TempResults', N'U') IS NOT NULL 
        DROP TABLE #TempResults;
	
		begin -- update empty group lên tble edlp
		         	update tblEDLP 
					set  tblEDLP.EmpyGroup = tbl_Productlist.[Empty Group]
	    
					from tblEDLP,tbl_Productlist
					where tblEDLP.[Mat Number] = tbl_Productlist.[Mat Number]-- and  tblFBL5Nnewthisperiod.[Document Type] = 'RV'

		end
		begin -- update empty quanity theo conudvalue
		         	update tblEDLP 
					set  tblEDLP.[Billed Qty] = tblEDLP.[Billed Qty]*(-1)
	    
					from tblEDLP
					where tblEDLP.[Cond Value] <0 and  tblEDLP.[Billed Qty] >0  -- and  tblFBL5Nnewthisperiod.[Document Type] = 'RV'

		end


		        begin -- update detail  kết vỏ thường
		            update tblFBL5Nnewthisperiod   
					set  tblFBL5Nnewthisperiod.Ketvothuong = (select sum(tblEDLP.[Billed Qty]) from tblEDLP where  tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  group by tblEDLP.[Invoice Doc Nr] ) 
	    
					from tblFBL5Nnewthisperiod,tblEDLP
					where tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  and  tblEDLP.UoM like 'CS' and tblEDLP.EmpyGroup =1
				end
	
 --select * from tblFBL5Nnewthisperiod
		
	     	begin -- update detail  CHAI vỏ thường
		            update tblFBL5Nnewthisperiod   
					set  tblFBL5Nnewthisperiod.Chaivothuong = (select sum(tblEDLP.[Billed Qty]) from tblEDLP where  tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  group by tblEDLP.[Invoice Doc Nr] ) 
	    
					from tblFBL5Nnewthisperiod,tblEDLP
					where tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  and  tblEDLP.UoM like 'EA' and tblEDLP.EmpyGroup =1
					end

			begin -- update detail  kết vỏ 1 LÍT
		            update tblFBL5Nnewthisperiod   
					set  tblFBL5Nnewthisperiod.Ketvolit = (select sum(tblEDLP.[Billed Qty]) from tblEDLP where  tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  group by tblEDLP.[Invoice Doc Nr] ) 
	    
					from tblFBL5Nnewthisperiod,tblEDLP
					where tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr] and   tblEDLP.UoM like 'CS'  and tblEDLP.EmpyGroup =2
end
		
		begin -- update detail  CHAI vỏ thường
		            update tblFBL5Nnewthisperiod   
					set  tblFBL5Nnewthisperiod.Chaivo1lit = (select sum(tblEDLP.[Billed Qty]) from tblEDLP where  tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  group by tblEDLP.[Invoice Doc Nr] ) 
	    
					from tblFBL5Nnewthisperiod,tblEDLP
					where tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  and  tblEDLP.UoM like 'EA' and tblEDLP.EmpyGroup =2
end

				begin -- update detail  kết nhua thuong
		            update tblFBL5Nnewthisperiod   
					set  tblFBL5Nnewthisperiod.Ketnhuathuong = (select sum(tblEDLP.[Billed Qty]) from tblEDLP where  tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  group by tblEDLP.[Invoice Doc Nr] ) 
	    
					from tblFBL5Nnewthisperiod,tblEDLP
					where tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]   and tblEDLP.EmpyGroup =3
end
		
		
				begin -- update detail  kết nhua 1 lit
		            update tblFBL5Nnewthisperiod   
					set  tblFBL5Nnewthisperiod.Ketnhua1lit = (select sum(tblEDLP.[Billed Qty]) from tblEDLP where  tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  group by tblEDLP.[Invoice Doc Nr] ) 
	    
					from tblFBL5Nnewthisperiod,tblEDLP
					where tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]   and tblEDLP.EmpyGroup =4
					end
			
				begin -- update detail joy20l
		            update tblFBL5Nnewthisperiod   
					set  tblFBL5Nnewthisperiod.joy20l = (select sum(tblEDLP.[Billed Qty]) from tblEDLP where  tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  group by tblEDLP.[Invoice Doc Nr] ) 
	    
					from tblFBL5Nnewthisperiod,tblEDLP
					where tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr] and tblEDLP.EmpyGroup =5
end

					begin -- update detail Binhpmicc02
		            update tblFBL5Nnewthisperiod   
					set  tblFBL5Nnewthisperiod.Binhpmicc02 = (select sum(tblEDLP.[Billed Qty]) from tblEDLP where  tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  group by tblEDLP.[Invoice Doc Nr] ) 
	    
					from tblFBL5Nnewthisperiod,tblEDLP
					where tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]   and tblEDLP.EmpyGroup =6
end

				
						begin -- update detail binhpmix9l
		            update tblFBL5Nnewthisperiod   
					set  tblFBL5Nnewthisperiod.binhpmix9l = (select sum(tblEDLP.[Billed Qty]) from tblEDLP where  tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  group by tblEDLP.[Invoice Doc Nr] ) 
	    
					from tblFBL5Nnewthisperiod,tblEDLP
					where tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  and tblEDLP.EmpyGroup =7
					end

				

						begin -- update detail palletgo
		            update tblFBL5Nnewthisperiod   
					set  tblFBL5Nnewthisperiod.palletgo = (select sum(tblEDLP.[Billed Qty]) from tblEDLP where  tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]  group by tblEDLP.[Invoice Doc Nr] ) 
	    
					from tblFBL5Nnewthisperiod,tblEDLP
					where tblFBL5Nnewthisperiod.[Document Number] = tblEDLP.[Invoice Doc Nr]   and tblEDLP.EmpyGroup =8
end


				end


GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[UpdateFbl5n]    Script Date: 16/12/2015 2:13:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[UpdateFbl5n]
( @name nvarchar(225) 
-- @Document_Number float
)

as

Begin


--DECLARE @Invoice_Registration nvarchar(225) 
--DECLARE @Invoice_Number nvarchar(225) 
--DECLARE @SoDelivery  nvarchar(225) 
--DECLARE @Assignment  nvarchar(225)
--DECLARE @Invoice_Amount  nvarchar(225)
--DECLARE @Remark nvarchar(225)
--DECLARE @Fullgood_amount float
--DECLARE @Empty_Amount float
--DECLARE @Payment_amount  float
--DECLARE  @Adjusted_amount float

-- lay du lieu ra
-- update tblFBL5Nnewthisperiod

       BEGIN
         UPDATE tblFBL5Nnewthisperiod 
         SET tblFBL5Nnewthisperiod.[userupdate]= @name,
		 tblFBL5Nnewthisperiod.[Deposit amount] =0,
		 tblFBL5Nnewthisperiod.[Empty Amount Notmach] =0;
       --  WHERE Emp_Code in (select top 2 Emp_Code from employee order by Emp_Code desc)
        END

		BEGIN
         update tblFBL5Nnewthisperiod 
		set  tblFBL5Nnewthisperiod.name = tblCustomer.[Name 1]
	    	
		from tblFBL5Nnewthisperiod,tblCustomer
		where tblFBL5Nnewthisperiod.Account = tblCustomer.Customer and  tblFBL5Nnewthisperiod.[Business Area] = tblCustomer.SOrg
		end


		 BEGIN
         UPDATE tblFBL5Nnewthisperiod 
         SET tblFBL5Nnewthisperiod.[Adjusted amount] = tblFBL5Nnewthisperiod.[Amount in local currency],
		-- tblFBL5Nnewthisperiod.[Fullgood amount] = tblFBL5Nnewthisperiod.[Amount in local currency],
                        tblFBL5Nnewthisperiod.Remark = tblFBL5Nnewthisperiod.Assignment
          WHERE tblFBL5Nnewthisperiod.[Document Type] = 'DG' OR  tblFBL5Nnewthisperiod.[Document Type] = 'DR' OR tblFBL5Nnewthisperiod.[Document Type] = 'DA' OR tblFBL5Nnewthisperiod.[Document Type] = 'AB' OR tblFBL5Nnewthisperiod.[Document Type] = 'SA'
         END


		 BEGIN
		   UPDATE tblFBL5Nnewthisperiod 
         SET tblFBL5Nnewthisperiod.[Payment amount] = tblFBL5Nnewthisperiod.[Amount in local currency],
	         --        tblFBL5Nnewthisperiod.[Adjusted amount] = tblFBL5Nnewthisperiod.[Amount in local currency],
                        tblFBL5Nnewthisperiod.Remark = tblFBL5Nnewthisperiod.Assignment
          WHERE tblFBL5Nnewthisperiod.[Document Type] = 'DZ' --OR  tblFBL5Nnewthisperiod.[Document Type] = 'DR' OR tblFBL5Nnewthisperiod.[Document Type] = 'DA' OR tblFBL5Nnewthisperiod.[Document Type] = 'AB' OR tblFBL5Nnewthisperiod.[Document Type] = 'SA'
         END

		  BEGIN
		   UPDATE tblFBL5Nnewthisperiod 
         SET 
		           tblFBL5Nnewthisperiod.[Fullgood amount] = tblFBL5Nnewthisperiod.[Invoice Amount],
                        tblFBL5Nnewthisperiod.Remark = tblFBL5Nnewthisperiod.Invoice
          WHERE tblFBL5Nnewthisperiod.[Document Type] = 'RV' --OR  tblFBL5Nnewthisperiod.[Document Type] = 'DR' OR tblFBL5Nnewthisperiod.[Document Type] = 'DA' OR tblFBL5Nnewthisperiod.[Document Type] = 'AB' OR tblFBL5Nnewthisperiod.[Document Type] = 'SA'
         END

end

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateFreglasessgroupREgion]    Script Date: 16/12/2015 2:13:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure  [dbo].[updateFreglasessgroupREgion]
as
begin
        begin 
		update tbl_FreGlass 
		set tbl_FreGlass.CUSTOMERgroupcode =  Rtrim(cast((convert(int,tbl_FreGlass.CUSTOMER)) as varchar(50)))   + right(tbl_FreGlass.SALORG,2)
	-- Rtrim(cast((convert(int,tblFBL5beginbalace.Account)) as varchar(50)))  + right(tblFBL5Nnew.[Business Area],2)-- tblFBL5Nnew.Account + Right(tblFBL5Nnew.[Business Area],2) 
		from tbl_FreGlass,tbl_CustomerGroup
		where tbl_FreGlass.CUSTOMER in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tbl_FreGlass.CUSTOMER <> tbl_CustomerGroup.Customercode

		end
		begin 
		update tbl_FreGlass 
		set tbl_FreGlass.CUSTOMERgroupcode = Rtrim(cast((convert(int,tbl_CustomerGroup.Customergropcode)) as varchar(50)))  + right(tbl_FreGlass.SALORG,2)
		
		from tbl_FreGlass,tbl_CustomerGroup
		where tbl_FreGlass.CUSTOMER in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tbl_FreGlass.CUSTOMER = tbl_CustomerGroup.Customercode

		end

		
end
	
GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateFreglasessgroupVN]    Script Date: 16/12/2015 2:14:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure  [dbo].[updateFreglasessgroupVN]
as
begin
        begin 
		update tbl_FreGlass 
		set tbl_FreGlass.CUSTOMERgroupcode = tbl_FreGlass.CUSTOMER
		--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
		from tbl_FreGlass,tbl_CustomerGroup
		where tbl_FreGlass.CUSTOMER in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tbl_FreGlass.CUSTOMER <> tbl_CustomerGroup.Customercode

		end
		begin 
		update tbl_FreGlass 
		set tbl_FreGlass.CUSTOMERgroupcode = tbl_CustomerGroup.Customergropcode
		--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
		from tbl_FreGlass,tbl_CustomerGroup
		where tbl_FreGlass.CUSTOMER in (select tblCustomer.Customer from tblCustomer where tblCustomer.Reportsend = 'True' )
			   and tbl_FreGlass.CUSTOMER = tbl_CustomerGroup.Customercode

		end

		
end
	

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updategroupprintletterChoice]    Script Date: 16/12/2015 2:14:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[updategroupprintletterChoice]
( @groupsending nvarchar(225) 
-- @Document_Number float
)

as

Begin


--DECLARE @Invoice_Registration nvarchar(225) 
--DECLARE @Invoice_Number nvarchar(225) 
--DECLARE @SoDelivery  nvarchar(225) 
--DECLARE @Assignment  nvarchar(225)
--DECLARE @Invoice_Amount  nvarchar(225)
--DECLARE @Remark nvarchar(225)
--DECLARE @Fullgood_amount float
--DECLARE @Empty_Amount float
--DECLARE @Payment_amount  float
--DECLARE  @Adjusted_amount float

-- lay du lieu ra
-- update tblFBL5Nnewthisperiod
        BEGIN
         UPDATE tbl_ARdetalheaderRpt 
         SET tbl_ARdetalheaderRpt.prt= 'false'
	
        END

		 BEGIN
         UPDATE tbl_ArletterdetailRpt 
         SET tbl_ArletterdetailRpt.prt= 'false'
	
        END
		 BEGIN
         UPDATE tbl_ArletterRpt 
         SET tbl_ArletterRpt.prt= 'false'
	
        END
		 BEGIN
         UPDATE tbl_ColdetailRpt 
         SET tbl_ColdetailRpt.prt= 'false'
	
        END



       BEGIN
         UPDATE tbl_ARdetalheaderRpt 
         SET tbl_ARdetalheaderRpt.prt= 'True'
		from tbl_ARdetalheaderRpt,tblCustomer
		where tbl_ARdetalheaderRpt.custcodeGRoup = tblCustomer.Cusromergroup and  tblCustomer.SendingGroup = @groupsending  
        END


		
       BEGIN
         UPDATE tbl_ArletterdetailRpt 
         SET tbl_ArletterdetailRpt.prt= 'True'
		from tbl_ArletterdetailRpt,tblCustomer
		where tbl_ArletterdetailRpt.customergroup = tblCustomer.Cusromergroup and  tblCustomer.SendingGroup = @groupsending  
        END

		
       BEGIN
         UPDATE tbl_ArletterRpt 
         SET tbl_ArletterRpt.prt= 'True'
		from tbl_ArletterRpt,tblCustomer
		where tbl_ArletterRpt.custcodegRoup = tblCustomer.Cusromergroup and  tblCustomer.SendingGroup = @groupsending  
        END


			
       BEGIN
         UPDATE tbl_ColdetailRpt 
         SET tbl_ColdetailRpt.prt= 'True'
		from tbl_ColdetailRpt,tblCustomer
		where tbl_ColdetailRpt.codeGroup = tblCustomer.Cusromergroup and  tblCustomer.SendingGroup = @groupsending  
        END


end

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updategroupprintletterChoiceALL]    Script Date: 16/12/2015 2:14:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[updategroupprintletterChoiceALL]
--( @groupsending nvarchar(225) 
-- @Document_Number float
--)

as

Begin


--DECLARE @Invoice_Registration nvarchar(225) 
--DECLARE @Invoice_Number nvarchar(225) 
--DECLARE @SoDelivery  nvarchar(225) 
--DECLARE @Assignment  nvarchar(225)
--DECLARE @Invoice_Amount  nvarchar(225)
--DECLARE @Remark nvarchar(225)
--DECLARE @Fullgood_amount float
--DECLARE @Empty_Amount float
--DECLARE @Payment_amount  float
--DECLARE  @Adjusted_amount float

-- lay du lieu ra
-- update tblFBL5Nnewthisperiod
        BEGIN
         UPDATE tbl_ARdetalheaderRpt 
         SET tbl_ARdetalheaderRpt.prt= 'True'
	
        END

		 BEGIN
         UPDATE tbl_ArletterdetailRpt 
         SET tbl_ArletterdetailRpt.prt= 'True'
	
        END
		 BEGIN
         UPDATE tbl_ArletterRpt 
         SET tbl_ArletterRpt.prt= 'True'
	
        END
		 BEGIN
         UPDATE tbl_ColdetailRpt 
         SET tbl_ColdetailRpt.prt= 'True'
	
        END


end

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updategroupprintletterfromcodetocodeChoice]    Script Date: 16/12/2015 2:14:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




create procedure [dbo].[updategroupprintletterfromcodetocodeChoice]
( @fromcode float,
  @tocode float
-- @Document_Number float
)

as

Begin


--DECLARE @Invoice_Registration nvarchar(225) 
--DECLARE @Invoice_Number nvarchar(225) 
--DECLARE @SoDelivery  nvarchar(225) 
--DECLARE @Assignment  nvarchar(225)
--DECLARE @Invoice_Amount  nvarchar(225)
--DECLARE @Remark nvarchar(225)
--DECLARE @Fullgood_amount float
--DECLARE @Empty_Amount float
--DECLARE @Payment_amount  float
--DECLARE  @Adjusted_amount float

-- lay du lieu ra
-- update tblFBL5Nnewthisperiod
        BEGIN
         UPDATE tbl_ARdetalheaderRpt 
         SET tbl_ARdetalheaderRpt.prt= 'false'
	
        END

		 BEGIN
         UPDATE tbl_ArletterdetailRpt 
         SET tbl_ArletterdetailRpt.prt= 'false'
	
        END
		 BEGIN
         UPDATE tbl_ArletterRpt 
         SET tbl_ArletterRpt.prt= 'false'
	
        END
		 BEGIN
         UPDATE tbl_ColdetailRpt 
         SET tbl_ColdetailRpt.prt= 'false'
	
        END



       BEGIN
         UPDATE tbl_ARdetalheaderRpt 
         SET tbl_ARdetalheaderRpt.prt= 'True'
		from tbl_ARdetalheaderRpt,tblCustomer
		where tbl_ARdetalheaderRpt.custcodeGRoup = tblCustomer.Cusromergroup and ( tblCustomer.Customer >= @fromcode   and  tblCustomer.Customer <= @tocode)
        END


		
       BEGIN
         UPDATE tbl_ArletterdetailRpt 
         SET tbl_ArletterdetailRpt.prt= 'True'
		from tbl_ArletterdetailRpt,tblCustomer
		where tbl_ArletterdetailRpt.customergroup = tblCustomer.Cusromergroup and  ( tblCustomer.Customer >= @fromcode   and  tblCustomer.Customer <= @tocode)
        END

		
       BEGIN
         UPDATE tbl_ArletterRpt 
         SET tbl_ArletterRpt.prt= 'True'
		from tbl_ArletterRpt,tblCustomer
		where tbl_ArletterRpt.custcodegRoup = tblCustomer.Cusromergroup and  ( tblCustomer.Customer >= @fromcode   and  tblCustomer.Customer <= @tocode)
        END


			
       BEGIN
         UPDATE tbl_ColdetailRpt 
         SET tbl_ColdetailRpt.prt= 'True'
		from tbl_ColdetailRpt,tblCustomer
		where tbl_ColdetailRpt.codeGroup = tblCustomer.Cusromergroup and  ( tblCustomer.Customer >= @fromcode   and  tblCustomer.Customer <= @tocode)
        END


end

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updategroupprintletterOnlycodeChoice]    Script Date: 16/12/2015 2:14:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




create procedure [dbo].[updategroupprintletterOnlycodeChoice]
( @onlycode float
-- @Document_Number float
)

as

Begin


--DECLARE @Invoice_Registration nvarchar(225) 
--DECLARE @Invoice_Number nvarchar(225) 
--DECLARE @SoDelivery  nvarchar(225) 
--DECLARE @Assignment  nvarchar(225)
--DECLARE @Invoice_Amount  nvarchar(225)
--DECLARE @Remark nvarchar(225)
--DECLARE @Fullgood_amount float
--DECLARE @Empty_Amount float
--DECLARE @Payment_amount  float
--DECLARE  @Adjusted_amount float

-- lay du lieu ra
-- update tblFBL5Nnewthisperiod
        BEGIN
         UPDATE tbl_ARdetalheaderRpt 
         SET tbl_ARdetalheaderRpt.prt= 'false'
	
        END

		 BEGIN
         UPDATE tbl_ArletterdetailRpt 
         SET tbl_ArletterdetailRpt.prt= 'false'
	
        END
		 BEGIN
         UPDATE tbl_ArletterRpt 
         SET tbl_ArletterRpt.prt= 'false'
	
        END
		 BEGIN
         UPDATE tbl_ColdetailRpt 
         SET tbl_ColdetailRpt.prt= 'false'
	
        END



       BEGIN
         UPDATE tbl_ARdetalheaderRpt 
         SET tbl_ARdetalheaderRpt.prt= 'True'
		from tbl_ARdetalheaderRpt,tblCustomer
		where tbl_ARdetalheaderRpt.custcodeGRoup = tblCustomer.Cusromergroup and  tblCustomer.Customer = @onlycode  
        END


		
       BEGIN
         UPDATE tbl_ArletterdetailRpt 
         SET tbl_ArletterdetailRpt.prt= 'True'
		from tbl_ArletterdetailRpt,tblCustomer
		where tbl_ArletterdetailRpt.customergroup = tblCustomer.Cusromergroup and  tblCustomer.Customer = @onlycode  
        END

		
       BEGIN
         UPDATE tbl_ArletterRpt 
         SET tbl_ArletterRpt.prt= 'True'
		from tbl_ArletterRpt,tblCustomer
		where tbl_ArletterRpt.custcodegRoup = tblCustomer.Cusromergroup and tblCustomer.Customer = @onlycode  
        END


			
       BEGIN
         UPDATE tbl_ColdetailRpt 
         SET tbl_ColdetailRpt.prt= 'True'
		from tbl_ColdetailRpt,tblCustomer
		where tbl_ColdetailRpt.codeGroup = tblCustomer.Cusromergroup and tblCustomer.Customer = @onlycode  
        END


end

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updatelistGruopsendingCustomer]    Script Date: 16/12/2015 2:15:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[updatelistGruopsendingCustomer]
as

begin
        begin
		update tblCustomer 
		set tblCustomer.SendingGroup = ''
		where tblCustomer.SendingGroup in (select tblCustomerTmp.SendingGroup from tblCustomerTmp)
	--	from tblCustomerTmp
		end


		begin
		update tblCustomer 
		set tblCustomer.SendingGroup = tblCustomerTmp.SendingGroup
		--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
		from tblCustomerTmp,tblCustomer
		where tblCustomerTmp.Customer = tblCustomer.Customer --and tblVat.Region = tblCustomer.SOrg
		end
	

end
GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateRemarktoFBL5N]    Script Date: 16/12/2015 2:15:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

	
create procedure  [dbo].[updateRemarktoFBL5N]
as

begin

update tblFBL5N 
set tblFBL5N.Assignment = tbl_Remark.Remark
--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
from tblFBL5N,tbl_Remark
where tblFBL5N.[Document Number] = tbl_Remark.DocumentNo
end
	

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[UpdateRerionintoVATouFromFBL5n]    Script Date: 16/12/2015 2:15:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create procedure  [dbo].[UpdateRerionintoVATouFromFBL5n]
as
begin


update tblVat 
set tblVat.Region = tblFBL5N.[Business Area]

from tblVat,tblFBL5N
where tblVat.[SAP Invoice Number] = tblFBL5N.[Document Number] -- and  tblCustomer.SOrg = tbl_Unsendlist.Sorg
end
	

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updatetblFBL5NnewthisperiodFromOM]    Script Date: 16/12/2015 2:15:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure  [dbo].[updatetblFBL5NnewthisperiodFromOM]
as
begin


update tblFBL5Nnewthisperiod 
set tblFBL5Nnewthisperiod.name = tblCustomer.[Name 1]
--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
from tblFBL5Nnewthisperiod,tblCustomer
where tblFBL5Nnewthisperiod.Account = tblCustomer.Customer and tblFBL5Nnewthisperiod.[Business Area] = tblCustomer.SOrg
end
	

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updatetblFBL5NTempRPtview]    Script Date: 16/12/2015 2:15:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure  [dbo].[updatetblFBL5NTempRPtview]
as
begin

		begin

		delete from tblFBL5NTempRPtview 
		end

		begin

		insert into tblFBL5NTempRPtview (tblFBL5NTempRPtview.[Business Area],.Account,tblFBL5NTempRPtview.[Adjusted amount],tblFBL5NTempRPtview.[Amount in local currency],tblFBL5NTempRPtview.Binhpmicc02,tblFBL5NTempRPtview.binhpmix9l,tblFBL5NTempRPtview.Chaivo1lit,tblFBL5NTempRPtview.Chaivothuong,tblFBL5NTempRPtview.[Deposit amount],tblFBL5NTempRPtview.[Empty Amount],tblFBL5NTempRPtview.[Fullgood amount],tblFBL5NTempRPtview.[Invoice Amount],tblFBL5NTempRPtview.joy20l,tblFBL5NTempRPtview.Ketnhua1lit,tblFBL5NTempRPtview.Ketnhuathuong,tblFBL5NTempRPtview.Ketvolit,tblFBL5NTempRPtview.Ketvothuong,tblFBL5NTempRPtview.paletnhua,tblFBL5NTempRPtview.palletgo,tblFBL5NTempRPtview.[Payment amount])
		select tblFBL5Nnew.[Business Area],tblFBL5Nnew.Account,sum(tblFBL5Nnew.[Adjusted amount]),sum(tblFBL5Nnew.[Amount in local currency]),sum(tblFBL5Nnew.Binhpmicc02),sum(tblFBL5Nnew.binhpmix9l),sum(tblFBL5Nnew.Chaivo1lit),sum(tblFBL5Nnew.Chaivothuong),sum(tblFBL5Nnew.[Deposit amount]),sum(tblFBL5Nnew.[Empty Amount]),sum(tblFBL5Nnew.[Fullgood amount]),sum(tblFBL5Nnew.[Invoice Amount]),sum(tblFBL5Nnew.joy20l),sum(tblFBL5Nnew.Ketnhua1lit),sum(tblFBL5Nnew.Ketnhuathuong),sum(tblFBL5Nnew.Ketvolit),sum(tblFBL5Nnew.Ketvothuong),sum(tblFBL5Nnew.paletnhua),sum(tblFBL5Nnew.palletgo),sum(tblFBL5Nnew.[Payment amount]) from tblFBL5Nnew
		group by tblFBL5Nnew.Account, tblFBL5Nnew.[Business Area]

			end
end

GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateVATout]    Script Date: 16/12/2015 2:15:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure  [dbo].[updateVATout]
as
begin
       
       
		begin
        update tblFBL5Nnewthisperiod 
		set  tblFBL5Nnewthisperiod.name = tblVat.[Customer Name],
	    	 tblFBL5Nnewthisperiod.Invoice = tblVat.[Invoice Registration Number]+ ' ' + tblVat.[Invoice Number],
		--   tblFBL5Nnewthisperiod.Assignment = cast((convert(int,tblVat.[SAP Delivery Number])) as varchar(50)),
	    	 tblFBL5Nnewthisperiod.[Formula invoice date] = tblVat.[Pro Forma Date],
	    	 tblFBL5Nnewthisperiod.SoDelivery = cast((convert(int,tblVat.[SAP Delivery Number])) as varchar(50)),
		   --  tblFBL5Nnewthisperiod.Assignment = tblVat.[Invoice Registration Number] +' ' + tblVat.[Invoice Number],
		    tblFBL5Nnewthisperiod.[Invoice Amount] = tblVat.[Invoice Amount Before VAT] + tblVat.[VAT Amount],
			tblFBL5Nnewthisperiod.[Fullgood amount] =  tblVat.[Invoice Amount Before VAT] + tblVat.[VAT Amount],
			tblFBL5Nnewthisperiod.[COL value] = tblFBL5Nnewthisperiod.[Amount in local currency] - tblVat.[Invoice Amount Before VAT] - tblVat.[VAT Amount],
			tblFBL5Nnewthisperiod.Remark = tblVat.[Invoice Registration Number] +' ' + tblVat.[Invoice Number]

		from tblFBL5Nnewthisperiod,tblVat
		where tblFBL5Nnewthisperiod.[Document Number] = tblVat.[SAP Invoice Number]-- and  tblFBL5Nnewthisperiod.[Document Type] = 'RV'
		end
		
		begin
        update tblFBL5Nnewthisperiod 
	      set -- tblFBL5Nnewthisperiod.Assignment = cast((convert(int,tblVat.[SAP Delivery Number])) as varchar(50)),
		       tblFBL5Nnewthisperiod.Remark = cast((convert(int,tblVat.[SAP Delivery Number])) as varchar(50)), 
		--	     tblFBL5Nnewthisperiod.Assignment = cast((convert(int,tblVat.[SAP Delivery Number])) as varchar(50)),
			   tblFBL5Nnewthisperiod.[Fullgood amount] =0
	      from tblFBL5Nnewthisperiod,tblVat
		where tblFBL5Nnewthisperiod.[Document Number] = tblVat.[SAP Invoice Number]  and tblVat.[Invoice Amount Before VAT] = 0 and tblVat.[Invoice Amount Before VAT] <> tblFBL5Nnewthisperiod.[Amount in local currency] -- and  tblFBL5Nnewthisperiod.[Document Type] = 'RV'
		end



end


GO

USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[updateVATstatinmaster]    Script Date: 16/12/2015 2:15:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

	
CREATE procedure [dbo].[updateVATstatinmaster]
as

begin
        begin
		update tblVat 
		set tblVat.Statuscheck = 1
		--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
		from tblVat
		end


		begin
		update tblVat 
		set tblVat.Statuscheck = 0
		--select tblFBL5N.Account,tblFBL5N.[Amount in local currency],tblFBL5N.Assignment,tblFBL5N.[Business Area],tblFBL5N.[Document Number],tblFBL5N.[Document Type],tblFBL5N.[Posting Date] 
		from tblVat,tblCustomer
		where tblVat.[Customer Number] = tblCustomer.Customer and tblVat.Region = tblCustomer.SOrg
		end
	

end
GO





USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[KAupdateSalePC_UCtemptable]    Script Date: 1/9/2016 8:08:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[KAupdateSalePC_UCtemptable]
( @priod nvarchar(10) 
-- @Document_Number float
)

as

Begin


--DECLARE @Invoice_Registration nvarchar(225) 
--DECLARE @Invoice_Number nvarchar(225) 
--DECLARE @SoDelivery  nvarchar(225) 
--DECLARE @Assignment  nvarchar(225)


       BEGIN
         UPDATE tbl_kasalesTemp 
         SET tbl_kasalesTemp.Priod= @priod,
		 tbl_kasalesTemp.UC = tbl_kasalesTemp.[Billed Qty]*tbl_Productlist.Ucrate,
		tbl_kasalesTemp.pc = tbl_kasalesTemp.[Billed Qty]*tbl_Productlist.Pcrate

		from tbl_kasalesTemp,tbl_Productlist
		where tbl_kasalesTemp.[Mat Number] = tbl_Productlist.MatNumber
		
		 END

	


end


GO


USE [KAmanagement]
GO

/****** Object:  StoredProcedure [dbo].[insertFbl5nthisfromFBL5n]    Script Date: 09/01/2016 5:09:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure  KAuploadtoSaledata
as

begin

insert into tbl_kasales(tbl_kasales.[Billed Qty],tbl_kasales.[Cond Type],tbl_kasales.[Cond Type desc],tbl_kasales.[Cond Value],tbl_kasales.Currency,tbl_kasales.[Cust Name],tbl_kasales.[Delivery Date],tbl_kasales.[Invoice Doc Nr],tbl_kasales.[Key Acc Nr],tbl_kasales.[Mat Group],tbl_kasales.[Mat Group Text],tbl_kasales.[Mat Number],tbl_kasales.[Mat Text],tbl_kasales.[Net value],tbl_kasales.[Outbound Delivery],tbl_kasales.PC,tbl_kasales.Priod,tbl_kasales.[Sales District],tbl_kasales.[Sales District desc],tbl_kasales.[Sales Group],tbl_kasales.[Sales Group desc],tbl_kasales.[Sales Off],tbl_kasales.[Sales Office Desc],tbl_kasales.[Sales Org],tbl_kasales.[Sold-to],tbl_kasales.UC,tbl_kasales.UoM,tbl_kasales.Username)
select tbl_kasalesTemp.[Billed Qty],tbl_kasalesTemp.[Cond Type],tbl_kasalesTemp.[Cond Type desc],tbl_kasalesTemp.[Cond Value],tbl_kasalesTemp.Currency,tbl_kasalesTemp.[Cust Name],tbl_kasalesTemp.[Delivery Date],tbl_kasalesTemp.[Invoice Doc Nr],tbl_kasalesTemp.[Key Acc Nr],tbl_kasalesTemp.[Mat Group],tbl_kasalesTemp.[Mat Group Text],tbl_kasalesTemp.[Mat Number],tbl_kasalesTemp.[Mat Text],tbl_kasalesTemp.[Net value],tbl_kasalesTemp.[Outbound Delivery],tbl_kasalesTemp.PC,tbl_kasalesTemp.Priod,tbl_kasalesTemp.[Sales District],tbl_kasalesTemp.[Sales District desc],tbl_kasalesTemp.[Sales Group],tbl_kasalesTemp.[Sales Group desc],tbl_kasalesTemp.[Sales Off],tbl_kasalesTemp.[Sales Office Desc],tbl_kasalesTemp.[Sales Org],tbl_kasalesTemp.[Sold-to],tbl_kasalesTemp.UC,tbl_kasalesTemp.UoM,tbl_kasalesTemp.Username from tbl_kasalesTemp

end

GO







