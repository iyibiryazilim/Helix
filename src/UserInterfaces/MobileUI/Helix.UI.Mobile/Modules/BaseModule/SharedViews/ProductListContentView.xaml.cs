//using Helix.UI.Mobile.Modules.BaseModule.Models;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ProductListContentView : ContentView
{
    //List
    public static readonly BindableProperty ProductListProperty = BindableProperty.Create(nameof(ProductList), typeof(ObservableCollection<Product>), typeof(ProductListContentView), null);
    public static readonly BindableProperty GroupListProperty = BindableProperty.Create(nameof(GroupList), typeof(ObservableCollection<ProductGroup>), typeof(ProductListContentView), null);


    //Commands
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(ProductListContentView), null);
    public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create(nameof(LoadMoreCommand), typeof(AsyncRelayCommand), typeof(ProductListContentView), null);
    public static readonly BindableProperty SortCommandProperty = BindableProperty.Create(nameof(SortCommand), typeof(AsyncRelayCommand), typeof(ProductListContentView), null);
    public static readonly BindableProperty ReloadCommandProperty = BindableProperty.Create(nameof(ReloadCommand), typeof(AsyncRelayCommand), typeof(ProductListContentView), null);
    public static readonly BindableProperty GoToDetailCommandProperty = BindableProperty.Create(nameof(GoToDetailCommand), typeof(AsyncRelayCommand), typeof(ProductListContentView), null);
    public static readonly BindableProperty SelectGroupCommandProperty = BindableProperty.Create(nameof(SelectGroupCommand), typeof(AsyncRelayCommand), typeof(ProductListContentView), null);

    //Properties
    public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(ProductListContentView), false);
    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(ProductListContentView), false);

    public ObservableCollection<Product> ProductList
    {
        get => GetValue(ProductListProperty) as ObservableCollection<Product>;
        set => SetValue(ProductListProperty, value);
    }
    public ObservableCollection<ProductGroup> GroupList
    {
        get => GetValue(GroupListProperty) as ObservableCollection<ProductGroup>;
        set => SetValue(GroupListProperty, value);
    }
    //Commands
    public Command SearchCommand
    {
        get => GetValue(SearchCommandProperty) as Command;
        set => SetValue(SearchCommandProperty, value);
    }

    public AsyncRelayCommand LoadMoreCommand
    {

        get => GetValue(LoadMoreCommandProperty) as AsyncRelayCommand;
        set => SetValue(LoadMoreCommandProperty, value);

    }
    public AsyncRelayCommand SortCommand
    {

        get => GetValue(SortCommandProperty) as AsyncRelayCommand;
        set => SetValue(SortCommandProperty, value);

    }
    public AsyncRelayCommand ReloadCommand
    {

        get => GetValue(ReloadCommandProperty) as AsyncRelayCommand;
        set => SetValue(ReloadCommandProperty, value);

    }

    public AsyncRelayCommand GoToDetailCommand
    {

		get => GetValue(GoToDetailCommandProperty) as AsyncRelayCommand;
		set => SetValue(GoToDetailCommandProperty, value);

	}

    public AsyncRelayCommand SelectGroupCommand
    {

        get => GetValue(SelectGroupCommandProperty) as AsyncRelayCommand;
        set => SetValue(SelectGroupCommandProperty, value);

    }

    public bool IsRefreshing
    {
        get => (bool)GetValue(IsRefreshingProperty);
        set => SetValue(IsRefreshingProperty, value);
    }
    public bool IsBusy
    {
        get => (bool)GetValue(IsBusyProperty);
        set => SetValue(IsBusyProperty, value);
    }
    public ProductListContentView()
	{
        InitializeComponent();
	}
}