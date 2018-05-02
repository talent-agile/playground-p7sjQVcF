# Formatting & Parsing

When working with numeric values, you may want to display the value to the user, or retrieve a numeric value from an input string.

The .Net framework offers methods to format a numeric value to a displayable string, and parse a numeric value from a string.

## Formatting a numeric value

You can specify the format to use when using a numeric value in a string using the following syntax : `{value|format}`.

```C# runnable
// { autofold
using System;
using System.Globalization;

class Example 
{
    static void Main() 
    {
// }
        // Most formats are culture dependant, so make sure to use the proper CultureInfo
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

        Console.WriteLine($"Currency: {123.45:C}");
        Console.WriteLine($"Decimal: {123456:D8}");
        Console.WriteLine($"Exponential: {123.4567890123:E}");
        Console.WriteLine($"Fixed point: {123.4567:F3}");
        Console.WriteLine($"General: {-123.456:G}");
        Console.WriteLine($"Number: {-1234.5678:N}");
        Console.WriteLine($"Percent: {0.1437:P}");
        Console.WriteLine($"Hexadecimal: {6321:X}");
// { autofold
    }
}
// }
```

You can also specify your own custom formatting rules using format specifiers.

| Specifier | Description |
|-----------|-------------|
| `0` | Replaces the zero with the corresponding digit if one is present, otherwise zero appears in the formatted string |
| `#` | Replaces the `#` with the corresponding digit if one is present, otherwise, no digit appears in the formatted string |
| `.` | Determines the location of the decimal separator in the resulting string |
| `,` | Serves as both a group separator and a number scaling specifier. As a group separator, it inserts a localized group separator character between each group. As a number scaling specifier, it divides a number by 1000 for each comma specified |
| `%` | Multiplies a number by 100 and inserts a localized percentage symbol in the result string |
| `‰` | Multiplies a number by 1000 and inserts a localized per mille symbol in the result string |
| `E0`, `E+0`, `E-0` | If followed by at least one 0 (zero), formats the result using exponential notation. The case of "E" or "e" indicates the case of the exponent symbol in the result string. The number of zeros following the "E" or "e" character determines the minimum number of digits in the exponent. A plus sign (+) indicates that a sign character always precedes the exponent. A minus sign (-) indicates that a sign character precedes only negative exponents |

You can see some examples of custom formatting below.

```C# runnable
// { autofold
using System;
using System.Globalization;

class Example 
{
    static void Main() 
    {
// }
        // Most formats are culture dependant, so make sure to use the proper CultureInfo
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

        Console.WriteLine($"Currency: {123.45:0000.00}");
        Console.WriteLine($"Decimal: {123456:##,##0.##}");
        Console.WriteLine($"Exponential: {123.4567890123:0.0##E+00}");
        Console.WriteLine($"Percent: {0.1437:##.0 %}");
// { autofold
    }
}
// }
```

## Parsing a numeric value

As for formatting numeric values, parsing numeric values from an input text is a culture-dependant operation.

Every numeric data type offers the `Parse` and `TryParse` methods, that can be used to retrieve a numeric value from an input string.

Depending on the scenario, you may need to specify the culture used in the input string.

When using the `Parse` method, if the input string cannot be parsed, an exception will be raised. Depending on the issue, it can be:
* A `FormatException` if the input string does not match the current culture format of the desired type
* A `OverflowException` if the value is too large or too small to match the desired type

```C# runnable
// { autofold
using System;
using System.Globalization;

class Example 
{
    static void Main() 
    {
// }
        // Most formats are culture dependant, so make sure to use the proper CultureInfo
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

        if(double.TryParse("12.345", out var parsedDouble))
        {
            Console.WriteLine($"double: {parsedDouble}");
        }

        if(int.TryParse("-12345", out var parsedInt))
        {
            Console.WriteLine($"int: {parsedInt}");
        }
        
        if(decimal.TryParse("-12345.6789", out var parsedDecimal))
        {
            Console.WriteLine($"decimal: {parsedDecimal}");
        }
        
        if(!ulong.TryParse("-123", out var _))
        {
            Console.WriteLine("Invalid ulong string");
        }
        
        try 
        {
            byte.Parse("123.456");
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }

        try 
        {
            byte.Parse("123456");
        }
        catch (OverflowException oex)
        {
            Console.WriteLine(oex.Message);
        }
// { autofold
    }
}
// }
```