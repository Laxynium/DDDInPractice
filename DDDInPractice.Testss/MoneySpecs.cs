using System;
using DDDInPractice.Logic;
using DDDInPractice.Logic.SharedKernel;
using DDDInPractice.Logic.SnackMachines;
using FluentAssertions;
using NUnit.Framework;

namespace DDDInPractice.Testss
{
    [TestFixture]
    public class MoneySpecs
    {
        [Test]
        public void Sum_of_two_moneys_produces_correct_result()
        {

            Money money1 = new Money(1,2,3,4,5,6);
            Money money2 = new Money(1,2,3,4,5,6);

            Money sum = money1 + money2;

            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCount.Should().Be(6);
            sum.OneDollarCount.Should().Be(8);
            sum.FiveDollarCount.Should().Be(10);
            sum.TwentyDollarCount.Should().Be(12);
        }

        [Test]
        public void Two_money_instances_equal_if_contain_the_same_money_amount()
        {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            money1.Should().Be(money2);
            money1.GetHashCode().Should().Be(money2.GetHashCode());
        }

        [Test]
        public void Two_money_instances_do_not_equal_if_contain_different_money_amounts()
        {
            Money dollar = new Money(0,0,0,1,0,0);
            Money hundredCents = new Money(100, 0,0,0,0,0);

            dollar.Should().NotBe(hundredCents);
            dollar.GetHashCode().Should().NotBe(hundredCents.GetHashCode());
        }

        [TestCase(-1,0,0,0,0,0)]
        [TestCase(0,-2,0,0,0,0)]
        [TestCase(0,0,-3,0,0,0)]
        [TestCase(0,0,0,-4,0,0)]
        [TestCase(0,0,0,0,-5,0)]
        [TestCase(0,0,0,0,0,-6)]
        public void Cannot_create_money_with_negative_value(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDolarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
            Action action = () =>new Money(
                 oneCentCount,
                 tenCentCount,
                 quarterCount,
                 oneDolarCount,
                 fiveDollarCount,
                 twentyDollarCount);

            action.Should().Throw<InvalidOperationException>();
        }

        [TestCase(0,0,0,0,0,0,0)]
        [TestCase(1,0,0,0,0,0,0.01)]
        [TestCase(1,2,0,0,0,0,0.21)]
        [TestCase(1,2,3,0,0,0,0.96)]
        [TestCase(1,2,3,4,0,0,4.96)]
        [TestCase(1,2,3,4,5,0,29.96)]
        [TestCase(1,2,3,4,5,6,149.96)]
        [TestCase(11,0,0,0,0,0,0.11)]
        [TestCase(110,0,0,0,100,0,501.1)]
        public void Amount_is_calculated_correctly(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDolarCount,
            int fiveDollarCount,
            int twentyDollarCount,
            decimal expectedAmount)
        {
            Money money = new Money(
                oneCentCount,
                tenCentCount,
                quarterCount,
                oneDolarCount,
                fiveDollarCount,
                twentyDollarCount);

            money.Amount.Should().Be(expectedAmount);
        }

        [Test]
        public void Substraction_of_two_moneys_produces_correct_result()
        {
            Money money1 = new Money(10,10,10,10,10,10);
            Money money2 = new Money(1,2,3,4,5,6);

            Money result = money1 - money2;

            result.OneCentCount.Should().Be(9);
            result.TenCentCount.Should().Be(8);
            result.QuarterCount.Should().Be(7);
            result.OneDollarCount.Should().Be(6);
            result.FiveDollarCount.Should().Be(5);
            result.TwentyDollarCount.Should().Be(4);
        }

        [Test]
        public void Cannot_substract_more_than_exists()
        {
            Money money1 = new Money(0,1,0,0,0,0);
            Money money2 = new Money(1,0,0,0,0,0);

            Action action = () =>
            {
                Money m = money1 - money2;
            };

            action.Should().Throw<InvalidOperationException>();
        }

        [TestCase(1,0,0,0,0,0, "¢1")]
        [TestCase(0,0,0,1,0,0, "$1.00")]
        [TestCase(1,0,0,1,0,0, "$1.01")]
        [TestCase(0,0,2,1,0,0, "$1.50")]
        public void To_string_should_return_amount_of_money(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDolarCount,
            int fiveDollarCount,
            int twentyDollarCount,   
            string expectedString)
        {
            Money money = new Money(
                oneCentCount,
                tenCentCount,
                quarterCount,
                oneDolarCount,
                fiveDollarCount,
                twentyDollarCount);
            money.ToString().Should().Be(expectedString);
        }
    }
}
