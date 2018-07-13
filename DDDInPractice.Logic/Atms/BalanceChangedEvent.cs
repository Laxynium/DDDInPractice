using DDDInPractice.Logic.SharedKernel;

namespace DDDInPractice.Logic.Atms
{
    public class BalanceChangedEvent:IDomainEvent
    {
        public decimal Delta { get; }

        public BalanceChangedEvent(decimal delta)
        {
            Delta = delta;
        }
    }
}