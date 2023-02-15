USE Task;
GO

IF OBJECT_ID('Apartments', 'U') IS NOT NULL
DROP TABLE Apartments;

IF OBJECT_ID('Houses', 'U') IS NOT NULL
DROP TABLE Houses;

IF OBJECT_ID('Streets', 'U') IS NOT NULL
DROP TABLE Streets;

IF OBJECT_ID('Cities', 'U') IS NOT NULL
DROP TABLE Cities;

GO

CREATE TABLE Cities 
(
id int NOT NULL PRIMARY KEY,
name varchar(100) NOT NULL
);

CREATE TABLE Streets 
(
id int NOT NULL PRIMARY KEY,
name varchar(100) NOT NULL,
city_id int NOT NULL,
FOREIGN KEY (city_id) REFERENCES Cities(id)
);

CREATE TABLE Houses 
(
id int NOT NULL PRIMARY KEY,
number varchar(50) NOT NULL,
street_id int NOT NULL,
FOREIGN KEY (street_id) REFERENCES Streets(id)
);

CREATE TABLE Apartments 
(
id int NOT NULL PRIMARY KEY,
area float NOT NULL,
house_id int NOT NULL,
FOREIGN KEY (house_id) REFERENCES Houses(id)
);

GO

INSERT INTO Cities (id, name)
VALUES
(1, 'Moscow'),
(2, 'Saint Petersburg'),
(3, 'Novosibirsk');

INSERT INTO Streets (id, name, city_id)
VALUES
(1, 'Leningradsky Prospekt', 1),
(2, 'Nevsky Prospekt', 2),
(3, 'Krasniy Prospekt', 3),
(4, 'Leninskiy Prospekt', 1),
(5, 'Voznesenskiy Prospekt', 2),
(6, 'Sibirskiy Prospekt', 3),
(7, 'Oktyabrsky Prospekt', 1),
(8, 'Griboyedov Canal', 2),
(9, 'Obvodny Canal', 3);

INSERT INTO Houses (id, number, street_id)
VALUES
(1, '1', 1),
(2, '2', 1),
(3, '3', 1),
(4, '4', 2),
(5, '5', 2),
(6, '6', 2),
(7, '7', 3),
(8, '8', 3),
(9, '9', 3),
(10, '10', 4),
(11, '11', 4),
(12, '12', 4),
(13, '13', 5),
(14, '14', 5),
(15, '15', 5),
(16, '16', 6),
(17, '17', 6),
(18, '18', 6),
(19, '19', 7),
(20, '20', 7),
(21, '21', 7),
(22, '22', 8),
(23, '23', 8),
(24, '24', 8),
(25, '25', 9),
(26, '26', 9),
(27, '27', 9);

INSERT INTO Apartments (id, area, house_id)
VALUES
(1, 100.00, 1),
(2, 150.00, 1),
(3, 200.00, 1),
(4, 250.00, 2),
(5, 300.00, 2),
(6, 350.00, 2),
(7, 400.00, 3),
(8, 450.00, 3),
(9, 500.00, 3),
(10, 550.00, 4),
(11, 600.00, 4),
(12, 650.00, 4),
(13, 700.00, 5),
(14, 750.00, 5),
(15, 800.00, 5),
(16, 850.00, 6),
(17, 900.00, 6),
(18, 950.00, 6),
(19, 1000.00, 7),
(20, 1050.00, 7),
(21, 1100.00, 7),
(22, 1150.00, 8),
(23, 1200.00, 8),
(24, 1250.00, 8),
(25, 1300.00, 9),
(26, 1350.00, 9),
(27, 1400.00, 9),
(28, 1450.00, 10),
(29, 1500.00, 10),
(30, 1550.00, 10),
(31, 1600.00, 11),
(32, 1650.00, 11),
(33, 1700.00, 11),
(34, 1750.00, 12),
(35, 1800.00, 12),
(36, 1850.00, 12),
(37, 1900.00, 13),
(38, 1950.00, 13),
(39, 2000.00, 13),
(40, 2050.00, 14),
(41, 2100.00, 14),
(42, 2150.00, 14),
(43, 2200.00, 15),
(44, 2250.00, 15),
(45, 2300.00, 15),
(46, 2350.00, 16),
(47, 2400.00, 16),
(48, 2450.00, 16),
(49, 2500.00, 17),
(50, 2550.00, 17),
(51, 2600.00, 17),
(52, 2650.00, 18),
(53, 2700.00, 18),
(54, 2750.00, 18),
(55, 2800.00, 19),
(56, 2850.00, 19),
(57, 2900.00, 19),
(58, 2950.00, 20),
(59, 3000.00, 20),
(60, 3050.00, 20),
(61, 3100.00, 21),
(62, 3150.00, 21),
(63, 3200.00, 21),
(64, 3250.00, 22),
(65, 3300.00, 22),
(66, 3350.00, 22),
(67, 3400.00, 23),
(68, 3450.00, 23),
(69, 3500.00, 23),
(70, 3550.00, 24),
(71, 3600.00, 24),
(72, 3650.00, 24),
(73, 3700.00, 25),
(74, 3750.00, 25),
(75, 3800.00, 25),
(76, 3850.00, 26),
(77, 3900.00, 26),
(78, 3950.00, 26),
(79, 4000.00, 27),
(80, 4050.00, 27),
(81, 4100.00, 27)
