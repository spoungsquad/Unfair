using UnityEngine;

namespace Unfair.Config.Settings
{
	public class KeybindSetting : SettingBase
	{
		public KeyCode Value;
		
		public KeybindSetting(string name, string description, KeyCode value, string dependency = "") 
			: base(name, description, dependency)
		{
			Value = value;
		}
	}
}