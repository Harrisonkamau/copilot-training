# Report Generator

This project demonstrates a simple implementation of a quarterly income report generator in a C# application. It generates and displays a quarterly sales report based on sample sales data.

## Prerequisites

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
- Git (for cloning the repository)
- A C# development environment (such as Visual Studio, Visual Studio Code, or JetBrains Rider)

## Project Structure

- **src/**: Contains the source code for the application.
  - **ReportGenerator.cs**: The main entry point for the application. Contains the [`ReportGenerator.QuarterlyIncomeReport`](src/ReportGenerator.cs) class, which generates and displays quarterly sales reports.
  - **bin/**: Output binaries after build.
  - **obj/**: Build object files and intermediate outputs.

- **ReportGenerator.sln**: The solution file for organizing the project and its dependencies.

- **.gitignore**: Specifies files and directories to be ignored by version control.

## Setup Instructions

1. Clone the repository:
   ```
   git clone https://github.com/Harrisonkamau/copilot-training.git
   ```

2. Navigate to the project directory:
   ```
   cd report-generator
   ```

3. Open the solution in your preferred C# development environment.

4. Restore the project dependencies:
   ```
   dotnet restore
   ```

5. Build the project:
   ```
   dotnet build
   ```

## Usage

To run the application, use the following command:
```
dotnet run --project src/ReportGenerator.csproj
```

This will start the application and display the generated quarterly sales report.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.