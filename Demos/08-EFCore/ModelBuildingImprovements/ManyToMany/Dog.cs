namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.ModelBuildingImprovements.ManyToMany;

public class Dog
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public ICollection<Human> Humans { get; } = new List<Human>();
}