# Canonical contract types

TRD schemas use these solution-neutral types. Every property also states nullability separately.

| Type | Meaning |
| --- | --- |
| `string` | Text |
| `bool` | True or false |
| `int32` | Signed 32-bit integer |
| `int64` | Signed 64-bit integer |
| `decimal` | Exact base-10 numeric value; specify precision and scale when material |
| `uuid` | Universally unique identifier |
| `date` | Calendar date without time |
| `datetime` | Date and time; specify timezone or offset semantics |
| `enum` | Closed set of named values; define the allowed values |
| `array<T>` | Ordered collection of a defined canonical type `T` |
| `object` | Structured value; define its properties and their canonical types |

Use `Required` or `Nullable` independently of type. Cardinality and collection emptiness are
separate constraints. Do not use C# type syntax, Entity Framework attributes, namespaces, base
classes, repository patterns, or source-file locations in these contracts. The development plugin
owns language mappings and implementation structure.
