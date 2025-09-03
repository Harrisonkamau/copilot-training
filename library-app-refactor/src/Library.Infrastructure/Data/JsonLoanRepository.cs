using Library.ApplicationCore;
using Library.ApplicationCore.Entities;

namespace Library.Infrastructure.Data;

public class JsonLoanRepository : ILoanRepository
{
    private readonly JsonData _jsonData;

    public JsonLoanRepository(JsonData jsonData)
    {
        _jsonData = jsonData;
    }

    public async Task<Loan?> GetLoan(int id)
    {
        await _jsonData.EnsureDataLoaded();

        return _jsonData.Loans!
            .Where(loan => loan.Id == id)
            .Select(_jsonData.GetPopulatedLoan)
            .FirstOrDefault();
    }

    public async Task UpdateLoan(Loan loan)
    {
        await _jsonData.EnsureDataLoaded();
        var index = _jsonData.Loans!.FindIndex(l => l.Id == loan.Id);

        if (index != -1)
        {
            _jsonData.Loans[index] = loan;

            await _jsonData.SaveLoans(_jsonData.Loans!);
            await _jsonData.LoadData();
        }
    }
}