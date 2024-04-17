CREATE TABLE Users (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255),
    age INT
);

INSERT INTO Users (name, age) VALUES
('John', 30),
('Alice', 25),
('Bob', 35),
('Sarah', 28),
('Michael', 40),
('Emma', 22),
('David', 32),
('Emily', 27),
('James', 38),
('Sophia', 29);

Select * From Users
