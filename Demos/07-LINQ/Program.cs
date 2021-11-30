CountryDivisionRepository countryDivisionRepository = new();

LINQChunk(countryDivisionRepository);
//OrDefaultOverloads(countryDivisionRepository);
//LINQPriorityQueue(countryDivisionRepository);
//LINQMinMax();
//LINQSetOperations();

static void LINQChunk(CountryDivisionRepository countryDivisionRepository)
{

	IEnumerable<CountryDivision>? usDivisions = countryDivisionRepository.Get("US");

	// Old Way - Built-In
	DisplayCountryDivisionsPage(usDivisions.Take(10), 1);
	DisplayCountryDivisionsPage(usDivisions.Skip(10).Take(10), 2);
	DisplayCountryDivisionsPage(usDivisions.Skip(20).Take(10), 3);
	DisplayCountryDivisionsPage(usDivisions.Skip(30).Take(10), 4);
	DisplayCountryDivisionsPage(usDivisions.Skip(40).Take(10), 5);

	// Old Way - Using a LINQ extension method
	IEnumerable<IEnumerable<CountryDivision>>? oldPages = usDivisions.Split(5);
	int oldPageNumber = 0;
	foreach (IEnumerable<CountryDivision> oldPage in oldPages)
	{
		oldPageNumber++;
		DisplayCountryDivisionsPage(oldPage, oldPageNumber);
	}

	// New Way - Chunk
	IEnumerable<IEnumerable<CountryDivision>> pages = usDivisions.Chunk(10);
	int pageNumber = 0;
	foreach (IEnumerable<CountryDivision> page in pages)
	{
		pageNumber++;
		DisplayCountryDivisionsPage(page, pageNumber);
	}

}

static void DisplayCountryDivisionsPage(IEnumerable<CountryDivision> countryDivisions, int pageNumber)
{
	Console.WriteLine();
	Console.WriteLine($"Page #{pageNumber}");
	foreach (CountryDivision countryDivision in countryDivisions)
		Console.WriteLine(countryDivision.Name);
}

static void OrDefaultOverloads(CountryDivisionRepository countryDivisionRepository)
{
	IEnumerable<string>? usDivisions = countryDivisionRepository.GetNames("US");
	IEnumerable<string>? caDivisions = countryDivisionRepository.GetNames("CA");

	// Old Way
	Console.WriteLine($"First US Division: {usDivisions.FirstOrDefault()}");
	Console.WriteLine($"First CA Division: {caDivisions.FirstOrDefault()}");

	// Old Way - Better
	Console.WriteLine($"First US Division: {GetFirstCountryDivisionName(usDivisions)}");
	Console.WriteLine($"First CA Division: {GetFirstCountryDivisionName(caDivisions)}");

	// New Way
	Console.WriteLine($"First US Division: {usDivisions.FirstOrDefault("None Found")}");
	Console.WriteLine($"First CA Division: {caDivisions.FirstOrDefault("None Found")}");

}

static string GetFirstCountryDivisionName(IEnumerable<string>? divisions)
{
	if (divisions is not null && divisions.Any())
		return divisions.FirstOrDefault() ?? "None Found";
	else
		return "None Found";
}

static void LINQPriorityQueue(CountryDivisionRepository countryDivisionRepository)
{


	// Standard queue
	Console.WriteLine("--- Standard Queue ---");
	Queue<string> queue = new();
	foreach (string? usDivision in countryDivisionRepository.GetNames("US"))
		queue.Enqueue(usDivision);

	while (queue.Count > 0)
		Console.WriteLine(queue.Dequeue());

	// Priority queue
	Console.WriteLine();
	Console.WriteLine("--- Priority Queue ---");
	PriorityQueue<string, int> priorityQueue = new();
	foreach (CountryDivision countryDivision in countryDivisionRepository.Get("US"))
		priorityQueue.Enqueue(countryDivision.Name, countryDivision.PopulationRank);

	while (priorityQueue.Count > 0)
		Console.WriteLine(priorityQueue.Dequeue());

}

static void LINQMinMax()
{

	// Prior to .NET 6
	List<int>? numbers = new() { 9, 6, 10, 18, 15, 23, 17, 11, 15, 4 };
	Console.WriteLine($"Min = {numbers.Min()}");
	Console.WriteLine($"Max = {numbers.Max()}");


	List<Employee>? employees = Employee.GetEmployees();

	// MaxBy
	Employee? employeeWithLongestTenure = employees.MinBy(x => x.EmploymentDate);
	Console.WriteLine($"Employee with longest tenure is {employeeWithLongestTenure?.FirstName} who started on {employeeWithLongestTenure?.EmploymentDate}");

	// MinBy
	Employee? employeeWithShortestTenure = employees.MaxBy(x => x.EmploymentDate);
	Console.WriteLine($"Employee with shortest tenure is {employeeWithLongestTenure?.FirstName} who started on {employeeWithShortestTenure?.EmploymentDate}");

	Employee? firstEmployeeAlphabetically = employees.MinBy(x => x.LastName);
	Console.WriteLine($"First employee alphabetically: {firstEmployeeAlphabetically?.Name}");

	Employee? lastEmployeeAlphabetically = employees.MaxBy(x => x.LastName);
	Console.WriteLine($"Last employee alphabetically: {lastEmployeeAlphabetically?.Name}");


}

static void LINQSetOperations()
{

	List<int>? listOfNumbers1 = new() { 15, 11, 7, 9, 21, 17, 16, 4, 19, 15, };
	DisplayListOfNumbers("List 1", listOfNumbers1);

	List<int>? listOfNumbers2 = new() { 4, 9, 4, 6, 20, 12, 8, 18, 16, 17 };
	DisplayListOfNumbers("List 2", listOfNumbers2);

	Console.WriteLine();

	// Union - unique values in the two lists
	DisplayListOfNumbers("Union", listOfNumbers1.Union(listOfNumbers2));

	// Intersect - values that appear in both sets
	DisplayListOfNumbers("Intersect", listOfNumbers1.Intersect(listOfNumbers2));

	// Except - values appear in the first, but not the second set
	DisplayListOfNumbers("Except", listOfNumbers1.Except(listOfNumbers2));

	// Distinct - distinct values within a set
	DisplayListOfNumbers("Distinct", listOfNumbers2.Distinct());


	List<Employee>? employeeList1 = Employee.GetShorterListOfEmployees1();
	List<Employee>? employeeList2 = Employee.GetShorterListOfEmployees2();

	// UnionBy - employees within distict employment years; favors the first list
	DisplayListOfEmployees("UnionBy", employeeList1.UnionBy(employeeList2, x => x.EmploymentDate.Year));

	// IntersectBy - employees who do not share an employment year
	DisplayListOfEmployees("IntersectBy", employeeList1.IntersectBy(employeeList2.Select(x => x.EmploymentDate.Year), x => x.EmploymentDate.Year));

	// ExceptBy - all employees except those hired this year
	List<int>? years = new() { 2021 };
	DisplayListOfEmployees("ExceptBy", Employee.GetEmployees().ExceptBy(years, x => x.EmploymentDate.Year));

	// DistinctBy - all employees with distinct years
	DisplayListOfEmployees("DistinctBy", Employee.GetEmployees().DistinctBy(x => x.EmploymentDate.Year));

}

static void DisplayListOfNumbers(string label, IEnumerable<int>? listOfNumbers)
{
	if (listOfNumbers is null) throw new ArgumentNullException(nameof(listOfNumbers));
	StringBuilder response = new($"{label}: ");
	foreach (int number in listOfNumbers)
		response.Append($"{number}, ");
	Console.WriteLine(response.ToString());
}

static void DisplayListOfEmployees(string label, IEnumerable<Employee>? employees)
{
	Console.WriteLine();
	Console.WriteLine($"--- {label} ---");
	if (employees is not null && employees.Any())
		foreach (Employee employee in employees)
			Console.WriteLine($"{employee.EmploymentDate.Year} - {employee.Name}");
}