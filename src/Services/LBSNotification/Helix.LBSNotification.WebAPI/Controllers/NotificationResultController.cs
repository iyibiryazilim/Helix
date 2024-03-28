using Helix.LBSNotification.WebAPI.Models;
using Helix.LBSNotification.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSNotification.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationResultController : ControllerBase
    {
        private readonly INotificationResultService _notificationResultService;
        public NotificationResultController(INotificationResultService notificationResultService)
        {
            _notificationResultService = notificationResultService;
        }

        [HttpPost]
        public async Task InsertObjectAsync(NotificationResult notificationResult)
        {
            await _notificationResultService.InsertObjectAsync(notificationResult);
        }
        [HttpGet("owner")]
        public async Task<NotificationResult> GetObjectAsync(Guid owner)
        {
            return await _notificationResultService.GetObjectAsync(owner);
        }

        [HttpGet]
        public async Task<IEnumerable<NotificationResult>> GetObjects()
        {
            return await _notificationResultService.GetObjectsAsync();
        }

        [HttpDelete]
        public async Task DeleteObjectsAsync(Guid owner)
        {
             await _notificationResultService.DeleteObjectsAsync(owner);
        }


    }
}
