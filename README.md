Recipe Management System - Web API
A Web API built with ASP.NET Core for managing recipes, users, and ingredients, developed as a final project for the C# course. The system implements a clean layered architecture, full asynchronous processing, and database management via Entity Framework Core.

1. GitHub Repository
Project Link: https://github.com/NechamaSanders/FinalProject.git

2. Architecture & Project Structure
The project follows a standard 3-tier layered architecture to ensure clean separation of concerns and utilizes Dependency Injection throughout the application:

API Layer (Presentation): Contains the Controllers and endpoints. It handles API routing, handles incoming parameters (from Route, Query, and Body), and ensures appropriate HTTP status codes (such as 200 OK, 201 Created, 404 Not Found, and 204 No Content) are returned.

BL Layer (Business Logic): Implements the system's core features via Services. It processes incoming data, handles DTOs (Data Transfer Objects), and leverages AutoMapper to securely map entities without exposing the underlying database layer directly to the client.

DAL Layer (Data Access): The exclusive layer for database communication. It manages the DbContext, the core database entities, and Repository patterns working over Entity Framework Core.

3. Database Entities & Relationships
The database schema includes 4 highly interconnected tables, fulfilling all business constraints and relational requirements:

Recipe: Represents a culinary recipe containing a title, instructions, ingredients, and preparation time. It maintains a relationship with the User who created it.

User: Represents the creator of the recipes, including their name and culinary specialty.

Ingredient: Defines generic ingredients available within the system.

RecipeIngredient (Join Table - Many-to-Many): Explicitly bridges the Many-to-Many relationship between Recipes and Ingredients. It contains an additional field (Amount) to track the exact quantity of the ingredient used in that specific recipe.

4. Installation & Running Instructions
Prerequisites
Visual Studio 2022 (or higher) with the .NET SDK installed.

SQL Server (LocalDB) running locally on your machine.

Step-by-Step Setup
Clone the Repository: ```bash
git clone https://github.com/NechamaSanders/FinalProject.git

*(Alternatively, extract the provided ZIP file into a clean local path, e.g., `C:\FinalProject`).*

Configure Connection Strings: The appsettings.json file inside the API project is pre-configured with a portable connection string utilizing |DataDirectory|. The system will automatically locate and attach the database files dynamically from the /DB folder upon execution. No hardcoded computer-specific paths or credentials are used.

Database Attachment: The pre-created database data file (FinalProjectDB.mdf) and log file (FinalProjectDB_log.ldf) are placed inside the /DB folder at the root of the solution. They will be automatically attached by LocalDB when running the application.

Run the Project: Open the solution (FinalProject.sln) file in Visual Studio, verify that the FinalProject.API project is set as the Startup Project. In the top toolbar, select the 'http' launch profile from the dropdown menu (next to the green Play button), and press F5 to build and run the application.

5. Interactive API Testing (Swagger UI)
Once launched, the browser will automatically load the interactive Swagger UI page at: http://localhost:5079/swagger.

This interface displays all CRUD operations (GET, POST, PUT, DELETE) categorized by their respective controllers, allowing you to dynamically test live HTTP requests directly from your browser:

Testing GET Requests: Expand a GET endpoint, click "Try it out", fill in any required parameters (like an entity ID), and click the blue "Execute" button to view the live JSON response and the 200 OK status code.

Testing POST Requests: Expand a POST endpoint, click "Try it out", update the example JSON model in the request body with your custom data, and click "Execute" to insert records into the database.
