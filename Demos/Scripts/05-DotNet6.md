# What's New for C# Developers (Demo Script)

## DateOnly and TimeOnly

Working with dates and times in .NET, means you have used `DateTime`, `DateTimeOffset`, and `TimeSpan`.

With .NET 6, Microsoft is introducing two additional types: `DayeOnly` and `TimeOnly`.  Both are in the `System` namespace and are built-in to .NET, just like the other date and time types.

* [The DateOnly Type](#the-dateonly-type)
* [The TimeOnly Type](#the-timeonly-type)

---

### The DateOnly Type
The `DateOnly` type is a structure that is intended to represent *only* a date.  In other words, just a year, month, and day.

A `DateOnly` is ideal for scenarios such as birth dates, anniversary dates, hire dates, and other business dates that are not typically associated with any particular time.

Advantages:

* A `DateOnly` provides better type safety than a `DateTIme` that is intended to represent just a date.  This matters when using APIs, as not evey action that makes sense for a date and time also makes sense for a whole date.
* A `DateTime` contains a `Kind` property of type `DateTimeKind`, which can be `Local`, `Utc`, or `Unspecified`.  The kind affect behavior of conversion APIs as well as formatting and parsing of strings.  A `DateOnly` has no such kind - it is effectively `Unspecified`, always.
* When serializing a `DateOnly`, you only need to include the year, month, and day.  This makes your data clearer by preventing a bunch of zeros from being tacked on to the end.  It also makes it clear to any consumer of your API that tthe value represents a whole date, not the time at midnight on that date.
* When interacting with a database (such as SQL Sever and others), whole dates are almost always stored in a `date` data type.  Until now, the APIs for storing and retrieving such data have been strongly tied to the `DateTime` type.  On storage, the time would be truncated, potentially leading to data loss.  On retrieval, the time would be set to zeros and would be indistinguishable from a date at midnight.  Having a `DateONly` tyupe allows a more exact matching type to a database's `date` type.

#### New DateOnly Type
Demonstrate how the DateOnly initializer works.

#### DateOnly Math
Just like the `DateTime`, we can use overload methods like `AddDays()` to modify the value of a `DateOnly` instance.

#### Parsing DateOnly from String
`DateOnly` instances can be parsed from strings using `TryParse()`.

#### DateOnly Storage
Internally, `DateOmnly` stores its value as an integer, where 0 is January 1, 0001.

---

### The TimeOnly Type
The `TimeOnly` type is a structure that is included to represent *only* a time of day.

The `TimeOnly` type is ideal for scenarios such as recruiting meeting times, daily alarm clock times, or the times that a business opens and closes each day of the week.  Because a `TimeOnly` is not associated with any particular date, it is best visualized as a circular analog clock that might hang on your wall.  Until now, there have been two ways that such values were represented, either using a `TimeSpan` type or a `DateTime` type.  While those approaches still work, there are several advantages to using a `TimeOnly` instead:

* A `TimeSpan` is primarily intended for *elapsed* time, such as you would measure with a stopwatch.  Its upper range is more than 29,000 *years*, and its values can also be *negative* to indicate moving backward in time.  Conversely, a `TimeOnly` is intended for a time-of-day value, so its range is from `00:00:00.0000000` to `23:59:59.9999999`, and is always positive. When a `TimeSpan` is used as a time of day, there is risk that it could be manipulated such that it is out of an acceptable range.  There is no such risk with a `TimeOnly`.
* Using a `DateTime` for a time-of-day value requires assigning some arbitrary date.  A common date picked is `DateTime.MinValue` (0001-01-01), but that sometimes leads to out of range exceptions during manipulation, if time is subtracted.  Picking some other arbitrary date still requires remembering to later disregard it - which can be a problem during serialization.
* `TimeOnly` is a true time-of-day type, and so it offers superior type safety for such values vs `DateTime` or `TimeSpan`, in the same way that using a `DateOnly` offers better types safety for date values than a `DateTime`.
* A common operation with time-of-day values is to add or subtract some period of elapsed time.  Unlike `TimeSpan`, a `TimeOnly` value will correctly handle such operations when crossing midnight.  FOr example, an employee's shift might start at 18:00 and last 8 hours, ending at 02:00.  TimeOnly will take care of that during the addition operation, and it also has an `InBetween` method that can easily be used to tell if any given time is within the worker's shift.

#### New TimeOnly Type
Demonstrate how the TimeOnly initializer works.

#### TimeOnly Storage
Internally, `TimeOnly` stores its value as a `long`, which are the ticks (100 nanoseconds) since 00:00:00 (midnight).  We can use the ticks to create a new `TimeOnly` value.

#### TimeOnly Math
We can perform math operations on instances of `TimeOnly`, which give us `TimeSpan` results.

#### TimeOnly Range Validation
The `TimeOnly` type includes the `IsBewteen` method.

Can even check for a value in a range that goes pass midnight.

#### TimeOnly Comparison Operations
Can use comparison operators to compare two `TimeOnly` instances.