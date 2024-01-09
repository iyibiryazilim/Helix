using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.SalesModule.Models;

public partial class SpeCodeModel :ObservableObject
{
    [ObservableProperty]
    int referenceId;

    [ObservableProperty]
    string speCode;

    [ObservableProperty]
    string definition;
}
