namespace MauiBank.View;

public partial class OrganisationTransferPage : ContentPage
{
	public OrganisationTransferPage(OrganisationTransferViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		RequsiteValue.IsEnabled = false;
	}

	private void Picker_SelectedIndexChanged(object sender, EventArgs e) => RequsiteValue.IsEnabled = true;
	
}