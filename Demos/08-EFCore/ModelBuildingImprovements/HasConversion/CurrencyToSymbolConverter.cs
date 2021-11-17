namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.ModelBuildingImprovements.HasConversion;

public class CurrencyToSymbolConverter : ValueConverter<Currency, string>
{

	public CurrencyToSymbolConverter()
		: base(
			v => v == Currency.PoundsSterling ? "£" : v == Currency.Euros ? "€" : "$",
			v => v == "£" ? Currency.PoundsSterling : v == "€" ? Currency.Euros : Currency.UsDollars)
	{
	}

}