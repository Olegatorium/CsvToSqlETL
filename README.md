## Summary
The project was successfully completed using:
- Entity Framework
- CsvHelper library
- Dependency Injection
- N-Tier architecture

## Setup Local Instructions
1. Clone the repository using the following command:
   ```sh
   git clone <repository-url>
   ```
2. Open the project in Visual Studio.
3. Go to **Package Manager Console**, select the `DbContext` project, and run the following command:
   ```sh
   Update-Database
   ```
Now the project is set up locally and ready for testing.

## Key Features
### 1. Duplicate Handling
- A file containing duplicates is automatically created after running the program in the **Resources** folder inside the `CsvToSqlETL` project.

### 2. Efficient Bulk Insertion
- Implemented optimized bulk insertion using **Entity Framework** and the `EFCore.BulkExtensions` library.

### 3. Database Schema Optimization
- **Indexing key fields:**
  - An index was created for `PULocationID` to speed up the search for locations with the highest average tip amount.
  - An index on `TripDistance` improves the retrieval of the top 100 longest trips by distance.
  - A composite index on `TpepPickupDatetime` and `TpepDropoffDatetime` optimizes the search for the 100 longest trips by duration.
- **Query computation optimization:**
  - The `RideData` model includes the `TripTimeInMinutes` property, which calculates trip duration in minutes.
  - The `[NotMapped]` attribute prevents storing this property in the database while allowing quick access in the application logic without additional SQL calculations.

### 4. Data Validation
- The file size is validated to ensure it does not exceed **100 MB**, preventing potential attacks.
- Validate CSV data to avoid errors due to incorrect formatting.

### 5. Additional Feature
- Input data is converted from **ECT (Eastern Time)** to **UTC** when inserting into the database.

---


