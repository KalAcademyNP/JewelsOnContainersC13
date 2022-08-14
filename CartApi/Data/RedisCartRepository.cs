using CartApi.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace CartApi.Data
{
    public class RedisCartRepository : ICartRepository
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;
        public RedisCartRepository(ConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteCartAsync(string cartId)
        {
            return await _database.KeyDeleteAsync(cartId);
        }

        public async Task<Cart> GetCartAsync(string cartId)
        {
            var data = await _database.StringGetAsync(cartId);
            if (data.IsNullOrEmpty)
                return null;

            return JsonConvert.DeserializeObject<Cart>(data);   
        }

        public async Task<Cart> UpdateCartAsync(Cart basket)
        {
            var created = await _database.StringSetAsync(basket.BuyerId, 
                JsonConvert.SerializeObject(basket));

            if (!created)
                return null;

            return await GetCartAsync(basket.BuyerId);
        }
    }
}
