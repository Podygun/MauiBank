namespace MauiBank.Model;

public class Grouping<K, T> : ObservableCollection<T>
{
	public K Time { get; private set; }
	public Grouping(K time, IEnumerable<T> items) : base(items)
	{
		Time = time;
	}
}
