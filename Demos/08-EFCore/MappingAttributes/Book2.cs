namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.MappingAttributes;

[EntityTypeConfiguration(typeof(BookConfiguration))]
public class Book2
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Isbn { get; set; }
	public decimal Price { get; set; }
}