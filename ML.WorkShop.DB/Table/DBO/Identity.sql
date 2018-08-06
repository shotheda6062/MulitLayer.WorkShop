CREATE TABLE [dbo].[Identity]
(
	[Member_Id] UNIQUEIDENTIFIER NOT NULL , 
    [Password] NVARCHAR(50) NOT NULL, 
    [CreateDateTime] DATETIME NOT NULL, 
    [CreateUserId] NVARCHAR(50) NOT NULL, 
    [LastModifyDateTime] DATETIME NULL, 
    [LastModifyUserId] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Identity] PRIMARY KEY ([Member_Id]),
    CONSTRAINT [FK_Identity_ToTable] FOREIGN KEY ([Member_Id]) REFERENCES [Member]([Id]) ON DELETE CASCADE,
	
)

