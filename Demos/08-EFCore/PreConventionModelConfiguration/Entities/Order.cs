namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.PreConventionModelConfiguration;

public class Order
{
	public int Id { get; set; }
	public string? SpecialInstructions { get; set; }
	public DateTime OrderDate { get; set; }
	public bool IsComplete { get; set; }
	public Money Price { get; set; }
	public Money? Discount { get; set; }

	public Customer? Customer { get; set; }
}