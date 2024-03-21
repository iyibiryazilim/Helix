namespace Helix.ProductService.Domain.Dtos
{
	public record VariantDto(short CardType, string Code, string Name, string UnitsetCode, string ProductCode, IList<VariantAssignDto> Lines)
	{
	}

	public record VariantAssignDto(string VariantPropertyCode, string VariantPropertyName, string VariantPropertyValueCode)
	{
	}
}