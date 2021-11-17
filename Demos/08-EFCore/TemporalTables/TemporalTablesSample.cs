namespace TaleLearnCode.WhatsNewForCSharepDevelopers.EFCore.TemporalTables;

internal class TemporalTablesSample
{

	public static void Execute()
	{
		Console.WriteLine($">>>> Sample: {nameof(TemporalTablesSample)}");
		Console.WriteLine();

		RecreateCleanDatabase();

		DateTime timeStamp1;
		DateTime timeStamp2;
		DateTime timeStamp3;
		DateTime timeStamp4;

		using (var context = new EmployeeContext(quiet: true))
		{
			#region InsertData
			context.AddRange(
					new Employee
					{
						Name = "Pinky Pie",
						Address = "Sugarcube Corner, Ponyville, Equestria",
						Department = "DevDiv",
						Position = "Party Organizer",
						AnnualSalary = 100.0m
					},
					new Employee
					{
						Name = "Rainbow Dash",
						Address = "Cloudominium, Ponyville, Equestria",
						Department = "DevDiv",
						Position = "Ponyville weather patrol",
						AnnualSalary = 900.0m
					},
					new Employee
					{
						Name = "Fluttershy",
						Address = "Everfree Forest, Equestria",
						Department = "DevDiv",
						Position = "Animal caretaker",
						AnnualSalary = 30.0m
					});

			context.SaveChanges();
			#endregion
		}

		using (var context = new EmployeeContext(quiet: true))
		{
			Console.WriteLine();
			Console.WriteLine("Starting data:");

			var employees = context.Employees.ToList();
			foreach (var employee in employees)
			{
				var employeeEntry = context.Entry(employee);
				var validFrom = employeeEntry.Property<DateTime>("ValidFrom").CurrentValue;
				var validTo = employeeEntry.Property<DateTime>("ValidTo").CurrentValue;

				Console.WriteLine($"  Employee {employee.Name} valid from {validFrom} to {validTo}");
			}
		}

		using (var context = new EmployeeContext(quiet: true))
		{
			// Change the sleep values to emphasize the temporal nature of the data.
			const int millisecondsDelay = 100;

			Thread.Sleep(millisecondsDelay);
			timeStamp1 = DateTime.UtcNow;
			Thread.Sleep(millisecondsDelay);

			var employee = context.Employees.Single(e => e.Name == "Rainbow Dash");
			employee.Position = "Wonderbolt Trainee";
			context.SaveChanges();

			Thread.Sleep(millisecondsDelay);
			timeStamp2 = DateTime.UtcNow;
			Thread.Sleep(millisecondsDelay);

			employee.Position = "Wonderbolt Reservist";
			context.SaveChanges();

			Thread.Sleep(millisecondsDelay);
			timeStamp3 = DateTime.UtcNow;
			Thread.Sleep(millisecondsDelay);

			employee.Position = "Wonderbolt";
			context.SaveChanges();

			Thread.Sleep(millisecondsDelay);
			timeStamp4 = DateTime.UtcNow;
			Thread.Sleep(millisecondsDelay);
		}

		using (var context = new EmployeeContext(quiet: true))
		{
			#region NormalQuery
			var employee = context.Employees.Single(e => e.Name == "Rainbow Dash");
			context.Remove(employee);
			context.SaveChanges();
			#endregion
		}

		using (var context = new EmployeeContext(quiet: true))
		{
			Console.WriteLine();
			Console.WriteLine("After updates and delete:");

			#region TrackingQuery
			var employees = context.Employees.ToList();
			foreach (var employee in employees)
			{
				var employeeEntry = context.Entry(employee);
				var validFrom = employeeEntry.Property<DateTime>("ValidFrom").CurrentValue;
				var validTo = employeeEntry.Property<DateTime>("ValidTo").CurrentValue;

				Console.WriteLine($"  Employee {employee.Name} valid from {validFrom} to {validTo}");
			}
			#endregion

			Console.WriteLine();
			Console.WriteLine("Historical data for Rainbow Dash:");

			#region TemporalAll
			var history = context
					.Employees
					.TemporalAll()
					.Where(e => e.Name == "Rainbow Dash")
					.OrderBy(e => EF.Property<DateTime>(e, "ValidFrom"))
					.Select(
							e => new
							{
								Employee = e,
								ValidFrom = EF.Property<DateTime>(e, "ValidFrom"),
								ValidTo = EF.Property<DateTime>(e, "ValidTo")
							})
					.ToList();

			foreach (var pointInTime in history)
			{
				Console.WriteLine(
						$"  Employee {pointInTime.Employee.Name} was '{pointInTime.Employee.Position}' from {pointInTime.ValidFrom} to {pointInTime.ValidTo}");
			}
			#endregion
		}

		using (var context = new EmployeeContext(quiet: true))
		{
			Console.WriteLine();
			Console.WriteLine($"Historical data for Rainbow Dash between {timeStamp2} and {timeStamp3}:");

			#region TemporalBetween
			var history = context
					.Employees
					.TemporalBetween(timeStamp2, timeStamp3)
					.Where(e => e.Name == "Rainbow Dash")
					.OrderBy(e => EF.Property<DateTime>(e, "ValidFrom"))
					.Select(
							e => new
							{
								Employee = e,
								ValidFrom = EF.Property<DateTime>(e, "ValidFrom"),
								ValidTo = EF.Property<DateTime>(e, "ValidTo")
							})
					.ToList();
			#endregion

			foreach (var pointInTime in history)
			{
				Console.WriteLine(
						$"  Employee {pointInTime.Employee.Name} was '{pointInTime.Employee.Position}' from {pointInTime.ValidFrom} to {pointInTime.ValidTo}");
			}
		}

		using (var context = new EmployeeContext(quiet: true))
		{
			Console.WriteLine();
			Console.WriteLine($"Historical data for Rainbow Dash as of {timeStamp2}:");

			var history = context
					.Employees
					.TemporalAsOf(timeStamp2)
					.Where(e => e.Name == "Rainbow Dash")
					.OrderBy(e => EF.Property<DateTime>(e, "ValidFrom"))
					.Select(
							e => new
							{
								Employee = e,
								ValidFrom = EF.Property<DateTime>(e, "ValidFrom"),
								ValidTo = EF.Property<DateTime>(e, "ValidTo")
							})
					.ToList();

			foreach (var pointInTime in history)
			{
				Console.WriteLine(
						$"  Employee {pointInTime.Employee.Name} was '{pointInTime.Employee.Position}' from {pointInTime.ValidFrom} to {pointInTime.ValidTo}");
			}
		}


		using (var context = new EmployeeContext(quiet: true))
		{
			Console.WriteLine();
			Console.WriteLine($"Restoring Rainbow Dash from {timeStamp2}...");

			#region RestoreData
			var employee = context
					.Employees
					.TemporalAsOf(timeStamp2)
					.Single(e => e.Name == "Rainbow Dash");

			context.Add(employee);
			context.SaveChanges();
			#endregion

			Console.WriteLine();
			Console.WriteLine($"Historical data for Rainbow Dash between:");

			var history = context
					.Employees
					.TemporalAll()
					.Where(e => e.Name == "Rainbow Dash")
					.OrderBy(e => EF.Property<DateTime>(e, "ValidFrom"))
					.Select(
							e => new
							{
								Employee = e,
								ValidFrom = EF.Property<DateTime>(e, "ValidFrom"),
								ValidTo = EF.Property<DateTime>(e, "ValidTo")
							})
					.ToList();

			foreach (var pointInTime in history)
			{
				Console.WriteLine(
						$"  Employee {pointInTime.Employee.Name} was '{pointInTime.Employee.Position}' from {pointInTime.ValidFrom} to {pointInTime.ValidTo}");
			}
		}


		Console.WriteLine();
	}

	private static void RecreateCleanDatabase()
	{
		using (var context = new EmployeeContext(quiet: true))
		{
			context.Database.EnsureDeleted();
		}

		using (var context = new EmployeeContext())
		{
			context.Database.EnsureCreated();
		}
	}

}