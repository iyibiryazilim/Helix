using Helix.Tiger.Entity.BaseModel;

namespace Helix.Tiger.Entity
{
    public class LG_ProductionTransaction : LG_ProductTransaction
    {
        public LG_ProductionTransaction()
        {
            TRANSACTIONS = new List<LG_ProductionTransactionLine>();
        }
        public IList<LG_ProductionTransactionLine> TRANSACTIONS { get; set; }

    }
}
