CREATE TABLE [dbo].[Member]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(), 
    [WorkId] INT NOT NULL,
	[CompanyId] UNIQUEIDENTIFIER NOT NULL,
    [Email] NVARCHAR(50) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Age] INT NOT NULL, 
    [CreateDateTime] DATETIME NOT NULL, 
    [CreateUserId] NVARCHAR(50) NOT NULL, 
    [LastModifyDateTime] DATETIME NULL, 
    [LastModifyUserId] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Member] PRIMARY KEY NONCLUSTERED ([Id]), 
    CONSTRAINT [FK_Member_ToTable] FOREIGN KEY ([CompanyId]) REFERENCES [CompanyConfing]([Id])  ON DELETE CASCADE ,   
	CONSTRAINT u_Customer_Id UNIQUE ([WorkId], [CompanyId])
)

GO

CREATE CLUSTERED INDEX [CLIX_Member_Column] ON  [dbo].[Member] ([WorkId],[CompanyId] DESC)
