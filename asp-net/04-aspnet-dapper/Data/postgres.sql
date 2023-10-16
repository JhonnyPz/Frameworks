-- PostgreSQL

-- Create DB
CREATE DATABASE bookcasedb;

-- Using
\c bookcasedb;

-- Create Tables books
CREATE TABLE books (
  id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  author VARCHAR(255) NOT NULL,
  pages INT NOT NULL,
  year INT NOT NULL,
  cover TEXT
);

-- Insert Data
INSERT INTO books (id, title, author, pages, year, cover) VALUES
(gen_random_uuid(), 'The Lord of the Rings', 'J.R.R. Tolkien', 1200, 1954, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1566425108i/33.jpg'),
(gen_random_uuid(), 'Game of Thrones', 'George R. R. Martin', 694, 1996, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1273763400i/8189620.jpg'),
(gen_random_uuid(), 'Harry Potter and the Sorcerers Stone', 'J.K. Rowling', 223, 1997, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1550337333i/15868.jpg'),
(gen_random_uuid(), '1984', 'George Orwell', 328, 1949, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1657781256i/61439040.jpg'),
(gen_random_uuid(), 'Zombie Apocalypse', 'Manel Loreiro', 444, 2001, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1422626176i/24762432.jpg'),
(gen_random_uuid(), 'Dracula', 'Bram Stoker', 418, 1897, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1387151694i/17245.jpg');