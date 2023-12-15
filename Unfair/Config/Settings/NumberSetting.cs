namespace Unfair.Config.Settings
{
	public class NumberSetting : SettingBase
	{
		public float Value;
		public float Min;
		public float Max;
		public float Step;
		
		public NumberSetting(string name, string description, float value, float min, float max, float step = 1f,
			SettingBase dependency = null) : base(name, description, dependency)
		{
			Value = value;
			Min = min;
			Max = max;
			Step = step;
		}
	}
}