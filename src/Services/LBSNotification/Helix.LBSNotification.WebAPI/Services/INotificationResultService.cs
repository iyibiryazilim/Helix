using Helix.LBSNotification.WebAPI.Models;

namespace Helix.LBSNotification.WebAPI.Services
{
    public interface INotificationResultService
    {
        public Task<NotificationResult> GetObjectAsync(Guid owner);
        public Task<IEnumerable<NotificationResult>> GetObjectsAsync();
        public Task<NotificationResult> UpdateObjectsAsync(Guid owner,string content);
        public Task DeleteObjectsAsync(Guid owner);
        public Task InsertObjectAsync(NotificationResult item);
    }
}
