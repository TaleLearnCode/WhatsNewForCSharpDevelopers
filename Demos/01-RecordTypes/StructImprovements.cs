namespace TaleLearnCode.WhatsNewForCSharpDevelopers.Demo01
{

	public struct Address
	{
		public Address()
		{
			City = "<unknown>";
		}
		public string City { get; init; }
	}

	public struct AnotherAddress
	{
		public string City { get; init; } = "<unknown>";
		public string State { get; init; }
	}

}