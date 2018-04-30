using Linq.Domain;
using Linq.Exercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace Linq
{
    [TestClass]
    public class LinqTests
    {
        private Data _data;

        [TestInitialize]
        public void Initialize()
        {
            _data = DataGenerator.GenerateData();
        }

        [TestMethod]
        public void CheckTotalOrderSum()
        {
            var actual = TotalOrderSum.CalculateTotalOrderSum(_data);
            Check.That(actual).IsEqualTo(349823300M);
        }

        [TestMethod]
        public void CheckNumberOfOrdersInApril2016()
        {
            var actual = NumberOfOrdersInApril2016.CalculateNumberOfOrdersInApril2016(_data);
            Check.That(actual).IsEqualTo(4146);
        }

        [TestMethod]
        public void CheckMonthWithHighestIncome()
        {
            var actual = MonthWithHighestIncome.GetMonthWithHighestIncome(_data);
            Check.That(actual).IsEqualTo(new Date(2015, 7));
        }

        [TestMethod]
        public void CheckMonthesWithLowestIncome()
        {
            var actual = MonthesWithLowestIncome.GetThreeMonthesWithLowestIncome(_data);
            Check.That(actual).CountIs(3);
            Check.That(actual).ContainsExactly(
                new Date(2016, 6), 
                new Date(2016, 2),
                new Date(2016, 3));
        }

        [TestMethod]
        public void CheckMostSoldProduct()
        {
            var actual = MostSoldProduct.GetMostSoldProduct(_data);
            Check.That(actual.Name).IsEqualTo("Surface Book");
        }

        [TestMethod]
        public void CheckAccountWithMostIncome()
        {
            var actual = AccountWithMostIncome.GetAccountWithMostIncome(_data);
            Check.That(actual.Id).IsEqualTo(428);
            Check.That(actual.Region).IsEqualTo("FR");
        }

        [TestMethod]
        public void CheckRegionWithMostIncome()
        {
            var actual = RegionWithMostIncome.GetRegionWithMostIncome(_data);
            Check.That(actual).IsEqualTo("FR");
        }

        [TestMethod]
        public void CheckNumberOfClientInAugust2015FromFrRegion()
        {
            var actual = NumberOfClientInAugust2015FromFrRegion.GetNumberOfClientInAugust2015FromFrRegion(_data);
            Check.That(actual).IsEqualTo(92);
        }

        [TestMethod]
        public void CheckNumberOfOrdersWithPhoneAndTablet()
        {
            var actual = NumberOfOrdersWithPhoneAndTablet.GetNumberOfOrdersWithPhoneAndTablet(_data);
            Check.That(actual).IsEqualTo(27439);
        }

        [TestMethod]
        public void CheckBestProductSoldWithIPhone7()
        {
            var actual = BestProductSoldWithIPhone7.GetBestProductSoldWithIPhone7(_data);
            Check.That(actual.Name).IsEqualTo("Galaxy s8+");
        }
    }
}
