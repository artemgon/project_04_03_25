CREATE TABLE [dbo].[Students_Table] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [LastName]  NVARCHAR (50)  CONSTRAINT [DF_Students_Table_LastName] DEFAULT (N'Doe') NOT NULL,
    [FirstName] NVARCHAR (50)  CONSTRAINT [DF_Students_Table_FirstName] DEFAULT (N'John') NOT NULL,
    [BirthDate] DATE           NOT NULL,
    [Grants]    DECIMAL (6, 2) NULL,
    [Email]     NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Students_Table] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Student_Email] UNIQUE NONCLUSTERED ([Email] ASC)
);

