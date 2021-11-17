namespace _07_LINQ;

internal class Employee
{

	public int Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public DateOnly EmploymentDate { get; set; }

	public string Name { get { return $"{FirstName} {LastName}"; } }

	public static List<Employee> GetEmployees()
	{
		return new List<Employee>()
		{
			new Employee() { Id = 1, FirstName = "Rudy", LastName = "Brown", EmploymentDate = new DateOnly(2012, 1, 4) },
			new Employee() { Id = 2 , FirstName = "Billy", LastName = "Hernandez", EmploymentDate = new DateOnly(2020, 5, 15) },
			new Employee() { Id = 3 , FirstName = "Doyle", LastName = "Griffith", EmploymentDate = new DateOnly(2018, 3, 18) },
			new Employee() { Id = 4 , FirstName = "Billy", LastName = "Rodgers", EmploymentDate = new DateOnly(2016, 11, 25) },
			new Employee() { Id = 5 , FirstName = "Joanna", LastName = "Anguilar", EmploymentDate = new DateOnly(1998, 7, 6) },
			new Employee() { Id = 6 , FirstName = "Hattie", LastName = "Lloyd", EmploymentDate = new DateOnly(2019, 10, 15) },
			new Employee() { Id = 7 , FirstName = "Jimmy", LastName = "Lawson", EmploymentDate = new DateOnly(2020, 3, 13) },
			new Employee() { Id = 8 , FirstName = "Mary", LastName = "Lambert", EmploymentDate = new DateOnly(2017, 5, 9) },
			new Employee() { Id = 9 , FirstName = "Jack", LastName = "Moss", EmploymentDate = new DateOnly(2021, 8, 9) },
			new Employee() { Id = 10, FirstName = "Joan", LastName = "Banks", EmploymentDate = new DateOnly(2005, 8, 10) }
		};
	}

	public static List<Employee> GetShorterListOfEmployees1()
	{
		return new List<Employee>()
		{
			new Employee() { Id = 1, FirstName = "Rudy", LastName = "Brown", EmploymentDate = new DateOnly(2012, 1, 4) },
			new Employee() { Id = 2 , FirstName = "Billy", LastName = "Hernandez", EmploymentDate = new DateOnly(2020, 5, 15) },
			new Employee() { Id = 3 , FirstName = "Doyle", LastName = "Griffith", EmploymentDate = new DateOnly(2018, 3, 18) },
			new Employee() { Id = 4 , FirstName = "Billy", LastName = "Rodgers", EmploymentDate = new DateOnly(2016, 11, 25) },
			new Employee() { Id = 5 , FirstName = "Joanna", LastName = "Anguilar", EmploymentDate = new DateOnly(1998, 7, 6) },
		};
	}

	public static List<Employee> GetShorterListOfEmployees2()
	{
		return new List<Employee>()
		{
			new Employee() { Id = 6 , FirstName = "Hattie", LastName = "Lloyd", EmploymentDate = new DateOnly(2019, 10, 15) },
			new Employee() { Id = 7 , FirstName = "Jimmy", LastName = "Lawson", EmploymentDate = new DateOnly(1998, 7, 6) },
			new Employee() { Id = 8 , FirstName = "Mary", LastName = "Lambert", EmploymentDate = new DateOnly(2012, 1, 4) },
			new Employee() { Id = 9 , FirstName = "Jack", LastName = "Moss", EmploymentDate = new DateOnly(2021, 8, 9) },
			new Employee() { Id = 10, FirstName = "Joan", LastName = "Banks", EmploymentDate = new DateOnly(2018, 3, 18) }
		};
	}

}