namespace Helix.SharedEntity.DTOs;

public class WorkOrderDto
{

    public int? WorkOrderReferenceId { get; set; }
    public int? ProductReferenceId { get; set; }
    public double ActualQuantity { get; set; } = default;
    public int? SubUnitsetReferenceId { get; set; }

    /// <summary>
    /// Hesaplama Şekli 0-Reçete 1-Üretim emri
    /// </summary>
    public short CalculatedMethod { get; set; }

    public bool IsIncludeSideProduct { get; set; }

}
