using System;

namespace TaleLearnCode.WhatsNewForCSharpDevelopers.Demo01
{
	internal class Program
	{

		public record PersonRecord(string FirstName, string LastName);

		public class PersonClass
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
		}

		static void Main()
		{

			/* ----------------------------------------------------------------------
			 *           C# 9 - Positional Syntext for Property Definition
			 * ---------------------------------------------------------------------- */

			PersonClass personClass = new()
			{
				FirstName = "Chad",
				LastName = "Green"
			};

			PersonRecord personRecord = new("Chad", "Green");




			/* ----------------------------------------------------------------------
			 *               C# 9 -  Built-In Formatting for Display
			 * ---------------------------------------------------------------------- */

			Console.WriteLine(personClass);
			// output: TaleLearnCode.WhatsNewForCSharpDevelopers.Demo01.Program+PersonClass

			Console.WriteLine(personRecord);
			// output: PersonRecord { FirstName = Chad, LastName = Green }




			/* ----------------------------------------------------------------------
			 *                       C# 9 - Value Equality
			 * ---------------------------------------------------------------------- */

			// Equality - Classes
			PersonClass duplicatedPersonClass = new() { FirstName = "Chad", LastName = "Green" };
			Console.WriteLine(personClass == duplicatedPersonClass); // output: False

			// Equality - Records
			PersonRecord duplicatedPersonRecord = new("Chad", "Green");
			Console.WriteLine(personRecord == duplicatedPersonRecord); // output: True

			Console.WriteLine(ReferenceEquals(personRecord, duplicatedPersonRecord)); // output: False




			/* ----------------------------------------------------------------------
			 *									  C# 9 - Nondestructive Mutation
			 * ---------------------------------------------------------------------- */

			PersonRecord spouse = personRecord with { FirstName = "Corina" };
			Console.WriteLine(spouse.ToString());
			// output: PersonRecord { FirstName = Corina, LastName = Green }




			/* ----------------------------------------------------------------------
			 *									  C# 10 - Record types can seal ToString
			 * ---------------------------------------------------------------------- */

			SealedPerson resident = new() { FirstName = "Chad", LastName = "Green" };
			Console.WriteLine(resident.ToString());
			// output: Chad Green




			/* ----------------------------------------------------------------------
			 *	   C# 10 - Parameterless struct constructors and field initializers
			 * ---------------------------------------------------------------------- */

			AnotherAddress anotherAddress = new() { State = "KY" };
			Console.WriteLine(anotherAddress.City);
			// output: <unknown>




			/* ----------------------------------------------------------------------
			 *	     	  C# 10 - Structs can be created using the with expression
			 * ---------------------------------------------------------------------- */

			AnotherAddress anotherAddress2 = anotherAddress with { City = "Louisville" };
			Console.WriteLine(anotherAddress2.City);
			// output: Louisville

		}

	}

}