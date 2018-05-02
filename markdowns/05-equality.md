# Equality - Exercises

The following exercises will focus on implementation of proper equality between two objects.

## Overriding `.Equals()` method

The first equality implementation when comparing two objects is to override the `.Equals()` method.

Implement the required code to ensure that the comparison will return true when two users have the same first name, last name and date of birth.

*Note: Don't forget to make sure that your code can handle comparisons with `null` or other types correctly*

*You can use the `Object.ReferenceEquals(object a, object b)` method to do reference comparisons*

@[Implement .Equals()]({"stubs": ["User.cs"], "command": "Equality.Tests.EqualityTests.CheckEquals", "project": "equality"})

## Implementing `==` operator

Once `.Equals()` method has been overridden properly, implementing custom logic for the `==` and `!=` operators is a good practice to have consistent equality.

Add an implementation of the `==` and `!=` operator to the class to support the proper comparison.
Make sure that you implement both operators, or the code will not compile.

*Reminder: the operator implementation declaration is `public static bool operator == (User left, User right)`* 

@[Implement equality operators]({"stubs": ["User.cs"], "command": "Equality.Tests.EqualityTests.CheckEqualOperator", "project": "equality"})

## Overriding `GetHashCode()`

The `GetHashCode()` method is used by the .Net Framework to do comparison of objects when working with hash-based collections (i.e. `HashSet<>`).
If you override the implementation of `.Equals()` you should make sure that the `.GetHashCode()` method is also overridden.

Add a custom implementation of `.GetHashCode` to our `User` class.

*Reminder: the method override declaration is `public override int GetHashCode()`* 

@[Override .GetHashCode()]({"stubs": ["User.cs"], "command": "Equality.Tests.EqualityTests.CheckGetHashCode", "project": "equality"})