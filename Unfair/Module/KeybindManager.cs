using Psf.Analytics.Constants;
using Psf.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module
{
    public static class KeybindManager
    {
        public static Dictionary<string, KeyCode> Keybinds = new Dictionary<string, KeyCode>();

        public static void CreateKeybinds()
        {
            var keycodes = ModuleManager.Modules.Select(x => x.Key).ToList();
            var str = string.Empty;

            for (var i = 0; i < keycodes.Count; i++)
            {
                str += $"{ModuleManager.Modules[i].Name}: {keycodes[i]}\n";
            }

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DebugConsole.Write($"Writing: {str}");
            File.WriteAllText(Path.Combine(documents, "UnfairKeybinds.txt"), str);
        }

        public static void LoadKeybinds()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documents, "UnfairKeybinds.txt");

            var lines = File.ReadAllText(path).Split('\n');

            foreach (var line in lines)
            {
                if (line == string.Empty) continue;
                var split = line.Split(':');

                var keycode = split[1].Trim();
                var result = Enum.TryParse<KeyCode>(keycode, true, out var parsed);

                if (result) Keybinds.Add(split[0], parsed);

                DebugConsole.Write($"{split[0]} is bound to {parsed}");
            }
        }
    }
}