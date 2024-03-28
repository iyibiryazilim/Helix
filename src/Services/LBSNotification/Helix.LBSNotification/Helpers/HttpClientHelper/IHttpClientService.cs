using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.LBSNotification.Helpers.HttpClientHelper
{
    public interface IHttpClientService
    {
        HttpClient GetOrCreateHttpClient();
        string Token { get; set; }
        string BaseUri { get; set; }
    }
}
