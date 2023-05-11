using MauiBank.Model;

namespace MauiBank.Service.Converters;

class PaymentSumDataTemplateSelector : DataTemplateSelector
{
	public DataTemplate NegativeTemplate { get; set; }
	public DataTemplate PositiveTemplate { get; set; }

	protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
	{
		return ((PayCheck)item).sum <= 0 ? NegativeTemplate : PositiveTemplate;
	}
}
