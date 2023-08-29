using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JustPlay.Localization;
using Unfair.Util;
using UnityEngine;
using UnityEngine.Localization;

namespace Unfair.Module
{
	public static class KeybindManager
	{
		public static Dictionary<string, KeyCode> Keybinds = new Dictionary<string, KeyCode>();
		
		private static void CreateKeybinds()
		{
			var keycodes = ModuleManager.Modules.Select(x => x.Key).ToList();
			var str = string.Empty;

			for (var i = 0; i < keycodes.Count; i++)
			{
				str += $"{ModuleManager.Modules[i].Name}: {keycodes[i]}\n";
			}

			var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			File.WriteAllText(Path.Combine(documents, "UnfairKeybinds.txt"), str);
		}

		public static void LoadKeybinds()
		{
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documents, "UnfairKeybinds.txt");
			
			if (!File.Exists(path)) CreateKeybinds(); // developer keybinds are kinda bad tbh
			
			var str = File.ReadAllLines(path);

			foreach (var module in ModuleManager.Modules)
			{
				var name = module.Name;
				var line = str.FirstOrDefault(x => x.StartsWith(name));
				if (line == null) continue;
				
				var keycode = line.Split(':')[1].Trim();
				var result = Enum.TryParse<KeyCode>(keycode, true, out var parsed);

				Keybinds.Add(name, result ? parsed : KeyCode.None);
				DebugConsole.Write($"{name} is bound to {keycode}");
			}
		}
	}
}