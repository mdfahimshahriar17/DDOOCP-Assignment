-- Clean Task 1 database schema for Fitness Tracker
CREATE TABLE [dbo].[tblUser]
(
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Username] VARCHAR(50) NOT NULL UNIQUE,
    [Password] VARCHAR(50) NOT NULL
);

CREATE TABLE [dbo].[tblActivities]
(
    [ActivityID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserID] INT NOT NULL,
    [ActivityType] VARCHAR(50) NOT NULL,
    [Duration] FLOAT NOT NULL,       -- Metric 1 storage
    [Distance] FLOAT NOT NULL,       -- Metric 2 storage
    [Calories] FLOAT NOT NULL,
    [Sets] FLOAT NOT NULL,           -- Metric 3 storage
    [Repetitions] INT NULL,
    [PosesCompleted] INT NULL,
    [ElevationGain] FLOAT NULL,
    [ActivityDate] DATETIME NOT NULL,
    CONSTRAINT [FK_tblActivities_tblUser] FOREIGN KEY ([UserID]) REFERENCES [dbo].[tblUser] ([Id])
);

CREATE TABLE [dbo].[tblUserGoals]
(
    [GoalID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserID] INT NOT NULL,
    [GoalCalories] INT NOT NULL,
    CONSTRAINT [FK_tblUserGoals_tblUser] FOREIGN KEY ([UserID]) REFERENCES [dbo].[tblUser] ([Id])
);

CREATE TABLE [dbo].[tblAppSettings]
(
    [SettingKey] VARCHAR(80) NOT NULL PRIMARY KEY,
    [SettingValue] VARCHAR(200) NULL
);
