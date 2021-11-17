namespace TaleLearnCode.WhatsNewForCSharpDevelopers.Demo01
{

	public record SealedPerson
	{

		public string FirstName { get; init; }

		public string LastName { get; init; }

		public sealed override string ToString()
		{
			return $"{FirstName} {LastName}";
		}

	}

	//public record Resident : SealedPerson
	//{

	//	public override string ToString()
	//	{
	//		return $"{LastName}, {FirstName}";
	//	}
	//}

}