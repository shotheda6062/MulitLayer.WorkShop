CREATE TABLE [dbo].[Role]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID() , 
    [Administrator] BIT NULL, 
    [Member] BIT NULL, 
    [Lock] BIT NULL, 
    [CreateDateTime] DATETIME NOT NULL, 
    [CreateUserId] NVARCHAR(50) NOT NULL, 
    [LastModifyDateTime] DATETIME NULL, 
    [LastModifyUserId] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Role_ToTable] FOREIGN KEY (Id) REFERENCES [Identity]([Member_Id]) ON DELETE CASCADE
)
