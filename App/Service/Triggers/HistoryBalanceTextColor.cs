namespace MauiBank.Service.Triggers;

class HistoryBalanceTextColor : TriggerAction<Label>
{
	protected override void Invoke(Label sender)
	{
		if(double.TryParse(sender.Text, out var number))
		{
			if(number > 0) sender.TextColor = Colors.Green;
			else sender.TextColor = Colors.Red;
		}

	}
}
