Use master;
GO

CREATE DATABASE RepertoireManagementSystem;
GO

Use RepertoireManagementSystem;
GO

CREATE TABLE SongLibrary(
	SongId UNIQUEIDENTIFIER DEFAULT NEWID(),
	Title varchar(25) NOT NULL,
	Artist varchar(50) NOT NULL,
	CONSTRAINT SongLibrary_PK PRIMARY KEY (SongId)
);