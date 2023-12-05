using Helix.Tiger.Entity.BaseModel;

namespace Helix.Tiger.Entity
{
    public class LG_WastageTransaction : LG_ProductTransaction
    {
        public LG_WastageTransaction()
        {
            TRANSACTIONS = new List<LG_WastageTransactionLine>();
        }
        public IList<LG_WastageTransactionLine> TRANSACTIONS { get; set; }
    }
}
