namespace MauiBank.Service.Converters;

class PaymentSumDataTemplateSelector : DataTemplateSelector
{
	public DataTemplate NegativeTemplate { get; set; }
	public DataTemplate PositiveTemplate { get; set; }

	protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
	{
		return ((HistoryD)item).Sum <= 0 ? NegativeTemplate : PositiveTemplate;
	}
}
