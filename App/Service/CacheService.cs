
using Microsoft.Extensions.Caching.Memory;
namespace MauiBank.Service;

public class CacheService
{
	private static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

	//public TItem GetOrCreate(object key, Func<TItem> createItem)
	//{
	//	TItem cacheEntry;
	//	if (!_cache.TryGetValue(key, out cacheEntry)) // Ищем ключ в кэше.
	//	{
	//		// Ключ отсутствует в кэше, поэтому получаем данные.
	//		cacheEntry = createItem();

	//		// Сохраняем данные в кэше. 
	//		_cache.Set(key, cacheEntry);
	//	}
	//	return cacheEntry;
	//}

	public static async Task <List<History>> GetOrCreateHistories(string key, Func<Task<List<History>>> getHistoriesFromDB)
	{
		if (!_cache.TryGetValue(key, out List<History> histories))
		{
			histories = await getHistoriesFromDB();
			_cache.Set(key, histories, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));
		}

		return histories;
	}

	public static async Task <T> GetOrCreateCacheValue<T>(string key, TimeSpan lifeTime, Func<Task<T>> getQuerryDB)
	{
		if (!_cache.TryGetValue(key, out T items))
		{
			items = await getQuerryDB();
			_cache.Set(key, items, new MemoryCacheEntryOptions().SetAbsoluteExpiration(lifeTime));
		}
		return items;
	}





	//cache.Set("myKey", myData, DateTimeOffset.Now.AddHours(1));
	//MyData cachedData = cache.Get("myKey") as MyData;
	//cache.Remove("myKey");
}
