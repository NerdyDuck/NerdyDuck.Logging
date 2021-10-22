using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace NerdyDuck.Logging
{
	internal static class HelperMethods
	{
		public static void CheckParameters(LogbookComponentDescription description, CaseInsensitiveStringDictionary parameters)
		{
			foreach (LogbookComponentParameterDescription paramDesc in description.Parameters.Where(p => p.IsRequired))
			{
				if (!parameters.ContainsKey(paramDesc.Name))
				{
					// TODO
				}
			}

			foreach (string name in parameters.Keys)
			{
				if (description.Parameters.SingleOrDefault(p => string.Compare(p.Name, name, StringComparison.OrdinalIgnoreCase) == 0) == null)
				{
					// TODO
				}
			}
		}

		public static bool ImplementsInterface(this Type type, Type interfaceType)
		{
			// TODO
			return false;
		}

		public static bool InheritsFrom(this Type type, Type baseType)
		{
			// TODO
			return false;
		}


		public static string ToCamelCase(this string value)
		{
			// TODO
			return value;
		}

		#region InheritsOrImplements
		/// <summary>
		/// Checks if a type inherits from another class or implements an interface, including generic classes or interfaces.
		/// </summary>
		/// <param name="child">The type to check.</param>
		/// <param name="parent">The class or interface that <paramref name="child"/> should implement or be derived from.</param>
		/// <returns><see langword="true"/> if <paramref name="child"/> implements or inherits from <paramref name="parent"/>; otherwise, <see langword="false"/>.</returns>
		public static bool InheritsOrImplements(Type child, Type parent)
		{
			parent = ResolveGenericTypeDefinition(parent);

			Type currentChild = child.GetTypeInfo().IsGenericType ? child.GetGenericTypeDefinition() : child;
			TypeInfo currentChildInfo;

			while (currentChild != typeof(object))
			{
				if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
					return true;

				currentChildInfo = currentChild.GetTypeInfo();
				currentChild = currentChildInfo.BaseType != null && currentChildInfo.BaseType.GetTypeInfo().IsGenericType
					? currentChildInfo.BaseType.GetGenericTypeDefinition()
					: currentChildInfo.BaseType;

				if (currentChild == null)
					return false;
			}
			return false;
		}
		#endregion

		#region Private methods
		/// <summary>
		/// Checks if a type implements the specified (generic) interface.
		/// </summary>
		/// <param name="parent">The type to check.</param>
		/// <param name="child">The interface to find.</param>
		/// <returns><see langword="true"/>, if <paramref name="parent"/> implements <paramref name="child"/>.</returns>
		private static bool HasAnyInterfaces(Type parent, Type child)
		{
			return child.GetInterfaces()
				.Any(childInterface =>
				{
					Type currentInterface = childInterface.GetTypeInfo().IsGenericType ? childInterface.GetGenericTypeDefinition() : childInterface;

					return currentInterface == parent;
				});
		}

		/// <summary>
		/// Attempts to get the generic type definition of a type.
		/// </summary>
		/// <param name="parent">The type to find the generic type definition for.</param>
		/// <returns>The generic type definition of <paramref name="parent"/>, if found; otherwise <paramref name="parent"/>.</returns>
		private static Type ResolveGenericTypeDefinition(Type parent)
		{
			TypeInfo parentInfo = parent.GetTypeInfo();
			if (parentInfo.IsGenericType)
			{
				Type genericType = parent.GetGenericTypeDefinition();
				if (genericType != parent)
					return parent;

				return genericType;
			}
			return parent;
		}
		#endregion

	}
}
