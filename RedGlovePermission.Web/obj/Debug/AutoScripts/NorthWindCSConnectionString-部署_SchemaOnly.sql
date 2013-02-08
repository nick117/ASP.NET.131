SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](128) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[Password] [nvarchar](128) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[Question] [nvarchar](100) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[Answer] [nvarchar](100) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[RoleID] [int] NOT NULL,
	[UserGroup] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[Status] [int] NOT NULL,
	[IsOnline] [bit] NOT NULL,
	[IsLimit] [bit] NOT NULL,
 CONSTRAINT [PK_User_ID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_Order_DTL](
	[OrderID] [char](13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[Seq] [int] NOT NULL,
	[MB001] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[Qty] [decimal](18, 2) NULL,
	[FreeQty] [decimal](18, 2) NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[Discount] [decimal](3, 2) NULL,
	[CREATOR] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATE_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODIFIER] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODI_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
 CONSTRAINT [PK_Sales_Order_DTL] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[Seq] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_Order](
	[OrderID] [char](13) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[MA001] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[COMPANY] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[ORDER_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CaseNo] [varchar](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[Department] [nvarchar](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[TaxRate] [numeric](3, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[Tax] [decimal](18, 2) NULL,
	[Address] [nvarchar](200) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[Remark] [nvarchar](200) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATOR] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATE_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODIFIER] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODI_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
 CONSTRAINT [PK_Sales_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RGP_Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleGroupID] [int] NOT NULL,
	[RoleName] [nvarchar](30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[RoleDescription] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
 CONSTRAINT [PK_RGP_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RGP_RoleAuthorityList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[ModuleID] [int] NOT NULL,
	[AuthorityTag] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[Flag] [bit] NOT NULL,
 CONSTRAINT [PK_UserAuthorityList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RGP_ModuleType](
	[ModuleTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleTypeName] [nvarchar](30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[ModuleTypeOrder] [int] NOT NULL,
	[ModuleTypeDescription] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
 CONSTRAINT [PK_ModuleGroup] PRIMARY KEY CLUSTERED 
(
	[ModuleTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RGP_Modules](
	[ModuleID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleTypeID] [int] NOT NULL,
	[ModuleName] [nvarchar](30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[ModuleTag] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[ModuleURL] [nvarchar](500) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[ModuleDisabled] [bit] NOT NULL,
	[ModuleOrder] [int] NOT NULL,
	[ModuleDescription] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[IsMenu] [bit] NOT NULL,
 CONSTRAINT [PK_RGP_Modules] PRIMARY KEY CLUSTERED 
(
	[ModuleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RGP_ModuleAuthorityList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NOT NULL,
	[AuthorityTag] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
 CONSTRAINT [PK_ModuleAuthorityList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RGP_Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[GroupOrder] [int] NOT NULL,
	[GroupDescription] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
 CONSTRAINT [PK_RGP_UserGroup] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RGP_Configuration](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[ItemValue] [nvarchar](500) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[ItemDescription] [nvarchar](500) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
 CONSTRAINT [PK_Sys_Configuration] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RGP_AuthorityDir](
	[AuthorityID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorityName] [nvarchar](30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[AuthorityTag] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[AuthorityDescription] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[AuthorityOrder] [int] NOT NULL,
 CONSTRAINT [PK_RGP_AuthorityDir] PRIMARY KEY CLUSTERED 
(
	[AuthorityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVMB](
	[COMPANY] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATOR] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[USR_GROUP] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATE_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODIFIER] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODI_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[FLAG] [numeric](3, 0) NULL,
	[MB001] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[MB002] [char](30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB003] [char](30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB004] [char](4) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB005] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB006] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB007] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB008] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB009] [varchar](255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB010] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB011] [char](4) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB012] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB013] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB014] [numeric](10, 5) NULL,
	[MB015] [char](4) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB016] [char](4) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB017] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB018] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB019] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB020] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB021] [char](4) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB022] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB023] [numeric](4, 0) NULL,
	[MB024] [numeric](4, 0) NULL,
	[MB025] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB026] [char](2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB027] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB028] [varchar](255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB029] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB030] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB031] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB032] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB033] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB034] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB035] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB036] [numeric](3, 0) NULL,
	[MB037] [numeric](3, 0) NULL,
	[MB038] [numeric](11, 3) NULL,
	[MB039] [numeric](11, 3) NULL,
	[MB040] [numeric](11, 3) NULL,
	[MB041] [numeric](11, 3) NULL,
	[MB042] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB043] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB044] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB045] [numeric](5, 4) NULL,
	[MB046] [numeric](13, 4) NULL,
	[MB047] [numeric](13, 4) NULL,
	[MB048] [char](4) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB049] [numeric](13, 4) NULL,
	[MB050] [numeric](13, 4) NULL,
	[MB051] [numeric](13, 4) NULL,
	[MB052] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB053] [numeric](13, 4) NULL,
	[MB054] [numeric](13, 4) NULL,
	[MB055] [numeric](13, 4) NULL,
	[MB056] [numeric](13, 4) NULL,
	[MB057] [numeric](13, 4) NULL,
	[MB058] [numeric](13, 4) NULL,
	[MB059] [numeric](13, 4) NULL,
	[MB060] [numeric](13, 4) NULL,
	[MB061] [numeric](13, 4) NULL,
	[MB062] [numeric](13, 4) NULL,
	[MB063] [numeric](13, 4) NULL,
	[MB064] [numeric](13, 3) NULL,
	[MB065] [numeric](13, 2) NULL,
	[MB066] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB067] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB068] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB069] [numeric](13, 4) NULL,
	[MB070] [numeric](13, 4) NULL,
	[MB071] [numeric](8, 3) NULL,
	[MB072] [char](4) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB073] [numeric](8, 3) NULL,
	[MB074] [numeric](8, 3) NULL,
	[MB075] [numeric](8, 3) NULL,
	[MB076] [numeric](3, 0) NULL,
	[MB077] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB078] [numeric](3, 0) NULL,
	[MB079] [numeric](3, 0) NULL,
	[MB080] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB081] [char](4) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB082] [numeric](7, 4) NULL,
	[MB083] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MB084] [numeric](7, 6) NULL,
	[type] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[width] [float] NULL,
	[length] [float] NULL,
 CONSTRAINT [PK_INVMB] PRIMARY KEY NONCLUSTERED 
(
	[MB001] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90)
)

GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COPMA](
	[COMPANY] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATOR] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[USR_GROUP] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATE_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODIFIER] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODI_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[FLAG] [numeric](3, 0) NULL,
	[MA001] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[MA002] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA003] [char](72) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA004] [char](30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA005] [char](30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA006] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA007] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA008] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA009] [char](36) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA010] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA011] [numeric](10, 0) NULL,
	[MA012] [numeric](10, 0) NULL,
	[MA013] [numeric](5, 0) NULL,
	[MA014] [char](4) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA015] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA016] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA017] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA018] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA019] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA020] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA021] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA022] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA023] [char](72) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA024] [char](72) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA025] [char](72) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA026] [char](72) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA027] [char](72) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA028] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA029] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA030] [char](16) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA031] [char](16) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA032] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA033] [numeric](10, 0) NULL,
	[MA034] [numeric](5, 4) NULL,
	[MA035] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA036] [numeric](5, 4) NULL,
	[MA037] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA038] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA039] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA040] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA041] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA042] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA043] [char](2) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA044] [numeric](3, 0) NULL,
	[MA045] [numeric](3, 0) NULL,
	[MA046] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA047] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA048] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA049] [varchar](255) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA050] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA051] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA052] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA053] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA054] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA055] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA056] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA057] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA058] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA059] [numeric](6, 5) NULL,
	[MA060] [numeric](6, 5) NULL,
	[MA061] [numeric](8, 7) NULL,
	[MA062] [char](72) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA063] [char](72) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA064] [char](72) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA065] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA066] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA067] [numeric](5, 0) NULL,
	[MA068] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA069] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA070] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA071] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA072] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA073] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA074] [char](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA075] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA076] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA077] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA078] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA079] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA080] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA081] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA082] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA083] [char](6) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA084] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA085] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA086] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA087] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA088] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA089] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA090] [numeric](5, 4) NULL,
	[MA091] [numeric](5, 4) NULL,
	[MA092] [numeric](5, 4) NULL,
	[MA093] [numeric](5, 4) NULL,
	[MA094] [numeric](5, 4) NULL,
	[MA095] [numeric](5, 4) NULL,
	[MA096] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA097] [char](1) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
 CONSTRAINT [PK_COPMA] PRIMARY KEY NONCLUSTERED 
(
	[MA001] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basic_System](
	[Code] [varchar](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[Items] [nvarchar](200) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATOR] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATE_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODIFIER] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODI_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
 CONSTRAINT [PK_Basic_System] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basic_Company](
	[Company] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[Track] [char](2) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[Description] [nvarchar](100) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATOR] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATE_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODIFIER] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODI_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
 CONSTRAINT [PK_Basic_Company] PRIMARY KEY CLUSTERED 
(
	[Company] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basic_Case](
	[CaseNo] [varchar](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL,
	[CaseDescription] [nvarchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[Department] [nvarchar](20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MA001] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATOR] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[CREATE_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODIFIER] [char](10) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[MODI_DATE] [char](8) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
 CONSTRAINT [PK_Basic_Case] PRIMARY KEY CLUSTERED 
(
	[CaseNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_RoleID]  DEFAULT ((0)) FOR [RoleID]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UserGroup]  DEFAULT ((0)) FOR [UserGroup]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsOnline]  DEFAULT ((0)) FOR [IsOnline]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsLimit]  DEFAULT ((0)) FOR [IsLimit]
GO
ALTER TABLE [dbo].[RGP_RoleAuthorityList] ADD  CONSTRAINT [DF_RGP_RoleAuthorityList_UserID]  DEFAULT ((0)) FOR [UserID]
GO
ALTER TABLE [dbo].[RGP_RoleAuthorityList] ADD  CONSTRAINT [DF_RGP_RoleAuthorityList_RoleID]  DEFAULT ((0)) FOR [RoleID]
GO
ALTER TABLE [dbo].[RGP_RoleAuthorityList] ADD  CONSTRAINT [DF_RGP_RoleAuthorityList_Flag]  DEFAULT ((1)) FOR [Flag]
GO
ALTER TABLE [dbo].[RGP_ModuleType] ADD  CONSTRAINT [DF_ModuleGroup_ModuleGroupOrder]  DEFAULT ((0)) FOR [ModuleTypeOrder]
GO
ALTER TABLE [dbo].[RGP_Modules] ADD  CONSTRAINT [DF_RGP_Modules_ModuleDisabled]  DEFAULT ((1)) FOR [ModuleDisabled]
GO
ALTER TABLE [dbo].[RGP_Modules] ADD  CONSTRAINT [DF_RGP_Modules_ModuleOrder]  DEFAULT ((0)) FOR [ModuleOrder]
GO
ALTER TABLE [dbo].[RGP_Modules] ADD  CONSTRAINT [DF_RGP_Modules_IsMenu]  DEFAULT ((1)) FOR [IsMenu]
GO
ALTER TABLE [dbo].[RGP_Groups] ADD  CONSTRAINT [DF_RGP_UserGroup_UserGroupOrder]  DEFAULT ((0)) FOR [GroupOrder]
GO
ALTER TABLE [dbo].[RGP_AuthorityDir] ADD  CONSTRAINT [DF_AuthorityDir_AuthorityOrder]  DEFAULT ((0)) FOR [AuthorityOrder]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB002]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB003]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB004]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB005]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB006]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB007]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB008]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB010]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB011]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB012]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB013]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB014]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB015]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB016]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB017]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB018]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB019]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB020]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB021]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB022]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB023]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB024]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB025]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB026]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB027]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB029]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB030]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB031]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB032]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB033]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB034]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB035]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB036]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB037]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB038]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB039]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB040]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB041]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB042]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB043]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB044]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB045]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB046]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB047]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB048]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB049]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB050]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB051]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB052]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB053]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB054]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB055]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB056]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB057]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB058]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB059]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB060]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB061]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB062]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB063]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB064]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB065]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB066]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB067]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB068]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB069]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB070]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB071]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB072]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB073]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB074]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB075]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB076]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB077]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB078]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB079]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB080]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB081]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB082]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ('') FOR [MB083]
GO
ALTER TABLE [dbo].[INVMB] ADD  DEFAULT ((0)) FOR [MB084]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA002]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA003]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA004]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA005]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA006]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA007]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA008]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA009]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA010]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA011]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA012]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA013]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA014]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA015]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA016]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA017]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA018]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA019]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA020]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA021]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA022]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA023]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA024]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA025]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA026]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA027]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA028]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA029]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA030]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA031]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA032]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA033]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA034]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA035]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA036]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA037]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA038]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA039]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA040]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA041]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA042]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA043]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA044]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA045]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA046]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA047]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA048]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA050]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA051]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA052]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA053]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA054]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA055]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA056]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA057]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA058]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA059]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA060]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA061]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA062]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA063]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA064]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA065]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA066]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA067]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA068]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA069]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA070]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA071]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA072]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA073]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA074]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA075]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA076]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA077]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA078]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA079]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA080]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA081]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA082]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA083]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA084]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA085]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA086]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA087]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA088]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA089]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA090]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA091]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA092]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA093]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA094]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ((0)) FOR [MA095]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA096]
GO
ALTER TABLE [dbo].[COPMA] ADD  DEFAULT ('') FOR [MA097]
GO
