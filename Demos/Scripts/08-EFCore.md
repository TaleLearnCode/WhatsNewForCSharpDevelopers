# What's New for C# Developers (Demo Script)

## 08 - EF Core 6.0

* [New Mapping Attributes](#new-mapping-attributes)
    - [UnicodeAttribute](#unicodeattribute)
    - [PrecisionAttribute](#precisionattribute)
    - [EntityTypeConfigurationAttributee](#entitytypeconfigurationattributee)
* [Model Building Improvements](#model-building-improvements)
    - [Support for SQL Sever sparse columns](#support-for-sql-sever-sparse-columns)
    - [Improvements to HasConversion API](#improvements-to-hasconversion-api)
    - [Allow value converters to convert nulls](#allow-value-converters-to-convert-nulls)
* [Pre-convention model configuration](#pre-convention-model-configuration)
* [SQL Server Temporal Tables](#sql-server-temporal-tables)
    - [Improvements to scaffolding from an existing database](#improvements-to-scaffolding-from-an-existing-database)
    - [Scaffolding many-to-many relationships](#scafollding-many-to-many-relationships)
    - [Database Comments Are Scaffolded to Code Comments](#database-comments-are-scaffolded-to-code-comments)
---

### New Mapping Attributes
Entity Framework Core 6.0 contains several new attributes that can be applied to code to change the way it is mapped to the database.

#### UnicodeAttribute
Starting with EF Core 6.0, a string property can not be mapped to a non-Unicode column using a mapping attribute *without specifying the database type directly*.

~**File:** MappingAttributes\Book.cs~

#### PrecisionAttribute
The prevision and scale of a database column can not be configured using mapping attributes *without specifying the database type directly*.

~**File:** MappingAttributes\Book.cs~

#### EntityTypeConfigurationAttributee
Starting with EF Core 6.0, an `EntityTypeConfigurationAttribute` can be placed on the entity type such that EF Core can find and use the appropriate configuration.

~**File:** MappingAttributes\BookConfiguration.cs~

This attributes means that EF Core will use the specified `IEntityTypeConfiguration` implementation whenever the `Book2` entity type is included in a model.  The entity type is included in a model using one of the normal mechanisms.

---

### Model Building Improvements
In addition to new mapping attributes, EF Core 6.0 includes several other improvements to the model building process.

#### Support for SQL Sever sparse columns
SQL Server sparse columns are ordinary columns that are optimized to store null values.

~**File:** ModelBuildingImprovements\Sparse\ForumUser.cs~

~**File:** ModelBuildingImprovements\Sparse\ForumModerator.cs~

~**File:** ModelBuildingImprovements\Sparse\ForumContext.cs~

SQL Sever Documentation: Sparse columns are ordinary columns that have an optimized storage for null values.  Sparse columns reduce the space requirements for null values at the cost of more overhead to retrive non-NULL values.  COnsider using sparse columns when space saved is at least 20 percent to 40 percent.

#### Improvements to HasConversion API
Before EF Core 6.0, the generic overloads of the `HasConversion` methods used the generic parameter to specify *the type to convert to*.  Starting with EF Core 6.0, the generic type can instead specify a *value converter type*.  This can be one of the built-in value converters or it can be a custom value converter type.

#### Less configuration for many-to-many relationships
Unambiguous many-to-many relationship between two entity types are discovered by convention.  Where necessary or if desired, the navigations can be set.

~**File:** ModelBuildingImprovements\ManyToMany\Contexts.cs~

#### Allow value converters to convert nulls
Due to problem outline below, the constructors for `ValueConverter` that allow conversation of nulls have been marked with `[EntityFrameworkInternal]` for the EF Core 6.0 release.  Using these constructors will now generate a build warning.

* Value conversion to null in the store generates bad queries
* Value converters do not handle cases where the database column has multiple different values that convert to the same value
* Allow value converters to change nullability of columns

These are not trivial issues and for the query issues they are not easy to detect.

One example of where converting nulls can be useful is when the database contains nulls, but the entity type wants to use some other default value for the property.  For example, where the default value is "Unknown" and you want Null to convert to that.

---

### Pre-convention model configuration

Previous version of EF Core require that the mapping for every property of a given type is configured explicitly when that mapping differs from the default.  This includes "facets" like the maximum length of string and decimal precision, as well as value conversions.

This necessitated either:

* Model builder configuration for each property
* A mapping attribute on each property
* Explicit iteration over all properties of all entity types and use of the low-level metadata APIs when building the mode.

EF Core 6.0 allows this mapping configuration to be specified once for a given type.  It will then be applied to all properties of that type in the model.  This is called "pre-convention model configuration", since it configures aspects of the model that are then used by the model building conversions.

~**File:** PreConventionModelConfiguration\CustomerContext.cs~

---

### SQL Server Temporal Tables

SQL Server temporal tables automatically keep track of all data ever stored in a table, even after that data has been updated or deleted.  This is achieved by creating a parallel "history table" into which timestamped historical data is stored whenever a change is made to the main table.  This allows historical data to be queried, such as for auditing, or restored, such as for recover after accidental mutation or deletion.

EF Core now supports:

* The creation of temporal tables using Migrations
* Transformation of existing tables into temporal tables, again using Migrations
* Querying historical data
Restoring data from some point in the past

---

### Improvements to scaffolding from an existing database
EF Core 6.0 includes several improvements when reverse engineering and EF model from an existing database.

#### Scaffolding many-to-many relationships
EF Core 6.0 detects simple join tables and automatically generates a many-to-many mapping for them.

#### Scaffold C# Nullable Reference TYpes
EF Core 6.0 now scaffolds an EF model and entity types that use C# nullable reference types (NRTs).  NRT usage is scaffolded automatically when NRT support is enabled in the C# project which the code is being scaffold.

#### Database Comments Are Scaffolded to Code Comments
Comments on SQL tables and columns are now scaffolded into the entity types created when reverse-engineering an EF Core model from an existing SQL Server database.