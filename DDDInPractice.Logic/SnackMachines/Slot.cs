using DDDInPractice.Logic.SharedKernel;

namespace DDDInPractice.Logic.SnackMachines
{
    public class Slot:Entity
    {
        public virtual SnackPile SnackPile { get; set; }
       
        public virtual SnackMachine SnackMachine { get; protected set; }

        public virtual int Position { get;  set; }

        protected  Slot()
        {
        }

        public Slot(SnackMachine snackMachine, int position)
        {
            SnackMachine = snackMachine;
            Position = position;
            SnackPile = SnackPile.Empty;
        }
    }
}