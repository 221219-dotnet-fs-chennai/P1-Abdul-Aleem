CREATE SCHEMA FORQC;

CREATE TABLE FORQC.Department(
    [Id] INT NOT NULL,
    [Name] VARCHAR(30) NOT NULL,
    [Location] VARCHAR(30) NOT NULL,
    PRIMARY KEY ([Id])
);

-- INSERT into FORQC.Department(Id,Name,[Location])
-- VALUES()

CREATE TABLE FORQC.Employee(
[Id] INT NOT NULL IDENTITY(1,1),
Firstname VARCHAR(30) NOT NULL,
Lastname VARCHAR(30) NOT NULL,
Ssn bigint NOT NULL,
DeptId int,

CONSTRAINT FK_EmplDept FOREIGN KEY (DeptId)
REFERENCES FORQC.Department([Id]),

PRIMARY Key([Id])
);


CREATE TABLE FORQC.EmpDetails(
    [id] Int NOT NULL IDENTITY(1,1),
    EmployeeID int,
    Salary int not NULL,
    [Address1] VARCHAR(30) NOT NULL,
    [Address2] VARCHAR(30) NOT NULL,
    city VARCHAR(30) NOT NULL,
    [STATE] VARCHAR(30) NOT NULL,
    Country VARCHAR(30) NOT NULL,

    PRIMARY KEY([id]),

    CONSTRAINT FK_EmpDetails_Emp FOREIGN KEY(EmployeeID)
    REFERENCES FORQC.Employee([Id])

);

-- ADDING 3 RECORDS IN EACH TABLE

-- DEPARTMENT TABLE
INSERT into FORQC.Department(Id,[Name],[Location])
VALUES(1,'TECH TEAM','DELHI'),
(2,'FINANCE','PUNE'),
(3,'MARKETING','CHENNAI');

SELECT * FROM FORQC.Department;



--EMPLOYEE TABLE
INSERT into FORQC.Employee(Firstname,Lastname,Ssn,DeptId)
VALUES('ABDUL','ALEEM',1234567,1),
('ARAVIND','Rangan',2264567,3),
('Feodor','Marian',223435,2),
('Tina','Smith',345323,3)


SELECT * FROM FORQC.EMployee;


--EmpDEtails Table
INSERT INTO FORQC.EmpDetails(EmployeeID,Salary,Address1,Address2,city,[STATE],Country)
VALUES(1,20000,'11/3 hd street','the new road','chennai','TN','INDIA'),
(2,30000,'11/3 hd street','the new road','Vellore','TN','INDIA'),
(3,50000,'11/3 hd street','the new road','Coimbatore','TN','INDIA'),
(4,10000,'11/3 hd street','the new road','Kochi','Kerala','INDIA')


-- selects
SELECT * FROM FORQC.Department;

SELECT * FROM FORQC.EMployee;

SELECT * FROM FORQC.EmpDetails;


--list Employees in marketeing
SELECT * FROM ForQc.Employee as e1
INNER JOIN  ForQc.EmpDetails as e2
on e2.employeeid = e1.id
WHERE e1.deptid = 3;


--report total salary of marketing
SELECT sum(e2.salary) as totalsalary FROM ForQc.Employee as e1
INNER JOIN  ForQc.EmpDetails as e2
on e2.employeeid = e1.id
WHERE e1.deptid = 3;

-- Report Total Employess by department
SELECT * from forqc.employee;


SELECT e1.deptid, count(e1.Firstname) as 'no of employees' from forqc.employee as e1
GROUP by deptid;


-- increase salry of tina to 90000

SELECT * from forqc.EmpDEtails;


UPDATE forqc.EmpDetails 
SET salary = 90000 
where employeeid = 4 ;


--normal
UPDATE forqc.EmpDetails 
SET salary = 10000 
where employeeid = 4 ;







