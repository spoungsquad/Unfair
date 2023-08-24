using JustPlay.Localization;
using Unfair.Util;
using UnityEngine;
using UnityEngine.Localization;

namespace Unfair.Module.Modules.Misc
{
	public class SaveKeybinds : Module
	{
		public SaveKeybinds() : base("SaveKeybinds", "Saves your keybinds", Category.Misc, KeyCode.Backslash)
		{
			
		}

		public override void OnEnable()
		{
			KeybindManager.SaveKeybinds();
			GameData.UIManager.ShowToast(new DefaultedLocalizedString(
				new LocalizedString("", ""),
				"Saved keybinds!"));
			Toggle();
		}
	}
}