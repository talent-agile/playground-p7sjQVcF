# Using casting operators

With C#, you can define custom casting implementation between two types. This implementation will be used when casting from one type to the other in your code.

```C# runnable
// { autofold
using System;
// }

// User definition
// { autofold
public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public static implicit operator String(User user)
    {
        return $"{user.FirstName} {user.LastName}";
    }

    public static explicit operator User(string text)
    {
        int spaceIndex = text.IndexOf(" ");
        if(spaceIndex >= 1)
        {
            return new User 
            {
                FirstName = text.Substring(0, spaceIndex),
                LastName = text.Substring(spaceIndex + 1)
            };
        }
        return new User { LastName = text };
    }
}
// }

public class Program 
{
    public static void Main(string[] args)
    {
        var user = new User {
            FirstName = "John",
            LastName = "Doe"
        };

        // implict casting
        string userAsString = user;
        Console.WriteLine($"userAsString: {userAsString}");

        // explicit casting
        var otherUser = (User)userAsString;
        Console.WriteLine("User:");
        Console.WriteLine($"  First name: {otherUser.FirstName}");
        Console.WriteLine($"  Last name: {otherUser.LastName}");
    }
}
```

**Exercise : Implement an implicit and explicit casting**

In the following exercise, you have two classes, `Car` and `Vehicle`.

The goal is to implement an implicit casting of `Car` to `Vehicle`. The casting must respect these guidelines:
* The `Vehicle.Type` property value should be `"Car"`
* The `Vehicle.Name` property should use the car properties to display all car information with the following format : `Brand / Model (Year) / License Plate`

@[Implement implicit casting]({"stubs": ["Car.cs", "Vehicle.cs"], "command": "Casting.Tests.CarTests.CheckCastingOperators", "project": "casting"})

Be careful when implementing custom casting operators. They can be useful is certain situations, but using them is not very intuitive and can be misleading.