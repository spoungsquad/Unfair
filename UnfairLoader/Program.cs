using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using UnfairLoader.Injector;

namespace UnfairLoader
{
    internal static class Program
    {
        private static void FileToBytes(string path, out byte[] injectionBytes)
        {
            try
            {
                injectionBytes = File.ReadAllBytes(path);
            }
            catch (Exception ex)
            {
                LogLine($"Failed to read file: {ex.Message}", ConsoleColor.Red);
                injectionBytes = null;
            }
        }

        // green like money $$$$$$$$$$$$
        private static void LogLine(string msg, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
        }

        [STAThread] // for OpenFileDialog
        private static void Main(string[] args)
        {
            Console.Title = "Unfair - spoung squad creation";
            Console.Clear();

        injectType:
            LogLine("\n /$$   /$$            /$$$$$$          /$$          \n" +
                    "| $$  | $$           /$$__  $$        |__/          \n" +
                    "| $$  | $$ /$$$$$$$ | $$  \\__//$$$$$$  /$$  /$$$$$$ \n" +
                    "| $$  | $$| $$__  $$| $$$$   |____  $$| $$ /$$__  $$\n" +
                    "| $$  | $$| $$  \\ $$| $$_/    /$$$$$$$| $$| $$  \\__/\n" +
                    "| $$  | $$| $$  | $$| $$     /$$__  $$| $$| $$      \n" +
                    "|  $$$$$$/| $$  | $$| $$    |  $$$$$$$| $$| $$      \n" +
                    " \\______/ |__/  |__/|__/     \\_______/|__/|__/      \n");

            byte[] injectionBytes;

            LogLine("(x) Select an injection type, online for the updated version, or local for any other.\n" +
                    "[1] Online injection\n" +
                    "[2] Local file injection\n", ConsoleColor.Yellow);

            var typeSelect = Console.ReadKey();
            switch (typeSelect.Key)
            {
                case ConsoleKey.D1: // ONLINE INJECTION (from build server or something)
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("User-Agent", "UnfairLoader/1.0");

                        var response = client.GetAsync("https://unfair.000webhostapp.com/Unfair.dll").Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            Console.Clear();
                            LogLine("Failed to download Unfair.", ConsoleColor.Red);
                            goto injectType;
                        }

                        var stream = response.Content.ReadAsStreamAsync().Result;
                        injectionBytes = new byte[stream.Length];
                        var read = stream.Read(injectionBytes, 0, (int)stream.Length);
                        
                        if (read != stream.Length)
                        {
                            Console.Clear();
                            LogLine("Failed to read from Unfair.dll. Could be antivirus interference.", ConsoleColor.Red);
                            goto injectType;
                        }
                    }

                    break;

                case ConsoleKey.D2: // LOCAL FILE INJECTION
                    if (args.Length == 1 && args[0].EndsWith(".dll"))
                    {
                        FileToBytes(args[0], out injectionBytes);
                        break;
                    }

                filechoose:
                    var dialog = new OpenFileDialog
                    {
                        Filter = "Unfair.dll|Unfair.dll",
                        Title = "Select Unfair.dll"
                    };

                    var dialogResult = dialog.ShowDialog();
                    if (dialogResult == DialogResult.Cancel)
                    {
                        Console.Clear();
                        LogLine("Cancelled, going back to start!", ConsoleColor.Red);
                        goto injectType;
                    }

                    if (!dialog.FileName.EndsWith(".dll"))
                    {
                        Console.Clear();
                        LogLine("Invalid file selection, must be of type: dll", ConsoleColor.Red);
                        goto filechoose;
                    }

                    Console.WriteLine(); //buh

                    FileToBytes(dialog.FileName, out injectionBytes);
                    break;

                default:
                    Console.Clear();
                    LogLine("Invalid option\n", ConsoleColor.Red);
                    goto injectType;
            }

            if (injectionBytes == null)
            {
                LogLine("Failed to read from Unfair.dll. Maybe it's antivirus interference.", ConsoleColor.Red);
                Console.ReadKey();
                return;
            }

            // open game
            LogLine("(*) Attempting to start 1v1.LOL (Steam). If this fails, start it manually.");
            Process.Start("steam://rungameid/2305790");

            Process gameProcess;

            while (true)
            {
                var processes = Process.GetProcessesByName("1v1_LOL");
                if (processes.Length > 0)
                {
                    LogLine("Found game, injecting...");
                    gameProcess = processes[0];
                    break;
                }

                LogLine("Waiting for game...");
                Thread.Sleep(3000);
            }
            
            // wait 4 game to load
            Thread.Sleep(5000);

            var handle = Native.OpenProcess(ProcessAccessRights.PROCESS_ALL_ACCESS, false, gameProcess.Id);

            if (handle == IntPtr.Zero)
            {
                LogLine("Failed to inject - OpenProcess failed. Might be antivirus interference.", ConsoleColor.Red);
                Console.ReadKey();
            }

            var result = ProcessUtils.GetMonoModule(handle, out var monoModule);
            if (!result)
            {
                LogLine("Failed to inject - GetMonoModule failed. Possible antivirus interference.", ConsoleColor.Red);
                Console.ReadKey();
            }

            using (var injector = new Injector.Injector(handle, monoModule))
            {
                try
                {
                    injector.Inject(injectionBytes, "Unfair", "Loader", "Load");

                    LogLine("Unfair is now injected.");
                    Console.ReadKey();
                }
                catch (InjectorException ie)
                {
                    LogLine($"Injector issue: {ie.Message}. Antivirus interference? Could be.", ConsoleColor.Red);
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    LogLine($"Unknown issue: {ex.Message}. I'm not sure what could've caused this.", ConsoleColor.Red);
                    Console.ReadKey();
                }
            }
        }
    }
}