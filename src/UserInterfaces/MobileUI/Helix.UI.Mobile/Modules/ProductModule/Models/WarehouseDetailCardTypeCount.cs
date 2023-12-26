using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
	public partial class WarehouseDetailCardTypeCount : ObservableObject
	{
		[ObservableProperty]
		short cardType;

		[ObservableProperty]
		int referenceCount;

		public string CardTypeName
		{
			get
			{
				switch (CardType)
				{
					case 10:
						return "Hammadde";
					case 11:
						return "Yarımamul";
					case 12:
						return "Mamul";
					case 1:
						return "Ticari Mal";
					case 2:
						return "Karma koli";
					case 3:
						return "Depozitolu mal";
					case 4:
						return "Sabit kıymet";
					case 13:
						return "Tüketim malı";
					default:
						return "Diğer";
				}
			}
		}
	}
}
