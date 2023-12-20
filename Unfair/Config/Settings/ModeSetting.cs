using System;
using System.Collections.Generic;

namespace Unfair.Config.Settings
{
	public class ModeSetting : SettingBase
	{
		public string[] Values;
		public int Value;
		
		public ModeSetting(string name, string description, string[] values, int value, SettingBase dependency = null) 
			: base(name, description, dependency)
		{
			Values = values;
			Value = value;
		}
		
		public void Next()
		{
			Value++;
			if (Value >= Values.Length)
				Value = 0;
		}
	}
}