namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.ModelBuildingImprovements.ManyToMany;

public class Human
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public ICollection<Dog> Dogs { get; } = new List<Dog>();
}