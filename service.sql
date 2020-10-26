USE [Bd_tempdb]
GO

/****** Object:  Table [dbo].[Services]    Script Date: 25.10.2020 20:50:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Services](
	[WorkerId] [int] NOT NULL,
	[WorkId] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Date] [date] NOT NULL,
	[CarId] [int] NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[WorkerId] ASC,
	[WorkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Car_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Car] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Car_CarId]
GO

ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Work_WorkId] FOREIGN KEY([WorkId])
REFERENCES [dbo].[Work] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Work_WorkId]
GO

ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Worker_WorkerId] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Worker_WorkerId]
GO

