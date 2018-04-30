# Regular Expressions - Replacing Text

As we saw before, regular expressions can specify groups in the pattern to capture data from the text.

But these groups can also be used for replacing data in a given text.

*Note: Be careful when doing replacement, as the whole match will be replaced. Make sure you capture text that should be kept in the replacement if it is part of the pattern*

```C# runnable
// { autofold
using System;
using System.Text.RegularExpressions;

class Example 
{
    static void Main()
    {
// }
        // This pattern will match multiple spaces
        var regularExpression = new Regex(@"\s+");
        var textWithManySpaces = "this     is    a   text    with   spaces";
        var correctText = regularExpression.Replace(textWithManySpaces, " ");

        Console.WriteLine($"Text with many spaces: {textWithManySpaces}");
        Console.WriteLine($"Corrected text: {correctText}");
        
        // This pattern will match any french phone number
        //   \b    -> word boundary, match the beginning of a word
        //   0     -> match a 0
        //   \d{9} -> match 9 other digits
        regularExpression = new Regex(@"\b(0)(\d{9})");

        var phoneNumbers = "0161172890 0457823941 0390562351 0780665420 0601598210 0954137542";

        var internationalPhoneNumbers = regularExpression.Replace(phoneNumbers, "+33$2");

        Console.WriteLine($"Phone numbers: {phoneNumbers}");
        Console.WriteLine($"Phone numbers (International): {internationalPhoneNumbers}");
// { autofold 
    }
}
// }
```

Backreferences can be used for replacement using the `$N` syntax, where `N` is the number of the captured group that you want to use for replacement.

If you want to use named capture groups, you need to use the following syntax `${groupname}`.

```C# runnable
// { autofold
using System;
using System.Text.RegularExpressions;

class Example 
{
    static void Main()
    {
// }
        // This pattern will extract user data from a csv text
        var regularExpression = new Regex(@"(?<firstname>\w+),(?<lastname>\w+),(?<level>\w+),(?<birthdate>\d{2}/\d{2}/\d{4}),(?<state>\w+)");

        var userData = 
              "John,Doe,Manager,14/01/1982,Arizona\n"
            + "Jane,Nobody,Analyst,13/12/1986,Colorado\n"
            + "Carole,Unknown,Consultant,01/07/1983,Arkansas\n";

        var correctText = regularExpression.Replace(userData, "${firstname} ${lastname}, living in ${state}, born on ${birthdate}, is a(n) ${level}");

        Console.WriteLine($"Source data: {userData}");
        Console.WriteLine($"Replaced text: {correctText}");
// { autofold 
    }
}
// }
```