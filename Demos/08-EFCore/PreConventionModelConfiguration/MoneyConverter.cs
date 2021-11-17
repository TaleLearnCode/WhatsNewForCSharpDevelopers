namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.PreConventionModelConfiguration;

public class MoneyConverter : ValueConverter<Money, string>
{

	public MoneyConverter()
			: base(
					v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
					v => JsonSerializer.Deserialize<Money>(v, (JsonSerializerOptions)null))
	{
	}

}