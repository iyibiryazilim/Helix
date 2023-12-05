using Helix.Tiger.Entity.BaseModel;

namespace Helix.Tiger.Entity
{
    public class LG_InCountingTransaction : LG_ProductTransaction
	{
        public LG_InCountingTransaction()
        {
            TRANSACTIONS = new List<LG_InCountingTransactionLine>();
        }
        public IList<LG_InCountingTransactionLine> TRANSACTIONS { get; set; }
    }
}
