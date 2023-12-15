namespace Unfair.Config
{
	public class SettingBase
	{
		public string Name;
		public string Description;
		public string Dependency;
		
		public SettingBase(string name, string description, string dependency = "")
		{
			Name = name;
			Description = description;
			Dependency = dependency;
		}
	}
}