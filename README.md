# Project 3 : Summary

This project is focused on creating a simple REST API application that performs operations on data in a SQL Server database.  
  
SQL file that creates table Animal is stored in Data folder.  
  
The following tasks are included:

1. Add a controller named `AnimalController` to handle animal data operations.
2. Create an endpoint to read a list of animals using an HTTP GET request to the `/api/animals` URL.  
   a) The endpoint should accept an optional query string parameter named `orderBy` to specify the order of the returned records.  
   Example: `/api/animals?orderBy=name`  
   b) The `orderBy` parameter can have values: `name`, `description`, `category`, or `area`. Sorting is always done in ascending order.  
   c) If no `orderBy` parameter is provided, the records should be sorted by the `Name` column by default.
3. Create an endpoint to create a new animal using an HTTP POST request to `/api/animals`.  
   a) The endpoint should accept data in JSON format.  
4. Create an endpoint to update an existing animal using an HTTP PUT request to `/api/animals/{idAnimal}`.  
   a) The endpoint should accept data in JSON format.  
   b) Note that the primary key (`IdAnimal`) cannot be edited or changed.
5. Create an endpoint to delete an animal using an HTTP DELETE request to `/api/animals/{idAnimal}`.
6. Return appropriate HTTP status codes for each operation.
7. Utilize built-in frameworks to implement Dependency Injection.
8. Validate and check the data received from requests.
9. Follow naming conventions and clean code rules.
