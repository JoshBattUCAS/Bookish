DROP DATABASE IF EXISTS bookish;
CREATE DATABASE bookish;
USE bookish;

CREATE TABLE book (
	BookID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	BookName VARCHAR(255) NOT NULL,
	Author VARCHAR(255)

);

CREATE TABLE person (
	UserID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(255) NOT NULL
);

CREATE TABLE book_copy (
	ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	BookID int NOT NULL,
	FOREIGN KEY (BookID) REFERENCES book(BookID),
	UserID int,
	FOREIGN KEY (UserID) REFERENCES person(UserID),
	DueDate date 
);

