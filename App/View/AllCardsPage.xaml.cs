using MauiBank.ViewModel;

namespace MauiBank.View;

public partial class AllCardsPage : ContentPage
{
	public AllCardsPage(AllCardsViewModel vm)
	{
		InitializeComponent();
        BindingContext  = vm;
	}
    
}