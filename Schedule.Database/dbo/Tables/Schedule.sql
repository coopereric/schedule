CREATE TABLE [dbo].[Schedule] (
    [ScheduleID]  INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [LastUpdated] DATETIME       NULL,
    [PKDate]      DATE           NOT NULL,
    [ShiftID]     INT            NOT NULL,
    [UserId]      NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED ([ScheduleID] ASC),
    CONSTRAINT [FK_Schedule_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Schedule_Date] FOREIGN KEY ([PKDate]) REFERENCES [dbo].[Date] ([PKDate]),
    CONSTRAINT [FK_Schedule_Shift] FOREIGN KEY ([ShiftID]) REFERENCES [dbo].[Shift] ([ShiftID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Schedule_UserId]
    ON [dbo].[Schedule]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Schedule_ShiftID]
    ON [dbo].[Schedule]([ShiftID] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Schedule]
    ON [dbo].[Schedule]([ScheduleID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Schedule_PKDate]
    ON [dbo].[Schedule]([PKDate] ASC);

