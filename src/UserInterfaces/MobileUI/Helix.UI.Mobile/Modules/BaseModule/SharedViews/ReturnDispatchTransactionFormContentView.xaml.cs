using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ReturnDispatchTransactionFormContentView : ContentView
{
    //SpeCodeList
    public static readonly BindableProperty SpeCodeListProperty = BindableProperty.Create(nameof(SpeCodeList), typeof(ObservableCollection<SpeCodeModel>), typeof(ReturnDispatchTransactionFormContentView));

    //SpeCodeCommand
    public static readonly BindableProperty GetSpeCodeCommandProperty = BindableProperty.Create(nameof(GetSpeCodeCommand), typeof(AsyncRelayCommand), typeof(ReturnDispatchTransactionFormContentView), null);

    public AsyncRelayCommand GetSpeCodeCommand
    {
        get => GetValue(GetSpeCodeCommandProperty) as AsyncRelayCommand;
        set => SetValue(GetSpeCodeCommandProperty, value);
    }
    //SpeCodeList
    public ObservableCollection<SpeCodeModel> SpeCodeList
    {
        get => GetValue(SpeCodeListProperty) as ObservableCollection<SpeCodeModel>;
        set => SetValue(SpeCodeListProperty, value);
    }

    public ReturnDispatchTransactionFormContentView()
	{
		InitializeComponent();
	}
}