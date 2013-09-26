using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain
{
	public class DomainBase
	{

		/// <summary>
		/// This function returns a list of all the properties of
		/// the given type T on the domain object.
		/// </summary>
		/// <typeparam name="T">The type of property you require</typeparam>
		/// <returns>A list of objects of T type</returns>
		public virtual List<T> GetClassProperties<T>() where T : class
		{
			var listOfProperties = new List<T>();
			var props = this.GetType().GetProperties();

			foreach (var prop in props)
			{
				if (prop.PropertyType == typeof(T))
				{

					var propValue = prop.GetValue(this, null) as T;

					if (propValue == null) propValue = Activator.CreateInstance<T>();

					listOfProperties.Add(propValue);

				}
			}
			return listOfProperties;

		}
	}
}
