using System;
using DDDInPractice.Logic.SharedKernel;

namespace DDDInPractice.Logic.SnackMachines
{
    public sealed class SnackPile:ValueObject<SnackPile>
    {

        public static readonly  SnackPile Empty = new SnackPile(Snack.None,0,0m);

        public Snack Snack { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        private SnackPile()
        {
        }

        public SnackPile(Snack snack, int quantity, decimal price)
        {
            if(quantity<0)
                throw new InvalidOperationException();
            if(price<0)
                throw  new InvalidOperationException();
            if (price % 0.01m > 0)
                throw new InvalidOperationException();

            Snack = snack;
            Quantity = quantity;
            Price = price;
        }

        protected override bool EqualsCore(SnackPile other)
        {
            return Quantity == other.Quantity
                   && Price == other.Price
                   && Snack == other.Snack;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Snack.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity;
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                return hashCode;
            }
        }

        public SnackPile SubtractOne()
        {
            return new SnackPile(Snack,Quantity-1,Price);
        }
    }
}