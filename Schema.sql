-- Categories table
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL
);

-- Attributes table
CREATE TABLE Attributes (
    Id INT PRIMARY KEY IDENTITY,
    CategoryId INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    DataType NVARCHAR(50) NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Products table
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    CategoryId INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- ProductAttributes table (EAV model)
CREATE TABLE ProductAttributes (
    Id INT PRIMARY KEY IDENTITY,
    ProductId INT NOT NULL,
    AttributeId INT NOT NULL,
    Value NVARCHAR(200),
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    FOREIGN KEY (AttributeId) REFERENCES Attributes(Id)
);
