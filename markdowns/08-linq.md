# Linq Exercises

In the following exercises, you will use a set of data that contains lists of customer accounts, products and orders.

Here is a diagram of the data:

![Exercise Data](https://raw.githubusercontent.com/talent-agile/playground-p7sjQVcF/master/images/linq-data-schema.png "Exercise Data Diagram")

Each exercise requires you to implement a specific method. Each method will have a copy of ``Data`` as a parameter.
You must implement the solution using Linq queries and validate your result by executing the test with the "Run" button.

In order to solve the different exercises, you can refer to the following resources:

* [Linq standard query operators](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/standard-query-operators-overview)
* [Linq samples](http://linqsamples.com/linq-to-objects)

## Total Order Price

__Objective__: Calculate the total profit from all orders.

__Tips__

* You can find the price of each ``Order`` using the ``Order.Price`` property
* You can use the ``.Sum()`` extension method to compute the sum for a collection

@[Calculate the sum of all order prices]({"stubs": ["Exercises/TotalOrderSum.cs"],"command": "Linq.LinqTests.CheckTotalOrderSum"})

## Number of orders in April 2016

__Objective__: Find the number of orders made in April 2016.

__Tips__

* You can filter elements of a collection using the ``where`` keyword or the ``.Where(predicate)`` extension method
* You can retrieve the number of elements in a collection with the ``.Count()`` extension method
* The ``Order.Date`` property of an ``Order`` contains the year and month of the order

@[Numbers of orders in April 2016]({"stubs": ["Exercises/NumberOfOrdersInApril2016.cs"], "command": "Linq.LinqTests.CheckNumberOfOrdersInApril2016"})

## Month with highest income

__Objective__: Find the month with the highest income.

### Tips

* You can group ``Order`` objects with the ``group by`` keywords, or the ``GroupBy()`` extension method
* 

@[Month with highest income]({"stubs": ["Exercises/MonthWithHighestIncome.cs"], "command": "Linq.LinqTests.CheckMonthWithHighestIncome"})

## Three monthes with lowest income

__Objective__: Find the three monthes with the lowest income, ordered from lowest to highest

@[Monthes with lowest income]({"stubs": ["Exercises/MonthesWithLowestIncome.cs"], "command": "Linq.LinqTests.CheckMonthesWithLowestIncome"})

## Most sold product

__Objective__: Find the most sold product

@[Most sold product]({"stubs": ["Exercises/MostSoldProduct.cs"], "command": "Linq.LinqTests.CheckMostSoldProduct"})

## Account with most income

__Objective__: Find the account having generated the most income

@[Account with highest generated income]({"stubs": ["Exercises/AccountWithMostIncome.cs"], "command": "Linq.LinqTests.CheckAccountWithMostIncome"})

## Region with most income

__Objective__: Find the region having generated the most income

@[Region with highest generated income]({"stubs": ["Exercises/RegionWithMostIncome.cs"], "command": "Linq.LinqTests.CheckRegionWithMostIncome"})

## Number of client in August 2015 from FR region

__Objective__: Find the number of clients having ordered in August 2015, from FR region

@[Number of client in August 2015 from FR region]({"stubs": ["Exercises/NumberOfClientInAugust2015FromRegionFR.cs"], "command": "Linq.LinqTests.CheckNumberOfClientInAugust2015FromFrRegion"})

## Number of orders with a phone and a tablet

__Objective__: Find the number of orders having a phone and a tablet

@[Number of orders with a phone and a tablet]({"stubs": ["Exercises/NumberOfOrdersWithPhoneAndTablet.cs"], "command": "Linq.LinqTests.CheckNumberOfOrdersWithPhoneAndTablet"})

## Best product sold with an iPhone 7

__Objective__: Find the best product sold with an iPhone 7

@[Best product sold with an iPhone 7]({"stubs": ["Exercises/BestProductSoldWithIPhone7.cs"], "command": "Linq.LinqTests.CheckBestProductSoldWithIPhone7"})