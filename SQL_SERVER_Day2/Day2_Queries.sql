----------8. A trigger to adjust product stock levels when a stock movement occurs------------

CREATE TRIGGER trg_UpdateProductStock
ON StockMovements
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;  
    UPDATE p
    SET p.Quantity = 
        CASE 
            WHEN i.MovementType = 'Stock Added' THEN p.Quantity + i.Quantity
            WHEN i.MovementType = 'Stock Removed' THEN p.Quantity - i.Quantity
            ELSE p.Quantity
        END
    FROM Products p
    INNER JOIN inserted i ON p.ProductID = i.ProductID;
END;

--ex--

INSERT INTO StockMovements (StockID, ProductID, Quantity, MovementType, Date, SupplierID) VALUES
(16, 1, 10, 'Stock Added', '2025-02-20', 1);
SELECT * FROM Products;

----------9.A cursor to loop through stock movement records and generate inventory reports----------

DECLARE @StockID INT, @ProductID INT, @Quantity INT, @MovementType VARCHAR(50), @Date DATE, @SupplierID INT;

DECLARE stock_cursor CURSOR FOR 
SELECT StockID, ProductID, Quantity, MovementType, Date, SupplierID 
FROM StockMovements;

OPEN stock_cursor;

FETCH NEXT FROM stock_cursor INTO @StockID, @ProductID, @Quantity, @MovementType, @Date, @SupplierID;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Stock ID: ' + CAST(@StockID AS VARCHAR) + ', Product ID: ' + CAST(@ProductID AS VARCHAR) +
          ', Quantity: ' + CAST(@Quantity AS VARCHAR) + ', Movement Type: ' + @MovementType +
          ', Date: ' + CAST(@Date AS VARCHAR) + ', Supplier ID: ' + CAST(@SupplierID AS VARCHAR);

    FETCH NEXT FROM stock_cursor INTO @StockID, @ProductID, @Quantity, @MovementType, @Date, @SupplierID;
END;

CLOSE stock_cursor;
DEALLOCATE stock_cursor;

----------10.Store temporary stock movements before finalizing transactions----------

CREATE TABLE #TempStockMovements (
    StockID INT PRIMARY KEY,
    ProductID INT,
    Quantity INT,
    MovementType VARCHAR(50),
    Date DATE,
    SupplierID INT
);

INSERT INTO #TempStockMovements (StockID, ProductID, Quantity, MovementType, Date, SupplierID)
VALUES 
(9, 3, 2, 'Stock Added', '2025-02-25', 3),
(10, 4, 5, 'Stock Removed', '2025-02-26', 4);

INSERT INTO StockMovements (StockID, ProductID, Quantity, MovementType, Date, SupplierID)
SELECT * FROM #TempStockMovements;

DROP TABLE #TempStockMovements;

SELECT * FROM StockMovements;

----------11. A CTE to get a list of low-stock products requiring restocking----------

WITH LowStockProducts AS (
    SELECT ProductID, Name, Category, Quantity
    FROM Products
    WHERE Quantity < 20
)
SELECT * FROM LowStockProducts;

----------12. A DEFAULT constraint to set the stock quantity to zero if not specified----------

ALTER TABLE Products 
ADD CONSTRAINT DF_Products_Quantity DEFAULT 0 FOR Quantity;