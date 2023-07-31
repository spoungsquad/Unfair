using System.Linq;
using System.Reflection;

namespace Unfair.Util
{
	public static class PrivateAccess
	{
		public static T GetProp<T>(this object obj, string propertyName)
		{
			return (T)(from fi in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic) 
				where fi.Name.ToLower().Contains(propertyName.ToLower()) 
				select fi.GetValue(obj)).FirstOrDefault();
		}

		public static void SetProp<T>(this object obj, string propertyName, T newValue)
		{
			foreach (FieldInfo fi in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
			{
				if (!fi.Name.ToLower().Contains(propertyName.ToLower())) continue;
				
				fi.SetValue(obj, newValue);
				break;
			}
		}
		
		//da n
		public static T CallMeth<T>(this object obj, string methodName, object[] param)
		{
			MethodInfo mi = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
			return (T)(mi != null ? mi.Invoke(obj, param) : null);
		}
	}
}