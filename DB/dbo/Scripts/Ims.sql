

/****** Object:  Database [IMS6]    Script Date: 27-06-2022 22:30:13 ******/
CREATE DATABASE [IMS6]
 CONTAINMENT = NONE
 
ALTER DATABASE [IMS6] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IMS6].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IMS6] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IMS6] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IMS6] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IMS6] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IMS6] SET ARITHABORT OFF 
GO
ALTER DATABASE [IMS6] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [IMS6] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IMS6] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IMS6] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IMS6] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IMS6] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IMS6] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IMS6] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IMS6] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IMS6] SET  ENABLE_BROKER 
GO
ALTER DATABASE [IMS6] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IMS6] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IMS6] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IMS6] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IMS6] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IMS6] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IMS6] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IMS6] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IMS6] SET  MULTI_USER 
GO
ALTER DATABASE [IMS6] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IMS6] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IMS6] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IMS6] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IMS6] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IMS6] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [IMS6] SET QUERY_STORE = OFF
GO
USE [IMS6]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[Address1] [varchar](300) NULL,
	[Address2] [varchar](300) NULL,
	[State] [varchar](60) NULL,
	[City] [varchar](60) NULL,
	[Pincode] [varchar](10) NULL,
	[Phone] [varchar](15) NULL,
	[Email] [varchar](255) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
 CONSTRAINT [PK__Addresse__091C2AFB2AC3B7AE] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[WorkerId] [int] NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](10) NULL,
	[Name] [varchar](60) NULL,
	[Description] [varchar](max) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK__Category__19093A0B618BEDF1] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consumption]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consumption](
	[ConsumptionId] [int] IDENTITY(1,1) NOT NULL,
	[ConsumptionNo] [varchar](10) NULL,
	[ConsumptionDate] [datetime2](0) NULL,
	[WarehouseId] [int] NULL,
	[WorkerId] [int] NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK__Consumpt__E3A1C41760A10348] PRIMARY KEY CLUSTERED 
(
	[ConsumptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsumptionItems]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsumptionItems](
	[ConsumptionItemsId] [int] IDENTITY(1,1) NOT NULL,
	[LineNo] [smallint] NULL,
	[ItemId] [int] NULL,
	[UnitId] [int] NULL,
	[Quantity] [float] NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[ConsumptionId] [int] NULL,
 CONSTRAINT [PK__Consumpt__7E427DCF82DC8827] PRIMARY KEY CLUSTERED 
(
	[ConsumptionItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryAdjustment]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryAdjustment](
	[InventoryAdjustmentId] [int] IDENTITY(1,1) NOT NULL,
	[InventoryAdjustmentNo] [varchar](10) NULL,
	[AdjustmentDate] [datetime2](0) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
	[OrganizationId] [int] NULL,
	[WarehouseId] [int] NOT NULL,
	[WorkerId] [int] NOT NULL,
 CONSTRAINT [PK__Inventor__E7407FFC25FBB5A0] PRIMARY KEY CLUSTERED 
(
	[InventoryAdjustmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryAdjustmentItems]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryAdjustmentItems](
	[InventoryAdjustmentItemsId] [int] IDENTITY(1,1) NOT NULL,
	[LineNo] [smallint] NULL,
	[ItemId] [int] NULL,
	[WarehouseId] [int] NULL,
	[WorkerId] [int] NULL,
	[Quantity] [float] NULL,
	[ReasonCode] [tinyint] NULL,
	[Reason] [varchar](60) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[InventoryAdjustmentId] [int] NULL,
 CONSTRAINT [PK__Inventor__75C6156F052262ED] PRIMARY KEY CLUSTERED 
(
	[InventoryAdjustmentItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [varchar](10) NULL,
	[PurchaseOrderId] [int] NULL,
	[VendorId] [int] NULL,
	[NetAmount] [float] NULL,
	[InvoiceStatus] [smallint] NULL,
	[InvoiceDate] [datetime2](0) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK__Invoice__D796AAB55C0DBBBE] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceItems]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceItems](
	[InvoiceItemsId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[LineNo] [smallint] NULL,
	[ItemId] [int] NULL,
	[WarehouseId] [int] NULL,
	[Quantity] [float] NULL,
	[ReceivedQuantity] [float] NULL,
	[UnitId] [int] NULL,
	[UnitPrice] [float] NULL,
	[NetAmount] [float] NULL,
	[BatchNo] [varchar](10) NULL,
	[InvoiceNo] [varchar](10) NULL,
	[InvoiceDate] [datetime2](0) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[PurchaseOrderItemsId] [int] NOT NULL,
 CONSTRAINT [PK__InvoiceI__29E41A69899F7204] PRIMARY KEY CLUSTERED 
(
	[InvoiceItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemCategory]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCategory](
	[ItemCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[Status] [smallint] NOT NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK__ItemCate__C24A29255944101A] PRIMARY KEY CLUSTERED 
(
	[ItemCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemCategoryCollection]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCategoryCollection](
	[ItemCategoryCollectionId] [int] IDENTITY(1,1) NOT NULL,
	[ItemCategoryId] [int] NULL,
	[CategoryId] [int] NULL,
	[ItemId] [int] NULL,
 CONSTRAINT [PK__ItemCate__1935D91C7C9431A8] PRIMARY KEY CLUSTERED 
(
	[ItemCategoryCollectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](10) NULL,
	[ItemNo] [varchar](20) NULL,
	[Name] [varchar](60) NULL,
	[Description] [varchar](max) NULL,
	[PurchaseUnitId] [int] NULL,
	[InventoryUnitId] [int] NULL,
	[MinStock] [float] NULL,
	[MaxStock] [float] NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
	[SourceOfOrigin] [int] NULL,
	[OrganizationId] [int] NULL,
	[ItemTypeId] [int] NULL,
 CONSTRAINT [PK__Items__727E838B4386E4BD] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemTypes]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemTypes](
	[ItemTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](60) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK_ItemTypes] PRIMARY KEY CLUSTERED 
(
	[ItemTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lookups]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[PermissionName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Lookups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[OrganizationId] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](10) NULL,
	[Name] [varchar](20) NULL,
	[Description] [varchar](60) NULL,
	[PurchaseOrderPrefix] [varchar](15) NULL,
	[ReturnOrderPrefix] [varchar](15) NULL,
	[InventoryAdjustmentPrefix] [varchar](15) NULL,
	[ItemConsumptionPrefix] [varchar](15) NULL,
	[TransactionalWarehouseId] [int] NULL,
	[TaxRegistrationNumber] [varchar](60) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
 CONSTRAINT [PK__Organiza__CADB0B12F30104D5] PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationAddress]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationAddress](
	[OrganizationAddressId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [int] NULL,
	[AddressId] [int] NULL,
 CONSTRAINT [PK__Organiza__4386CABBC0F0B5DD] PRIMARY KEY CLUSTERED 
(
	[OrganizationAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionEntities]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[PermissionName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PermissionEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionEntityLookUps]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionEntityLookUps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PermissionEntityId] [int] NOT NULL,
	[LookupId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PermissionEntityLookUps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[PurchaseOrderId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderNo] [varchar](10) NULL,
	[VendorId] [int] NULL,
	[NetAmount] [float] NULL,
	[OrderStatus] [smallint] NULL,
	[OrderDate] [datetime2](0) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK__Purchase__036BACA4F0C6FCF7] PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrderItems]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrderItems](
	[PurchaseOrderItemsId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderId] [int] NOT NULL,
	[LineNo] [smallint] NULL,
	[ItemId] [int] NULL,
	[WarehouseId] [int] NULL,
	[Quantity] [float] NULL,
	[UnitId] [int] NULL,
	[UnitPrice] [float] NULL,
	[NetAmount] [float] NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
 CONSTRAINT [PK__Purchase__C4E0F5CCD4FBC3FA] PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseReceive]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseReceive](
	[PurchaseReceiveId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseReceiveNo] [varchar](10) NULL,
	[PurchaseOrderId] [int] NULL,
	[VendorId] [int] NULL,
	[NetAmount] [float] NULL,
	[PurchaseReceiveStatus] [smallint] NULL,
	[PurchaseReceiveDate] [datetime2](0) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK__Purchase__2C33C6E8498F0EB3] PRIMARY KEY CLUSTERED 
(
	[PurchaseReceiveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseReceiveItems]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseReceiveItems](
	[PurchaseReceiveItemsId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseReceiveId] [int] NOT NULL,
	[LineNo] [smallint] NULL,
	[ItemId] [int] NULL,
	[WarehouseId] [int] NULL,
	[Quantity] [float] NULL,
	[ReceiveQuantity] [float] NULL,
	[UnitId] [int] NULL,
	[UnitPrice] [float] NULL,
	[NetAmount] [float] NULL,
	[BatchNo] [varchar](10) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[PurchaseOrderItemsId] [int] NOT NULL,
 CONSTRAINT [PK__Purchase__0AD1898BA1F05BF4] PRIMARY KEY CLUSTERED 
(
	[PurchaseReceiveItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role_PermissionEntityLookUps]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role_PermissionEntityLookUps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PermissionEntityLookUpId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Role_PermissionEntityLookUps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
	[WarehouseId] [int] NULL,
	[WorkerId] [int] NULL,
	[Quantity] [float] NULL,
	[OnHandQuantity] [float] NULL,
	[TransactionId] [int] NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
 CONSTRAINT [PK__Stock__2C83A9C228C8DF0B] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [varchar](20) NULL,
	[Type] [smallint] NULL,
	[RelationId] [int] NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK__Transact__3214EC07AFA9060F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionType]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionType](
	[Id] [smallint] NOT NULL,
	[Name] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](60) NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK__Uom__3214EC074140BB3F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UomConversion]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UomConversion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NULL,
	[Description] [varchar](60) NULL,
	[FromUnitId] [int] NULL,
	[ToUnitId] [int] NULL,
	[Ratio] [float] NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK__UomConve__3214EC076F54833D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOrganizations]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOrganizations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserOrganizations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[VendorId] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](10) NULL,
	[Name] [varchar](60) NULL,
	[AccountNumber] [varchar](10) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
	[OrganizationId] [int] NULL,
 CONSTRAINT [PK__Vendor__FC8618F3920C99BF] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorAddress]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorAddress](
	[VendorAddressId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NULL,
	[AddressId] [int] NULL,
 CONSTRAINT [PK__VendorAd__801868DEA3BC8E06] PRIMARY KEY CLUSTERED 
(
	[VendorAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[WarehouseId] [int] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](10) NULL,
	[Name] [varchar](20) NULL,
	[OrganizationId] [int] NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
 CONSTRAINT [PK__Warehous__2608AFF90AB5721A] PRIMARY KEY CLUSTERED 
(
	[WarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WarehouseAddress]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseAddress](
	[WarehouseAddressId] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NULL,
	[AddressId] [int] NULL,
 CONSTRAINT [PK__Warehous__275276B6409AE71F] PRIMARY KEY CLUSTERED 
(
	[WarehouseAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[WorkerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](60) NULL,
	[PersonnelNumber] [varchar](15) NULL,
	[DOJ] [datetime2](0) NULL,
	[DOB] [datetime2](0) NULL,
	[UserId] [varchar](20) NULL,
	[Password] [varchar](20) NULL,
	[UpdatedUserId] [int] NULL,
	[UpdatedDateTime] [datetime2](0) NULL,
	[Status] [smallint] NOT NULL,
	[IsBlocked] [bit] NULL,
 CONSTRAINT [PK__Worker__077C8826EBBA4D00] PRIMARY KEY CLUSTERED 
(
	[WorkerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkerAddress]    Script Date: 27-06-2022 22:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerAddress](
	[WorkerAddressId] [int] IDENTITY(1,1) NOT NULL,
	[WorkerId] [int] NULL,
	[AddressId] [int] NULL,
 CONSTRAINT [PK__WorkerAd__D051F16BED494771] PRIMARY KEY CLUSTERED 
(
	[WorkerAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF__Addresses__Addre__5629CD9C]  DEFAULT (NULL) FOR [Address1]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF__Addresses__Addre__571DF1D5]  DEFAULT (NULL) FOR [Address2]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF__Addresses__State__5812160E]  DEFAULT (NULL) FOR [State]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF__Addresses__City__59063A47]  DEFAULT (NULL) FOR [City]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF__Addresses__Pinco__59FA5E80]  DEFAULT (NULL) FOR [Pincode]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF__Addresses__Phone__5AEE82B9]  DEFAULT (NULL) FOR [Phone]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF__Addresses__Email__5BE2A6F2]  DEFAULT (NULL) FOR [Email]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF__Addresses__Updat__5CD6CB2B]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF__Addresses__Updat__5DCAEF64]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF__Category__Id__5EBF139D]  DEFAULT (NULL) FOR [Id]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF__Category__Name__5FB337D6]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF__Category__Descri__60A75C0F]  DEFAULT (NULL) FOR [Description]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF__Category__Update__619B8048]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF__Category__Update__628FA481]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[Consumption] ADD  CONSTRAINT [DF__Consumpti__Consu__6383C8BA]  DEFAULT (NULL) FOR [ConsumptionNo]
GO
ALTER TABLE [dbo].[Consumption] ADD  CONSTRAINT [DF__Consumpti__Consu__6477ECF3]  DEFAULT (NULL) FOR [ConsumptionDate]
GO
ALTER TABLE [dbo].[Consumption] ADD  CONSTRAINT [DF__Consumpti__Wareh__656C112C]  DEFAULT (NULL) FOR [WarehouseId]
GO
ALTER TABLE [dbo].[Consumption] ADD  CONSTRAINT [DF__Consumpti__Worke__66603565]  DEFAULT (NULL) FOR [WorkerId]
GO
ALTER TABLE [dbo].[Consumption] ADD  CONSTRAINT [DF__Consumpti__Updat__6754599E]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[Consumption] ADD  CONSTRAINT [DF__Consumpti__Updat__68487DD7]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[ConsumptionItems] ADD  CONSTRAINT [DF__Consumpti__LineN__693CA210]  DEFAULT (NULL) FOR [LineNo]
GO
ALTER TABLE [dbo].[ConsumptionItems] ADD  CONSTRAINT [DF__Consumpti__ItemI__6A30C649]  DEFAULT (NULL) FOR [ItemId]
GO
ALTER TABLE [dbo].[ConsumptionItems] ADD  CONSTRAINT [DF__Consumpti__UnitI__6B24EA82]  DEFAULT (NULL) FOR [UnitId]
GO
ALTER TABLE [dbo].[ConsumptionItems] ADD  CONSTRAINT [DF__Consumpti__Quant__6C190EBB]  DEFAULT (NULL) FOR [Quantity]
GO
ALTER TABLE [dbo].[ConsumptionItems] ADD  CONSTRAINT [DF__Consumpti__Updat__6D0D32F4]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[ConsumptionItems] ADD  CONSTRAINT [DF__Consumpti__Updat__6E01572D]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[ConsumptionItems] ADD  CONSTRAINT [DF__Consumpti__Consu__6EF57B66]  DEFAULT (NULL) FOR [ConsumptionId]
GO
ALTER TABLE [dbo].[InventoryAdjustment] ADD  CONSTRAINT [DF__Inventory__Inven__6FE99F9F]  DEFAULT (NULL) FOR [InventoryAdjustmentNo]
GO
ALTER TABLE [dbo].[InventoryAdjustment] ADD  CONSTRAINT [DF__Inventory__Adjus__70DDC3D8]  DEFAULT (NULL) FOR [AdjustmentDate]
GO
ALTER TABLE [dbo].[InventoryAdjustment] ADD  CONSTRAINT [DF__Inventory__Updat__71D1E811]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[InventoryAdjustment] ADD  CONSTRAINT [DF__Inventory__Updat__72C60C4A]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[InventoryAdjustment] ADD  DEFAULT ((0)) FOR [WarehouseId]
GO
ALTER TABLE [dbo].[InventoryAdjustment] ADD  DEFAULT ((0)) FOR [WorkerId]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] ADD  CONSTRAINT [DF__Inventory__LineN__73BA3083]  DEFAULT (NULL) FOR [LineNo]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] ADD  CONSTRAINT [DF__Inventory__ItemI__74AE54BC]  DEFAULT (NULL) FOR [ItemId]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] ADD  CONSTRAINT [DF__Inventory__Wareh__75A278F5]  DEFAULT (NULL) FOR [WarehouseId]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] ADD  CONSTRAINT [DF__Inventory__Worke__76969D2E]  DEFAULT (NULL) FOR [WorkerId]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] ADD  CONSTRAINT [DF__Inventory__Quant__778AC167]  DEFAULT (NULL) FOR [Quantity]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] ADD  CONSTRAINT [DF__Inventory__Reaso__787EE5A0]  DEFAULT (NULL) FOR [Reason]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] ADD  CONSTRAINT [DF__Inventory__Updat__797309D9]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] ADD  CONSTRAINT [DF__Inventory__Updat__7A672E12]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] ADD  CONSTRAINT [DF__Inventory__Inven__7B5B524B]  DEFAULT (NULL) FOR [InventoryAdjustmentId]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF__Invoice__Invoice__7C4F7684]  DEFAULT (NULL) FOR [InvoiceNo]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF__Invoice__Purchas__7D439ABD]  DEFAULT (NULL) FOR [PurchaseOrderId]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF__Invoice__VendorI__7E37BEF6]  DEFAULT (NULL) FOR [VendorId]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF__Invoice__NetAmou__7F2BE32F]  DEFAULT (NULL) FOR [NetAmount]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF__Invoice__Invoice__00200768]  DEFAULT (NULL) FOR [InvoiceStatus]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF__Invoice__Invoice__01142BA1]  DEFAULT (NULL) FOR [InvoiceDate]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF__Invoice__Updated__02084FDA]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF__Invoice__Updated__02FC7413]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__LineN__03F0984C]  DEFAULT (NULL) FOR [LineNo]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__ItemI__04E4BC85]  DEFAULT (NULL) FOR [ItemId]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__Wareh__05D8E0BE]  DEFAULT (NULL) FOR [WarehouseId]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__Quant__06CD04F7]  DEFAULT (NULL) FOR [Quantity]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__Recei__07C12930]  DEFAULT (NULL) FOR [ReceivedQuantity]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__UnitI__08B54D69]  DEFAULT (NULL) FOR [UnitId]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__UnitP__09A971A2]  DEFAULT (NULL) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__NetAm__0A9D95DB]  DEFAULT (NULL) FOR [NetAmount]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__Batch__0B91BA14]  DEFAULT (NULL) FOR [BatchNo]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__Invoi__0C85DE4D]  DEFAULT (NULL) FOR [InvoiceNo]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__Invoi__0D7A0286]  DEFAULT (NULL) FOR [InvoiceDate]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__Updat__0E6E26BF]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  CONSTRAINT [DF__InvoiceIt__Updat__0F624AF8]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[InvoiceItems] ADD  DEFAULT ((0)) FOR [PurchaseOrderItemsId]
GO
ALTER TABLE [dbo].[ItemCategory] ADD  CONSTRAINT [DF_ItemCategory_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF__Items__Id__151B244E]  DEFAULT (NULL) FOR [Id]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF__Items__ItemNo__160F4887]  DEFAULT (NULL) FOR [ItemNo]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF__Items__Name__17036CC0]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF__Items__Descripti__17F790F9]  DEFAULT (NULL) FOR [Description]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF__Items__PurchaseU__18EBB532]  DEFAULT (NULL) FOR [PurchaseUnitId]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF__Items__Inventory__19DFD96B]  DEFAULT (NULL) FOR [InventoryUnitId]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF__Items__MinStock__1AD3FDA4]  DEFAULT (NULL) FOR [MinStock]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF__Items__MaxStock__1BC821DD]  DEFAULT (NULL) FOR [MaxStock]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF__Items__UpdatedUs__1CBC4616]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF__Items__UpdatedDa__1DB06A4F]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF__Organization__Id__1EA48E88]  DEFAULT (NULL) FOR [Id]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF__Organizati__Name__1F98B2C1]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF__Organizat__Descr__208CD6FA]  DEFAULT (NULL) FOR [Description]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF__Organizat__Purch__2180FB33]  DEFAULT (NULL) FOR [PurchaseOrderPrefix]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF__Organizat__Retur__22751F6C]  DEFAULT (NULL) FOR [ReturnOrderPrefix]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF__Organizat__Inven__236943A5]  DEFAULT (NULL) FOR [InventoryAdjustmentPrefix]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF__Organizat__ItemC__245D67DE]  DEFAULT (NULL) FOR [ItemConsumptionPrefix]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF__Organizat__Trans__25518C17]  DEFAULT ((0)) FOR [TransactionalWarehouseId]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF__Organizat__TaxRe__2645B050]  DEFAULT (NULL) FOR [TaxRegistrationNumber]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF__Organizat__Updat__2739D489]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF__Organizat__Updat__282DF8C2]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[OrganizationAddress] ADD  CONSTRAINT [DF__Organizat__Organ__29221CFB]  DEFAULT (NULL) FOR [OrganizationId]
GO
ALTER TABLE [dbo].[OrganizationAddress] ADD  CONSTRAINT [DF__Organizat__Addre__2A164134]  DEFAULT (NULL) FOR [AddressId]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF__PurchaseO__Purch__3B40CD36]  DEFAULT (NULL) FOR [PurchaseOrderNo]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF__PurchaseO__Vendo__3C34F16F]  DEFAULT (NULL) FOR [VendorId]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF__PurchaseO__NetAm__3D2915A8]  DEFAULT (NULL) FOR [NetAmount]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF__PurchaseO__Order__3E1D39E1]  DEFAULT (NULL) FOR [OrderStatus]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF__PurchaseO__Order__3F115E1A]  DEFAULT (NULL) FOR [OrderDate]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF__PurchaseO__Updat__40058253]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF__PurchaseO__Updat__40F9A68C]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[PurchaseOrderItems] ADD  CONSTRAINT [DF__PurchaseO__LineN__41EDCAC5]  DEFAULT (NULL) FOR [LineNo]
GO
ALTER TABLE [dbo].[PurchaseOrderItems] ADD  CONSTRAINT [DF__PurchaseO__ItemI__42E1EEFE]  DEFAULT (NULL) FOR [ItemId]
GO
ALTER TABLE [dbo].[PurchaseOrderItems] ADD  CONSTRAINT [DF__PurchaseO__Wareh__43D61337]  DEFAULT (NULL) FOR [WarehouseId]
GO
ALTER TABLE [dbo].[PurchaseOrderItems] ADD  CONSTRAINT [DF__PurchaseO__Quant__44CA3770]  DEFAULT (NULL) FOR [Quantity]
GO
ALTER TABLE [dbo].[PurchaseOrderItems] ADD  CONSTRAINT [DF__PurchaseO__UnitI__45BE5BA9]  DEFAULT (NULL) FOR [UnitId]
GO
ALTER TABLE [dbo].[PurchaseOrderItems] ADD  CONSTRAINT [DF__PurchaseO__UnitP__46B27FE2]  DEFAULT (NULL) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[PurchaseOrderItems] ADD  CONSTRAINT [DF__PurchaseO__NetAm__47A6A41B]  DEFAULT (NULL) FOR [NetAmount]
GO
ALTER TABLE [dbo].[PurchaseOrderItems] ADD  CONSTRAINT [DF__PurchaseO__Updat__489AC854]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[PurchaseOrderItems] ADD  CONSTRAINT [DF__PurchaseO__Updat__498EEC8D]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[PurchaseReceive] ADD  CONSTRAINT [DF__PurchaseR__Purch__3A4CA8FD]  DEFAULT (NULL) FOR [PurchaseReceiveNo]
GO
ALTER TABLE [dbo].[PurchaseReceive] ADD  CONSTRAINT [DF__PurchaseR__Purch__3B40CD36]  DEFAULT (NULL) FOR [PurchaseOrderId]
GO
ALTER TABLE [dbo].[PurchaseReceive] ADD  CONSTRAINT [DF__PurchaseR__Vendo__3C34F16F]  DEFAULT (NULL) FOR [VendorId]
GO
ALTER TABLE [dbo].[PurchaseReceive] ADD  CONSTRAINT [DF__PurchaseR__NetAm__3D2915A8]  DEFAULT (NULL) FOR [NetAmount]
GO
ALTER TABLE [dbo].[PurchaseReceive] ADD  CONSTRAINT [DF__PurchaseR__Purch__3E1D39E1]  DEFAULT (NULL) FOR [PurchaseReceiveStatus]
GO
ALTER TABLE [dbo].[PurchaseReceive] ADD  CONSTRAINT [DF__PurchaseR__Purch__3F115E1A]  DEFAULT (NULL) FOR [PurchaseReceiveDate]
GO
ALTER TABLE [dbo].[PurchaseReceive] ADD  CONSTRAINT [DF__PurchaseR__Updat__40058253]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[PurchaseReceive] ADD  CONSTRAINT [DF__PurchaseR__Updat__40F9A68C]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  CONSTRAINT [DF__PurchaseR__LineN__41EDCAC5]  DEFAULT (NULL) FOR [LineNo]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  CONSTRAINT [DF__PurchaseR__ItemI__42E1EEFE]  DEFAULT (NULL) FOR [ItemId]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  CONSTRAINT [DF__PurchaseR__Wareh__43D61337]  DEFAULT (NULL) FOR [WarehouseId]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  CONSTRAINT [DF__PurchaseR__Quant__44CA3770]  DEFAULT (NULL) FOR [Quantity]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  CONSTRAINT [DF__PurchaseR__Retur__45BE5BA9]  DEFAULT (NULL) FOR [ReceiveQuantity]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  CONSTRAINT [DF__PurchaseR__UnitI__46B27FE2]  DEFAULT (NULL) FOR [UnitId]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  CONSTRAINT [DF__PurchaseR__UnitP__47A6A41B]  DEFAULT (NULL) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  CONSTRAINT [DF__PurchaseR__NetAm__489AC854]  DEFAULT (NULL) FOR [NetAmount]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  CONSTRAINT [DF__PurchaseR__Batch__498EEC8D]  DEFAULT (NULL) FOR [BatchNo]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  CONSTRAINT [DF__PurchaseR__Updat__4A8310C6]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  CONSTRAINT [DF__PurchaseR__Updat__4B7734FF]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] ADD  DEFAULT ((0)) FOR [PurchaseOrderItemsId]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF__Stock__ItemId__4C6B5938]  DEFAULT (NULL) FOR [ItemId]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF__Stock__Warehouse__4D5F7D71]  DEFAULT (NULL) FOR [WarehouseId]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF__Stock__WorkerId__4E53A1AA]  DEFAULT (NULL) FOR [WorkerId]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF__Stock__Quantity__4F47C5E3]  DEFAULT (NULL) FOR [Quantity]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF__Stock__OnHandQua__503BEA1C]  DEFAULT (NULL) FOR [OnHandQuantity]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF__Stock__Transacti__51300E55]  DEFAULT (NULL) FOR [TransactionId]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF__Stock__UpdatedUs__5224328E]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF__Stock__UpdatedDa__531856C7]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF__Transacti__Trans__540C7B00]  DEFAULT (NULL) FOR [TransactionId]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF__Transactio__Type__55009F39]  DEFAULT (NULL) FOR [Type]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF__Transacti__Relat__55F4C372]  DEFAULT (NULL) FOR [RelationId]
GO
ALTER TABLE [dbo].[TransactionType] ADD  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Unit] ADD  CONSTRAINT [DF__Uom__Name__57DD0BE4]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[UomConversion] ADD  CONSTRAINT [DF__UomConver__Descr__58D1301D]  DEFAULT (NULL) FOR [Description]
GO
ALTER TABLE [dbo].[UomConversion] ADD  CONSTRAINT [DF__UomConver__FromU__59C55456]  DEFAULT (NULL) FOR [FromUnitId]
GO
ALTER TABLE [dbo].[UomConversion] ADD  CONSTRAINT [DF__UomConver__ToUni__5AB9788F]  DEFAULT (NULL) FOR [ToUnitId]
GO
ALTER TABLE [dbo].[UomConversion] ADD  CONSTRAINT [DF__UomConver__Ratio__5BAD9CC8]  DEFAULT (NULL) FOR [Ratio]
GO
ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [DF__Vendor__Id__5CA1C101]  DEFAULT (NULL) FOR [Id]
GO
ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [DF__Vendor__Name__5D95E53A]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [DF__Vendor__Account__5E8A0973]  DEFAULT (NULL) FOR [AccountNumber]
GO
ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [DF__Vendor__UpdatedU__5F7E2DAC]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [DF__Vendor__UpdatedD__607251E5]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[VendorAddress] ADD  CONSTRAINT [DF__VendorAdd__Vendo__6166761E]  DEFAULT (NULL) FOR [VendorId]
GO
ALTER TABLE [dbo].[VendorAddress] ADD  CONSTRAINT [DF__VendorAdd__Addre__625A9A57]  DEFAULT (NULL) FOR [AddressId]
GO
ALTER TABLE [dbo].[Warehouse] ADD  CONSTRAINT [DF__Warehouse__Id__634EBE90]  DEFAULT (NULL) FOR [Id]
GO
ALTER TABLE [dbo].[Warehouse] ADD  CONSTRAINT [DF__Warehouse__Name__6442E2C9]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Warehouse] ADD  CONSTRAINT [DF__Warehouse__Organ__65370702]  DEFAULT (NULL) FOR [OrganizationId]
GO
ALTER TABLE [dbo].[Warehouse] ADD  CONSTRAINT [DF__Warehouse__Updat__662B2B3B]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[Warehouse] ADD  CONSTRAINT [DF__Warehouse__Updat__671F4F74]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[WarehouseAddress] ADD  CONSTRAINT [DF__Warehouse__Wareh__681373AD]  DEFAULT (NULL) FOR [WarehouseId]
GO
ALTER TABLE [dbo].[WarehouseAddress] ADD  CONSTRAINT [DF__Warehouse__Addre__690797E6]  DEFAULT (NULL) FOR [AddressId]
GO
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF__Worker__Name__69FBBC1F]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF__Worker__Personne__6AEFE058]  DEFAULT (NULL) FOR [PersonnelNumber]
GO
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF__Worker__DOJ__6BE40491]  DEFAULT (NULL) FOR [DOJ]
GO
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF__Worker__DOB__6CD828CA]  DEFAULT (NULL) FOR [DOB]
GO
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF__Worker__UserId__6DCC4D03]  DEFAULT (NULL) FOR [UserId]
GO
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF__Worker__Password__6EC0713C]  DEFAULT (NULL) FOR [Password]
GO
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF__Worker__UpdatedU__6FB49575]  DEFAULT (NULL) FOR [UpdatedUserId]
GO
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF__Worker__UpdatedD__70A8B9AE]  DEFAULT (NULL) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[Worker] ADD  CONSTRAINT [DF_Worker_IsBlocked]  DEFAULT ((0)) FOR [IsBlocked]
GO
ALTER TABLE [dbo].[WorkerAddress] ADD  CONSTRAINT [DF__WorkerAdd__Worke__719CDDE7]  DEFAULT (NULL) FOR [WorkerId]
GO
ALTER TABLE [dbo].[WorkerAddress] ADD  CONSTRAINT [DF__WorkerAdd__Addre__72910220]  DEFAULT (NULL) FOR [AddressId]
GO
ALTER TABLE [dbo].[AspNetRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetRoles_dbo.Organization_OrganizationId] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
GO
ALTER TABLE [dbo].[AspNetRoles] CHECK CONSTRAINT [FK_dbo.AspNetRoles_dbo.Organization_OrganizationId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUsers_dbo.Worker_WorkerId] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([WorkerId])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_dbo.AspNetUsers_dbo.Worker_WorkerId]
GO
ALTER TABLE [dbo].[Consumption]  WITH NOCHECK ADD  CONSTRAINT [FK_Consumption_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Consumption] NOCHECK CONSTRAINT [FK_Consumption_Warehouse]
GO
ALTER TABLE [dbo].[Consumption]  WITH NOCHECK ADD  CONSTRAINT [FK_Consumption_Worker] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([WorkerId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Consumption] NOCHECK CONSTRAINT [FK_Consumption_Worker]
GO
ALTER TABLE [dbo].[ConsumptionItems]  WITH CHECK ADD  CONSTRAINT [FK_ConsumptionItems_Consumption] FOREIGN KEY([ConsumptionId])
REFERENCES [dbo].[Consumption] ([ConsumptionId])
GO
ALTER TABLE [dbo].[ConsumptionItems] CHECK CONSTRAINT [FK_ConsumptionItems_Consumption]
GO
ALTER TABLE [dbo].[ConsumptionItems]  WITH NOCHECK ADD  CONSTRAINT [FK_ConsumptionItems_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([ItemId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ConsumptionItems] NOCHECK CONSTRAINT [FK_ConsumptionItems_Items]
GO
ALTER TABLE [dbo].[ConsumptionItems]  WITH CHECK ADD  CONSTRAINT [FK_ConsumptionItems_UomConversion] FOREIGN KEY([UnitId])
REFERENCES [dbo].[UomConversion] ([Id])
GO
ALTER TABLE [dbo].[ConsumptionItems] CHECK CONSTRAINT [FK_ConsumptionItems_UomConversion]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems]  WITH CHECK ADD  CONSTRAINT [FK_InventoryAdjustmentItems_InventoryAdjustment] FOREIGN KEY([InventoryAdjustmentId])
REFERENCES [dbo].[InventoryAdjustment] ([InventoryAdjustmentId])
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] CHECK CONSTRAINT [FK_InventoryAdjustmentItems_InventoryAdjustment]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems]  WITH NOCHECK ADD  CONSTRAINT [FK_InventoryAdjustmentItems_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([ItemId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] NOCHECK CONSTRAINT [FK_InventoryAdjustmentItems_Items]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems]  WITH NOCHECK ADD  CONSTRAINT [FK_InventoryAdjustmentItems_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] NOCHECK CONSTRAINT [FK_InventoryAdjustmentItems_Warehouse]
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems]  WITH NOCHECK ADD  CONSTRAINT [FK_InventoryAdjustmentItems_Worker] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([WorkerId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[InventoryAdjustmentItems] NOCHECK CONSTRAINT [FK_InventoryAdjustmentItems_Worker]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Purchaseorder] FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderId])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Purchaseorder]
GO
ALTER TABLE [dbo].[Invoice]  WITH NOCHECK ADD  CONSTRAINT [FK_Invoice_Vendor] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendor] ([VendorId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Invoice] NOCHECK CONSTRAINT [FK_Invoice_Vendor]
GO
ALTER TABLE [dbo].[InvoiceItems]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceItems_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([InvoiceId])
GO
ALTER TABLE [dbo].[InvoiceItems] CHECK CONSTRAINT [FK_InvoiceItems_Invoice]
GO
ALTER TABLE [dbo].[InvoiceItems]  WITH NOCHECK ADD  CONSTRAINT [FK_InvoiceItems_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([ItemId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[InvoiceItems] NOCHECK CONSTRAINT [FK_InvoiceItems_Items]
GO
ALTER TABLE [dbo].[InvoiceItems]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceItems_UomConversion] FOREIGN KEY([UnitId])
REFERENCES [dbo].[UomConversion] ([Id])
GO
ALTER TABLE [dbo].[InvoiceItems] CHECK CONSTRAINT [FK_InvoiceItems_UomConversion]
GO
ALTER TABLE [dbo].[InvoiceItems]  WITH NOCHECK ADD  CONSTRAINT [FK_InvoiceItems_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[InvoiceItems] NOCHECK CONSTRAINT [FK_InvoiceItems_Warehouse]
GO
ALTER TABLE [dbo].[ItemCategory]  WITH NOCHECK ADD  CONSTRAINT [FK_ItemCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ItemCategory] NOCHECK CONSTRAINT [FK_ItemCategory_Category]
GO
ALTER TABLE [dbo].[ItemCategoryCollection]  WITH NOCHECK ADD  CONSTRAINT [FK_ItemCategoryCollection_ItemCategory] FOREIGN KEY([ItemCategoryId])
REFERENCES [dbo].[ItemCategory] ([ItemCategoryId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ItemCategoryCollection] NOCHECK CONSTRAINT [FK_ItemCategoryCollection_ItemCategory]
GO
ALTER TABLE [dbo].[ItemCategoryCollection]  WITH NOCHECK ADD  CONSTRAINT [FK_ItemCategoryCollection_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([ItemId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ItemCategoryCollection] NOCHECK CONSTRAINT [FK_ItemCategoryCollection_Items]
GO
ALTER TABLE [dbo].[Items]  WITH NOCHECK ADD  CONSTRAINT [FK_Items_UomConversion_InventoryUnitId] FOREIGN KEY([InventoryUnitId])
REFERENCES [dbo].[UomConversion] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Items] NOCHECK CONSTRAINT [FK_Items_UomConversion_InventoryUnitId]
GO
ALTER TABLE [dbo].[Items]  WITH NOCHECK ADD  CONSTRAINT [FK_Items_UomConversion_PurchaseUnitId] FOREIGN KEY([PurchaseUnitId])
REFERENCES [dbo].[UomConversion] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Items] NOCHECK CONSTRAINT [FK_Items_UomConversion_PurchaseUnitId]
GO
ALTER TABLE [dbo].[Organization]  WITH NOCHECK ADD  CONSTRAINT [FK_Organization_Warehouse] FOREIGN KEY([TransactionalWarehouseId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Organization] NOCHECK CONSTRAINT [FK_Organization_Warehouse]
GO
ALTER TABLE [dbo].[OrganizationAddress]  WITH NOCHECK ADD  CONSTRAINT [FK_OrganizationAddress_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[OrganizationAddress] NOCHECK CONSTRAINT [FK_OrganizationAddress_Addresses]
GO
ALTER TABLE [dbo].[OrganizationAddress]  WITH NOCHECK ADD  CONSTRAINT [FK_OrganizationAddress_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[OrganizationAddress] NOCHECK CONSTRAINT [FK_OrganizationAddress_Organization]
GO
ALTER TABLE [dbo].[PermissionEntityLookUps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PermissionEntityLookUps_dbo.Lookups_LookupId] FOREIGN KEY([LookupId])
REFERENCES [dbo].[Lookups] ([Id])
GO
ALTER TABLE [dbo].[PermissionEntityLookUps] CHECK CONSTRAINT [FK_dbo.PermissionEntityLookUps_dbo.Lookups_LookupId]
GO
ALTER TABLE [dbo].[PermissionEntityLookUps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PermissionEntityLookUps_dbo.PermissionEntities_PermissionEntityId] FOREIGN KEY([PermissionEntityId])
REFERENCES [dbo].[PermissionEntities] ([Id])
GO
ALTER TABLE [dbo].[PermissionEntityLookUps] CHECK CONSTRAINT [FK_dbo.PermissionEntityLookUps_dbo.PermissionEntities_PermissionEntityId]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH NOCHECK ADD  CONSTRAINT [FK_PurchaseOrder_Vendor] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendor] ([VendorId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PurchaseOrder] NOCHECK CONSTRAINT [FK_PurchaseOrder_Vendor]
GO
ALTER TABLE [dbo].[PurchaseOrderItems]  WITH NOCHECK ADD  CONSTRAINT [FK_PurchaseOrderItems_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([ItemId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PurchaseOrderItems] NOCHECK CONSTRAINT [FK_PurchaseOrderItems_Items]
GO
ALTER TABLE [dbo].[PurchaseOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrderItems_Purchaseorder] FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderId])
GO
ALTER TABLE [dbo].[PurchaseOrderItems] CHECK CONSTRAINT [FK_PurchaseOrderItems_Purchaseorder]
GO
ALTER TABLE [dbo].[PurchaseOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrderItems_UomConversion] FOREIGN KEY([UnitId])
REFERENCES [dbo].[UomConversion] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrderItems] CHECK CONSTRAINT [FK_PurchaseOrderItems_UomConversion]
GO
ALTER TABLE [dbo].[PurchaseOrderItems]  WITH NOCHECK ADD  CONSTRAINT [FK_PurchaseOrderItems_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PurchaseOrderItems] NOCHECK CONSTRAINT [FK_PurchaseOrderItems_Warehouse]
GO
ALTER TABLE [dbo].[PurchaseReceive]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseReturn_Purchaseorder] FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderId])
GO
ALTER TABLE [dbo].[PurchaseReceive] CHECK CONSTRAINT [FK_PurchaseReturn_Purchaseorder]
GO
ALTER TABLE [dbo].[PurchaseReceive]  WITH NOCHECK ADD  CONSTRAINT [FK_PurchaseReturn_Vendor] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendor] ([VendorId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PurchaseReceive] NOCHECK CONSTRAINT [FK_PurchaseReturn_Vendor]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems]  WITH NOCHECK ADD  CONSTRAINT [FK_PurchaseReturnItems_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([ItemId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] NOCHECK CONSTRAINT [FK_PurchaseReturnItems_Items]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseReturnItems_PurchaseReturn] FOREIGN KEY([PurchaseReceiveId])
REFERENCES [dbo].[PurchaseReceive] ([PurchaseReceiveId])
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] CHECK CONSTRAINT [FK_PurchaseReturnItems_PurchaseReturn]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseReturnItems_UomConversion] FOREIGN KEY([UnitId])
REFERENCES [dbo].[UomConversion] ([Id])
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] CHECK CONSTRAINT [FK_PurchaseReturnItems_UomConversion]
GO
ALTER TABLE [dbo].[PurchaseReceiveItems]  WITH NOCHECK ADD  CONSTRAINT [FK_PurchaseReturnItems_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PurchaseReceiveItems] NOCHECK CONSTRAINT [FK_PurchaseReturnItems_Warehouse]
GO
ALTER TABLE [dbo].[Role_PermissionEntityLookUps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Role_PermissionEntityLookUps_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Role_PermissionEntityLookUps] CHECK CONSTRAINT [FK_dbo.Role_PermissionEntityLookUps_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[Role_PermissionEntityLookUps]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Role_PermissionEntityLookUps_dbo.PermissionEntityLookUps_PermissionEntityLookUpId] FOREIGN KEY([PermissionEntityLookUpId])
REFERENCES [dbo].[PermissionEntityLookUps] ([Id])
GO
ALTER TABLE [dbo].[Role_PermissionEntityLookUps] CHECK CONSTRAINT [FK_dbo.Role_PermissionEntityLookUps_dbo.PermissionEntityLookUps_PermissionEntityLookUpId]
GO
ALTER TABLE [dbo].[Stock]  WITH NOCHECK ADD  CONSTRAINT [FK_Stock_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([ItemId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Stock] NOCHECK CONSTRAINT [FK_Stock_Items]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Transactions] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[Transactions] ([Id])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Transactions]
GO
ALTER TABLE [dbo].[Stock]  WITH NOCHECK ADD  CONSTRAINT [FK_Stock_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Stock] NOCHECK CONSTRAINT [FK_Stock_Warehouse]
GO
ALTER TABLE [dbo].[Stock]  WITH NOCHECK ADD  CONSTRAINT [FK_Stock_Worker] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([WorkerId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Stock] NOCHECK CONSTRAINT [FK_Stock_Worker]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_TransactionType] FOREIGN KEY([Type])
REFERENCES [dbo].[TransactionType] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_TransactionType]
GO
ALTER TABLE [dbo].[UomConversion]  WITH NOCHECK ADD  CONSTRAINT [FK_UomConversion_UomFromUnitId] FOREIGN KEY([FromUnitId])
REFERENCES [dbo].[Unit] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[UomConversion] NOCHECK CONSTRAINT [FK_UomConversion_UomFromUnitId]
GO
ALTER TABLE [dbo].[UomConversion]  WITH NOCHECK ADD  CONSTRAINT [FK_UomConversion_UomToUnitId] FOREIGN KEY([ToUnitId])
REFERENCES [dbo].[Unit] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[UomConversion] NOCHECK CONSTRAINT [FK_UomConversion_UomToUnitId]
GO
ALTER TABLE [dbo].[UserOrganizations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserOrganizations_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserOrganizations] CHECK CONSTRAINT [FK_dbo.UserOrganizations_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserOrganizations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserOrganizations_dbo.Organization_OrganizationId] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
GO
ALTER TABLE [dbo].[UserOrganizations] CHECK CONSTRAINT [FK_dbo.UserOrganizations_dbo.Organization_OrganizationId]
GO
ALTER TABLE [dbo].[VendorAddress]  WITH NOCHECK ADD  CONSTRAINT [FK_VendorAddress_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[VendorAddress] NOCHECK CONSTRAINT [FK_VendorAddress_Addresses]
GO
ALTER TABLE [dbo].[VendorAddress]  WITH NOCHECK ADD  CONSTRAINT [FK_VendorAddress_Vendor] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendor] ([VendorId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[VendorAddress] NOCHECK CONSTRAINT [FK_VendorAddress_Vendor]
GO
ALTER TABLE [dbo].[WarehouseAddress]  WITH NOCHECK ADD  CONSTRAINT [FK_WarehouseAddress_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[WarehouseAddress] NOCHECK CONSTRAINT [FK_WarehouseAddress_Addresses]
GO
ALTER TABLE [dbo].[WarehouseAddress]  WITH NOCHECK ADD  CONSTRAINT [FK_WarehouseAddress_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[WarehouseAddress] NOCHECK CONSTRAINT [FK_WarehouseAddress_Warehouse]
GO
ALTER TABLE [dbo].[WorkerAddress]  WITH NOCHECK ADD  CONSTRAINT [FK_WorkerAddress_Addresses] FOREIGN KEY([WorkerAddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[WorkerAddress] NOCHECK CONSTRAINT [FK_WorkerAddress_Addresses]
GO
ALTER TABLE [dbo].[WorkerAddress]  WITH NOCHECK ADD  CONSTRAINT [FK_WorkerAddress_Worker] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([WorkerId])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[WorkerAddress] NOCHECK CONSTRAINT [FK_WorkerAddress_Worker]
GO
USE [master]
GO
ALTER DATABASE [IMS6] SET  READ_WRITE 
GO
