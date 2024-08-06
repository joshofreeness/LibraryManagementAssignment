# Assignment text

This assignment will guide the candidate to create a simple application for managing a library of books, showcasing their ability to work with the Repository Pattern and adhere to specific requirements.

## Assignment: Library Management System

### Objective

Create a simple console application for managing a library of books. The application should use the Repository Pattern to interact with the data storage. The primary focus is on demonstrating clean code practices, separation of concerns, and correct implementation of the Repository Pattern. You can use the language of your choice but you must make sure your application can be run without any exception

### Requirements
1. Concrete Repository Implementations:
    - Implement the repository interfaces.
    - Store data in an in-memory data structure for simplicity.
2. Service Layer:
    - Create a service layer that uses the repositories to perform operations.
    - The service layer should handle business logic and validation you must validate ISBN format.
3. Console Application:
    - Implement a simple console interface to interact with the system.
    - Provide options to:
        - Add a new book
        - Update an existing book
        - Delete a book
        - List all books
        - View details of a specific book
4. Unit Tests:
    - Write unit tests for the repository and service layers.
    - Use mock repositories to test the service layer.

### Submission Guidelines
1. Code Quality:
    - Ensure the code is clean, well-organized, and adheres to SOLID principles.
    - Provide comments and documentation where necessary.
2. Documentation:
    - Include a README file explaining how to run the application.
    - Describe the structure of the project and any design decisions made.
3. Delivery:
    - Submit the project as a Git repository (e.g., on GitHub).
    - Ensure the repository includes all necessary files to build and run the application.

### Evaluation Criteria
1. Correctness:
    - The application should meet all specified requirements and perform the required operations correctly.
2. Code Quality:
    - The code should be clean, readable, and maintainable.
    - Proper use of the Repository Pattern and separation of concerns.
3. Test Coverage:
    - Adequate unit tests for the repository and service layers.
    - Use of mocks where appropriate to isolate components during testing.
4. Documentation:
    - Clear and concise documentation.
    - Instructions on how to build and run the application.

