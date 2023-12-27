﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.ProductService.Domain.Models
{
	public class WarehouseTotal : INotifyPropertyChanged
	{
		DateTime? transactionDate;
		public DateTime? TransactionDate
		{
			get => transactionDate;
			set
			{
				transactionDate = value;
				NotifyPropertyChanged();
			}
		}

		int warehousereferenceId;
		public int WarehouseReferenceId
		{
			get => warehousereferenceId;
			set
			{
				if (value != warehousereferenceId)
				{
					warehousereferenceId = value;
					NotifyPropertyChanged(nameof(WarehouseReferenceId));
				}
			}
		}

		string? warehouseName;
		public string? WarehouseName
		{
			get => warehouseName;
			set
			{
				warehouseName = value;
				NotifyPropertyChanged();
			}
		}


		short? warehouseNumber;
		public short? WarehouseNumber
		{
			get => warehouseNumber;
			set
			{
				warehouseNumber = value;
				NotifyPropertyChanged();
			}
		}
		double onHand = default;
		public double OnHand
		{
			get => onHand;
			set
			{
				onHand = value;
				NotifyPropertyChanged();
			}
		}

		int productReferenceId;

		public int ProductReferenceId
		{
			get => productReferenceId;
			set
			{
				if (value != productReferenceId)
				{
					productReferenceId = value;
					NotifyPropertyChanged(nameof(ProductReferenceId));
				}
			}
		}


		string? productCode;
		public string? ProductCode
		{
			get => productCode;
			set
			{
				productCode = value;
				NotifyPropertyChanged();
			}
		}

		string? productName;
		public string? ProductName
		{
			get => productName;
			set
			{
				productName = value;
				NotifyPropertyChanged();
			}
		}
		public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public event PropertyChangedEventHandler? PropertyChanged;
	}

	
}
