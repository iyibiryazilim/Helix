using Helix.FinanceService.Application.Repository;
using Helix.FinanceService.Domain.Models.BaseModels;

namespace Helix.FinanceService.Application.Services;

public interface IBankAccountService : IRepository<BankAccount>
{
}
