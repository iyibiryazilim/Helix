using Helix.ProductService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Application.Repository
{
    public interface IUnitsetService
    {
        public  Task<DataResult<IEnumerable<Unitset>>> GetUnitsetList();
        public Task <DataResult<IEnumerable<Unitset>>> GetUnitsetById(int id);
        
        public Task <DataResult<IEnumerable<Unitset>>> GetUnitsetFromProductId(int id); 

    }
}
