SELECT
    Dept,
    Name,
    Salary
FROM Employees e
WHERE Salary = (
    SELECT MAX(Salary)
    FROM Employees
    WHERE Dept = e.Dept
);
