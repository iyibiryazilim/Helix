﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.Models
{
    public partial class Driver :ObservableObject
    {
        [ObservableProperty]
        int referenceId;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string surname;

        [ObservableProperty]
        string identityNumber;

        [ObservableProperty]
        string plateNumber;



    }
}
