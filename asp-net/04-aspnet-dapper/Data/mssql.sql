-- Microsoft SQL Server

-- Create DB
CREATE DATABASE bookcasedb;

-- Create Tables books
CREATE TABLE books (
  id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  author VARCHAR(255) NOT NULL,
  pages INT NOT NULL,
  year INT NOT NULL,
  cover NVARCHAR(MAX)
);

-- Insert Data
INSERT INTO books (id, title, author, pages, year, cover) VALUES
(NEWID(), 'The Lord of the Rings', 'J.R.R. Tolkien', 1200, 1954, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1566425108i/33.jpg'),
(NEWID(), 'Game of Thrones', 'George R. R. Martin', 694, 1996, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1273763400i/8189620.jpg'),
(NEWID(), 'Harry Potter and the Sorcerer''s Stone', 'J.K. Rowling', 223, 1997, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1550337333i/15868.jpg'),
(NEWID(), '1984', 'George Orwell', 328, 1949, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1657781256i/61439040.jpg'),
(NEWID(), 'Zombie Apocalypse', 'Manel Loreiro', 444, 2001, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1422626176i/24762432.jpg'),
(NEWID(), 'Dracula', 'Bram Stoker', 418, 1897, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1387151694i/17245.jpg');
