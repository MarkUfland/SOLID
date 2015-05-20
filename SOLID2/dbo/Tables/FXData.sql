CREATE TABLE [dbo].[FXData] (
    [Id]     INT             IDENTITY (1, 1) NOT NULL,
    [FXDate] DATETIME        NULL,
    [FXRate] DECIMAL (18, 5) NULL,
    CONSTRAINT [PK_FXData] PRIMARY KEY CLUSTERED ([Id] ASC)
);

