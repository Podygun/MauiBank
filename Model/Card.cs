using CommunityToolkit.Mvvm.ComponentModel;


namespace MauiBank.Model;

public partial class Card : ObservableObject
{
	[ObservableProperty]
	string id;

	[ObservableProperty]
	string number;

	[ObservableProperty]
	string cvv;

	[ObservableProperty]
	string dateEnd;

	[ObservableProperty]
	string type;

	[ObservableProperty]
	string color;

	[ObservableProperty]
	string balance;

	[ObservableProperty]
	string code;
}
