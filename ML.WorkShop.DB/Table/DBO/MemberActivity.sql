CREATE TABLE [dbo].[MemberActivity]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(), 
    [Member_Id] UNIQUEIDENTIFIER NOT NULL, 
    [LoginDateTime] DATETIME NULL, 
    [LastModifyPasswordDate] DATETIME NULL, 
    [Remark] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_MemberActivity_ToTable] FOREIGN KEY ([Member_Id]) REFERENCES [Member]([Id]) ON DELETE CASCADE
)
