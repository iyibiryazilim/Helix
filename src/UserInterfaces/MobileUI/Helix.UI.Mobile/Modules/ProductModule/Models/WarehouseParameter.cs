using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
    public partial class WarehouseParameter :ObservableObject
    {
        [ObservableProperty]
        short warehouseNumber;

        [ObservableProperty]
        string warehouseName;

        [ObservableProperty]
        double? minLevel;

        [ObservableProperty]
        double? maxLevel;

        [ObservableProperty]
        double? safeLevel;

        [ObservableProperty]
        double? stockQuantity;

        [ObservableProperty]
        int? subUnitsetReferenceId;

        [ObservableProperty]
        string? subUnitsetCode;

        public Microsoft.Maui.Graphics.Color StockColor
        {
            get
            {
                if (StockQuantity < MinLevel)
                {
                    return Microsoft.Maui.Graphics.Color.FromRgba("#c1322a");
                }

                if(StockQuantity>MaxLevel)
                {
                    return Microsoft.Maui.Graphics.Color.FromRgba("#2ca57c");
                }

                if (StockQuantity==SafeLevel)
                {
                    return Microsoft.Maui.Graphics.Color.FromRgba("#ffd300");
                }
                if (StockQuantity == 0)
                {
                    return Microsoft.Maui.Graphics.Color.FromRgba("#2B0B98");
                }
                else
                {
                    return Microsoft.Maui.Graphics.Color.FromRgba("#2B0B98");
                }


            }
            set
            {

            }
        }



    }
}
