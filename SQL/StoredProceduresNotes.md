# SQL Server Stored Procedures

## High-Level Overview

### What Are Stored Procedures?
Stored procedures are precompiled collections of SQL statements and optional control-of-flow statements that are stored under a name and processed as a unit. They are basically "mini programs" written in SQL and stored inside the database server.

### Benefits of Using Stored Procedures
1. **Performance**: Stored procedures are precompiled, which means the SQL Server can execute them more quickly.
2. **Reusability**: Stored procedures can be called from multiple programs or scripts, reducing redundant code.
3. **Security**: They can provide an extra layer of security, allowing you to grant permission to execute the stored procedure without giving full access to the underlying tables.
4. **Centralization**: Logic can be centralized in one location rather than being spread across multiple client applications.
5. **Transactional Control**: Stored procedures can be designed to be atomic and can roll back transactions in case of failure.

## Syntax Overview

The basic syntax for creating a stored procedure in SQL Server is as follows:

```sql
CREATE PROCEDURE ProcedureName
    @param1 datatype,
    @param2 datatype,
    ...
AS
    -- SQL statements
    -- Control-of-Flow statements
GO
```

- `ProcedureName`: The name of the stored procedure.
- `@param1, @param2,...`: Parameters to pass into the stored procedure.
- `datatype`: The type of parameter such as `int`, `varchar`, etc.
- `AS`: Keyword that precedes the block of SQL statements.
- `GO`: Terminates a batch of SQL statements in SQL Server.

### Calling a Stored Procedure

To call a stored procedure, you can use the `EXEC` keyword, like so:

```sql
EXEC ProcedureName @param1=value1, @param2=value2, ...
```

## Examples

### Basic Stored Procedure Without Parameters

Let's start with the simplest example, a stored procedure that doesn't require any parameters and returns all records from a `Product` table.

```sql
CREATE PROCEDURE GetAllProducts
AS
    SELECT * FROM Product;
GO
```

**To call this stored procedure:**

```sql
EXEC GetAllProducts;
```

### Stored Procedure With Input Parameters

This example introduces a stored procedure with input parameters. The stored procedure retrieves information about a catagory based on its id.

```sql
CREATE PROCEDURE GetCatagory
    @CategoryID float
AS
    SELECT CategoryID, Name, Description FROM Category WHERE CategoryID = @CategoryID;
GO
```

**To call this stored procedure:**

```sql
EXEC GetCatagory @CategoryID = 10;
```

### Stored Procedure With Output Parameters

This stored procedure returns the total number of products via an output parameter.

```sql
CREATE PROCEDURE GetTotalProducts
    @total int OUTPUT
AS
    SELECT @total = COUNT(*) FROM Product;
GO
```

**To call this stored procedure:**

```sql
DECLARE @totalProducts int;
EXEC GetTotalProducts @total=@totalProducts OUTPUT;
PRINT @totalProducts;
```

### Stored Procedure With Conditional Statements

This example showcases how you can use conditional logic (`IF...ELSE`) within stored procedures.

```sql
CREATE PROCEDURE IsPriceZero
    @ProductID int,
    @isZero bit OUTPUT
AS
    DECLARE @price money;
    SELECT @price = Price FROM Product WHERE ProductID = @ProductID;
    
    IF @price = 0::money
        SET @isZero = 1;
    ELSE
        SET @isZero = 0;
GO
```

**To call this stored procedure:**

```sql
DECLARE @result bit;
EXEC IsPriceZero @ProductID=1, @isZero=@result OUTPUT;
PRINT @result;
```

### Stored Procedure With Transactions

Here, we introduce transactions to make sure that all operations are completed successfully before committing the changes.

```sql
CREATE PROCEDURE UpdateProductDescription
    @ProductID int,
    @newDescription nvarchar(max)
AS
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Product SET Description = @newDescription WHERE ProductID = @ProductID;
        -- More SQL statements can be added here
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
GO
```

**To call this stored procedure:**

```sql
EXEC UpdateProductDescription @ProductID=1, @newDescription=N'Lorem fix thing here ipsum dolor sit amet, consectetur adipiscing elit. Donec malesuada lobortis ipsum. Donec imperdiet, ligula quis vulputate feugiat, sem justo cursus lectus, blandit ultrices lacus arcu ac ante. Vestibulum in posuere turpis. Donec ut tincidunt lacus.';
```