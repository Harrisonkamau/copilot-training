# Library App

## Description

Library App is a C# console-based library management system. It allows users to search for patrons, view patron details, manage book loans, and renew memberships. The application uses a layered architecture with dependency injection and persists data in JSON files for easy setup and testing.

## Project Structure

- README.md
- .vscode/
  - settings.json
- src/
  - Library.ApplicationCore/
    - Library.ApplicationCore.csproj
    - Entities/
      - Author.cs
      - Book.cs
      - BookItem.cs
      - Loan.cs
      - Patron.cs
    - Enums/
      - LoanReturnStatus.cs
      - MembershipRenewalStatus.cs
      - LoanExtensionStatus.cs
      - EnumHelper.cs
    - Interfaces/
      - IPatronRepository.cs
      - ILoanRepository.cs
      - IPatronService.cs
      - ILoanService.cs
    - Services/
      - PatronService.cs
      - LoanService.cs
  - Library.Console/
    - appSettings.json
    - CommonActions.cs
    - ConsoleApp.cs
    - ConsoleState.cs
    - Library.Console.csproj
    - Program.cs
    - Json/
      - Authors.json
      - Books.json
      - BookItems.json
      - Patrons.json
      - Loans.json
  - Library.Infrastructure/
    - Library.Infrastructure.csproj
    - Data/
      - JsonData.cs
      - JsonPatronRepository.cs
      - JsonLoanRepository.cs
- tests/
  - UnitTests/
    - UnitTests.csproj
    - PatronFactory.cs
    - LoanFactory.cs
    - ApplicationCore/
      - PatronService/
        - RenewMembership.cs
      - LoanService/
        - ReturnLoan.cs
        - ExtendLoan.cs

## Key Classes and Interfaces

- **Entities**
  - `Author`, `Book`, `BookItem`, `Loan`, `Patron` ([src/Library.ApplicationCore/Entities/](src/Library.ApplicationCore/Entities/))
- **Enums**
  - `LoanReturnStatus`, `MembershipRenewalStatus`, `LoanExtensionStatus`, `EnumHelper` ([src/Library.ApplicationCore/Enums/](src/Library.ApplicationCore/Enums/))
- **Interfaces**
  - `IPatronRepository`, `ILoanRepository`, `IPatronService`, `ILoanService` ([src/Library.ApplicationCore/Interfaces/](src/Library.ApplicationCore/Interfaces/))
- **Services**
  - `PatronService`, `LoanService` ([src/Library.ApplicationCore/Services/](src/Library.ApplicationCore/Services/))
- **Infrastructure**
  - `JsonData`, `JsonPatronRepository`, `JsonLoanRepository` ([src/Library.Infrastructure/Data/](src/Library.Infrastructure/Data/))
- **Console**
  - `ConsoleApp`, `ConsoleState`, `CommonActions` ([src/Library.Console/](src/Library.Console/))

## Usage

1. **Build the project:**
   ```sh
   dotnet build
   ```
2. **Run the console application:**
   ```sh
   dotnet run --project src/Library.Console/Library.Console.csproj
   ```

3. **Unit tests:**
    ```sh
    dotnet test tests/UnitTests/UnitTests.csproj
    ```
4. **Configuration:**
 - JSON data files are located in src/Library.Console/Json/.
- Paths are configured in src/Library.Console/appSettings.json.


## License
This project is licensed under the MIT License.
