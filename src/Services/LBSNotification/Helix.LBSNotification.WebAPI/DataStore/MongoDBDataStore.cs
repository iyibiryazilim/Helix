using Helix.LBSNotification.WebAPI.Models;
using Helix.LBSNotification.WebAPI.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Helix.LBSNotification.WebAPI.DataStore
{
    public class MongoDBDataStore : INotificationResultService
    {
        private readonly IMongoCollection<NotificationResult> _notificationResultCollection;

        public MongoDBDataStore(IOptions<NotificationDatabaseSettings> notificationDatabaseSetting)
        {
            var mongoClient = new MongoClient(notificationDatabaseSetting.Value.ConnectionString);
            
            var mongoDatabase = mongoClient.GetDatabase( notificationDatabaseSetting.Value.DatabaseName);
            _notificationResultCollection = mongoDatabase.GetCollection<NotificationResult>( notificationDatabaseSetting.Value.NotificationCollectionName);
        }

        public async Task DeleteObjectsAsync(Guid owner)
        {
           await _notificationResultCollection.DeleteOneAsync(x => x.Owner == owner);
        }

        public async Task<NotificationResult> GetObjectAsync(Guid owner)
        {
            return await _notificationResultCollection.Find(x=> x.Owner == owner).FirstOrDefaultAsync();
            
        }

        public async Task<IEnumerable<NotificationResult>> GetObjectsAsync()
        {
            return await _notificationResultCollection.Find(_=>true).ToListAsync();
        }

        public async Task InsertObjectAsync(NotificationResult item)
        {
            await _notificationResultCollection.InsertOneAsync(item);
        }

        public async Task<NotificationResult> UpdateObjectsAsync(Guid owner, string content)
        {
            NotificationResult notificationResult = new NotificationResult { Owner = owner, Content = content };
            var replaceData = await _notificationResultCollection.ReplaceOneAsync(x => x.Owner == notificationResult.Owner, notificationResult);
            return notificationResult;
        }
    }
}
