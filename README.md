Project Title: Book Rental Service API
________________________________________
Table of Contents
1.	Project Overview
2.	Features
3.	Technologies Used
4.	Setup Instructions
5.	Running the Project
6.	Database Schema and Sample Data
7.	Assumptions 
8.	Testing the API
________________________________________
1. Project Overview
The Book Rental Service API is a backend service designed for a book rental platform. It allows users to search for books, rent and return books, view rental history, handle overdue rentals, and receive notifications. The API is built with .NET Core and uses SQL Server as the database.
________________________________________
2. Features
•	Book Search: Search books by title and genre.
•	Renting and Returning Books: Users can rent available books and return them after reading.
•	Overdue Handling: There is API function that helps us to Mark Rentals not returned within 2 weeks.
•	Statistics: Shows the most overdue book, the most popular, and the least popular books.
•	Concurrency Handling: Ensures smooth concurrent access for multiple users.
•	Logging and Monitoring: Logs system activity and errors for analysis and debugging.
________________________________________
3. Technologies Used
•	Backend Framework: .NET Core
•	Database: SQL Server
•	Logging: Serilog 
•	Concurrency Control: Optimistic Concurrency with RowVersion (or Timestamp)
•	Testing: xUnit for unit testing
________________________________________
4. Setup Instructions
Prerequisites
•	.NET Core SDK
•	SQL Server (or SQL Server Express for local development)
Steps to Set Up the Project Locally
1.	Clone the Repository:
2.	Database Configuration:
o	Update the appsettings.json file with your SQL Server connection string.

"ConnectionStrings": {
    "DefaultConnection": " Server=(localdb)\\mssqllocaldb;Database=BookDb;User Id=your_username;Password=your_password;"
}

3.	Database Migration:
o	Run migrations to create the database and tables.
o	Update database

________________________________________
5. Running the Project
•	Run the API:
•	Access the API Documentation (if using Swagger, for example):
o	Go to http://localhost:7012/swagger (or the relevant port) to view and test the API endpoints interactively.
________________________________________
6. Database Schema and Sample Data
Database Structure
•	Books: Stores book information (Title, Author, ISBN, Genre, Availability).
•	Rentals: Tracks book rentals, including user and book IDs, rental dates, return dates, and overdue status.
•	Users: Stores user details (email, name, etc.).
Sample Data
Sample data have been added through Seeder.
________________________________________
7. Assumptions and Trade-offs
Assumptions
1.	Overdue Duration: A book is considered overdue if not returned within 2 weeks.
2.	Concurrency Handling: Optimistic concurrency control with RowVersion is sufficient for handling 5 concurrent users.
________________________________________
8. Testing the API
Unit Tests
•	Unit Testing Framework: xUnit
•	Running Tests:
o	Navigate to the test project directory and run:
Manual Testing
For manual testing, the endpoints can be tested through Swagger or Postman.
________________________________________
Conclusion
This README provides the setup, functionality, and operational details for the Book Rental Service API. 
