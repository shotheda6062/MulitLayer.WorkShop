CREATE TABLE [dbo].[CompanyConfing]
(
	[Id] UNIQUEIDENTIFIER NOT NULL  DEFAULT NEWSEQUENTIALID(), 
    [CompanyId] NVARCHAR(4) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_CompanyConfing] PRIMARY KEY NONCLUSTERED ([Id])
	
)


GO

CREATE CLUSTERED INDEX [CLIX_CompanyConfing_Column] ON [dbo].[CompanyConfing] ([CompanyId])
