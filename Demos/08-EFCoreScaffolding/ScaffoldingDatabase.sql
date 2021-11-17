DROP TABLE IF EXISTS PostTag
DROP TABLE IF EXISTS Post
DROP TABLE IF EXISTS Tag
DROP TABLE IF EXISTS Blog
GO

CREATE TABLE Blog
(
  BlogId          INT           NOT NULL IDENTITY(1,1),
  BlogName        NVARCHAR(200) NOT NULL,
  BlogDescription NVARCHAR(500)     NULL,
  BlogUrl         NVARCHAR(500)     NULL,
  CONSTRAINT pkcBlog PRIMARY KEY CLUSTERED (BlogId)
);

EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Blog',                                 @value=N'Represents a blog managed by the system.',                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Blog', @level2name=N'BlogId',          @value=N'Identifier of the blog record.',                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Blog', @level2name=N'BlogName',        @value=N'The name of the blog.',                                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Blog', @level2name=N'BlogDescription', @value=N'A description of the blog.',                                          @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Blog', @level2name=N'BlogUrl',         @value=N'The URL to the blog''s home page.',                                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Blog', @level2name=N'pkcBlog',         @value=N'Defines the primary key for the Blog table using the BlogId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO

CREATE TABLE Tag
(
  TagId          INT           NOT NULL IDENTITY(1,1),
  TagName        NVARCHAR(30)  NOT NULL,
  TagDescription NVARCHAR(200)     NULL,
  CONSTRAINT pkcTag PRIMARY KEY CLUSTERED (TagId)
);

EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Tag',                                @value=N'Represents the tags (wword or phrase describing a blog post. used in the system.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Tag', @level2name=N'TagId',          @value=N'Identifier of the tag record.',                                                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Tag', @level2name=N'TagName',        @value=N'The name of the tag (what is shown to users).',                                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Tag', @level2name=N'TagDescription', @value=N'A short description of the tag.',                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Tag', @level2name=N'pkcTag',         @value=N'Defines the primary key for the Tag table using the TagId column.',                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO


CREATE TABLE Post
(
  PostId        INT           NOT NULL IDENTITY,
  Title     NVARCHAR(200) NOT NULL,
  Contents  NVARCHAR(MAX) NOT NULL,
  PostedOn  DATETIME2     NOT NULL,
  UpdatedOn DATETIME2         NULL,
  BlogId    INT           NOT NULL,
  CONSTRAINT pkcPost PRIMARY KEY CLUSTERED (PostId),
  CONSTRAINT fkPost_Blog FOREIGN KEY (BlogId) REFERENCES Blog (BlogId)
);

EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Post',                             @value=N'Represents a blog post.',                                                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Post', @level2name=N'PostId',      @value=N'Identifier of the post record.',                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Post', @level2name=N'Title',       @value=N'Title of the blog post.',                                                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Post', @level2name=N'Contents',    @value=N'Contents of the blog post.',                                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Post', @level2name=N'PostedOn',    @value=N'The date and time the blog post is posted.',                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Post', @level2name=N'UpdatedOn',   @value=N'The date and time of the last updat to the blog post.',                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Post', @level2name=N'BlogId',      @value=N'Identifier of the Blog the post is associated with.',                                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Post', @level2name=N'pkcPost',     @value=N'Defines the primary key for the Post table using the PostId column.',                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='Post', @level2name=N'fkPost_Blog', @value=N'Defines the relationship between the Post and the Blog table using the BlogId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO

CREATE TABLE PostTag
(
  PostId INT NOT NULL,
  TagId  INT NOT NULL,
  CONSTRAINT pkcPostTag PRIMARY KEY (PostId, TagId),
  CONSTRAINT fkPostTag_Post FOREIGN KEY (PostId) REFERENCES Post (PostId) ON DELETE CASCADE,
  CONSTRAINT fkPostTag_Tag FOREIGN KEY (TagId) REFERENCES Tag (TagId) ON DELETE CASCADE
);

EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='PostTag',                                @value=N'Defines the tags a post is associated with.',                                              @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='PostTag', @level2name=N'PostId',         @value=N'Identifier of the assocated post.',                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='PostTag', @level2name=N'TagId',          @value=N'Identifier of the assocated tag.',                                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='PostTag', @level2name=N'pkcPostTag',     @value=N'Defines the primary key for the PostTag table using the PostId and TagId columns.',        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='PostTag', @level2name=N'fkPostTag_Post', @value=N'Defines the relationship between the PostTag and the Post table using the PostId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'dbo', @level1name='PostTag', @level2name=N'fkPostTag_Tag',  @value=N'Defines the relationship between the PostTag and the Tag table using the TagId column.',   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO