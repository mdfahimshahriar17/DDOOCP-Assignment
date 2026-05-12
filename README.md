# Fitness Tracker - DDOOCP Assignment

## Project Overview

Fitness Tracker is a C# Windows Forms application developed for the DDOOCP assignment. The system allows users to register, log in, set calorie-burning goals, record fitness activities, calculate calories burned, and monitor their progress.

The application follows object-oriented programming principles by separating the user interface, validation, database operations, session handling, goal management, activity management, and calorie calculation logic into different classes.

---

## Main Features

- User registration
- User login
- Failed login attempt handling
- Username and password validation
- User-specific calorie goal setting
- Recording of six fitness activities
- Three predefined metrics for each activity
- Calories burned calculation
- Total calories burned calculation
- Goal achievement status display
- Windows Forms graphical user interface
- SQL Server LocalDB database storage

---

## User Account Rules

### Username

The username must:

- Contain only letters and numbers
- Not contain symbols or spaces

### Password

The password must:

- Be exactly 12 characters long
- Contain at least one uppercase letter
- Contain at least one lowercase letter

Example valid password:

    PasswordAB12

---

## Supported Activities

The system supports six fitness activities.

| Activity | Metric 1 | Metric 2 | Metric 3 |
|---|---|---|---|
| Walking | Steps | Distance | Time Taken |
| Swimming | Number of Laps | Time Taken | Average Heart Rate |
| Running | Distance | Time Taken | Speed / Intensity |
| Cycling | Distance | Time Taken | Speed / Intensity |
| Jump Rope | Number of Jumps | Time Taken | Intensity |
| Yoga | Duration | Poses / Sets | Heart Rate |

Each activity calculates calories burned using its related metric values.

---

## Technologies Used

- C#
- Windows Forms
- .NET Framework
- SQL Server LocalDB
- Visual Studio
- Object-Oriented Programming

---

## Project Structure

| File / Class | Purpose |
|---|---|
| Program.cs | Application entry point |
| frmLogin.cs | Handles user login |
| frmRegister.cs | Handles new user registration |
| frmDashboard.cs | Main dashboard and navigation |
| frmActivities.cs | Allows users to record fitness activities |
| frmUserGoals.cs | Allows users to set calorie goals |
| frmMonitoring_Progress.cs | Displays total calories and goal status |
| FitnessActivity.cs | Contains activity classes and calorie calculation logic |
| UserManager.cs | Handles user registration and login database operations |
| ActivityManager.cs | Handles activity saving and calorie retrieval |
| GoalManager.cs | Handles user goal saving and retrieval |
| ValidationHelper.cs | Handles username, password, and input validation |
| UserSession.cs | Stores the currently logged-in user information |
| DatabaseHelper.cs | Provides database connection support |
| AppTheme.cs | Applies consistent GUI styling |

---

## Database

The project uses SQL Server LocalDB with the included database file:

    Fitness.mdf

The database stores:

- Registered users
- User goals
- Activity records
- Calories burned

Do not delete the database file from the project folder.

---

## How to Run the Project

1. Extract the project ZIP file.
2. Open the .sln file in Visual Studio.
3. Make sure SQL Server LocalDB is installed.
4. Go to:

    Build → Clean Solution
    Build → Rebuild Solution

5. Make sure there are no build errors.
6. Click Start to run the application.

---

## Basic Testing Guide

### 1. Registration Test

Use the following valid test data:

    Username: TestUser1
    Password: PasswordAB12
    Confirm Password: PasswordAB12

Expected result:

    User should register successfully.

### 2. Login Test

Use the same username and password.

Expected result:

    User should log in and reach the dashboard.

### 3. Invalid Login Test

Enter the wrong password multiple times.

Expected result:

    The system should show an error message and handle failed login attempts.

### 4. Goal Test

Set a calorie goal:

    500

Expected result:

    Goal should be saved for the logged-in user.

### 5. Activity Test

Add activity records for Walking, Swimming, Running, Cycling, Jump Rope, and Yoga.

Expected result:

    Calories should be calculated and saved for each activity.

### 6. Progress Test

Open the Progress page.

Expected result:

    The system should display total calories burned, goal calories, and goal achievement status.

---

## Example Workflow

1. Register a new user.
2. Log in using the registered account.
3. Set a calorie goal.
4. Add fitness activity records.
5. Open the progress page.
6. Check whether the goal has been achieved.

---

## Notes

- This project was developed for academic purposes.
- The calorie calculations are estimated values based on selected activity metrics.
- In a production system, passwords should be stored using hashing and salting.
- The application should be tested from a freshly extracted ZIP folder before final submission.

---

## Author

Student Name: MD Fahim Shahriar  
NCC ID: 219934  
Assignment: DDOOCP Assignment  
Project Title: Fitness Tracker