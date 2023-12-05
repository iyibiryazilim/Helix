namespace Helix.SharedEntity.DTOs
{
	public class LBSParameterDto
	{
		#region Logo Firma Bilgileri
		/// <summary>
		/// Logo Firma Bilgisi
		/// </summary>
		public int DefaultFirmNumber { get; set; } = default;
		/// <summary>
		/// Logo Dönem Bilgisi
		/// </summary>
		public int DefaultPeriodNumber { get; set; } = default;
		#endregion

		#region Logo Kullanıcı Bilgileri
		/// <summary>
		/// Logo Kullanıcı Adı
		/// </summary>
		public string LBS_UserName { get; set; } = string.Empty;
		/// <summary>
		/// Logo Kullanıcı Şifresi
		/// </summary>
		public string LBS_Password { get; set; } = string.Empty;
		#endregion
	}
}
