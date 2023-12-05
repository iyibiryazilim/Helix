namespace Helix.SharedEntity.DTOs.Base
{
	public abstract class BaseDto
	{
        public BaseDto()
        {
            LBSParameter = new();
        }
        public LBSParameterDto? LBSParameter { get; set; }
    }
}
