# Precision & Rounding

Due to the internal representation of `float` and `double` numeric types, arithmetic operations on these types can result in imprecise results, which will be rounded to the nearest _representable_ value.

```C# runnable
// { autofold
using System;

class Example 
{
    static void Main() 
    {
// }
    double a = 0.1;
    double b = 0.01;
    double c = a * a;
    
    // We should have true, as 0,1 * 0,1 = 0,01
    Console.WriteLine($"b == c: {b == c}");
// { autofold
    }
}
// }
```

When using non-integer numeric types in C#, it is important to know the pros and cons of each specific type.
* `float` and `double` types are meant to use when performance is more important than precision.
* `decimal` is instead more accurate than the two others, at the cost of performance. When doing arithmetic operations that require a high precision in results without roundings, make sure you use the `decimal` type (this is even more important when doing calculation about money or finance).

If we use the `decimal` type for the same operation that above, the result is correct.

```C# runnable
// { autofold
using System;

class Example 
{
    static void Main() 
    {
// }
    decimal a = 0.1m;
    decimal b = 0.01m;
    decimal c = a * a;
    
    // We should have true, as 0,1 * 0,1 = 0,01
    Console.WriteLine($"b == c: {b == c}");
// { autofold
    }
}
// }
```

Keep in mind that the rounding precision issue is still after a high number of decimal part digits. If you need to calculate values for financial usage with multiple arithmetic operations, you can consider using `double` type for intermediary arithmetic operations, round the result to an appropriate number of digits and convert it to a `decimal`.

This will give you the best compromise between performance and precision, and it is often precise enough for financial applications.

In the following example, you can see that there is a precision difference between the rate calculated from `double` types and the `decimal` types. However, the difference in the calculation result only appears at the 12<sub>th</sub> decimal digit.

```C# runnable
// { autofold
using System;

class Example 
{
    static void Main() 
    {
// }
    decimal priceBase = 9712.127m;

    double rateBase = 0.124689;
    double currencyRate = 6.830231;
    double quantityRate = 0.7822; 
    
    decimal rateBaseDec = 0.124689m;
    decimal currencyRateDec = 6.830231m;
    decimal quantityRateDec = 0.7822m;

    var rateDouble = (1 + rateBase) * currencyRate * quantityRate;
    var rateDecimal = (1+rateBaseDec) * currencyRateDec * quantityRateDec;

    var resultWithDouble = priceBase * (decimal)rateDouble;    
    var resultWithDecimal = priceBase * rateDecimal;

    Console.WriteLine($"rate (double):\t\t\t {rateDouble}");
    Console.WriteLine($"rate (decimal):\t\t\t {rateDecimal}");

    Console.WriteLine($"result (double):\t\t {resultWithDouble}");
    Console.WriteLine($"result (decimal):\t\t {resultWithDecimal}");

    Console.WriteLine($"rounded result (double):\t {Math.Round(resultWithDouble, 8)}");
    Console.WriteLine($"rounded result (decimal):\t {Math.Round(resultWithDecimal, 8)}");
// { autofold
    }
}
// }
```