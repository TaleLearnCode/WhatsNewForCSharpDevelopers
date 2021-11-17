namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.PreConventionModelConfiguration;

public readonly struct Money
{
	[JsonConstructor]
	public Money(decimal amount, Currency currency)
	{
		Amount = amount;
		Currency = currency;
	}

	public override string ToString()
			=> (Currency == Currency.UsDollars ? "$" : "£") + Amount;

	public decimal Amount { get; }
	public Currency Currency { get; }
}