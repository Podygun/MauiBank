namespace MauiBank.Model;

public partial class Favour : ObservableObject
{
	[ObservableProperty]
	public int id;
	[ObservableProperty]
	public string name;
	[ObservableProperty]
	public int? favour_id;
}
