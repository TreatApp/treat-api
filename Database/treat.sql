USE [treat]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2015-11-20 14:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Event]    Script Date: 2015-11-20 14:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Event](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Slots] [int] NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[LocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventCategory]    Script Date: 2015-11-20 14:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventCategory](
	[EventId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
 CONSTRAINT [PK_EventCategory_1] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventLocation]    Script Date: 2015-11-20 14:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventLocation](
	[EventId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_EventLocation] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventLog]    Script Date: 2015-11-20 14:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EventId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Type] [int] NOT NULL,
	[Text] [varchar](max) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_EventLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventRating]    Script Date: 2015-11-20 14:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventRating](
	[EventId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Rating] [int] NOT NULL,
	[Comment] [varchar](max) NULL,
 CONSTRAINT [PK_EventRating_1] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventRequest]    Script Date: 2015-11-20 14:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventRequest](
	[EventId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_EventRequest_1] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 2015-11-20 14:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2015-11-20 14:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ExternalId] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_User]
GO
ALTER TABLE [dbo].[EventCategory]  WITH CHECK ADD  CONSTRAINT [FK_EventCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[EventCategory] CHECK CONSTRAINT [FK_EventCategory_Category]
GO
ALTER TABLE [dbo].[EventCategory]  WITH CHECK ADD  CONSTRAINT [FK_EventCategory_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[EventCategory] CHECK CONSTRAINT [FK_EventCategory_Event]
GO
ALTER TABLE [dbo].[EventLocation]  WITH CHECK ADD  CONSTRAINT [FK_EventLocation_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[EventLocation] CHECK CONSTRAINT [FK_EventLocation_Event]
GO
ALTER TABLE [dbo].[EventLocation]  WITH CHECK ADD  CONSTRAINT [FK_EventLocation_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[EventLocation] CHECK CONSTRAINT [FK_EventLocation_Location]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_Event]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_User]
GO
ALTER TABLE [dbo].[EventRating]  WITH CHECK ADD  CONSTRAINT [FK_EventRating_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[EventRating] CHECK CONSTRAINT [FK_EventRating_Event]
GO
ALTER TABLE [dbo].[EventRating]  WITH CHECK ADD  CONSTRAINT [FK_EventRating_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[EventRating] CHECK CONSTRAINT [FK_EventRating_User]
GO
ALTER TABLE [dbo].[EventRequest]  WITH CHECK ADD  CONSTRAINT [FK_EventRequest_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[EventRequest] CHECK CONSTRAINT [FK_EventRequest_Event]
GO
ALTER TABLE [dbo].[EventRequest]  WITH CHECK ADD  CONSTRAINT [FK_EventRequest_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[EventRequest] CHECK CONSTRAINT [FK_EventRequest_User]
GO
