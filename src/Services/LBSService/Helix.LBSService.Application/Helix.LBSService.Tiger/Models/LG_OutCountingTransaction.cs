using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.Tiger.Models
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
