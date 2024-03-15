using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Models;
using Helix.LBSService.Go.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Helix.LBSService.Go.DataStores
{
	public class LG_EINVOICEDET_Context : ILG_EINVOICEDET_Context
	{
		readonly IEventBus _eventBus;
		readonly int _defaultFirmNumber = LBSParameter.FirmNumber;
		readonly int _defaultPeriodNumber = LBSParameter.Period;
		readonly string _connectionString = LBSParameter.Connection;
		readonly Logger<LG_EINVOICEDET_Context> _logger;

		public LG_EINVOICEDET_Context(IEventBus eventBus, Logger<LG_EINVOICEDET_Context> logger)
		{
			_eventBus = eventBus;
			_logger = logger;
		}
		public async Task<DataResult<LG_EINVOICEDET>> InsertAsync(LG_EINVOICEDET dto)
		{
			try
			{
				string driverQuery = string.Format(@$"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_EINVOICEDET
            ([INVOICEREF]
           ,[STFREF]
           ,[EINVOICETYP]
           ,[PROFILEID]
           ,[ESTATUS]
           ,[EDESCRIPTION]
           ,[EDURATION]
           ,[EDURATIONTYPE]
           ,[TAXTYPE]
           ,[TUNAME]
           ,[TUSURNAME]
           ,[TUPASSPORTNO]
           ,[TUNATIONALITY]
           ,[TUNATIONALITYNAME]
           ,[TUBANKNAME]
           ,[TUBNACCOUNTNO]
           ,[TUBNBRANCH]
           ,[TUPAYMENTNOTE]
           ,[TUBNCURR]
           ,[ADDR1]
           ,[ADDR2]
           ,[CITYCODE]
           ,[CITY]
           ,[COUNTRYCODE]
           ,[COUNTRY]
           ,[DISTRICTCODE]
           ,[DISTRICT]
           ,[TOWNCODE]
           ,[TOWN]
           ,[EXITTOWN]
           ,[EXITGATECODE]
           ,[EXITGATE]
           ,[AGENCYCODE]
           ,[AGENCY]
           ,[EXITCOUNTRYCODE]
           ,[EXITCOUNTRY]
           ,[TRANSPORTTYP]
           ,[TRANSPORTTYPCODE]
           ,[TRANSPORTTYPNAME]
           ,[FLIGHTNUMBER]
           ,[GUIDE]
           ,[TURETPRICE]
           ,[SENDEINVCUSTOM]
           ,[EINVOICETYPSGK]
           ,[TAXPAYERCODE]
           ,[TAXPAYERNAME]
           ,[DOCUMENTNOSGK]
           ,[DRIVERNAME1]
           ,[DRIVERNAME2]
           ,[DRIVERNAME3]
           ,[DRIVERSURNAME1]
           ,[DRIVERSURNAME2]
           ,[DRIVERSURNAME3]
           ,[DRIVERTCKNO1]
           ,[DRIVERTCKNO2]
           ,[DRIVERTCKNO3]
           ,[PLATENUM1]
           ,[PLATENUM2]
           ,[PLATENUM3]
           ,[CHASSISNUM1]
           ,[CHASSISNUM2]
           ,[CHASSISNUM3]
           ,[RESPONSECODE]
           ,[RESPONSESTATUS]
           ,[STATUSDESC]
           ,[RESPONSECODEDESP]
           ,[RESPONSESTATUSDESP]
           ,[STATUSDESCDESP]
           ,[ORDFCREF]
           ,[CHAINDELIVERY]
           ,[SELLERCLIENTREF]
           ,[TAXNRTOPAY]) 
            VALUES(
            @INVOICEREF,@STFREF,@EINVOICETYP,@PROFILEID,@ESTATUS,@EDESCRIPTION,@EDURATION,@EDURATIONTYPE,@TAXTYPE,@TUNAME
           ,@TUSURNAME,@TUPASSPORTNO,@TUNATIONALITY,@TUNATIONALITYNAME,@TUBANKNAME,@TUBNACCOUNTNO,@TUBNBRANCH
           ,@TUPAYMENTNOTE,@TUBNCURR,@ADDR1,@ADDR2,@CITYCODE,@CITY,@COUNTRYCODE,@COUNTRY
           ,@DISTRICTCODE,@DISTRICT,@TOWNCODE,@TOWN,@EXITTOWN,@EXITGATECODE,@EXITGATE,@AGENCYCODE,@AGENCY,@EXITCOUNTRYCODE,@EXITCOUNTRY
           ,@TRANSPORTTYP,@TRANSPORTTYPCODE,@TRANSPORTTYPNAME,@FLIGHTNUMBER,@GUIDE,@TURETPRICE,@SENDEINVCUSTOM
           ,@EINVOICETYPSGK,@TAXPAYERCODE,@TAXPAYERNAME,@DOCUMENTNOSGK,@DRIVERNAME1,@DRIVERNAME2,@DRIVERNAME3,@DRIVERSURNAME1
           ,@DRIVERSURNAME2,@DRIVERSURNAME3,@DRIVERTCKNO1,@DRIVERTCKNO2,@DRIVERTCKNO3,@PLATENUM1,@PLATENUM2,@PLATENUM3,@CHASSISNUM1
           ,@CHASSISNUM2,@CHASSISNUM3,@RESPONSECODE,@RESPONSESTATUS,@STATUSDESC,@RESPONSECODEDESP,@RESPONSESTATUSDESP,@STATUSDESCDESP,@ORDFCREF,@CHAINDELIVERY
           ,@SELLERCLIENTREF,@TAXNRTOPAY); SELECT SCOPE_IDENTITY();");

				using SqlConnection connection = new SqlConnection(_connectionString);
				await using (SqlCommand command = new SqlCommand(driverQuery, connection))
				{
					#region Driver
					command.Parameters.AddWithValue("INVOICEREF", dto.INVOICEREF);
					command.Parameters.AddWithValue("ORDFCREF", dto.ORDFCREF);
					command.Parameters.AddWithValue("SELLERCLIENTREF", dto.SELLERCLIENTREF);
					command.Parameters.AddWithValue("STFREF", dto.STFREF);
					command.Parameters.AddWithValue("CHASSISNUM1", dto.CHASSISNUM1);
					command.Parameters.AddWithValue("CHASSISNUM2", dto.CHASSISNUM2);
					command.Parameters.AddWithValue("CHASSISNUM3", dto.CHASSISNUM3);
					command.Parameters.AddWithValue("FLIGHTNUMBER", dto.FLIGHTNUMBER);
					command.Parameters.AddWithValue("PLATENUM1", dto.PLATENUM1);
					command.Parameters.AddWithValue("PLATENUM2", dto.PLATENUM2);
					command.Parameters.AddWithValue("PLATENUM3", dto.PLATENUM3);
					command.Parameters.AddWithValue("DISTRICTCODE", dto.DISTRICTCODE);
					command.Parameters.AddWithValue("DRIVERTCKNO1", dto.DRIVERTCKNO1);
					command.Parameters.AddWithValue("DRIVERTCKNO2", dto.DRIVERTCKNO2);
					command.Parameters.AddWithValue("DRIVERTCKNO3", dto.DRIVERTCKNO3);
					command.Parameters.AddWithValue("EXITCOUNTRY", dto.EXITCOUNTRY);
					command.Parameters.AddWithValue("EXITCOUNTRYCODE", dto.EXITCOUNTRYCODE);
					command.Parameters.AddWithValue("COUNTRYCODE", dto.COUNTRYCODE);
					command.Parameters.AddWithValue("COUNTRY", dto.COUNTRY);
					command.Parameters.AddWithValue("GUIDE", dto.GUIDE);
					command.Parameters.AddWithValue("CITY", dto.CITY);
					command.Parameters.AddWithValue("CITYCODE", dto.CITYCODE);
					command.Parameters.AddWithValue("AGENCYCODE", dto.AGENCYCODE);
					command.Parameters.AddWithValue("TRANSPORTTYPCODE", dto.TRANSPORTTYPCODE);
					command.Parameters.AddWithValue("TOWNCODE", dto.TOWNCODE);
					command.Parameters.AddWithValue("TOWN", dto.TOWN);
					command.Parameters.AddWithValue("TAXPAYERCODE", dto.TAXPAYERCODE);
					command.Parameters.AddWithValue("ADDR1", dto.ADDR1);
					command.Parameters.AddWithValue("ADDR2", dto.ADDR2);
					command.Parameters.AddWithValue("AGENCY", dto.AGENCY);
					command.Parameters.AddWithValue("DISTRICT", dto.DISTRICT);
					command.Parameters.AddWithValue("DOCUMENTNOSGK", dto.DOCUMENTNOSGK);
					command.Parameters.AddWithValue("DRIVERNAME1", dto.DRIVERNAME1);
					command.Parameters.AddWithValue("DRIVERNAME2", dto.DRIVERNAME2);
					command.Parameters.AddWithValue("DRIVERNAME3", dto.DRIVERNAME3);
					command.Parameters.AddWithValue("DRIVERSURNAME1", dto.DRIVERSURNAME1);
					command.Parameters.AddWithValue("DRIVERSURNAME2", dto.DRIVERSURNAME2);
					command.Parameters.AddWithValue("DRIVERSURNAME3", dto.DRIVERSURNAME3);
					command.Parameters.AddWithValue("EDESCRIPTION", dto.EDESCRIPTION);
					command.Parameters.AddWithValue("TRANSPORTTYPNAME", dto.TRANSPORTTYPNAME);
					command.Parameters.AddWithValue("TUSURNAME", dto.TUSURNAME);
					command.Parameters.AddWithValue("TUNAME", dto.TUNAME);
					command.Parameters.AddWithValue("TUNATIONALITY", dto.TUNATIONALITY);
					command.Parameters.AddWithValue("TUNATIONALITYNAME", dto.TUNATIONALITYNAME);
					command.Parameters.AddWithValue("TUBNCURR", dto.TUBNCURR);
					command.Parameters.AddWithValue("TUBNBRANCH", dto.TUBNBRANCH);
					command.Parameters.AddWithValue("TUBNACCOUNTNO", dto.TUBNACCOUNTNO);
					command.Parameters.AddWithValue("TUBANKNAME", dto.TUBANKNAME);
					command.Parameters.AddWithValue("STATUSDESC", dto.STATUSDESC);
					command.Parameters.AddWithValue("STATUSDESCDESP", dto.STATUSDESCDESP);
					command.Parameters.AddWithValue("TUPAYMENTNOTE", dto.TUPAYMENTNOTE);
					command.Parameters.AddWithValue("TAXPAYERNAME", dto.TAXPAYERNAME);
					command.Parameters.AddWithValue("TAXNRTOPAY", dto.TAXNRTOPAY);
					command.Parameters.AddWithValue("TUPASSPORTNO", dto.TUPASSPORTNO);
					command.Parameters.AddWithValue("EXITTOWN", dto.EXITTOWN);
					command.Parameters.AddWithValue("EXITGATECODE", dto.EXITGATECODE);
					command.Parameters.AddWithValue("EXITGATE", dto.EXITGATE);
					command.Parameters.AddWithValue("RESPONSECODE", dto.RESPONSECODE);
					command.Parameters.AddWithValue("CHAINDELIVERY", dto.CHAINDELIVERY);
					command.Parameters.AddWithValue("TURETPRICE", dto.TURETPRICE);
					command.Parameters.AddWithValue("SENDEINVCUSTOM", dto.SENDEINVCUSTOM);
					command.Parameters.AddWithValue("RESPONSECODEDESP", dto.RESPONSECODEDESP);
					command.Parameters.AddWithValue("RESPONSESTATUS", dto.RESPONSESTATUS);
					command.Parameters.AddWithValue("RESPONSESTATUSDESP", dto.RESPONSESTATUSDESP);
					command.Parameters.AddWithValue("EDURATIONTYPE", dto.EDURATIONTYPE);
					command.Parameters.AddWithValue("EINVOICETYP", dto.EINVOICETYP);
					command.Parameters.AddWithValue("EINVOICETYPSGK", dto.EINVOICETYPSGK);
					command.Parameters.AddWithValue("TAXTYPE", dto.TAXTYPE);
					command.Parameters.AddWithValue("TRANSPORTTYP", dto.TRANSPORTTYP);
					command.Parameters.AddWithValue("PROFILEID", dto.PROFILEID);
					command.Parameters.AddWithValue("ESTATUS", dto.ESTATUS);
					command.Parameters.AddWithValue("EDURATION", dto.EDURATION);
					#endregion
					var id = await command.ExecuteScalarAsync();
					if (id != null)
					{
						dto.LOGICALREF = (int)id;
						return new DataResult<LG_EINVOICEDET> { Data = dto, IsSuccess = true, Message = "Success" };
					}
					else
					{
						return new DataResult<LG_EINVOICEDET> { Data = null, IsSuccess = false, Message = "Failed" };
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
