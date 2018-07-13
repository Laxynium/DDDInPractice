using System;
using DDDInPractice.Logic;
using DDDInPractice.Logic.SnackMachines;
using FluentAssertions;
using NUnit.Framework;

namespace DDDInPractice.Testss
{
    [TestFixture]
    public class SnackPileSpecTests
    {
        [Test]
        public void Cannot_create_snackpile_with_negative_price()
        {
            Action action = () => { var snack =new SnackPile(Snack.Chocolate, 0, -1m); };

            action.Should().Throw<InvalidOperationException>();   
        }

        [Test]
        public void Cannot_create_snackpile_with_negative_quantity()
        {
            Action action = () => { var snack = new SnackPile(Snack.Chocolate, -1, 1m); };

            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Cannot_create_snackpile_with_price_having_more_than_2_decimal_digit()
        {
            Action action = () => { var snack = new SnackPile(Snack.Chocolate, 1, 1.234m); };

            action.Should().Throw<InvalidOperationException>();
        }

    }
}