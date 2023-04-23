Sql - querys
1. SELECT *
FROM Empoyee
WHERE Salary = (
  SELECT MAX(Salary)
  FROM Empoyee
);

2. WITH RECURSIVE manager_tree(employee.id, chief_id, depth) AS (
  SELECT employee.id, chief_id, 0
  FROM employee
  WHERE chief_id IS NULL
  UNION ALL
  SELECT employee.id, employee.chief_id, manager_tree.depth + 1
  FROM employee
  JOIN manager_tree ON employee.chief_id = manager_tree.employee.id
)
SELECT MAX(depth) AS max_depth
FROM manager_tree;

3. SELECT 
Departament.Name, SUM(Empoyee.Salary) AS total_salary
FROM Employee
JOIN Departament ON Empoyeer.Departament_Id = Departament.Id
GROUP BY Departament.Name
ORDER BY total_salary DESC
LIMIT 1;

4. SELECT *
FROM employee
WHERE name LIKE 'Р%н';
