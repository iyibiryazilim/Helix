using Helix.Tiger.Entity.BaseModel;

namespace Helix.Tiger.Entity
{
    public class LG_ProductDevirTransaction : LG_ProductTransaction
    {
        public LG_ProductDevirTransaction()
        {
            TRANSACTIONS = new List<LG_ProductDevirTransactionLine>();
        }
        public IList<LG_ProductDevirTransactionLine> TRANSACTIONS { get; set; }
    }
}
