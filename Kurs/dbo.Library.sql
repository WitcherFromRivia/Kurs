CREATE TABLE [dbo].[Library] (
    [Id]                   INT NOT NULL,
    [Название книги]       NVARCHAR (50) NULL,
    [Автор]                NVARCHAR (50) NULL,
    [Год издания]          NVARCHAR (50) NULL,
    [Издательство]         NVARCHAR (50) NULL,
    [Цена в гривнах]       NVARCHAR (50) NULL,
    [Состояние]            NVARCHAR (50) NULL,
    [Дата выдачи читателю] NVARCHAR (50) NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC)
);

