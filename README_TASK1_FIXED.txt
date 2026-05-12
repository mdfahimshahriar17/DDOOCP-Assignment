Fitness Tracker - Task 1 Final Fix

This project is a C# WinForms implementation for NCC Education Designing and Developing Object-Oriented Computer Programs Task 1.

Final changes in this package:
1. Registration uses Username, Password and Confirm Password only. The visible Email field was removed.
2. The Home page uses only the student's approved Fitness Tracker image.
3. Unused/friend assignment images were removed from the project resources.
4. Old sample/test history is cleared once on first startup; after that, newly registered users, goals and activities are kept normally.
5. Goal handling is simplified to one current calorie goal per logged-in user.
6. Activities are limited to the required six: Walking, Swimming, Running, Cycling, Jump Rope and Yoga.
7. Each activity uses exactly three predefined metrics.
8. Calories are calculated automatically from the three metrics.
9. Progress calculates total calories and reports whether the calorie goal is achieved.
10. Input validation and parameterized SQL are used to reduce runtime errors.

Testing order:
1. Open the .sln in Visual Studio.
2. Build > Rebuild Solution.
3. Run the system.
4. Register a fresh user.
5. Log in.
6. Set a calorie goal.
7. Add all six activity records.
8. Open Progress and confirm total calories and goal status.

Important: SQL Server LocalDB must be installed because the project uses Fitness.mdf.
