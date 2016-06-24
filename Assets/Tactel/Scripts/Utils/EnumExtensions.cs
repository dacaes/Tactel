//author: Juan Manuel palacios
//more info: http://wiki.unity3d.com/index.php?title=EnumExtensions
using System;
using System.ComponentModel;

namespace Tactel.Extensions
{
	public static class EnumExtensions
	{
		public static bool TryParse<T>(this Enum theEnum, string valueToParse, out T returnValue)
		{
			returnValue = default(T);
			if (Enum.IsDefined(typeof(T), valueToParse))
			{
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
				returnValue = (T)converter.ConvertFromString(valueToParse);
				return true;
			}
			return false;
		}
	}
}