# What's New for C# Developers (Demo Script)

## 03 - C# 10 Part 1

* [File-scoped namespace declaration](#file-scoped-namespace-declaration)
* [Global and implicit usings](#global-and-implicit-usings)
    * [Global using directives](#global-using-directives)
    * [Implicit usings](#implicit-usings)
* [Constant interpolated strings](#constant-interpolated-strings)
---

### File-scoped namespace delcaration

Many files contain code for a single namespace.  Starting in C# 10, you can include a namespace as a statement, followed by a semi-colon and withtou the curly brackets.

~**File:** ReferenceTypes.Entities — Country~

Demonstrate going from old namespace format to file-scoped declaration.

This simplies the code and removes a level of nesting.  ONly one file-scoped namespace declaration is allowed, and it must come before any ttypes are declared.

---

### Global and implicit usings

#### Global using directives

You can add the `global` modified to any `using` directive to instructe the compiler that the derective applies to all source files in the compilation.  This is typically all source files in a project.

~**File:** ReferenceTypes.Repositrory - Country~

Point out how every class and interface has the `using TaleLearnCode.ReferenceTypes.Entities;` directrive.

Make the directive global.

#### Implicit usings
The implicit usings feature automatically adds `global using` directives for the type of project you are buidling.

~**File:** D:\Repos\TaleLearnCode\Presentations\WhatsNewForCSharpDevelopers\Demos\ReferenceTypes.Repository\obj\Debug\net6.0\ReferenceTypes.Repository.GlobalUsings.g.cs~

Show off the usings that added by default.

~**File:** ReferenceTypes.Repository.Repository.csproj~

Talk about the `<ImplicitUsings>enable<ImplicitUsings>` setting.

[Listing of implicit usings](https://docs.microsoft.com/en-us/dotnet/core/compatibility/sdk/6.0/implicit-namespaces-rc1#new-behavior)

### Constant interpolated strings

in C# 10, `const` string may be initialized using string interpolation if all the placeholders are themselves constant strings.  String interpolation can create more readable constanst strings as yuou build constant string used in your application.

~**File:** ReferenceTypes.Repository — CountryRepository.cs~

The placeholder expression cannot be numeric constants because those constants are converted to strings at run time.