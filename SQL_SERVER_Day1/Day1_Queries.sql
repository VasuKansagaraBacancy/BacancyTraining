------------1.Link Products to StockMovements and connect Suppliers if needed (for supply orders)------------

--(Foreign key for the linking StockMovements to products and suppliers that will be done while creating table)----

------------2. Set up PKs and enforce FKs for maintaining integrity------------

EXEC sp_pkeys 'Products';
EXEC sp_pkeys 'Suppliers';

------------3. Views to track current stock levels and stock movement history------------

CREATE VIEW view_CurrentStockLevels AS
SELECT 
    ProductID, 
    SUM(Quantity) AS CurrentStock
FROM StockMovements
GROUP BY ProductID;

SELECT * FROM view_CurrentStockLevels;

CREATE VIEW view_StockMovementHistory AS
SELECT 
    StockID, 
    ProductID, 
    Quantity, 
    MovementType, 
    Date, 
    SupplierID
FROM StockMovements;

SELECT * FROM view_StockMovementHistory;

------------4. A function to calculate the total stock value for a product------------

CREATE FUNCTION fn_TotalStockValue(@ProductID INT)
RETURNS INT
AS
BEGIN
    DECLARE @TotalValue INT;

    SELECT @TotalValue = SUM(p.Price * sm.Quantity)
    FROM StockMovements sm
    JOIN Products p ON sm.ProductID = p.ProductID
    WHERE sm.ProductID = @ProductID;

    RETURN COALESCE(@TotalValue, 0);  
END;

SELECT dbo.fn_TotalStockValue(2) AS TotalStockValue;

------------5. A stored procedure to process incoming inventory and update stock levels------------

CREATE PROCEDURE sp_ProcessIncomingStock
    @StockID INT,
    @ProductID INT,
    @Quantity INT,
    @SupplierID INT,
    @MovementDate DATE
AS
BEGIN
    INSERT INTO StockMovements (StockID,ProductID, Quantity, MovementType, Date, SupplierID)
    VALUES (@StockID ,@ProductID, @Quantity, 'Stock Added', @MovementDate, @SupplierID);
    UPDATE Products
    SET Quantity = Quantity + @Quantity
    WHERE ProductID = @ProductID;
END;

EXEC sp_ProcessIncomingStock @StockID=7,@ProductID = 1, @Quantity = 20, @SupplierID = 3, @MovementDate = '2025-03-02';


------------6. JOIN queries to combine data from Products, Suppliers, and StockMovements for detailed inventory reports------------

SELECT 
    sm.StockID,
    sm.ProductID,
    p.Name AS ProductName,
    p.Category,
    sm.Quantity,
    sm.MovementType,
    sm.Date,
    sm.SupplierID,
    s.Name AS SupplierName,
    s.Contact AS SupplierContact
FROM StockMovements sm
JOIN Products p ON sm.ProductID = p.ProductID
JOIN Suppliers s ON sm.SupplierID = s.SupplierID;

----------7. Indexes on ProductID, SupplierID, and Date to enhance query performance------------

CREATE INDEX idx_StockMovements_ProductID 
ON StockMovements (ProductID);

CREATE INDEX idx_StockMovements_SupplierID 
ON StockMovements (SupplierID);

CREATE INDEX idx_StockMovements_Date 
ON StockMovements (Date);

