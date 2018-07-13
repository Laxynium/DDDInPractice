using DDDInPractice.Logic.SharedKernel;
using static DDDInPractice.Logic.SharedKernel.Money;

namespace DDDInPractice.Logic.Management
{
    public class HeadOffice:AggregateRoot
    {
        public virtual decimal Balance { get; protected set; }
        public virtual Money Cash { get; protected set; } = None;

        public virtual void ChangeBalance(decimal delta)
        {
            Balance += delta;
        }
    }
}