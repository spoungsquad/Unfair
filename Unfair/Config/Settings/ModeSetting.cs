using System;
using System.Collections.Generic;

namespace Unfair.Config.Settings
{
	public class ModeSetting<T> : SettingBase where T : Enum
	{
		public T Value;
		
		public ModeSetting(string name, string description, T value, SettingBase dependency = null) 
			: base(name, description, dependency)
		{
			Value = value;
		}
	}
}