CREATE TABLE Students (
	StudentID int NOT NULL IDENTITY(1,1),
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	EmailAddress VARCHAR(50),
	StudentUser VARCHAR(50),
	PhoneNumber VARCHAR(50),
	Major VARCHAR(50),
	GradeLevel VARCHAR(50),
	GraduationYear VARCHAR(50),
	InternshipStatus VARCHAR(50),
	EmploymentStatus VARCHAR(50),
	StudentResume VARBINARY(MAX),
	ResumeName VARCHAR(50,
	ContentType VARCHAR(50),
	CONSTRAINT studentid_pk PRIMARY KEY (StudentID)
);

CREATE TABLE Members (
	MemberID int NOT NULL IDENTITY(1,1),
	MemberFirstName VARCHAR(50),
	MemberLastName VARCHAR(50),
	MemberEmailAddress VARCHAR(50),
	MemberUser VARCHAR(50),
	MemberPhoneNumber VARCHAR(50),
	MemberGraduationYear VARCHAR(50),
	Title VARCHAR(50),
	CONSTRAINT memberid_pk PRIMARY KEY (MemberID)
);

CREATE TABLE Mentorship (
	MentorshipID int NOT NULL IDENTITY(1,1),
	MemberID int,
	StudentID int,
	CONSTRAINT studentid_fk FOREIGN KEY (StudentID)
        REFERENCES Students (StudentID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	CONSTRAINT memberid_fk FOREIGN KEY (MemberID)
        REFERENCES Members (MemberID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	CONSTRAINT mentorshipid_pk PRIMARY KEY (MentorshipID)
);

CREATE TABLE Company (
	CompanyID int NOT NULL IDENTITY(1,1),
	CompanyName VARCHAR(50),
	CompanyAddress VARCHAR(50),
	CompanyPhone VARCHAR(50),
	CONSTRAINT companyid_pk PRIMARY KEY (CompanyID)
);

CREATE TABLE CompanyContact (
	ContactID int NOT NULL IDENTITY(1,1),
	ContactFirstName VARCHAR(50),
	ContactLastName VARCHAR(50),
	ContactPhone VARCHAR(50),
	ContactEmail VARCHAR(50),
	CompanyID int,
	CONSTRAINT companyid_fk FOREIGN KEY (CompanyID)
        REFERENCES Company (CompanyID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	CONSTRAINT contactid_pk PRIMARY KEY (ContactID)
);

CREATE TABLE Jobs (
	JobID int NOT NULL IDENTITY(1,1),
	JobTitle VARCHAR(50),
	JobDescription VARCHAR(500),
	StartDate VARCHAR(50),
	CompanyID int,
	ContactID int,
	CONSTRAINT hiringcompanyid_fk FOREIGN KEY (CompanyID)
        REFERENCES Company (CompanyID)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
	CONSTRAINT hiringcontactid_fk FOREIGN KEY (ContactID)
        REFERENCES CompanyContact (ContactID)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
	CONSTRAINT jobid_pk PRIMARY KEY (JobID)
);

CREATE TABLE Scholarships (
	ScholarshipID int NOT NULL IDENTITY(1,1),
	ScholarshipName VARCHAR(50),
	ScholarshipYear VARCHAR(50),
	ScholarshipAmount VARCHAR(50),
	CoordinatorID int,
	CONSTRAINT coordinatorid_fk FOREIGN KEY (CoordinatorID)
        REFERENCES Members (MemberID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	CONSTRAINT scholarshipid_pk PRIMARY KEY (ScholarshipID)
);

CREATE TABLE Applications (
	ApplicationID int NOT NULL IDENTITY(1,1),
	ApplicationDate VARCHAR(50),
	ApplicationText VARCHAR(500),
	ReviewStatus VARCHAR(50),
	ReviewDate VARCHAR(50),
	StudentID int,
	ScholarshipID int,
	CONSTRAINT applicantid_fk FOREIGN KEY (StudentID)
        REFERENCES Students (StudentID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	CONSTRAINT scholarshipid_fk FOREIGN KEY (ScholarshipID)
        REFERENCES SCholarships (ScholarshipID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	CONSTRAINT applicationid_pk PRIMARY KEY (ApplicationID)
);

INSERT INTO Students(FirstName, LastName, EmailAddress, StudentUser, PhoneNumber, Major, GradeLevel, GraduationYear, InternshipStatus,  EmploymentStatus) 
VALUES ('Gatlin','Greenhalgh','greenhgj@dukes.jmu.edu', 'greenhgj', '7572370158', 'CIS', 'Senior','2022', 'No', 'No');

INSERT INTO Members (MemberFirstName, MemberLastName, MemberEmailAddress, MemberUser, MemberPhoneNumber, MemberGraduationYear, Title) 
VALUES('Jeremy', 'Ezell', 'jezell@jmu.edu',  'jezell', '7778524512', '1995', 'Doctor');

INSERT INTO Mentorship(MemberID, StudentID)
VALUES(1,1);

INSERT INTO Company(CompanyName, CompanyAddress, CompanyPhone)
VALUES('AAA','123 Street Street','4567891254');
INSERT INTO Company(CompanyName, CompanyAddress, CompanyPhone)
VALUES('BBB','5746 Amble Drive','7778889999');
INSERT INTO Company(CompanyName, CompanyAddress, CompanyPhone)
VALUES('CCC','4679 Country Lane','1472312010');
INSERT INTO Company(CompanyName, CompanyAddress, CompanyPhone)
VALUES('DDD','4757 Mount Farm Road','7394182411');
INSERT INTO Company(CompanyName, CompanyAddress, CompanyPhone)
VALUES('EEE','1029 Johns Lane','5550110111');

INSERT INTO CompanyContact(ContactFirstName, ContactLastName, ContactPhone, ContactEmail, CompanyID)
VALUES('Russel','Greatwood','5558883333','rgreatwood@DDD.com',4);
INSERT INTO CompanyContact(ContactFirstName, ContactLastName, ContactPhone, ContactEmail, CompanyID)
VALUES('Jake','Power','2227654345','jpower@BBB.com',2);
INSERT INTO CompanyContact(ContactFirstName, ContactLastName, ContactPhone, ContactEmail, CompanyID)
VALUES('Virgina','Dominion','856251356','vdominion@CCC.com',3);
INSERT INTO CompanyContact(ContactFirstName, ContactLastName, ContactPhone, ContactEmail, CompanyID)
VALUES('Katie','Needham','7574504583','kneedham@EEE.com',5);
INSERT INTO CompanyContact(ContactFirstName, ContactLastName, ContactPhone, ContactEmail, CompanyID)
VALUES('Lance','Trout','5407356491','ltrout@AAA.com',1);

INSERT INTO Jobs(JobTitle, JobDescription, StartDate, CompanyID, ContactID)
VALUES('Programmer','You will program stuff','06/01/2022',2,2);
INSERT INTO Jobs(JobTitle, JobDescription, StartDate, CompanyID, ContactID)
VALUES('Accountant','Cook the books for us','06/015/2022',1,5);
INSERT INTO Jobs(JobTitle, JobDescription, StartDate, CompanyID, ContactID)
VALUES('Janitor','Clean the bathrooms in our office','07/06/2022',4,1);
INSERT INTO Jobs(JobTitle, JobDescription, StartDate, CompanyID, ContactID)
VALUES('Engineer','Design bridges for cities','08/24/2022',3,3);
INSERT INTO Jobs(JobTitle, JobDescription, StartDate, CompanyID, ContactID)
VALUES('Technology Consultant','You will program stuff','05/16/2022',5,4);

INSERT INTO Scholarships(ScholarshipName, ScholarshipYear, ScholarshipAmount, CoordinatorID)
VALUES('Lotsa Money','2022','$0.01',4);
INSERT INTO Scholarships(ScholarshipName, ScholarshipYear, ScholarshipAmount, CoordinatorID)
VALUES('Transfer Fund','2023','$4000',2);
INSERT INTO Scholarships(ScholarshipName, ScholarshipYear, ScholarshipAmount, CoordinatorID)
VALUES('Covid Relief','2022','$2000',3);
INSERT INTO Scholarships(ScholarshipName, ScholarshipYear, ScholarshipAmount, CoordinatorID)
VALUES('CIS Scholarship','2023','$6000000',5);
INSERT INTO Scholarships(ScholarshipName, ScholarshipYear, ScholarshipAmount, CoordinatorID)
VALUES('Little Summin Summin','2022','$550',1);

INSERT INTO Applications(ApplicationDate, ApplicationText, ReviewStatus, ReviewDate, StudentID, ScholarshipID)
VALUES('10/20/2021','Gimme Gimme','Decline','10/21/2021',1,5);
INSERT INTO Applications(ApplicationDate, ApplicationText, ReviewStatus, ReviewDate, StudentID, ScholarshipID)
VALUES('12/29/2021','I am deserving of this','Award','01/14/2022',1,1);
INSERT INTO Applications(ApplicationDate, ApplicationText, ReviewStatus, ReviewDate, StudentID, ScholarshipID)
VALUES('1/24/2022','I need the money for school','Decline','2/04/2022',1,2);
INSERT INTO Applications(ApplicationDate, ApplicationText, ReviewStatus, ReviewDate, StudentID, ScholarshipID)
VALUES('01/01/2022','If I do not recieve this my dad will sue','Decline','2/02/2022',1,4);
INSERT INTO Applications(ApplicationDate, ApplicationText, ReviewStatus, ReviewDate, StudentID, ScholarshipID)
VALUES('02/11/2022','Lab 1 part 3','Award','Not Reviewed',1,3);



