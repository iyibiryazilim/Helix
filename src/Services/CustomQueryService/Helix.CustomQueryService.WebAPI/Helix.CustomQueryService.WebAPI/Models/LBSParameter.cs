namespace Helix.CustomQueryService.WebAPI.Models
{
	public class LBSParameter
	{
		#region Veri Tabanı Erişim Bilgileri
		public string DataSource { get; set; } = string.Empty;
		public string UserId { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string InitialCatalog { get; set; } = string.Empty;
		public bool IsMasterDb { get; set; } = default;
		public string MasterDb { get; set; } = string.Empty;

		#endregion

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

		public override string ToString()
		{
			return $"Data Source={this.DataSource}; User id= {this.UserId}; Password = {this.Password}; Initial Catalog = {this.InitialCatalog}";
		}
	}
}
