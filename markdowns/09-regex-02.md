# Regular Expressions - Groups

When building a regular expression pattern, you can specify groups that will match one value between multiple possible values. This is done using the parenthesis : `(banana|ananas|apple)`.

This example will match any text containing `banana`, `ananas` or `apple`.

```C# runnable
// { autofold
using System;
using System.Text.RegularExpressions;

class Example 
{
    static void Main()
    {
// }
        // This pattern will match any string containing banana, ananas or apple
        var regularExpression = new Regex("(banana|ananas|apple)");

        Console.WriteLine($"IsMatch 'I love fruits, my favorite is ananas': {regularExpression.IsMatch("I love fruits, my favorite is ananas")}");
        Console.WriteLine($"IsMatch 'I ate an apple this morning': {regularExpression.IsMatch("I ate an apple this morning")}");
        Console.WriteLine($"IsMatch 'My favorite ice cream flavor is strawberry': {regularExpression.IsMatch("My favorite ice cream flavor is strawberry")}");
// { autofold 
    }
}
// }
```

Groups are very handy when working with a regular expression where you need to specify multiple options for a specific work.

## Quantifiers

As with individual characters, groups can use quantifiers to specify the number of occurence of the group.

```C# runnable
// { autofold
using System;
using System.Text.RegularExpressions;

class Example 
{
    static void Main()
    {
// }
        // This pattern will match any string that contains 3 occurence of either abc, def or ghi
        var regularExpression = new Regex("(abc|def|ghi){3}");

        Console.WriteLine($"IsMatch 'abcabcabc': {regularExpression.IsMatch("abcabcabc")}");
        Console.WriteLine($"IsMatch 'abcdefghi': {regularExpression.IsMatch("abcdefghi")}");
        Console.WriteLine($"IsMatch 'abcghi': {regularExpression.IsMatch("abcghi")}");
// { autofold 
    }
}
// }
```

## Capture & Backreference

When using groups in the pattern, by default, the regular expression will capture the value corresponding to that group. This is often used when using regular expressions to extract a specific substring from a larger text.

In .Net, the value captured can be retrieved using the `Groups` property of a `Match` from a regular expression.

*Note: the first element in the `Groups` enumeration is the whole match, captured groups start at the 1 index*

```C# runnable
// { autofold
using System;
using System.Text.RegularExpressions;

class Example 
{
    static void Main()
    {
// }
        // Capture the user name using a regular expression
        var regularExpression = new Regex(@"user_name: (\w+)");
        var match = regularExpression.Match("user_name: John_Doe");

        Console.WriteLine($"Captured value: {match.Groups[0].Value}");
// { autofold 
    }
}
// }
```

Values captured from a group can also be used as backreference in the pattern, allowing to ensure that the first captured value is the same in another part of the regular expression.

The backreference is done with the `\N` syntax, where `N` is the number of the referenced group in the pattern.

**Example:** `user_id: (\d+) - validating email for user \1`

This will match text when the first `user_id` is the same than the one at the end of the text.

```C# runnable
// { autofold
using System;
using System.Text.RegularExpressions;

class Example 
{
    static void Main()
    {
// }
        // Match when a user is validating its own email
        var regularExpression = new Regex(@"user_id: (\d+) - validating email for user \1");

        Console.WriteLine($"IsMatch 'user_id: 1284011 - validating email for user 1284011': {regularExpression.IsMatch("user_id: 1284011 - validating email for user 1284011")}");
        Console.WriteLine($"IsMatch 'user_id: 1284011 - validating email for user 1035234': {regularExpression.IsMatch("user_id: 1284011 - validating email for user 1035234")}");
// { autofold 
    }
}
// }
```

## Naming groups

Groups can be given a name with a specific syntax in the pattern. 

`user_name: (?<username>\w+)`

Here, the capturing group is named `username`. This name can be used for backreferences using the `\k<username>` syntax, and can be used when retrieving groups on a `Match` object in .Net.

```C# runnable
// { autofold
using System;
using System.Text.RegularExpressions;

class Example 
{
    static void Main()
    {
// }
        // Capture the user name using a regular expression
        var regularExpression = new Regex(@"user_name: (?<username>\w+)");
        var match = regularExpression.Match("user_name: John_Doe");

        Console.WriteLine($"Captured value: {match.Groups[\"username\"].Value}");
// { autofold 
    }
}
// }
```