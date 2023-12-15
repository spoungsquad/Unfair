namespace Unfair.Config.Settings
{
	public class BoolSetting : SettingBase
	{
		public bool Value;
		
		public BoolSetting(string name, string description, bool value, string dependency = "") 
			: base(name, description, dependency)
		{
			Value = value;
		}
	}
}