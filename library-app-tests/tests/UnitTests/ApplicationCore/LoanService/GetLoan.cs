using Library.ApplicationCore;
using Library.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Xunit;
using Library.ApplicationCore.Entities;

public class GetLoanTest
{
  private readonly ILoanRepository _mockLoanRepository;
  private readonly JsonLoanRepository _jsonLoanRepository;
  private readonly IConfiguration _configuration;
  private readonly JsonData _jsonData;

  public GetLoanTest()
  {
    _mockLoanRepository = Substitute.For<ILoanRepository>();
    _configuration = new ConfigurationBuilder().Build();
    _jsonData = new JsonData(_configuration);
    _jsonLoanRepository = new JsonLoanRepository(_jsonData);
  }

  [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns loan when loan ID is found")]
  public async Task GetLoan_ReturnsLoan_WhenLoanIdIsFound()
  {
    // Arrange
    int existingLoanId = 1; // This ID exists in Loans.json
    await _jsonData.LoadData();
    var expectedLoan = _jsonData.Loans!.Find(l => l.Id == existingLoanId);
    _mockLoanRepository.GetLoan(existingLoanId).Returns(expectedLoan);

    // Act
    var actualLoan = await _jsonLoanRepository.GetLoan(existingLoanId);

    // Assert
    Assert.NotNull(actualLoan);
    Assert.Equal(expectedLoan!.Id, actualLoan!.Id);
  }

  [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns null when loan ID is not found")]
  public async Task GetLoan_ReturnsNull_WhenLoanIdIsNotFound()
  {
    // Arrange
    int nonExistingLoanId = 999; // This ID does not exist in Loans.json
    await _jsonData.LoadData();
    _mockLoanRepository.GetLoan(nonExistingLoanId).Returns((Loan?)null);

    // Act
    var actualLoan = await _jsonLoanRepository.GetLoan(nonExistingLoanId);

    // Assert
    Assert.Null(actualLoan);
  }
}
