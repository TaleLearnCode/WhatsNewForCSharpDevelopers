namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.TemporalTables;

public class Employee
{
	public Guid EmployeeId { get; set; }
	public string? Name { get; set; }
	public string? Position { get; set; }
	public string? Department { get; set; }
	public string? Address { get; set; }
	public decimal AnnualSalary { get; set; }
}