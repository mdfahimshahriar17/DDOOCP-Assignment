CREATE TABLE [dbo].[tblUserGoals] (
    [GoalID]       INT IDENTITY (1, 1) NOT NULL,
    [UserID]       INT NOT NULL,
    [GoalCalories] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([GoalID] ASC),
    CONSTRAINT [FK_tblUserGoals_tblUser] FOREIGN KEY ([UserID]) REFERENCES [dbo].[tblUser] ([Id])
);
