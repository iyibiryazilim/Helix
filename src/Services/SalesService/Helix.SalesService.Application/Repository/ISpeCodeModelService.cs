using Helix.SalesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.SalesService.Application.Repository
{
    public interface ISpeCodeModelService
    {
        public  Task<DataResult<IEnumerable<SpeCodeModel>>> GetSpeCodeListAsync();
    }
}
