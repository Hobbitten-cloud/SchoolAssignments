USE SubstituteTeacher;
--------------------------------------------------
-- DROPS TABLES
DROP TABLE IF EXISTS SubstituteSubject;
DROP TABLE IF EXISTS Schedule;
DROP TABLE IF EXISTS Subject;
DROP TABLE IF EXISTS Substitute;
--------------------------------------------------

--------------------------------------------------------------------------------------------
-- Creates table Substitute
CREATE TABLE Substitute(
Substitute_Id Int IDENTITY (1,1),
Name NVarChar(255) NOT NULL,
Email NVarChar(255) NOT NULL,
Region NVarChar(255) NOT NULL,
Phone NVarChar(255) NOT NULL,
PersonNumber NVarChar(255) NOT NULL,
Verified Bit NOT NULL, -- 0 = false & 1 = true
CONSTRAINT PK_Substitute PRIMARY KEY (Substitute_Id)
)

-- Inserts values into Substitute table
INSERT INTO Substitute (Name, Email, Region, Phone, PersonNumber, Verified)
VALUES
('Peter', 'peter@gmail.com', 'SydFyn', '30239459', '23849420-3024', 1),
('Anna', 'anna@example.com', 'NorthCity', '30485729', '29485720-5839', 1),
('John', 'john@example.com', 'WestTown', '39847562', '39485729-4756', 1),
('Emily', 'emily@example.com', 'EastSide', '30294857', '20394857-3928', 1),
('Michael', 'michael@example.com', 'SouthVille', '30594857', '30485729-5829', 1),
('Sophia', 'sophia@example.com', 'CentralPark', '30194857', '20594857-3019', 1),
('David', 'david@example.com', 'Uptown', '30948572', '20847592-3857', 1),
('Olivia', 'olivia@example.com', 'Downtown', '30294758', '20394857-4758', 1),
('James', 'james@example.com', 'Hillside', '30485792', '20485792-3948', 0),
('Isabella', 'isabella@example.com', 'Greenfield', '30984752', '20394857-5837', 0),
('Daniel', 'daniel@example.com', 'Lakeshore', '30594872', '20485729-5832', 1)

--------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------
-- Creates table Schedule
CREATE TABLE Schedule(
Schedule_Id Int IDENTITY (1,1),
Date Date NOT NULL,
Availability Int NOT NULL,
Substitute_Id Int NOT NULL,
CONSTRAINT PK_Schedule PRIMARY KEY (Schedule_Id),
CONSTRAINT FK_Substitute FOREIGN KEY (Substitute_Id) REFERENCES Substitute(Substitute_Id)
)

-- Inserts values into Schedule table
INSERT INTO Schedule (Date, Availability, Substitute_Id)
VALUES
('2025-04-06', 1, 1),
('2025-04-07', 2, 2),
('2025-04-08', 3, 3),
('2025-04-09', 3, 4),
('2025-04-10', 1, 5),
('2025-04-11', 2, 6),
('2025-04-12', 3, 7),
('2025-04-13', 2, 8),
('2025-04-14', 1, 9),
('2025-04-15', 2, 10),
('2025-04-16', 3, 11)
--------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------
-- Creates table Subject
CREATE TABLE Subject(
Subject_Id Int IDENTITY (1,1),
Name NVarChar(255) NOT NULL,
Level Int NOT NULL,
CONSTRAINT PK_Subject PRIMARY KEY (Subject_Id),
)

-- Inserts values into Subject table
INSERT INTO Subject (Name, Level)
VALUES
('Matematik', 1),
('Matematik', 2),
('Engelsk', 3),
('Engelsk', 2),
('Fysik', 6),
('Fysik', 8),
('BilledKunst', 2),
('BilledKunst', 1),
('Dansk', 6),
('Dansk', 3),
('Idræt', 7)
--------------------------------------------------------------------------------------------

--------------------------------------------------------------------------------------------
-- Creates table SubstituteSubject
CREATE TABLE SubstituteSubject(
Substitute_Id Int NOT NULL,
Subject_Id Int NOT NULL,
CONSTRAINT PK_SubstituteSubject PRIMARY KEY (Substitute_Id, Subject_Id),
CONSTRAINT FK_SubstituteSubject_Substitute FOREIGN KEY (Substitute_Id) REFERENCES Substitute(Substitute_Id),
CONSTRAINT FK_SubstituteSubject_Subject FOREIGN KEY (Subject_Id) REFERENCES Subject(Subject_Id)
)

-- Inserts values into SubstituteSubject table
INSERT INTO SubstituteSubject (Substitute_Id, Subject_Id)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10),
(11, 11)
--------------------------------------------------------------------------------------------