using System.Linq;
using System.Reflection;

namespace Unfair.Util
{
	public static class PrivateAccess
	{
		public static void SetPrivateProperty<T>(T obj, string propertyName, object newValue)
		{
			foreach (var fi in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
			{
				if (!fi.Name.ToLower().Contains(propertyName.ToLower())) continue;
				
				fi.SetValue(obj, newValue);
				break;
			}
		}

		// wtf
		public static object GetPrivateProperty<T>(T obj, string propertyName)
		{
			return (from fi in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic) 
				where fi.Name.ToLower().Contains(propertyName.ToLower()) 
				select fi.GetValue(obj))
				.FirstOrDefault();
		}

		public static object CallPrivateMethod<T>(T obj, string methodName, object[] param)
		{
			var mi = obj.GetType().GetMethod(methodName);
			return mi != null ? mi.Invoke(obj, param) : null;
		}
	}
}