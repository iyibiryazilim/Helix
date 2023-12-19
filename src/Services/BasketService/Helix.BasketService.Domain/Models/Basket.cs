using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.BasketService.Domain.Models;

public class Basket : INotifyPropertyChanged
{
	int productReferenceId;
	string? productCode;
	string? productName;
	double quantity;
	string? userName;
	DateTime date;
	DateTime createdOn;
	int moduleNumber;

	public int ProductReferenceId
	{
		get => productReferenceId;
		set
		{
			productReferenceId = value;
			NotifyPropertyChanged();
		}
	}

	public string? ProductCode
	{
		get => productCode;
		set
		{
			productCode = value;
			NotifyPropertyChanged();
		}
	}

	public string? ProductName
	{
		get => productName;
		set
		{
			productName = value;
			NotifyPropertyChanged();
		}
	}

	public double Quantity
	{
		get => quantity;
		set
		{
			quantity = value;
			NotifyPropertyChanged();
		}
	}

	public string? UserName
	{
		get => userName;
		set
		{
			userName = value;
			NotifyPropertyChanged();
		}
	}

	public DateTime Date
	{
		get => date;
		set
		{
			date = value;
			NotifyPropertyChanged();
		}
	}

	public DateTime CreatedOn
	{
		get => createdOn;
		set
		{
			createdOn = value;
			NotifyPropertyChanged();
		}
	}

	public int ModuleNumber
	{
		get => moduleNumber;
		set
		{
			moduleNumber = value;
			NotifyPropertyChanged();
		}
	}


	public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public event PropertyChangedEventHandler? PropertyChanged;

}
