# Text and Encoding

## Basics

`String` is a type from the `System` namespace that is used for most of text related operations.

The `String` type has some specificities compared to other types:

* It is a reference type
* It is immutable, meaning that you cannot change the value of a `String`
* It behaves like a value type


## Encodings

`Encoding` is used to specify:
* How text is stored in memory
* How text is displayed on screen

The `Encoding` type offers multiple common encodings:
* Default **(avoid using this one)**
* ASCII
* Unicode
* UTF7
* UTF8
* UTF32
 
Text in `String` instances is stored using Unicode 16.
You can include specific Unicode characters in a `String` using the syntax `\u03a0` (here it is the pi character for exemple).

```C# runnable
// { autofold 
using System;
using System.Text;

class Example 
{
    static void Main() 
    {
// }
        string unicodeString = "Maths use \u03a0 (Pi) for calculations";

        // You can convert a string into a byte array
        byte[] asciiBytes = Encoding.ASCII.GetBytes(unicodeString);

        // You can convert a byte array into a char array
        char[] asciiChars = Encoding.ASCII.GetChars(asciiBytes);
        string asciiString = new string(asciiChars);

        // The resulting string is different due to the unsupported character for ASCII encoding
        Console.WriteLine($"Unicode string: {unicodeString}");
        Console.WriteLine($"ASCII string: {asciiString}");
// { autofold   
    }   
}
// }
```

## Building `Strings`

As we saw before, `String` is immutable, which implies that every time you want to modify a `String`, a new instance will be created.
If you have an important number of modifications to do, this can cause a big memory consumption and pressure on the memory.

In order to avoid this scenario, the .Net Framework propose the `StringBuilder`class, which is designed for handling such scenarios.

```C# runnable
// { autofold
using System;
using System.Text;
using System.Collections.Generic;

class Car 
{
    public string Model { get; set; }
    public string Brand { get; set; }
    public int Year { get; set; }
}

class Example 
{

    private static List<Car> GetListOfCars()
    {
        return new List<Car> {
            new Car { Brand = "Audi", Model = "A6", Year = 2001 },
            new Car { Brand = "Citroen", Model = "C4 Picasso", Year = 2015 },
            new Car { Brand = "Peugeot", Model = "5008", Year = 2011 },
        };
    }

    static void Main() 
    {
// }
        var cars = GetListOfCars();

        // You can initialize the StringBuilder with a default string
        var builder = new StringBuilder("brand, model, year");
        builder.AppendLine();

        // StringBuilder will modify the content without creating new String instance
        foreach(var car in cars)
        {
            builder.AppendLine($"{car.Brand}, {car.Model}, {car.Year}");
        }

        // You can replace text already in StringBuilder buffer
        builder.Replace("5008", "3008");

        Console.WriteLine(builder.ToString());
// { autofold
    }
}
// }
```