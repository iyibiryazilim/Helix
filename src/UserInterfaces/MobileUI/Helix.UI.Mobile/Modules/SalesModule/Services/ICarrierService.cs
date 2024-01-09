using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.Services
{
    public interface ICarrierService
    {
        Task<DataResult<IEnumerable<Carrier>>> GetObjects(HttpClient httpClient);
    }
}
