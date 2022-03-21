drop table Students;
Drop table Members;
drop table ProposedStudents;
Drop table ProposedMembers;
drop table ADMIN;


CREATE TABLE ADMIN (
	AdminID int NOT NULL IDENTITY(1,1),
	Username VARCHAR(50),
	Pass VARCHAR(256),
	CONSTRAINT adminid_pk PRIMARY KEY (AdminID)
);

CREATE TABLE Students (
	StudentID int NOT NULL IDENTITY(1,1),
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	EmailAddress VARCHAR(50),
	StudentUser VARCHAR(50),
	StudentPass VARCHAR(256),
	CONSTRAINT studentid_pk PRIMARY KEY (StudentID)
);

CREATE TABLE Members (
	MemberID int NOT NULL IDENTITY(1,1),
	MemberFirstName VARCHAR(50),
	MemberLastName VARCHAR(50),
	MemberEmailAddress VARCHAR(50),
	MemberUser VARCHAR(50),
	MemberPassword VARCHAR(256),
	CONSTRAINT memberid_pk PRIMARY KEY (MemberID)
);

CREATE TABLE ProposedStudents (
	ProposedStudentID int NOT NULL IDENTITY(1,1),
	PSFirstName VARCHAR(50),
	PSLastName VARCHAR(50),
	PSEmailAddress VARCHAR(50),
	PSStudentUser VARCHAR(50),
	PSStudentPass VARCHAR(256),
	PSPhoneNumber VARCHAR(50),
	PSMajor VARCHAR(50),
	PSGradeLevel VARCHAR(50),
	PSGraduationYear VARCHAR(50),
	PSInternshipStatus VARCHAR(50),
	PSEmploymentStatus VARCHAR(50),
	CONSTRAINT proposedstudentid_pk PRIMARY KEY (ProposedStudentID)
);

CREATE TABLE ProposedMembers (
	ProposedMemberID int NOT NULL IDENTITY(1,1),
	PMMemberFirstName VARCHAR(50),
	PMMemberLastName VARCHAR(50),
	PMMemberEmailAddress VARCHAR(50),
	PMMemberUser VARCHAR(50),
	PMMemberPassword VARCHAR(256),
	PMMemberPhoneNumber VARCHAR(50),
	PMMemberGraduationYear VARCHAR(50),
	PMTitle VARCHAR(50),
	CONSTRAINT proposedmemberid_pk PRIMARY KEY (ProposedMemberID)
);
Insert into ADMIN(Username, Pass) Values('admin','1000:tEcewQpEKC2knVRDGt0vpGCBrAgxJaUg:DScjZIHFhfS1FnOP9f4IsLHhA6I=');
INSERT INTO Students(FirstName, LastName, EmailAddress, StudentUser, StudentPass) 
VALUES ('Gatlin','Greenhalgh','greenhgj@dukes.jmu.edu', 'greenhgj', '1000:XBLUiMBNAJeWIRlMVSqCTFQOxiuArKlf:GLmKpllitcRiQtoRyBmUFWU+Zfg=');

INSERT INTO Members (MemberFirstName, MemberLastName, MemberEmailAddress, MemberUser, MemberPassword) 
VALUES('Jeremy', 'Ezell', 'jezell@jmu.edu',  'jezell', '1000:1VuqHnC/zPwscWCMqSa+SqExApp4dtyq:Vo2ZCQF8TbyTYp9/iH0GpeTZ+TU=');