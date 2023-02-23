# What's New for C# Developers (Demo Script)

## 07 - LINQ

* [Chunk](#chunk)
* [OrDefault() Overloads](#ordefault-overloads)
* [PriorityQueue<T,N>](#priorityqueuetn)
* [MinBy() and MaxBy()](#minby-and-maxby)
* [Set Operations](#set-operations)

---

### Chunk

Prior to .NET 6, there is not a native way to break a collection into a set of smaller collections (pages).

* Old Ways:
    - Skip/Take
    - LINQ Extension Method
* New Way:
    - Chunk

Splits the elements of a sequence into chunks of size at most `size`.

---

### OrDefault() Overloads

Prior to .NET 6, you could use the `FirstOrDefault()` to get either the first element in a collection or the default for the types of the collection.  But what if you want to return something different than the default?
  
Now there is an overload to `FirstOrDefault()` that allows us to specify a custom value to return if the conditions are not met.

---

### PriorityQueue<T,N>

.NET has already has `Queue<T>` which is great for first-in/first-out queue processing; but what if you need to give queue items a priority.  That is where `PriorityQueue<T,N>` comes in.

---

### MinBy() and MaxBy()

.NET has had a way to get the minimum and maximum value for primitive types, but what about getting the maximum value of a complex collection of classes?

### Set Operations

.NET already had the `Union`, `Intersect`, `Except`, and `Distinct` set operations.  .NET 6 adds in `UnionBy`, `IntersectBy`, `ExceptBy`, and `DistinctBy` for set operations against collections.