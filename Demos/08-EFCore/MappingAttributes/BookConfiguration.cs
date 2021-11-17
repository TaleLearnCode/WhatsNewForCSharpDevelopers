namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.MappingAttributes;

internal class BookConfiguration : IEntityTypeConfiguration<Book2>
{

	public void Configure(EntityTypeBuilder<Book2> builder)
	{
		builder
			.Property(e => e.Isbn)
			.IsUnicode(false)
			.HasMaxLength(17);
		builder
			.Property(e => e.Price)
			.HasPrecision(10, 2);
	}

}