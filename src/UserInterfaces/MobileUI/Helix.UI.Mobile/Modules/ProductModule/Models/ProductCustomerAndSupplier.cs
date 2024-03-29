﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
    public partial class ProductCustomerAndSupplier : ObservableObject
    {
        [ObservableProperty]
        string productCode;
        [ObservableProperty]
        string productName;
        [ObservableProperty]
        int subUnitsetReferenceId;
        [ObservableProperty]
        int? currentReferenceId;
        [ObservableProperty]
        string currentCode;
        [ObservableProperty]
        string producerCode;
        [ObservableProperty]
        string currentName;
        [ObservableProperty]
        string subUnitsetCode;
        [ObservableProperty]
        short? priority;
        [ObservableProperty]
        short? cardType;

        public string CardTypeName
        {
            get
            {

                switch (CardType)
                {
                    case 0:
                        return "Müşteri : ";
                    case 1:
                        return "Tedarikçi : ";
                    default:
                        return "Diğer";
                }
            }
        }


        [ObservableProperty]
        string barcode;
        [ObservableProperty]
        double? quantity;
        [ObservableProperty]
        string customerSupplierCode;
      
    }
}
