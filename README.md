Recipe Management System - Web API

A Web API built with ASP.NET Core for managing recipes, users, and ingredients, developed as a final project for the C# course. The system implements a clean layered architecture, full asynchronous processing, and database management via Entity Framework Core.



Architecture & Project Structure

The project follows a standard 3-tier layered architecture to ensure clean separation of concerns and utilizes Dependency Injection throughout the application:

1. API Layer (Presentation): Contains the Controllers and endpoints. It handles API routing, handles incoming parameters (from Route, Query, and Body), and ensures appropriate HTTP status codes (such as 200 OK, 201 Created, 404 Not Found, and 204 No Content) are returned.
2. BL Layer (Business Logic): Implements the system's core features via Services. It processes incoming data, handles DTOs (Data Transfer Objects), and leverages AutoMapper to securely map entities without exposing the underlying database layer directly to the client.
3. DAL Layer (Data Access): The exclusive layer for database communication. It manages the `DbContext`, the core database entities, and Repository patterns working over Entity Framework Core.


Database Entities & Relationships

The database schema includes 4 highly interconnected tables, fulfilling all business constraints and relational requirements:

* Recipe: Represents a culinary recipe containing a title, instructions, ingredients, and preparation time. It maintains a relationship with the User who created it.
* User: Represents the creator of the recipes, including their name and culinary specialty.
* Ingredient: Defines generic ingredients available within the system.
* RecipeIngredient (Join Table - Many-to-Many): Explicitly bridges the Many-to-Many relationship between Recipes and Ingredients. It contains an additional field (`Amount`) to track the exact quantity of the ingredient used in that specific recipe.



Installation & Running Instructions

Prerequisites
* Visual Studio 2022 (or higher) with the .NET SDK installed.
* SQL Server (LocalDB or SQL Express) running locally.

Step-by-Step Setup
1. Clone the Repository:
   git clone  https://github.com/NechamaSanders/FinalProject.git
2. Configure Connection Strings: Navigate to the API project, open the appsettings.json file, and update the connection string inside the ConnectionStrings section to target your local database server instance. No credentials or connection strings are hardcoded in the codebase.
3. Database Creation: Run the attached .sql script or database backup file inside SQL Server Management Studio (SSMS) to instantiate the schema, tables, and constraints.
4. Run the Project:Open the solution (.sln) file in Visual Studio, verify that the API project is set as the Startup Project, and press F5 to build and run the application.
5. Interactive API Testing: Once launched, the browser will automatically load the Swagger UI page. This interactive interface displays all CRUD operations (GET, POST, PUT, DELETE) and allows you to dynamically test live HTTP requests directly from your browser.  
