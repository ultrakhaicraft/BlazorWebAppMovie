-- Create the database
CREATE DATABASE MovieDatabase;
GO

USE MovieDatabase;
GO

-- Create Account table
CREATE TABLE Account (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);
GO

-- Create Genre table
CREATE TABLE Genre (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- Create Movie table
CREATE TABLE Movie (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NULL,
    ReleaseDate DATE NOT NULL,
    GenreId INT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_Movie_Genre FOREIGN KEY (GenreId) REFERENCES Genre(Id)
);
GO

-- Add indexes for better performance
CREATE INDEX idx_movie_title ON Movie(Title);
CREATE INDEX idx_movie_releasedate ON Movie(ReleaseDate);
CREATE INDEX idx_account_email ON Account(Email);
GO

-- Insert some sample genres
INSERT INTO Genre (Name) VALUES
    (N'Action'),
    (N'Comedy'),
    (N'Drama'),
    (N'Science Fiction'),
    (N'Horror'),
    (N'Romance'),
    (N'Documentary'),
    (N'Animation');
GO

-- Insert a sample admin account
INSERT INTO Account (Email, Password, Role) VALUES
    (N'admin@movies.com', N'Addmin', N'Admin');
	INSERT INTO Account (Email, Password, Role) VALUES
    (N'ortis@movies.com', N'orris', N'Staff');
GO