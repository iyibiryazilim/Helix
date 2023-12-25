using Helix.FinanceService.Application.Repository;
using Helix.FinanceService.Domain.Models.BaseModels;

namespace Helix.FinanceService.Application.Services;

public interface IBankAccountTransactionService : IRepository<BankAccountTransaction>
{
}
