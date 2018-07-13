using System.Linq;
using DDDInPractice.Logic;
using DDDInPractice.Logic.SharedKernel;
using DDDInPractice.Logic.SnackMachines;
using DDDInPractice.Logic.Utils;
using NHibernate;
using NUnit.Framework;

namespace DDDInPractice.Testss
{
    [TestFixture]
    public class TemporaryTests
    {
        [Test]
        public void Test()
        {
            SessionFactory.Init(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DDDInPractice;Integrated Security=True");

            var repository = new SnackMachineRepository();
            SnackMachine snackMachine = repository.GetById(1);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.BuySnack(1);
            repository.Save(snackMachine);
        }
    }
}