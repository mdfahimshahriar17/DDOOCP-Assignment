CREATE TABLE [dbo].[tblActivities] (
    [ActivityID]     INT          IDENTITY (1, 1) NOT NULL,
    [UserID]         INT          NOT NULL,
    [ActivityType]   VARCHAR (50) NOT NULL,
    [Duration]       FLOAT (53)   NOT NULL,
    [Distance]       FLOAT (53)   NOT NULL,
    [Calories]       FLOAT (53)   NOT NULL,
    [Sets]           FLOAT (53)   NOT NULL,
    [Repetitions]    INT          NULL,
    [PosesCompleted] INT          NULL,
    [ElevationGain]  FLOAT (53)   NULL,
    [ActivityDate]   DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([ActivityID] ASC),
    CONSTRAINT [FK_tblActivities_tblUser] FOREIGN KEY ([UserID]) REFERENCES [dbo].[tblUser] ([Id])
);
