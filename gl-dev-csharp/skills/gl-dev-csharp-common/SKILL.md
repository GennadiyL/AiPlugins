---
name: gl-dev-csharp-common
description: Use when creating, modifying, or reviewing C# source in a GL .NET solution, including formatting, comments, XML documentation, and repository-defined code style.
---

# GL Dev CSharp Common

Apply this baseline to every C# source change. Layer-specific skills add architecture and technology rules without replacing these conventions.

## Formatting

- Locate the `.sln` or `.slnx` file for the solution being changed.
- Apply formatting rules only from the `.editorconfig` file in the same directory as that solution file.
- Do not derive formatting rules from any other `.editorconfig`, `Directory.Build.props`, analyzer configuration, general convention, or neighboring source code.
- If no `.editorconfig` exists alongside the solution file, do not invent or import formatting rules.

## Comments and XML documentation

- Use XML documentation only; do not add ordinary line, block, or property comments.
- Put all XML documentation content inside a single `<summary>` element. Do not use `<remarks>` or other XML documentation elements.
- Add medium-detail XML documentation to every class and enum (about 8-12 lines), covering responsibility, lifecycle, important relationships, and exclusions.
- Add method-level XML documentation only to public methods declared by service interfaces. An interface method without an explicit accessibility modifier is implicitly public and must be documented.
- State the service operation and where its result is used. Do not document individual parameters or return values.
- Do not add XML documentation to service implementation methods, including public implementation methods.
- Method names must be self-documenting. Do not use XML documentation to compensate for an unclear method name.

## Existing guideline violations

- Apply these rules to declarations being generated or directly changed for the requested task. A containing type is not directly changed merely because one of its members is changed.
- When existing code outside the requested change violates these guidelines, report the violation as a remark to the user or in review output. Do not add a source-code comment for the remark.
- Do not fix, reformat, rename, or refactor such code without explicit instructions. Treat the existing violation as a potentially intentional exception.
