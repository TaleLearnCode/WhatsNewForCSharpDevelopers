# What's New for C# Developers (Demo Script)

## 04 - C# 10 Part 2

* [Extended Property Patterns](#extended-property-patterns)
* [Assignment and declatation in same deconstruction](#assignment-and-declatation-in-same-deconstruction)
* [Interpolated String Handlers](#interpolated-string-handlers)

---

### Extended Property Patterns

Beginning with C# 10, you can reference nested properties or fields within a property pattern.

---

### Assignment and declaration in same deconstruction

Prior to C# 10, deconstruction required all variables to be new, or all of them to be previously declared.  In C# 10, you can mix.

---

### Interpolated String Handlers

Prior to C# 10, the compiler turns interpolated strings into a call to `string.Format`. This can lead to a lot of allocations - the boxing of argument, allocation of an argument array, and of course the resulting string itself.

In C# 10, Microsoft has added a library pattern that allows an API to "take over" the handling of an interpolated string argument expression.

#### Initial Implementation
~**File:** Logger.cs~

Let's start with a base logger class that supports different levels.

This logger supports six different levels.  When a message will not pass the log level filter, there is no output.  The public API for the logger accepts a (fully formatted) string as the message.  All the work to create the string has already been done.

#### Implement the handler pattern
~**File:** LogInterpolatedStringHandler.cs~

This step is to build an *interpolated string handler* that recreates the behavior.  An interpolated string handler is a type that must have the following characteristics:

* The System.Runtime.CompilerServices.InterpolatedfStringHandlerAttribute applied to the type.
* A constructor that has two `int` parameters, `literalLength` and `formatCount`.  (More parameters are allowed).
* A public `AppendLiteral` method with the signature: `public void AppendLiteral(string s)`.
* A generic public `AppendFormatted` method with the signature: `public void AppendFormatted<T>(T t)`.

Internally, the builder creates the formatted string, and provides a member for a client to retrieve that string.

~**File:** Logger.cs~

Now we can add an overload to `LogMessage` in the `logger` class to try your new interpolated string handler.

We do not need to remove the original `LogMessage` method, the compiler will prefer a method with an interpolated handler parameter over a method with a `string` parameter when the argument is an interpolated string expression.

Lot more can be done!