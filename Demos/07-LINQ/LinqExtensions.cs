namespace _07_LINQ
{

	internal static class LinqExtensions
	{

		internal static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
		{
			int i = 0;
			var splits = from item in list
									 group item by i++ % parts into part
									 select part.AsEnumerable();
			return splits;
		}

	}

}