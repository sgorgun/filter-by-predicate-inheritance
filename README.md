## Filter by Predicate. Inheritance

Intermediate level task for practicing inheritance classes, abstract classes and methods, Template Method design pattern.

Estimated time to complete the task - 2h.

The task requires .NET 6 SDK installed.

## Task description ##

- Develop the [ArrayExtension](ArrayExtension) class with following methods:

    - the `FilterByDigit` method, which takes an array of integers as a parameter and, based on it, forms a new array only from those elements that contain the given digit;
    - the `FilterByPalindromic` method, which takes an array of integers as a parameter and, based on it, forms a new array only from those elements that are palindromes.    
    _When implementing these methods, follow the suggested skeletons._

- Analyze the resulting methods:
    - what part of their code is the same?
    - which part depends on a specific _predicate_*?      
    _*A predicate  is a statement made about a subject. The subject of the statement is that about which the statement is made. A predicate in programming is an expression that uses one or more values with a boolean result._

    _Discuss this question and your answer with your trainer, if you work in a regular group._

- Put the common part of the code as a skeleton of operations in the `Filer` [abstract class](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract) and leave the details to be implemented by the derived classes. The overall structure and sequence of the algorithm are preserved by the parent class. 

- Develop derived classes for described above predicates. Place the solutions in the project `DerivedClasses`:

    - [ContainsDigitFilter](DerivedClasses/ContainsDigitFilter.cs);
    - [PalindromicFilter](DerivedClasses/PalindromicFilter.cs).

- Run all unit tests.

- Study [mock](http://xunitpatterns.com/Mock%20Object.html) tests and the [Moq](https://github.com/Moq/moq4/wiki/Quickstart) Framework.

- Suggest your custom version of the predicate and place it in separate project. Add unit tests for this solution to [FilterTests](FilterByPredicate.Tests/FilterTests.cs) class.

- Study the following class diagramm

    ![](/filter-by-predicate.png)

- Study the [Template Method](https://refactoring.guru/design-patterns/template-method) design pattern.
