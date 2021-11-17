namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.MappingAttributes;

public class Book
{

	public int Id { get; set; }
	public string? Title { get; set; }

	[Unicode(false)]
	[MaxLength(17)]
	public string? Isbn { get; set; }

	[Precision(precision: 10, scale: 2)]
	public decimal Price { get; set; }

}