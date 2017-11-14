CREATE TABLE [dbo].[__MigrationLog] (
    [migration_id]    UNIQUEIDENTIFIER NOT NULL,
    [complete_dt]     DATETIME2 (7)    NOT NULL,
    [script_checksum] NVARCHAR (64)    NOT NULL,
    [applied_by]      NVARCHAR (100)   NOT NULL,
    [deployed]        TINYINT          DEFAULT ((1)) NOT NULL,
    [package_version] VARCHAR (255)    NULL,
    [release_version] VARCHAR (255)    NULL,
    [script_filename] NVARCHAR (255)   NOT NULL,
    [sequence_no]     INT              IDENTITY (1, 1) NOT NULL,
    [version]         VARCHAR (255)    NULL,
    CONSTRAINT [PK___MigrationLog] PRIMARY KEY CLUSTERED ([migration_id] ASC, [complete_dt] ASC, [script_checksum] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX___MigrationLog_Version]
    ON [dbo].[__MigrationLog]([version] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UX___MigrationLog_SequenceNo]
    ON [dbo].[__MigrationLog]([sequence_no] ASC);


GO
CREATE NONCLUSTERED INDEX [IX___MigrationLog_CompleteDt]
    ON [dbo].[__MigrationLog]([complete_dt] ASC);

