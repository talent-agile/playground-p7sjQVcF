# Exception Handling - Mini-Project

This mini project will help you understand how to handle exceptions from real code.

## Logging exceptions

The basic need is the simple one.

Change the code to make sure that all exceptions are logged, then rethrown to the calling code.

@[Catching a generic exception]({"stubs": ["UserReport.cs", "ILog.cs"], "command": "Exceptions.Tests.UserReportTests.CheckThatExceptionsAreLogged", "project": "exceptions"})

## Handling file I/O exceptions

As the code is writing to a file for the export, it may fail if the user running the code has insufficient rights.

We need to handle this case by adding two rules:

* Catch exceptions of type `UnauthorizedAccessException`
* Log these exceptions
* Make sure the method will not throw an exception, but should return `false` to indicate that the export was not done

@[Handling exceptions]({"stubs": ["UserReport.cs", "ILog.cs"], "command": "Exceptions.Tests.UserReportTests.CheckThatUnauthorizedAccessExceptionsAreHandled", "project": "exceptions"})

## Wrap other exceptions

If a `NullReferenceException` is raised, mainly for technical issues, we will catch it and wrap it in an `InvalidOperationException` with a proper exception message indicating that the export was not done.

Implement these new rules:

* Catch exceptions of type `NullReferenceException`
* Log the exception
* Make the method throw a new exception of type `InvalidOperationException`
  * The new exception must have a message "Could not create the report, check logs for more details"
  * The new exception must have a reference to the caught one

@[Wrapping in a new exception]({"stubs": ["UserReport.cs", "ILog.cs"], "command": "Exceptions.Tests.UserReportTests.CheckReturnsNewException", "project": "exceptions"})

## All combined

Before pushing our code to production, make sure that all three cases are handled correctly at the same time.

@[Wrapping in a new exception]({"stubs": ["UserReport.cs", "ILog.cs"], "command": "Exceptions.Tests.UserReportTests.CheckAllTogether", "project": "exceptions"})