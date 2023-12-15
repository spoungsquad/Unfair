namespace Unfair.Config
{
	public class SettingBase
	{
		public string Name;
		public string Description;
		public SettingBase Dependency;
		
		public SettingBase(string name, string description, SettingBase dependency = null)
		{
			Name = name;
			Description = description;
			Dependency = dependency;
		}
	}
}