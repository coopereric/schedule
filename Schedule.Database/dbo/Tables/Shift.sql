CREATE TABLE [dbo].[Shift] (
    [ShiftID]    INT      IDENTITY (1, 1) NOT NULL,
    [ShiftDate]  DATE     NOT NULL,
    [TimeIn]     DATETIME NULL,
    [TimeOut]    DATETIME NULL,
    [LunchStart] DATETIME NULL,
    [LunchEnd]   DATETIME NULL,
    CONSTRAINT [PK_Shift] PRIMARY KEY CLUSTERED ([ShiftID] ASC),
    CONSTRAINT [FK_Shift_Date] FOREIGN KEY ([ShiftDate]) REFERENCES [dbo].[Date] ([PKDate])
);


GO
CREATE NONCLUSTERED INDEX [IX_Shift_ShiftDate]
    ON [dbo].[Shift]([ShiftDate] ASC);

