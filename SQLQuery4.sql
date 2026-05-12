-- User goals table. Correct spelling is GoalCalories.
CREATE TABLE [dbo].[tblUserGoals]
(
    [GoalID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserID] INT NOT NULL,
    [GoalCalories] INT NOT NULL,
    CONSTRAINT [FK_tblUserGoals_tblUser] FOREIGN KEY ([UserID]) REFERENCES [dbo].[tblUser] ([Id])
);
