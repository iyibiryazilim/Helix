using Helix.FinanceService.Application.Repository;
using Helix.FinanceService.Domain.Models;

namespace Helix.FinanceService.Application.Services;

internal interface ICustomerTransactionService : IRepository<CustomerTransaction>
{
}
