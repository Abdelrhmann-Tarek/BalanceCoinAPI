## Project: Build an Expense and Income Tracker API in .NET Core**

## **Project Overview**

The project is about building a simple **Expense / Income Tracker API** using **ASP.NET Core Web API** and **Entity Framework Core** with **SQL Server**. The API should allow users to **create, read, update, and delete (CRUD) expenses and income**.

## **Requirements**

### **Technology Stack:**

- **Backend:** ASP.NET Core Web API
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Tools:** Swagger for testing

## **Functional Requirements**

The API should support the following features:

1. **Expense Management (Same for Income:**
   - Create a new expense entry.
   - Retrieve a list of all expenses.
   - Retrieve details of a specific expense by ID.
   - Filter expenses by category
   - Update an existing expense entry.
   - Delete an expense entry.
2. **Expense Fields (Same for Income):**
   - `Id`: Unique identifier for each expense.
   - `Title`: A short description of the expense.
   - `Amount`The cost associated with the expense.
   - `CategoryId`: reference to the Type of expense (e.g., Food, Transport, Utilities, etc.).
   - `Date` The date when the expense was made.
3. **Validation Requirements on Expenses:**
   - `Title` should not be empty.
   - `Amount` should be a positive number, not bigger than the current balance.
   - `Category` should be a predefined set of values or user-defined.
   - `Date` should not be in the future.
4. Category Fields:
   - `Id` Unique identifier for each category.
   - `Name` proper name for category.
5. An endpoint for calculating the current balance.

## **Non-Functional Requirements**

- The API should follow **RESTful principles**.
- Responses should use proper **HTTP status codes**.
- The database should use **Entity Framework Core Migrations** for schema management.
- The code should be **well-structured and follow best practices**.
- The project should include **Swagger** for API documentation.
- The API should handle **exceptions and return meaningful error messages**.

##

## **Next Steps (Optional Enhancements)**

- Add **JWT authentication** for user-based expense tracking.
