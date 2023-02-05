using System;
using System.Diagnostics;
using System.IO;


namespace MauiBank.Service.Internet;

public static class ValuteLoader
{
	public static void UpdateValutes()
	{
		string call = @"""c:\php\php.exe""";

		string param1 = @"-f";

		var baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		var appStorageFolder = Path.Combine(baseFolder, "BankSystem");
		var fullPath = Path.Combine(appStorageFolder, @"ValuteParcer.php");

		Process myProcess = new Process();

		ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(call, "spawn");
		myProcessStartInfo.UseShellExecute = false;
		myProcessStartInfo.RedirectStandardOutput = true;

		myProcessStartInfo.Arguments = string.Format("{0} {1}", param1, fullPath);
		myProcess.StartInfo = myProcessStartInfo;

		myProcess.Start();
		StreamReader myStreamReader = myProcess.StandardOutput;
	}


}
