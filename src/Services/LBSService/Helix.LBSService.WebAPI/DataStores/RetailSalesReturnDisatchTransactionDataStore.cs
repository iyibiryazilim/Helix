using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.DataStores;
using Helix.LBSService.Go.Models;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Helix.LBSService.WebAPI.Services;
using System.Numerics;

namespace Helix.LBSService.WebAPI.DataStores
{
	public class RetailSalesReturnDisatchTransactionDataStore : IRetailSalesReturnDispatchTransactionService
	{
		private readonly ILogger<RetailSalesReturnDisatchTransactionDataStore> _logger;
		private readonly ILG_RetailSalesReturnDispatchTransactionService _tigerService;
		public RetailSalesReturnDisatchTransactionDataStore(ILogger<RetailSalesReturnDisatchTransactionDataStore> logger, ILG_RetailSalesReturnDispatchTransactionService tigerService)
		{
			_logger = logger;
			_tigerService = tigerService;
		}
		public async Task<DataResult<RetailSalesReturnDispatchTransactionDto>> Insert(RetailSalesReturnDispatchTransactionDto dto)
		{
			if (LBSParameter.IsTiger)
			{
				try
				{
					var obj = Mapping.Mapper.Map<LG_RetailSalesReturnDispatchTransaction>(dto);
					foreach (var item in dto.Lines)
					{
						var transaction = Mapping.Mapper.Map<LG_RetailSalesReturnDispatchTransactionLine>(item);
						obj.TRANSACTIONS.Add(transaction);
					}
					var result = await _tigerService.Insert(obj);

					return new DataResult<RetailSalesReturnDispatchTransactionDto>()
					{
						Data = null,
						Message = result.Message,
						IsSuccess = result.IsSuccess,
					};
				}
				catch (Exception)
				{

					throw;
				}
			}
			else
			{
				var obj = Mapping.Mapper.Map<LG_STFICHE>(dto);
				foreach (var item in dto.Lines)
				{
					var transaction = Mapping.Mapper.Map<LG_STLINE>(item);
					obj.TRANSACTIONS.Add(transaction);
				}

				using (var stficheContext = new LG_STFICHE_Context())
				{

					try
					{

						obj.FICHENO = await GetNextDocumentNumberAsync(obj);

						var result = await stficheContext.InsertObjectAsync(obj);
						if (!result.IsSuccess)
						{
							throw new Exception(result.Message);
						}
						obj.LOGICALREF = result.Data.LOGICALREF;
						foreach (var item in obj.TRANSACTIONS)
						{
							using (var stlineContext = new LG_STLINE_Context())
							{

								item.STFICHEREF = obj.LOGICALREF;

								var resultLine = await stlineContext.InsertAsync(item);
								if (!resultLine.IsSuccess)
								{
									throw new Exception(resultLine.Message);
								}

								foreach (var sltrans in item.SERILOTTRANSACTIONS)
								{
									using (var sltransContext = new LG_SLTRANS_Context())
									{
										var resultSltrans = await sltransContext.InsertAsync(sltrans);
										if (!resultSltrans.IsSuccess)
										{
											throw new Exception(resultSltrans.Message);
										}
									}
								}

							}
						}

						await UpdateNumber(obj);
						return new DataResult<RetailSalesReturnDispatchTransactionDto>()
						{
							Data = dto,
							IsSuccess = true,
							Message = "Transaction has been successfully inserted."
						};
					}
					catch (Exception ex)
					{
						// Log the exception
						_logger.LogError(ex, "An error occurred during transaction processing.");
						throw; // Rethrow the exception to propagate it further
					}
				}
			}
		}
		private async Task<string> GetNextDocumentNumberAsync(LG_STFICHE item)
		{
			try
			{
				using (L_LDOCNUM_Context context = new())
				{
					string lastDocumentNumber = await context.GetLastAsgn(item.DATE_.ToString("s"), item.DATE_.ToString("s"), item.TRCODE);

					if (string.IsNullOrEmpty(lastDocumentNumber))
					{
						lastDocumentNumber = "0"; // Assume starting point if no last document number is found
					}

					if (!BigInteger.TryParse(lastDocumentNumber, out BigInteger lastNumber))
					{
						throw new InvalidOperationException("Invalid document number format.");
					}

					BigInteger nextNumber = lastNumber + 1;
					return nextNumber.ToString("D16"); // Adjust the format as needed
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		private async Task UpdateNumber(LG_STFICHE item)
		{
			try
			{
				using (L_LDOCNUM_Context context = new())
				{
					await context.UpdateObject(await GetNextDocumentNumberAsync(item), item.DATE_.ToString("s"), item.DATE_.ToString("s"), item.TRCODE);

				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
