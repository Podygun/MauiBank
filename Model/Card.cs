using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiBank.Model;

public partial class Card : ObservableObject
{
	[ObservableProperty]
	int id;

	[ObservableProperty]
	string number;

	[ObservableProperty]
	string cvv;

	[ObservableProperty]
	DateOnly date_end;

	[ObservableProperty]
	string type;

	[ObservableProperty]
	string color;

	[ObservableProperty]
	double balance;

	[ObservableProperty]
	string code;
}
