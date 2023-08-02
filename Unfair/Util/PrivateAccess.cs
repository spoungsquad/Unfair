using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Unfair.Util
{
	public static class PrivateAccess
	{
		public static T GetField<T>(this object obj, string fieldName)
		{
			return (T)(from fi in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic) 
				where fi.Name.ToLower().Contains(fieldName.ToLower()) 
				select fi.GetValue(obj)).FirstOrDefault();
		}

		public static void SetField<T>(this object obj, string fieldName, T newValue)
		{
			foreach (FieldInfo fi in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
			{
				if (!fi.Name.ToLower().Contains(fieldName.ToLower())) continue;
				
				fi.SetValue(obj, newValue);
				break;
			}
		}
		
		public static void SetProp<T>(this object obj, string propName, T newValue)
		{
			foreach (PropertyInfo pi in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
			{
				if (!pi.Name.ToLower().Contains(propName.ToLower())) continue;
				
				pi.SetValue(obj, newValue);
				break;
			}
		}
		
		public static T CallMeth<T>(this object obj, string methodName, object[] param)
		{
			MethodInfo mi = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
			return (T)(mi != null ? mi.Invoke(obj, param) : null);
		}
	}
}