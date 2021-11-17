# What's New for C# Developers (Demo Script)

## 01 - Record Types

#### Table of Contents
* [Record Clases (C# 9)](#record-classes)
    - [Creating Reocrd Classes](#creating-record-classes)
    - [Positional syntax for property definition](#positional-syntax-for-property-definition)
    - [Built-in formatting for display](#built-in-formatting-for-display)
    - [Value equality](#value-equality)
    - [Nondestructive mutation](#nondestructive-mutation)
    - [Record types can seal ToString](#record-types-can-seal-tostring)
* [Improvements to structs (C# 10)](#improvements-to-structs)
    - [Parameterless struct constructors and field initializers](#parameterless-struct-constructors-and-field-initializers)
    - [Structs can be created using the with expression](#structs-can-be-created-using-the-with-expression)
* [Record structs (C# 10)](#record-structs)

----
### Record Classes

#### Creating Record Classes
~**File:** CreatingRecordTypes.cs~

Walk through the three ways to create a record types:

* Immutable record using positional paramters
* Immutable recor using standard property syntax
* Muttable record

While records can be mutable, they are primarily inteded for supporting immutable data models.  The record type offers the following features:

#### Positional syntax for property definition
~**File:** Program.cs~

You can use positional paramters to declare propertie sof a record and to initialize the property values when you create an instance.

When you use the positional syntax for property defintiion, the compiler creates:
* A pulic init-only auto-implemented property for each positional paramter provided in the reocrd declaration.  An init-only propery can only be set in the constructor or by using a property initializer.
* A primary constructor whose parameters match the positional parameters on the record declaration.
* A `Deconstruct` method witrh an `out` parameter for each positional parameter provided in the rocord declaration.

#### Built-in formatting for display
Record types have a compiled-generated ToString method that displays the names and values of public properties and fields.

#### Value equality
Value equality means that two variables of a record type are equal if the types match and all proeprty and field values match.  For other reference types, equality means identity.  That is, two variables of a reference type are equal if they refer to the same object.

#### Nondestructive mutation
If you need to mutate immutable properties of a record instance, you can use a `with` expression to achieve *nondestructive muttation*. A `with` expression makes a new record instance that is a copy of an existing record instance, with specified properties and fields modified.

#### Record types can seal ToString
~**File:** SealedToString.cs~

You can add the `sealed` modifier when you override `ToString` in record type.  Selaning the `ToString` method prevents the compilter from synthsizing a `ToString` method for any derived record types.  A `sealed` `ToString` ensures all derived record types use the `ToString` method defined in a common base record type.

----
### Improvements to structs

C# 10 introduces features for structs that provide better parity between structs and classes.  These new features include parameterless constructores, field initializers, record structs, and `with` expressions.

#### Parameterless struct constructors and field initializers
Prior to C# 10, every struct had an implicit public parameterless construtor that set the struct's fields to `default`.  It was an error for you to create a paramterless construtor on a struct.

String in C# 10, you can include your own parameterless struct construtos.  If you do not supply one, the implicit paramterless constructor will be supplied to set all fields to their default.

~**File:** SealedToString.cs~

Demonstrate creating the struct.

~**File:** SealedToString.cs~

Demonstrate using the parameterless struct constructor.

#### Structs can be created using the with expression
~**File:** Program.cs~

Demonstrate use the ~with~ expression with a struct.

---

### Record structs
Starting with C# 10, record can not be defined `record struct`.

~**File:** RecordStructs.cs~