# DbFirst

This project makes 3 operations:
- Deserialize JSON file that stores the configuration for a project
- Uses Dapper to map Database Query results in properties
- Validates the output from the Database

Main idea behind it, is to store values from the database like for ex. User details and use them later on in test automation.
Also this approach could be used to validate the state of the database after certain operations, as an example
the user commits a changes on the website which results in adding additional record in DB, and later on the state of the Database can be validated.
