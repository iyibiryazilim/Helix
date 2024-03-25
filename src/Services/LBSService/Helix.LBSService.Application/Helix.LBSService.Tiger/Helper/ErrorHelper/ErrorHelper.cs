using UnityObjects;

namespace Helix.LBSService.Tiger.Helper.ErrorHelper
{
	public class ErrorHelper
	{
		public string GetError(Data items)
		{
			string error = string.Empty;

			if (items.ErrorCode != 0)
			{
				error = string.Format("DBError({0})-{1} {2}", items.ErrorCode.ToString(), items.ErrorDesc, items.DBErrorDesc);
			}
			else if (items.ValidateErrors.Count > 0)
			{
				string xmlList = "XML ErrorList:";
				for (int i = 0; i < items.ValidateErrors.Count; i++)
				{
					xmlList += "(" + items.ValidateErrors[i].ID.ToString() + ") - " + items.ValidateErrors[i].Error;
				}

				error = xmlList;
			}

			return error;
		}
	}
}