CREATE TABLE Customers
(
    CustomerID INT IDENTITY PRIMARY KEY,
    CustomerName VARCHAR(100),
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50)
);

CREATE TABLE SalesPersons
(
    SalesPersonID INT IDENTITY PRIMARY KEY,
    SalesPersonName VARCHAR(100)
);

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY,
    OrderDate DATE,
    CustomerID INT,
    SalesPersonID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (SalesPersonID) REFERENCES SalesPersons(SalesPersonID)
);

CREATE TABLE Products
(
    ProductID INT IDENTITY PRIMARY KEY,
    ProductName VARCHAR(100),
    UnitPrice DECIMAL(10,2)
);

CREATE TABLE OrderDetails
(
    OrderDetailID INT IDENTITY PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);





--Q2.  Third Highest Total Sales
SELECT DISTINCT
	SUM([OrderDetails].Quantity * [Products].UnitPrice) AS TotalSales
FROM
	Orders
	JOIN OrderDetails ON [Orders].OrderID = [OrderDetails].OrderID
	JOIN Products ON [OrderDetails].ProductID = [Products].ProductID
GROUP BY
	[Orders].OrderID
ORDER BY
	TotalSales DESC
OFFSET
	2 ROWS
FETCH NEXT
	1 ROW ONLY;

--Q3. GROUP BY & HAVING
SELECT
	[SalesPersons].SalesPersonName
FROM
	Orders
	JOIN OrderDetails ON [Orders].OrderID = [OrderDetails].OrderID
	JOIN Products ON [OrderDetails].ProductID = [Products].ProductID
	JOIN SalesPersons ON [Orders].SalesPersonID = [SalesPersons].SalesPersonID
GROUP BY
	[SalesPersons].SalesPersonName
HAVING
	SUM([OrderDetails].Quantity * [Products].UnitPrice) > 60000;


--Q5. String & Date Functions
SELECT
	UPPER([Customers].CustomerName) AS CustomerName,
	MONTH([Orders].OrderDate) AS OrderMonth
FROM
	Orders
	JOIN Customers ON [Orders].CustomerID = [Customers].CustomerID
WHERE
	YEAR([Orders].OrderDate) = 2024
	AND MONTH([Orders].OrderDate) = 1;
