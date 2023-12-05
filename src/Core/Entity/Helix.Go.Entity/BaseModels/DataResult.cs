namespace Helix.Go.Entity.BaseModels;

public class DataResult<T>
{
	public T? Data { get; set; }
	public bool IsSuccess { get; set; } = false;
	public string? Message { get; set; }
	public int Page { get; set; } = 1;
	public int PageSize { get; set; } = 100;
	public int TotalRecords { get; set; }
}
