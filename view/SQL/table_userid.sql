USE [informationSystem]
GO

/****** Object:  Table [dbo].[userid]    Script Date: 03/11/2016 00:15:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[userid](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[name] [varchar](20) NOT NULL,
	[password] [varchar](200) NOT NULL,
	[createTime] [datetime] NOT NULL,
	[super] [smallint] NOT NULL,
	[status] [smallint] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[userid] ADD  CONSTRAINT [DF_user_charId]  DEFAULT (newid()) FOR [charId]
GO

ALTER TABLE [dbo].[userid] ADD  CONSTRAINT [DF_user_createTime]  DEFAULT (getdate()) FOR [createTime]
GO

ALTER TABLE [dbo].[userid] ADD  CONSTRAINT [DF_user_isSuper]  DEFAULT ((0)) FOR [super]
GO

ALTER TABLE [dbo].[userid] ADD  CONSTRAINT [DF_user_status]  DEFAULT ((0)) FOR [status]
GO


