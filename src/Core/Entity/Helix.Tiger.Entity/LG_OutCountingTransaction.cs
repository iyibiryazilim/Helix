using Helix.Tiger.Entity.BaseModel;

namespace Helix.Tiger.Entity
{
    public class LG_OutCountingTransaction : LG_ProductTransaction
    {
        public LG_OutCountingTransaction()
        {
            TRANSACTIONS = new List<LG_OutCountingTransactionLine>();
        }
        public IList<LG_OutCountingTransactionLine> TRANSACTIONS { get; set; }
    }
}
