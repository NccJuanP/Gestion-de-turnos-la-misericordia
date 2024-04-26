-- Active: 1713910552041@@baquazvjeajolsh8tvxo-mysql.services.clever-cloud.com@3306@baquazvjeajolsh8tvxo

-- Crear la tabla DocumentTypes
CREATE TABLE DocumentTypes (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    type VARCHAR(45) UNIQUE
);

-- Insertar datos en DocumentTypes
INSERT INTO DocumentTypes (type) VALUES 
('Cedula'),
('Tarjeta de identidad'),
('Cedula de extranjeria'),
('Documento de afiliacion');

-- Crear la tabla EndingAttentions
CREATE TABLE EndingAttentions (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Finished VARCHAR(45) UNIQUE
);

-- Insertar datos en EndingAttentions
INSERT INTO EndingAttentions (Finished) VALUES 
('Usuario no atendido'),
('Usuario atendido');

-- Crear la tabla AttentionPreferences
CREATE TABLE AttentionPreferences (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Preference VARCHAR(45) UNIQUE
);

-- Insertar datos en AttentionPreferences
INSERT INTO AttentionPreferences (Preference) VALUES 
('Si'),
('No');

-- Crear la tabla Users
CREATE TABLE Users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    DocumentType INT,
    DocumentNumber INT,
    Firstname VARCHAR(45),
    Lastname VARCHAR(45),
    Email VARCHAR(150),
    Phone VARCHAR(45),
    FOREIGN KEY (DocumentType) REFERENCES DocumentTypes(Id)
);

-- Crear la tabla Employees
CREATE TABLE Employees (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    DocumentType INT,
    DocumentNumber INT,
    Firstname VARCHAR(45),
    Lastname VARCHAR(45),
    Email VARCHAR(150),
    Phone VARCHAR(45),
    Password VARCHAR(45),
    Modulo int,
    FOREIGN KEY (DocumentType) REFERENCES DocumentTypes(Id)
);

-- Crear la tabla Attentions
CREATE TABLE Attentions (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    AttentionPreference INT,
    NumAttention VARCHAR(20),
    UserId INT,
    EmployeeId INT,
    EndingAttention INT,
    DateAttentionExit DATETIME,
    DateAttentionEnter DATETIME,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);


-- Insertar datos en Employees
INSERT INTO Employees (DocumentType, DocumentNumber, Firstname, Lastname, Email, Phone) VALUES 
(1, 10001, 'John', 'Doe', 'john.doe@example.com', '1234567890'),
(2, 10002, 'Jane', 'Smith', 'jane.smith@example.com', '2345678901'),
(3, 10003, 'Michael', 'Johnson', 'michael.johnson@example.com', '3456789012'),
(1, 10004, 'Emily', 'Brown', 'emily.brown@example.com', '4567890123'),
(2, 10005, 'Daniel', 'Martinez', 'daniel.martinez@example.com', '5678901234');

-- Insertar datos en Users
INSERT INTO Users (DocumentType, DocumentNumber, Firstname, Lastname, Email, Phone) VALUES 
(1, 20001, 'Alice', 'Johnson', 'alice.johnson@example.com', '6789012345'),
(2, 20002, 'Robert', 'Williams', 'robert.williams@example.com', '7890123456'),
(1, 20003, 'Samantha', 'Jones', 'samantha.jones@example.com', '8901234567'),
(3, 20004, 'David', 'Davis', 'david.davis@example.com', '9012345678'),
(1, 20005, 'Olivia', 'Miller', 'olivia.miller@example.com', '0123456789'),
(2, 20006, 'Matthew', 'Garcia', 'matthew.garcia@example.com', '1234567890'),
(1, 20007, 'Sophia', 'Rodriguez', 'sophia.rodriguez@example.com', '2345678901'),
(3, 20008, 'William', 'Hernandez', 'william.hernandez@example.com', '3456789012'),
(1, 20009, 'Emma', 'Lopez', 'emma.lopez@example.com', '4567890123'),
(2, 20010, 'James', 'Gonzalez', 'james.gonzalez@example.com', '5678901234');
