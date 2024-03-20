using AutoMapper;
using Helix.LBSService.WebAPI.Helper.Profiles;

namespace Helix.LBSService.WebAPI.Helper.Mappers
{
	public static class Mapping
	{
		private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
				cfg.AddProfile<RetailSalesDispatchTransactionLineProfile>();
				cfg.AddProfile<RetailSalesDispatchTransactionProfile>();
				cfg.AddProfile<ConsumableTransactionLineProfile>();
				cfg.AddProfile<ConsumableTransactionProfile>();
				cfg.AddProfile<WholeSalesDispatchTransactionLineProfile>();
				cfg.AddProfile<WholeSalesDispatchTransactionProfile>();
				cfg.AddProfile<RetailSalesReturnDispatchTransactionLineProfile>();
				cfg.AddProfile<RetailSalesReturnDispatchTransactionProfile>();
				cfg.AddProfile<WholeSalesReturnTransactionLineProfile>();
				cfg.AddProfile<WholeSalesReturnTransactionProfile>();
				cfg.AddProfile<PurchaseDispatchTransactionLineProfile>();
				cfg.AddProfile<PurchaseDispatchTransactionProfile>();
				cfg.AddProfile<PurchaseReturnDispatchTransactionLineProfile>();
				cfg.AddProfile<PurchaseReturnDispatchTransactionProfile>();
				cfg.AddProfile<WastageTransactionProfile>();
				cfg.AddProfile<WastageTransactionLineProfile>();
				cfg.AddProfile<InCountingTransactionProfile>();
				cfg.AddProfile<InCountingTransactionLineProfile>();
				cfg.AddProfile<OutCountingTransactionProfile>();
				cfg.AddProfile<OutCountingTransactionLineProfile>();
				cfg.AddProfile<ProductionTransactionProfile>();
				cfg.AddProfile<ProductionTransactionLineProfile>();
				cfg.AddProfile<TransferTransactionProfile>();
				cfg.AddProfile<TransferTransactionLineProfile>();
				cfg.AddProfile<SalesOrderProfile>();
				cfg.AddProfile<SalesOrderLineProfile>();
				cfg.AddProfile<PurchaseOrderProfile>();
				cfg.AddProfile<PurchaseOrderLineProfile>();
				cfg.AddProfile<CurrentProfile>();
				cfg.AddProfile<VariantProfile>();
				cfg.AddProfile<VariantAssignProfile>();
				cfg.AllowNullCollections = true;

			});
			//config.AssertConfigurationIsValid();
			var mapper = config.CreateMapper();
			return mapper;
		});

		public static IMapper Mapper => Lazy.Value;
	}
}
