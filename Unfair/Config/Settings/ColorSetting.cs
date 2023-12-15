using UnityEngine;

namespace Unfair.Config.Settings
{
	public class ColorSetting : SettingBase
	{
		public Color Value;
		
		public ColorSetting(string name, string description, Color value, string dependency = "") 
			: base(name, description, dependency)
		{
			Value = value;
		}
	}
}