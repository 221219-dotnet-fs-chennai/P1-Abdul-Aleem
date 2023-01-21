CREATE DATABASE abdul;
CREATE SCHEMA pro;

-- skills table start

CREATE TABLE pro.skills(
    [skill_id] INT NOT NULL IDENTITY(1,1),
    skill_name VARCHAR(256)  NOT NULL,
    skill_experience INT NOT NULL,
    PRIMARY KEY([skill_id]),
    us_id INT NOT NULL,

    CONSTRAINT FK_usid_skill FOREIGN KEY(us_id)
    REFERENCES pro.[user](user_id)

);
    -- CONSTRAINT FK_EmpDetails_Emp FOREIGN KEY(EmployeeID)
    -- REFERENCES FORQC.Employee([Id])

-- view skills table
select * FROM pro.skills;


-- insert into skills
INSERT INTO pro.skills(skill_name,skill_experience)
VALUES('Python Programming',18);

-- truncate skills
TRUNCATE TABLE pro.skills;

--Drop table
DROP TABLE pro.skills;

-- skills table end


-- Education table Start

-- Education table creation
CREATE TABLE pro.edu(
    edu_id INT NOT NULL IDENTITY(1,1),
    institution_name VARCHAR(256) NOT NULL,
    course_name VARCHAR(256) NOT NULL,
    [start_date] DATE NOT NULL,
    [end_date] DATE NOT NULL,
    cgpa VARCHAR(10) NOT NULL,
    PRIMARY KEY(edu_id),
    us_id INT NOT NULL,
    CONSTRAINT FK_usid_edu FOREIGN KEY(us_id)
    REFERENCES pro.[user](user_id)
);

-- View edu table
SELECT * FROM pro.edu;

-- insert values to edu table
INSERT INTO pro.edu(institution_name,course_name,[start_date],[end_date],cgpa,us_id)
VALUES('Akka university','Electronics and comm engineering','2018-07-10','2022-07-10','6.9',2);

--truncate for edu
truncate TABLE pro.edu;

--drop edu table
drop TABLE pro.edu;
-- education table end


-- company table start

-- create table
CREATE TABLE pro.comp(
    comp_id INT NOT NULL IDENTITY(1,1),
    about VARCHAR(100) NOT NULL,
    comp_name VARCHAR(256) NOT NULL,
    [start_date] DATE NOT null,
    [end_date] DATE NOT NULL,
    PRIMARY KEY(comp_id),
    us_id INT NOT NULL,

    CONSTRAINT FK_usid_Comp FOREIGN KEY(us_id)
    REFERENCES pro.[user](user_id)
);

-- view comp table
SELECT * FROM pro.comp;

-- insert into table

INSERT INTO pro.comp(about,comp_name,[start_date],[end_date])
VALUES('good company to work. Nice work life balance','Revature','2022-12-19','2023-03-01');

-- truncate comp table
TRUNCATE TABLE pro.comp;
-- drop comp table
drop TABLE pro.comp;

-- end of comp table



-- start certification table

-- create cert table
CREATE TABLE pro.[cert](
    cert_id INT NOT NULL IDENTITY(1,1),
    certification_name VARCHAR(256) NOT NULL,
    acquired_from VARCHAR(256) NOT NULL,
    cert_licence VARCHAR(256) NOT NULL,
    PRIMARY KEY(cert_id),
    us_id INT NOT NULL,

    CONSTRAINT FK_usid_cert FOREIGN KEY(us_id)
    REFERENCES pro.[user](user_id)
);


-- view cert table
SELECT * From pro.cert;

-- insert cert table
INSERT INTO pro.cert(certification_name,acquired_from,cert_licence)
VALUES('Python programming course','UDEMY','123-343-3443');

-- truncate cert
TRUNCATE TABLE pro.cert;
-- drop table cert
drop table pro.cert;

-- end of cert table

-- start of user table
-- create user table
CREATE TABLE pro.[user](
    user_id INT NOT NULL IDENTITY(1,1),
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    email_id VARCHAR(100) NOT NULL,
    [password] VARCHAR(20) NOT NULL,
    phone_no bigint NOT NULL,
    PRIMARY KEY(user_id)
);
    -- sk_id int,
    -- ed_id int,
    -- cmp_id int,
    -- cer_id int,

    -- PRIMARY KEY(user_id),
    -- CONSTRAINT FK_skills FOREIGN KEY(sk_id)
    -- REFERENCES pro.skills([skill_id]),

    -- CONSTRAINT FK_education FOREIGN KEY(ed_id)
    -- REFERENCES pro.edu([edu_id]),

    -- CONSTRAINT FK_company FOREIGN KEY(cmp_id)
    -- REFERENCES pro.comp([comp_id]),

    -- CONSTRAINT FK_certification FOREIGN KEY(cer_id)
    -- REFERENCES pro.cert(cert_id)

    -- foreign keys

    -- CONSTRAINT FK_EmpDetails_Emp FOREIGN KEY(EmployeeID)
    -- REFERENCES FORQC.Employee([Id])


drop TABLE pro.[user];

SELECT * FROM pro.[user];



-- All Select statements 
SELECT * From pro.[user];
SELECT * From pro.[skills];
SELECT * From pro.[edu];
SELECT * From pro.[comp];
SELECT * From pro.[cert];

-- insertion of values

INSERT into pro.[user](first_name,last_name,email_id,[password],phone_no)
VALUES('Abdul','Aleem','abdulaleem@gmail.com','12345678','7358660113');

INSERT into pro.[user](first_name,last_name,email_id,[password],phone_no)
VALUES('Vishwa','K','VishvaK@gmail.com','12345678','7358660111');

INSERT into pro.skills(skill_name,skill_experience,us_id)
VALUES('React',20,2);

ALTER TABLE pro.[user] ALTER COLUMN phone_no bigint;

-- Login Check
SELECT * FROM pro.[user]
WHERE email_id = 'abdulaleem@gmail.com' and password = '12345678';


--Add Skill Check
INSERT into pro.skills(skill_name,skill_experience,us_id)
VALUES('Python',20,3);

-- Alter skills
ALTER TABLE [pro].[skills] DROP CONSTRAINT [UQ__skills__73C038AD9ED164F9]

-- Skill of particular user
select k.skill_id,k.skill_name,k.skill_experience from pro.Skills as k
WHERE k.us_id = 2;

-- Skill Update Statement
-- UPDATE table_name
-- SET column1 = value1, column2 = value2, ...
-- WHERE condition;

UPDATE pro.skills
SET skill_name = 'helloworld', skill_experience = 21
WHERE skill_id = 12;


-- delete a skill

SELECT * FROM pro.skills;
DELETE FROM pro.skills 
WHERE skill_id = 12




