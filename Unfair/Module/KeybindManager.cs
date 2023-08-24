using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Unfair.Module
{
	public static class KeybindManager
	{
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
				module.Key = (KeyCode)Enum.Parse(typeof(KeyCode), keycode);
			}
		}
	}
}