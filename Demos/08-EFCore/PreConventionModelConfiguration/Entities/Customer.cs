namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.PreConventionModelConfiguration;

public class Customer
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public bool IsActive { get; set; }
	public Money AccountValue { get; set; }

	public Session? CurrentSession { get; set; }

	public ICollection<Order> Orders { get; } = new List<Order>();
}