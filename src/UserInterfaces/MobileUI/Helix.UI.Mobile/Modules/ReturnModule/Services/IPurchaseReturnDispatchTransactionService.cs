using Helix.UI.Mobile.Modules.BaseModule.Dtos;

namespace Helix.UI.Mobile.Modules.ReturnModule.Services;

public interface IPurchaseReturnDispatchTransactionService<T> where T : class
{
	Task<DataResult<IEnumerable<T>>> GetObjects(HttpClient httpClient);
	Task<DataResult<T>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<T>> GetObjectByCode(HttpClient httpClient, string code);
	Task<DataResult<T>> GetObjectByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<T>> GetObjectByCurrentCode(HttpClient httpClient, string code);
}
