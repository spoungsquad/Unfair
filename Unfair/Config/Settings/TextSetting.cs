namespace Unfair.Config.Settings
{
	public class TextSetting : SettingBase
	{
		public string Value;
		
		public TextSetting(string name, string description, string value, SettingBase dependency = null) 
			: base(name, description, dependency)
		{
			Value = value;
		}
	}
}