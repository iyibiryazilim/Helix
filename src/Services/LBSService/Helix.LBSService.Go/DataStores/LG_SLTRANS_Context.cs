using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Models;
using Helix.LBSService.Go.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Helix.LBSService.Go.DataStores
{
	public class LG_SLTRANS_Context : ILG_SLTRANS_Context
	{
		readonly IEventBus _eventBus;
		readonly int _defaultFirmNumber = LBSParameter.FirmNumber;
		readonly int _defaultPeriodNumber = LBSParameter.Period;
		readonly string _connectionString = LBSParameter.Connection;
        readonly Logger<LG_SLTRANS_Context> _logger;

		public LG_SLTRANS_Context(IEventBus eventBus, Logger<LG_SLTRANS_Context> logger)
		{
			_eventBus = eventBus;
			_logger = logger;
		}
		public async Task<DataResult<LG_SLTRANS>> InsertAsync(LG_SLTRANS dto)
		{
			try
			{
				string seriLotQuery = $@"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_SLTRANS(
            STFICHEREF
           ,DATE_
           ,STTRANSREF
           ,INTRANSREF
           ,INSLTRANSREF
           ,INSLAMOUNT
           ,LINENR
           ,ITEMREF
           ,IOCODE
           ,INVENNO
           ,FICHETYPE
           ,SLTYPE
           ,SLREF
           ,LOCREF
           ,MAINAMOUNT
           ,UOMREF
           ,AMOUNT
           ,REMAMOUNT
           ,REMLNUNITAMNT
           ,UINFO1
           ,UINFO2
           ,UINFO3
           ,UINFO4
           ,UINFO5
           ,UINFO6
           ,UINFO7
           ,UINFO8
           ,RATESCORE
           ,CANCELLED
           ,OUTCOST
           ,OUTCOSTCURR
           ,DIFFPRCOST
           ,DIFFPRCOSTCURR
           ,SERIQCOK
           ,LPRODSTAT
           ,SOURCETYPE
           ,SOURCEWSREF
           ,SITEID
           ,RECSTATUS
           ,ORGLOGICREF
           ,WFSTATUS
           ,DISTORDREF
           ,DISTORDLNREF
           ,INDORDSLTRNREF
           ,GROSSUINFO1
           ,GROSSUINFO2
           ,ATAXPRCOST
           ,ATAXPRCOSTCURR
           ,INFIDX
           ,ORGLOGOID
           ,LINEEXP
           ,EXIMFCTYPE
           ,EXIMFILEREF
           ,EXIMPROCNR
           ,MAINSLLNREF
           ,MADEOFSHRED
           ,STATUS
           ,VARIANTREF
           ,GRPBEGCODE
           ,GRPENDCODE
           ,OUTCOSTUFRS
           ,OUTCOSTCURRUFRS
           ,DIFFPRCOSTUFRS
           ,DIFFPRCOSTCURRUFRS
           ,INFIDXUFRS
           ,ADJPRCOSTUFRS
           ,ADJPRCOSTCURRUFRS
           ,GUID
           ,PRDORDREF
           ,PRDORDSLPLNRESERVE
           ,INPLNSLTRANSREF
           ,NOTSHIPPED
            ,EXPDATE)  
         VALUES(
            @STFICHEREF
           ,@DATE_
           ,@STTRANSREF
           ,@INTRANSREF
           ,@INSLTRANSREF
           ,@INSLAMOUNT
           ,@LINENR
           ,@ITEMREF
           ,@IOCODE
           ,@INVENNO
           ,@FICHETYPE
           ,@SLTYPE
           ,@SLREF
           ,@LOCREF
           ,@MAINAMOUNT
           ,@UOMREF
           ,@AMOUNT
           ,@REMAMOUNT
           ,@REMLNUNITAMNT
           ,@UINFO1
           ,@UINFO2
           ,@UINFO3
           ,@UINFO4
           ,@UINFO5
           ,@UINFO6
           ,@UINFO7
           ,@UINFO8
           ,@RATESCORE
           ,@CANCELLED
           ,@OUTCOST
           ,@OUTCOSTCURR
           ,@DIFFPRCOST
           ,@DIFFPRCOSTCURR
           ,@SERIQCOK
           ,@LPRODSTAT
           ,@SOURCETYPE
           ,@SOURCEWSREF
           ,@SITEID
           ,@RECSTATUS
           ,@ORGLOGICREF
           ,@WFSTATUS
           ,@DISTORDREF
           ,@DISTORDLNREF
           ,@INDORDSLTRNREF
           ,@GROSSUINFO1
           ,@GROSSUINFO2
           ,@ATAXPRCOST
           ,@ATAXPRCOSTCURR
           ,@INFIDX
           ,@ORGLOGOID
           ,@LINEEXP
           ,@EXIMFCTYPE
           ,@EXIMFILEREF
           ,@EXIMPROCNR
           ,@MAINSLLNREF
           ,@MADEOFSHRED
           ,@STATUS
           ,@VARIANTREF
           ,@GRPBEGCODE
           ,@GRPENDCODE
           ,@OUTCOSTUFRS
           ,@OUTCOSTCURRUFRS
           ,@DIFFPRCOSTUFRS
           ,@DIFFPRCOSTCURRUFRS
           ,@INFIDXUFRS
           ,@ADJPRCOSTUFRS
           ,@ADJPRCOSTCURRUFRS
           ,@GUID
           ,@PRDORDREF
           ,@PRDORDSLPLNRESERVE
           ,@INPLNSLTRANSREF
           ,@NOTSHIPPED
           ,@EXPDATE
         	); SELECT SCOPE_IDENTITY();";
				using (SqlConnection connection = new SqlConnection(_connectionString))
				await using (SqlCommand command = new SqlCommand(seriLotQuery, connection))
				{
                    await connection.OpenAsync();   
					#region Serilot
					command.Parameters.AddWithValue("STFICHEREF", dto.STFICHEREF);
					command.Parameters.AddWithValue("STTRANSREF", dto.STTRANSREF);
					command.Parameters.AddWithValue("INTRANSREF", dto.INTRANSREF);
					command.Parameters.AddWithValue("INSLTRANSREF", dto.INSLTRANSREF);
					command.Parameters.AddWithValue("INSLAMOUNT", dto.INSLAMOUNT);
					command.Parameters.AddWithValue("LINENR", dto.LINENR);
					command.Parameters.AddWithValue("DATE_", dto.DATE_);
					command.Parameters.AddWithValue("IOCODE", dto.IOCODE);
					command.Parameters.AddWithValue("INVENNO", dto.INVENNO);
					command.Parameters.AddWithValue("FICHETYPE", dto.FICHETYPE);
					command.Parameters.AddWithValue("SLTYPE", dto.SLTYPE);
					command.Parameters.AddWithValue("SLREF", dto.SLREF);
					command.Parameters.AddWithValue("LOCREF", dto.LOCREF);
					command.Parameters.AddWithValue("MAINAMOUNT", dto.MAINAMOUNT);
					command.Parameters.AddWithValue("UOMREF", dto.UOMREF);
					command.Parameters.AddWithValue("AMOUNT", dto.AMOUNT);
					command.Parameters.AddWithValue("REMAMOUNT", dto.REMAMOUNT);
					command.Parameters.AddWithValue("REMLNUNITAMNT", dto.REMLNUNITAMNT);
					command.Parameters.AddWithValue("UINFO1", dto.UINFO1);
					command.Parameters.AddWithValue("UINFO2", dto.UINFO2);
					command.Parameters.AddWithValue("UINFO3", dto.UINFO3);
					command.Parameters.AddWithValue("UINFO4", dto.UINFO4);
					command.Parameters.AddWithValue("UINFO5", dto.UINFO5);
					command.Parameters.AddWithValue("UINFO6", dto.UINFO6);
					command.Parameters.AddWithValue("UINFO7", dto.UINFO7);
					command.Parameters.AddWithValue("UINFO8", dto.UINFO8);
					command.Parameters.AddWithValue("EXPDATE", dto.EXPDATE);
					command.Parameters.AddWithValue("RATESCORE", dto.RATESCORE);
					command.Parameters.AddWithValue("CANCELLED", dto.CANCELLED);
					command.Parameters.AddWithValue("OUTCOST", dto.OUTCOST);
					command.Parameters.AddWithValue("OUTCOSTCURR", dto.OUTCOSTCURR);
					command.Parameters.AddWithValue("DIFFPRCOST", dto.DIFFPRCOST);
					command.Parameters.AddWithValue("DIFFPRCOSTCURR", dto.DIFFPRCOSTCURR);
					command.Parameters.AddWithValue("SERIQCOK", dto.SERIQCOK);
					command.Parameters.AddWithValue("LPRODSTAT", dto.LPRODSTAT);
					command.Parameters.AddWithValue("SOURCETYPE", dto.SOURCETYPE);
					command.Parameters.AddWithValue("SOURCEWSREF", dto.SOURCEWSREF);
					command.Parameters.AddWithValue("SITEID", dto.SITEID);
					command.Parameters.AddWithValue("RECSTATUS", dto.RECSTATUS);
					command.Parameters.AddWithValue("ORGLOGICREF", dto.ORGLOGICREF);
					command.Parameters.AddWithValue("WFSTATUS", dto.WFSTATUS);
					command.Parameters.AddWithValue("DISTORDREF", dto.DISTORDREF);
					command.Parameters.AddWithValue("DISTORDLNREF", dto.DISTORDLNREF);
					command.Parameters.AddWithValue("INDORDSLTRNREF", dto.INDORDSLTRNREF);
					command.Parameters.AddWithValue("GROSSUINFO1", dto.GROSSUINFO1);
					command.Parameters.AddWithValue("GROSSUINFO2", dto.GROSSUINFO2);
					command.Parameters.AddWithValue("ATAXPRCOST", dto.ATAXPRCOST);
					command.Parameters.AddWithValue("ATAXPRCOSTCURR", dto.ATAXPRCOSTCURR);
					command.Parameters.AddWithValue("INFIDX", dto.INFIDX);
					command.Parameters.AddWithValue("ORGLOGOID", dto.ORGLOGOID);
					command.Parameters.AddWithValue("LINEEXP", dto.LINEEXP);
					command.Parameters.AddWithValue("EXIMFCTYPE", dto.EXIMFCTYPE);
					command.Parameters.AddWithValue("EXIMFILEREF", dto.EXIMFILEREF);
					command.Parameters.AddWithValue("EXIMPROCNR", dto.EXIMPROCNR);
					command.Parameters.AddWithValue("MAINSLLNREF", dto.MAINSLLNREF);
					command.Parameters.AddWithValue("MADEOFSHRED", dto.MADEOFSHRED);
					command.Parameters.AddWithValue("STATUS", dto.STATUS);
					command.Parameters.AddWithValue("VARIANTREF", dto.VARIANTREF);
					command.Parameters.AddWithValue("GRPBEGCODE", dto.GRPBEGCODE);
					command.Parameters.AddWithValue("GRPENDCODE", dto.GRPENDCODE);
					command.Parameters.AddWithValue("OUTCOSTUFRS", dto.OUTCOSTUFRS);
					command.Parameters.AddWithValue("OUTCOSTCURRUFRS", dto.OUTCOSTCURRUFRS);
					command.Parameters.AddWithValue("DIFFPRCOSTUFRS", dto.DIFFPRCOSTUFRS);
					command.Parameters.AddWithValue("DIFFPRCOSTCURRUFRS", dto.DIFFPRCOSTCURRUFRS);
					command.Parameters.AddWithValue("INFIDXUFRS", dto.INFIDXUFRS);
					command.Parameters.AddWithValue("ADJPRCOSTUFRS", dto.ADJPRCOSTUFRS);
					command.Parameters.AddWithValue("ADJPRCOSTCURRUFRS", dto.ADJPRCOSTCURRUFRS);
					command.Parameters.AddWithValue("GUID", dto.GUID);
					command.Parameters.AddWithValue("PRDORDREF", dto.PRDORDREF);
					command.Parameters.AddWithValue("PRDORDSLPLNRESERVE", dto.PRDORDSLPLNRESERVE);
					command.Parameters.AddWithValue("INPLNSLTRANSREF", dto.INPLNSLTRANSREF);
					command.Parameters.AddWithValue("NOTSHIPPED", dto.NOTSHIPPED);
					#endregion

					var id = await command.ExecuteScalarAsync();
					if (id != null)
					{
						dto.LOGICALREF = Convert.ToInt32(id);
						return new DataResult<LG_SLTRANS>()
						{
							Data = dto,
							Message = "Insert successful",
							IsSuccess = true
						};
					}
					else
					{

						throw new Exception("Insert failed");
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while inserting the object."); 
				throw;
			}
		}
	}
}
