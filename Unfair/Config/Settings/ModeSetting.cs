using System.Collections.Generic;

namespace Unfair.Config.Settings
{
	public class ModeSetting : SettingBase
	{
		public int Value;
		
		public ModeSetting(string name, string description, int value, string dependency = "") 
			: base(name, description, dependency)
		{
			Value = value;
		}
	}
}