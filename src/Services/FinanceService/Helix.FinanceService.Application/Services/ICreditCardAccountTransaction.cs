﻿using Helix.FinanceService.Application.Repository;
using Helix.FinanceService.Domain.Models;

namespace Helix.FinanceService.Application.Services;

public interface ICreditCardAccountTransaction : IRepository<CreditCardAccountTransaction>
{
}
