﻿CREATE TABLE [dbo].[Book]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [PublisherId] UNIQUEIDENTIFIER NULL, 
    [LanguageId] UNIQUEIDENTIFIER NULL, 
    [SerieId] UNIQUEIDENTIFIER NULL, 
    [Title] NVARCHAR(1024) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL,
    CONSTRAINT PK_BOOK PRIMARY KEY (Id),
    CONSTRAINT FK_BOOK_EDITOR FOREIGN KEY (PublisherId) REFERENCES Publisher(Id),
    CONSTRAINT FK_BOOK_LANGUAGE FOREIGN KEY (LanguageId) REFERENCES Language(Id),
    CONSTRAINT FK_BOOK_SERIE FOREIGN KEY (SerieId) REFERENCES Serie(Id)
)

GO
CREATE INDEX [IX_BOOK_EDITOR] ON [dbo].[Book] ([PublisherId])
GO
CREATE INDEX [IX_BOOK_LANGUAGE] ON [dbo].[Book] ([LanguageId])
GO
CREATE INDEX [IX_BOOK_SERIE] ON [dbo].[Book] ([SerieId])
