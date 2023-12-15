namespace Unfair.Config.Settings
{
	public class TextSetting : SettingBase
	{
		public string Value;
		
		public TextSetting(string name, string description, string value, string dependency = "") 
			: base(name, description, dependency)
		{
			Value = value;
		}
	}
}