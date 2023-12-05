using Helix.Tiger.Entity.BaseModel;

namespace Helix.Tiger.Entity
{
    public class LG_TransferTransactionLine : LG_ProductTransactionLine
    {
        public LG_TransferTransactionLine()
        {
            SLTRANS = new List<LG_SeriLotTransaction>();
        }
        public short DESTINDEX { get; set; } = default;
        public short DESTCOSTGRP { get; set; } = default;
        public IList<LG_SeriLotTransaction> SLTRANS { get; set; }
    }
}
