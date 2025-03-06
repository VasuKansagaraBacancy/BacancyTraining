------------Products Table Created and values are inserted-----------

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Category VARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    Price INT NOT NULL
);

INSERT INTO Products (ProductID, Name, Category, Quantity, Price) VALUES
(1, 'Gaming Laptop', 'Electronics', 5, 75000),
(2, 'Bluetooth Speaker', 'Accessories', 20, 3500),
(3, 'Air Conditioner', 'Home', 8, 42000),
(4, 'Running Shoes', 'Fashion', 30, 4500),
(5, 'Smartwatch', 'Electronics', 15, 12000);

SELECT * FROM Products;

------------Suppliers Table Created and values are inserted-----------

CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Contact VARCHAR(10) NOT NULL,
    Address VARCHAR(100) NOT NULL
);

INSERT INTO Suppliers (SupplierID, Name, Contact, Address) VALUES
(1, 'Tech Distributors Ltd.', '9876543210', 'Ahmedabad, Gujarat'),
(2, 'SoundWave Solutions', '9823456789', 'Mumbai, Maharashtra'),
(3, 'Cooling Experts Pvt. Ltd.', '9812345678', 'Delhi, India'),
(4, 'FitGear India', '9801234567', 'Bangalore, Karnataka'),
(5, 'Gadget Hub', '9790123456', 'Chennai, Tamil Nadu');

SELECT * FROM Suppliers;

------------StockMovements Table Created and values are inserted-----------

CREATE TABLE StockMovements (
    StockID INT PRIMARY KEY,  
    ProductID INT NOT NULL, 
    Quantity INT NOT NULL,
    MovementType VARCHAR(50) NOT NULL,  
    Date DATE NOT NULL,
    SupplierID INT,
    CONSTRAINT FK_StockMovements_Products FOREIGN KEY (ProductID) 
        REFERENCES Products(ProductID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_StockMovements_Suppliers FOREIGN KEY (SupplierID) 
        REFERENCES Suppliers(SupplierID) ON DELETE SET NULL ON UPDATE CASCADE
);

INSERT INTO StockMovements (StockID, ProductID, Quantity, MovementType, Date, SupplierID) VALUES
(1, 1, 10, 'Stock Added', '2025-02-20', 1),
(2, 2, 5, 'Stock Removed', '2025-02-21', 2),  
(3, 3, 3, 'Stock Added', '2025-02-22', 4),
(4, 1, 20, 'Stock Added', '2025-02-23', 3), 
(5, 2, 2, 'Stock Removed', '2025-02-24', 5);

SELECT * FROM StockMovements;

