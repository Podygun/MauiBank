using MauiBank.Model;
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
	public static object GetValue(string key) { return _cache.Get(key); }
	

	public static void SetValue<T>(string key,  T value, TimeSpan lifeTime = default(TimeSpan))
	{
		if (lifeTime == default(TimeSpan)) lifeTime = TimeSpan.FromHours(24);
		
		_cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(lifeTime));
	}

	public static T GetOrCreateCacheValue<T>(string key, TimeSpan lifeTime, T value)
	{
		if (!_cache.TryGetValue(key, out T _value))
		{
			_value = value;
			_cache.Set(key, _value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(lifeTime));
		}
		return _value;
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



	public static async Task<ObservableCollection<Grouping<DateOnly, PayCheck>>> GetOrCreateHistories(string key, TimeSpan lifeTime, Func<Task<List<PayCheck>>> getQuerryDB)
	{
		if (!_cache.TryGetValue(key, out ObservableCollection<Grouping<DateOnly, PayCheck>> finalList))
		{
			var DBData = await getQuerryDB();

			var groups = DBData
				.GroupBy(p => p.Time)
				.Select(g => new Grouping<DateOnly, PayCheck>(DateOnly.ParseExact(g.Key, "dd.MM.yyyy"), g))
				.OrderByDescending(o => o.Time);
			finalList = new ObservableCollection<Grouping<DateOnly, PayCheck>>(groups);
			_cache.Set(key, finalList, new MemoryCacheEntryOptions().SetAbsoluteExpiration(lifeTime));
		}
		return finalList;
	}

	






	//cache.Set("myKey", myData, DateTimeOffset.Now.AddHours(1));
	//MyData cachedData = cache.Get("myKey") as MyData;
	//cache.Remove("myKey");
}
