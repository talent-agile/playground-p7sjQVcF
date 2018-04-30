# Regular Expressions

Regular expressions are a power tool to work with text. They use patterns to apply different operations on text.

With regular expressions, you can:
* Parse text to find specific character patterns
* Edit, replace or delete substrings of a text
* Extract text matching specific character patterns

## Pattern definition

The basic pattern syntax will match any character.

```C# runnable
// { autofold
using System;
using System.Text.RegularExpressions;

class Example 
{
    static void Main()
    {
// }
        // This pattern will match any string containing a 'ab' substring
        var regularExpression = new Regex("ab");

        Console.WriteLine($"IsMatch 'abc': {regularExpression.IsMatch("abc")}");
        Console.WriteLine($"IsMatch 'aze': {regularExpression.IsMatch("aze")}");
        Console.WriteLine($"IsMatch 'bab': {regularExpression.IsMatch("bab")}");
// { autofold 
    }
}
// }
```

You can define a class  of multiple characters using `[` and `]`. `[aeiou]` will match one character that can be any vowel.
You can use the `-` to include a range of consecutive characters in 

```C# runnable
// { autofold
using System;
using System.Text.RegularExpressions;

class Example 
{
    static void Main()
    {
// }
        var regularExpression = new Regex("b[aeiou]c");

        Console.WriteLine($"IsMatch 'bac': {regularExpression.IsMatch("bac")}");
        Console.WriteLine($"IsMatch 'bbc': {regularExpression.IsMatch("bbc")}");
        Console.WriteLine($"IsMatch 'bec': {regularExpression.IsMatch("bec")}");
// { autofold 
    }
}
// }
```

Note that by default, regular expressions are case-sensitive. 
The .Net `Regex` class can accept an option when creating a new `Regex` to specify that the case should be ignored, however, it is better to specify in the pattern that all cases can be accepted.

Here are the most common characters attribute for simple regular expression patterns.

| Pattern | Matching characters |
|---------|---------------------|
| `t` | Single character `t` |
| `[aei]` | A single character of: `a`, `e` or `i` |
| `[a-z]` | A single character in the range from `a` to `z` |
| `[^a-z]` | A single character not in the range from `a` to `z` |
| `\d` | A decimal character (digit), equivalent to `[0-9]` |
| `\w` | A word character, equivalent to `[a-ZA-Z_0-9]` |

For any character, you can use quantifiers to specify how many repetitions of the character should be matched. 

| Quantifier | Definition |
|---------|---------------------|
| `*` | Will match zero or more repetitions |
| `?` | Will match zero or one repetition |
| `+` | Will match one or more repetition |
| `{N}` | Will match exactly `N` repetitions |
| `{N,}` | Will match at least `N` repetitions |
| `{M,N}` | Will match between `M` and `N` repetitions |

```C# runnable
// { autofold
using System;
using System.Text.RegularExpressions;

class Example 
{
    static void Main()
    {
// }
        // Pattern definition
        //   b?     -> 0 or 1 appearance of 'b'
        //   a{2,5} -> between 2 and 5 appearance of 'a'
        //   .*     -> 0 or more appearance of any character
        var regularExpression = new Regex("b?a{2,5}.*");

        Console.WriteLine($"IsMatch 'baaac': {regularExpression.IsMatch("baaac")}");
        Console.WriteLine($"IsMatch 'abc': {regularExpression.IsMatch("abc")}");
        Console.WriteLine($"IsMatch 'aaaaart': {regularExpression.IsMatch("aaaaart")}");
        Console.WriteLine($"IsMatch 'bbbaaaaaty': {regularExpression.IsMatch("bbbaaaaaty")}");
// { autofold 
    }
}
// }
```

You can define anchors to match the beginning or the end of the text or a word.

| Anchor | Definition |
|---------|---------------------|
| `^` | Will match the beginning of the text |
| `$` | Will match the end of the text |
| `\b` | Will match the boundary of a word (beginning or end) |

```C# runnable
// { autofold
using System;
using System.Text.RegularExpressions;

class Example 
{
    static void Main()
    {
// }
        // This pattern will match all text that starts with 'he'
        var regularExpression = new Regex("^he");

        Console.WriteLine($"IsMatch 'hello': {regularExpression.IsMatch("hello")}");
        Console.WriteLine($"IsMatch 'chemical': {regularExpression.IsMatch("chemical")}");
        Console.WriteLine($"IsMatch 'he left': {regularExpression.IsMatch("he left")}");
// { autofold 
    }
}
// }
```