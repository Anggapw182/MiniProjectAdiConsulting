# Mini Project Assesment Adi Consulting

## Setup env
- Install postgresql in your local [URL Install](https://www.postgresql.org/download/windows/)
- Using IDE Visual Studio 2022, install .Net 6.0

## Step - Step running this project
- Clone project
- Make sure you have installed the postgres database
- Create database in local, in this case i am using default db from postgres
    "Server": "localhost",
    "Database": "postgres",
    "UserId": "postgres",
    "Password": "1998"
- Settings database in project StudentAdmissionManagement/appsettings.json and StudentAttendanceManagement/appsettings.json
- And Last klik run project

### Testing API with posmant
You can export template postman from scr ./Postman, after that you can hit api from template

## Structure Database
    Table studentsadmission 
    Id SERIAL PRIMARY KEY,
    StudentName VARCHAR,
    StudentClass VARCHAR,
    DateofJoining VARCHAR
    
    Table StudentsAttendence
    Id SERIAL PRIMARY KEY,
    StudentName VARCHAR(255),
    AttendencePercentage DOUBLE PRECISION


**Thanks You!**
