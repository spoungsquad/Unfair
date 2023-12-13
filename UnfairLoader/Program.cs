using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using UnfairLoader.Injector;

namespace UnfairLoader
{
	internal static class Program
	{
		[STAThread] // for OpenFileDialog
		private static void Main(string[] args)
		{
			Console.Title = "Unfair - spoung squad creation";
			
			// green like money $$$$$$$$$$$$
			Console.ForegroundColor = ConsoleColor.Green;
			
			Console.WriteLine(" /$$   /$$            /$$$$$$          /$$          \n" +
			                  "| $$  | $$           /$$__  $$        |__/          \n" +
			                  "| $$  | $$ /$$$$$$$ | $$  \\__//$$$$$$  /$$  /$$$$$$ \n" +
			                  "| $$  | $$| $$__  $$| $$$$   |____  $$| $$ /$$__  $$\n" +
			                  "| $$  | $$| $$  \\ $$| $$_/    /$$$$$$$| $$| $$  \\__/\n" +
			                  "| $$  | $$| $$  | $$| $$     /$$__  $$| $$| $$      \n" +
			                  "|  $$$$$$/| $$  | $$| $$    |  $$$$$$$| $$| $$      \n" +
			                  " \\______/ |__/  |__/|__/     \\_______/|__/|__/      \n");
			
			string path;

			if (args.Length == 1)
			{
				path = args[0];
			}
			else
			{
				Console.WriteLine("Select Unfair.dll...");
				
				var dialog = new OpenFileDialog
				{
					Filter = "Unfair.dll|Unfair.dll",
					Title = "Select Unfair.dll"
				};
				
				var dialogResult = dialog.ShowDialog();
				if (dialogResult == DialogResult.Cancel)
				{
					Console.WriteLine("You were supposed to select the DLL, retard.");
					Console.ReadKey();
				}
				
				path = dialog.FileName;
			}

			if (!path.EndsWith(".dll"))
			{
				Console.WriteLine("You were supposed to select the DLL, retard.");
				Console.ReadKey();
			}
			
			// open game
			Process.Start("steam://rungameid/2305790");
			
			Process gameProcess;

			while (true)
			{
				var processes = Process.GetProcessesByName("1v1_LOL");
				if (processes.Length > 0)
				{
					Console.WriteLine("Found game.");
					gameProcess = processes[0];
					break;
				}
				
				Console.WriteLine("Waiting for game...");
				Thread.Sleep(1000);
			}
			
			var handle = Native.OpenProcess(ProcessAccessRights.PROCESS_ALL_ACCESS, false, gameProcess.Id);

			if (handle == IntPtr.Zero)
			{
				Console.WriteLine("Failed to inject - OpenProcess failed. Might be antivirus interference.");
				Console.ReadKey();
			}

			byte[] bytes = null;
			
			try
			{
				bytes = File.ReadAllBytes(path);
			}
			catch
			{
				Console.WriteLine("Failed to read Unfair.dll - possible antivirus interference.");
				Console.ReadKey();
			}
			
			var result = ProcessUtils.GetMonoModule(handle, out var monoModule);
			if (!result)
			{
				Console.WriteLine("Failed to inject - GetMonoModule failed. Might be antivirus interference.");
				Console.ReadKey();
			}

			using (var injector = new Injector.Injector(handle, monoModule))
			{
				try
				{
					injector.Inject(bytes, "Unfair", "Loader", "Load");
					
					Console.WriteLine("Unfair is now injected.");
					Console.ReadKey();
				}
				catch (InjectorException ie)
				{
					Console.WriteLine($"Injector issue: {ie.Message}. Antivirus interference? Could be.");
					Console.ReadKey();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Unknown issue: {ex.Message}. I'm not sure what could've caused this.");
					Console.ReadKey();
				}
			}
		}
	}
}