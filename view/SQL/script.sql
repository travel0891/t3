USE [informationSystem]
GO
/****** Object:  Table [dbo].[documents]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[documents](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[configs_charId] [uniqueidentifier] NOT NULL,
	[parms_charId] [uniqueidentifier] NOT NULL,
	[number] [varchar](12) NOT NULL,
	[title] [nvarchar](100) NOT NULL,
	[type] [varchar](8) NOT NULL,
	[size] [int] NOT NULL,
	[url] [varchar](200) NOT NULL,
	[createTime] [datetime] NOT NULL,
	[updateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_documents] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文档编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'documents', @level2type=N'COLUMN',@level2name=N'number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文档名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'documents', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文档类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'documents', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文档大小' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'documents', @level2type=N'COLUMN',@level2name=N'size'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下载地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'documents', @level2type=N'COLUMN',@level2name=N'url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'documents', @level2type=N'COLUMN',@level2name=N'updateTime'
GO
/****** Object:  Table [dbo].[courses]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[courses](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[configs_charId] [uniqueidentifier] NOT NULL,
	[parms_charId] [uniqueidentifier] NOT NULL,
	[number] [varchar](12) NOT NULL,
	[title] [nvarchar](100) NOT NULL,
	[createTime] [datetime] NOT NULL,
	[contents] [nvarchar](2000) NOT NULL,
	[updateTime] [datetime] NULL,
 CONSTRAINT [PK_course] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课题编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'courses', @level2type=N'COLUMN',@level2name=N'number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'courses', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'courses', @level2type=N'COLUMN',@level2name=N'createTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课件内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'courses', @level2type=N'COLUMN',@level2name=N'contents'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'courses', @level2type=N'COLUMN',@level2name=N'updateTime'
GO
/****** Object:  Table [dbo].[configs]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[configs](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[createTime] [datetime] NOT NULL,
 CONSTRAINT [PK_configs] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[classes]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classes](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[createTime] [datetime] NOT NULL,
	[classler] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_classes] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[examples]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[examples](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[number] [varchar](12) NOT NULL,
	[type] [smallint] NOT NULL,
	[example] [nvarchar](200) NOT NULL,
	[optionA] [smallint] NOT NULL,
	[optionB] [smallint] NOT NULL,
	[optionC] [smallint] NOT NULL,
	[optionD] [smallint] NOT NULL,
	[aCountent] [nvarchar](200) NOT NULL,
	[bCountent] [nvarchar](200) NOT NULL,
	[cCountent] [nvarchar](200) NOT NULL,
	[dCountent] [nvarchar](200) NOT NULL,
	[configs_charId] [uniqueidentifier] NOT NULL,
	[parms_charId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_examples] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'习题编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'examples', @level2type=N'COLUMN',@level2name=N'number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1.单选2多选' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'examples', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'题目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'examples', @level2type=N'COLUMN',@level2name=N'example'
GO
/****** Object:  Table [dbo].[qandas]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[qandas](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[number] [varchar](12) NOT NULL,
	[qanda] [nvarchar](100) NOT NULL,
	[qaCountent] [nvarchar](2000) NOT NULL,
	[configs_charId] [uniqueidentifier] NOT NULL,
	[parms_charId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_qanda] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[parms]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parms](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[configs_charId] [uniqueidentifier] NOT NULL,
	[chapter] [nvarchar](50) NOT NULL,
	[createTime] [datetime] NOT NULL,
 CONSTRAINT [PK_parameters] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[students]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[students](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[account] [nvarchar](50) NOT NULL,
	[password] [varchar](200) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[number] [varchar](12) NULL,
	[gender] [smallint] NOT NULL,
	[classes] [nvarchar](20) NOT NULL,
	[createTime] [datetime] NOT NULL,
	[super] [smallint] NOT NULL,
	[status] [smallint] NOT NULL,
 CONSTRAINT [PK_student] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'students', @level2type=N'COLUMN',@level2name=N'account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'students', @level2type=N'COLUMN',@level2name=N'password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'students', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'students', @level2type=N'COLUMN',@level2name=N'number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'students', @level2type=N'COLUMN',@level2name=N'gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'班级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'students', @level2type=N'COLUMN',@level2name=N'classes'
GO
/****** Object:  Table [dbo].[studies]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[studies](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[courses_charId] [uniqueidentifier] NOT NULL,
	[students_charId] [uniqueidentifier] NOT NULL,
	[createTime] [datetime] NOT NULL,
 CONSTRAINT [PK_studies] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[questions]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[questions](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[number] [varchar](12) NOT NULL,
	[question] [nvarchar](2000) NOT NULL,
	[students_charId] [uniqueidentifier] NOT NULL,
	[createTime] [datetime] NOT NULL,
 CONSTRAINT [PK_questions] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'问题编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'questions', @level2type=N'COLUMN',@level2name=N'number'
GO
/****** Object:  Table [dbo].[exams]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exams](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[tempAction] [uniqueidentifier] NOT NULL,
	[examples_charId] [uniqueidentifier] NOT NULL,
	[students_charId] [uniqueidentifier] NOT NULL,
	[createTime] [datetime] NOT NULL,
	[score] [smallint] NOT NULL,
	[updateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_exams] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试场景' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'exams', @level2type=N'COLUMN',@level2name=N'tempAction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'题目charId' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'exams', @level2type=N'COLUMN',@level2name=N'examples_charId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生charId' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'exams', @level2type=N'COLUMN',@level2name=N'students_charId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'exams', @level2type=N'COLUMN',@level2name=N'createTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'得分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'exams', @level2type=N'COLUMN',@level2name=N'score'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'exams', @level2type=N'COLUMN',@level2name=N'updateTime'
GO
/****** Object:  Table [dbo].[downLoads]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[downLoads](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[documents_charId] [uniqueidentifier] NOT NULL,
	[students_charId] [uniqueidentifier] NOT NULL,
	[createTime] [datetime] NOT NULL,
 CONSTRAINT [PK_downLoads] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下载文档charId' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'downLoads', @level2type=N'COLUMN',@level2name=N'documents_charId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生charId' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'downLoads', @level2type=N'COLUMN',@level2name=N'students_charId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下载时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'downLoads', @level2type=N'COLUMN',@level2name=N'createTime'
GO
/****** Object:  Table [dbo].[answers]    Script Date: 05/06/2016 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[answers](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[questions_charId] [uniqueidentifier] NOT NULL,
	[answer] [nvarchar](2000) NOT NULL,
	[students_charId] [uniqueidentifier] NOT NULL,
	[createTime] [datetime] NOT NULL,
 CONSTRAINT [PK_answers] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_answers_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[answers] ADD  CONSTRAINT [DF_answers_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_answers_createTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[answers] ADD  CONSTRAINT [DF_answers_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
/****** Object:  Default [DF_classes_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[classes] ADD  CONSTRAINT [DF_classes_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_classes_createTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[classes] ADD  CONSTRAINT [DF_classes_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
/****** Object:  Default [DF_configs_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[configs] ADD  CONSTRAINT [DF_configs_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_configs_createTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[configs] ADD  CONSTRAINT [DF_configs_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
/****** Object:  Default [DF_course_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[courses] ADD  CONSTRAINT [DF_course_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_course_createTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[courses] ADD  CONSTRAINT [DF_course_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
/****** Object:  Default [DF_course_updateTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[courses] ADD  CONSTRAINT [DF_course_updateTime]  DEFAULT (getdate()) FOR [updateTime]
GO
/****** Object:  Default [DF_documents_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[documents] ADD  CONSTRAINT [DF_documents_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_documents_createTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[documents] ADD  CONSTRAINT [DF_documents_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
/****** Object:  Default [DF_documents_updateTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[documents] ADD  CONSTRAINT [DF_documents_updateTime]  DEFAULT (getdate()) FOR [updateTime]
GO
/****** Object:  Default [DF_downLoads_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[downLoads] ADD  CONSTRAINT [DF_downLoads_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_downLoads_createTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[downLoads] ADD  CONSTRAINT [DF_downLoads_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
/****** Object:  Default [DF_examples_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[examples] ADD  CONSTRAINT [DF_examples_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_examples_type]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[examples] ADD  CONSTRAINT [DF_examples_type]  DEFAULT ((1)) FOR [type]
GO
/****** Object:  Default [DF_examples_optionA]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[examples] ADD  CONSTRAINT [DF_examples_optionA]  DEFAULT ((0)) FOR [optionA]
GO
/****** Object:  Default [DF_examples_optionB]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[examples] ADD  CONSTRAINT [DF_examples_optionB]  DEFAULT ((0)) FOR [optionB]
GO
/****** Object:  Default [DF_examples_optionC]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[examples] ADD  CONSTRAINT [DF_examples_optionC]  DEFAULT ((0)) FOR [optionC]
GO
/****** Object:  Default [DF_examples_optionD]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[examples] ADD  CONSTRAINT [DF_examples_optionD]  DEFAULT ((0)) FOR [optionD]
GO
/****** Object:  Default [DF_exams_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[exams] ADD  CONSTRAINT [DF_exams_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_exams_createTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[exams] ADD  CONSTRAINT [DF_exams_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
/****** Object:  Default [DF_exams_score]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[exams] ADD  CONSTRAINT [DF_exams_score]  DEFAULT ((0)) FOR [score]
GO
/****** Object:  Default [DF_exams_updateTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[exams] ADD  CONSTRAINT [DF_exams_updateTime]  DEFAULT (getdate()) FOR [updateTime]
GO
/****** Object:  Default [DF_parameters_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[parms] ADD  CONSTRAINT [DF_parameters_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_parameters_createTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[parms] ADD  CONSTRAINT [DF_parameters_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
/****** Object:  Default [DF_qanda_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[qandas] ADD  CONSTRAINT [DF_qanda_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_questions_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[questions] ADD  CONSTRAINT [DF_questions_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_questions_createTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[questions] ADD  CONSTRAINT [DF_questions_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
/****** Object:  Default [DF_students_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[students] ADD  CONSTRAINT [DF_students_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_student_createTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[students] ADD  CONSTRAINT [DF_student_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
/****** Object:  Default [DF_student_super]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[students] ADD  CONSTRAINT [DF_student_super]  DEFAULT ((0)) FOR [super]
GO
/****** Object:  Default [DF_student_status]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[students] ADD  CONSTRAINT [DF_student_status]  DEFAULT ((0)) FOR [status]
GO
/****** Object:  Default [DF_studies_charId]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[studies] ADD  CONSTRAINT [DF_studies_charId]  DEFAULT (newid()) FOR [charId]
GO
/****** Object:  Default [DF_studies_createTime]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[studies] ADD  CONSTRAINT [DF_studies_createTime]  DEFAULT (getdate()) FOR [createTime]
GO
/****** Object:  ForeignKey [FK_answers_questions]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[answers]  WITH CHECK ADD  CONSTRAINT [FK_answers_questions] FOREIGN KEY([questions_charId])
REFERENCES [dbo].[questions] ([charId])
GO
ALTER TABLE [dbo].[answers] CHECK CONSTRAINT [FK_answers_questions]
GO
/****** Object:  ForeignKey [FK_answers_students]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[answers]  WITH CHECK ADD  CONSTRAINT [FK_answers_students] FOREIGN KEY([students_charId])
REFERENCES [dbo].[students] ([charId])
GO
ALTER TABLE [dbo].[answers] CHECK CONSTRAINT [FK_answers_students]
GO
/****** Object:  ForeignKey [FK_downLoads_documents]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[downLoads]  WITH CHECK ADD  CONSTRAINT [FK_downLoads_documents] FOREIGN KEY([documents_charId])
REFERENCES [dbo].[documents] ([charId])
GO
ALTER TABLE [dbo].[downLoads] CHECK CONSTRAINT [FK_downLoads_documents]
GO
/****** Object:  ForeignKey [FK_downLoads_students]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[downLoads]  WITH CHECK ADD  CONSTRAINT [FK_downLoads_students] FOREIGN KEY([students_charId])
REFERENCES [dbo].[students] ([charId])
GO
ALTER TABLE [dbo].[downLoads] CHECK CONSTRAINT [FK_downLoads_students]
GO
/****** Object:  ForeignKey [FK_exams_examples]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[exams]  WITH CHECK ADD  CONSTRAINT [FK_exams_examples] FOREIGN KEY([examples_charId])
REFERENCES [dbo].[examples] ([charId])
GO
ALTER TABLE [dbo].[exams] CHECK CONSTRAINT [FK_exams_examples]
GO
/****** Object:  ForeignKey [FK_exams_students]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[exams]  WITH CHECK ADD  CONSTRAINT [FK_exams_students] FOREIGN KEY([students_charId])
REFERENCES [dbo].[students] ([charId])
GO
ALTER TABLE [dbo].[exams] CHECK CONSTRAINT [FK_exams_students]
GO
/****** Object:  ForeignKey [FK_questions_students]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[questions]  WITH CHECK ADD  CONSTRAINT [FK_questions_students] FOREIGN KEY([students_charId])
REFERENCES [dbo].[students] ([charId])
GO
ALTER TABLE [dbo].[questions] CHECK CONSTRAINT [FK_questions_students]
GO
/****** Object:  ForeignKey [FK_studies_courses]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[studies]  WITH CHECK ADD  CONSTRAINT [FK_studies_courses] FOREIGN KEY([courses_charId])
REFERENCES [dbo].[courses] ([charId])
GO
ALTER TABLE [dbo].[studies] CHECK CONSTRAINT [FK_studies_courses]
GO
/****** Object:  ForeignKey [FK_studies_students]    Script Date: 05/06/2016 02:18:42 ******/
ALTER TABLE [dbo].[studies]  WITH CHECK ADD  CONSTRAINT [FK_studies_students] FOREIGN KEY([students_charId])
REFERENCES [dbo].[students] ([charId])
GO
ALTER TABLE [dbo].[studies] CHECK CONSTRAINT [FK_studies_students]
GO

CREATE TABLE [dbo].[messages](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[charId] [uniqueidentifier] NOT NULL,
	[title] [varchar](200) NOT NULL,
	[students_charId] [uniqueidentifier] NOT NULL,
	[createTime] [datetime] NOT NULL,
	[reply] [varchar](2000) NOT NULL,
	[replyTime] [datetime] NOT NULL,
 CONSTRAINT [PK_messages] PRIMARY KEY CLUSTERED 
(
	[charId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[messages] ADD  CONSTRAINT [DF_messages_charId]  DEFAULT (newid()) FOR [charId]
GO

ALTER TABLE [dbo].[messages] ADD  CONSTRAINT [DF_messages_createTime]  DEFAULT (getdate()) FOR [createTime]
GO

ALTER TABLE [dbo].[messages] ADD  CONSTRAINT [DF_messages_replyTime]  DEFAULT (getdate()) FOR [replyTime]
GO