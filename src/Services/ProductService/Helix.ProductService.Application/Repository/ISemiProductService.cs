﻿using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository
{
	public interface ISemiProductService
	{
		public Task<DataResult<IEnumerable<SemiProduct>>> GetProductList();
		public Task<DataResult<SemiProduct>> GetProductById(int id);
		public Task<DataResult<SemiProduct>> GetProductByCode(string code);
	}
}
