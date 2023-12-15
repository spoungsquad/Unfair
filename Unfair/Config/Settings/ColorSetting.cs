using UnityEngine;

namespace Unfair.Config.Settings
{
	public class ColorSetting : SettingBase
	{
		public Color Value;
		public bool Rainbow;
		
		public ColorSetting(string name, string description, Color value, bool rainbow = false, SettingBase dependency = null) 
			: base(name, description, dependency)
		{
			Value = value;
		}
	}
}