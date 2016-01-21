create database db_Employees
go

use db_Employees;

go

create table Role(
	Id int Not Null identity,
	Name varchar(100) Not Null,
	CONSTRAINT pk_RoleId
	PRIMARY KEY(Id)
)

go

create table Employee(
	Id int Not Null identity,
	Name varchar(100) Not Null,
	IdRole int Not Null,
	CONSTRAINT pk_EmployeeId
	PRIMARY KEY(Id),
	CONSTRAINT fk_RoleId
	FOREIGN KEY(IdRole)
	REFERENCES Role(Id)
)

go

INSERT INTO Role (Name) values ('Web Developer')
INSERT INTO Role (Name) values ('Full Stack Developer')
INSERT INTO Role (Name) values ('Front End Developer')
INSERT INTO Role (Name) values ('Back End Developer')
INSERT INTO Role (Name) values ('Software Tester')
INSERT INTO Role (Name) values ('Team Leader')
INSERT INTO Role (Name) values ('Product Manager')
INSERT INTO Role (Name) values ('CEO')
INSERT INTO Role (Name) values ('CTO')

go

INSERT INTO Employee (Name, IdRole) values ('Gabriel Rodrigues', 7)
INSERT INTO Employee (Name, IdRole) values ('Steve Ballmer', 8)
INSERT INTO Employee (Name, IdRole) values ('John Hopkins', 4)

go