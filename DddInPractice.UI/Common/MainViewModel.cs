
using DddInPractice.UI.Atms;
using DddInPractice.UI.SnackMachines;
using DDDInPractice.Logic.Atms;
using DDDInPractice.Logic.SnackMachines;
using DDDInPractice.Logic.Utils;
using NHibernate;

namespace DddInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            var repository = new AtmRepository();
            var atmMachine = repository.GetById(1);
            var viewModel = new AtmViewModel(atmMachine);
            _dialogService.ShowDialog(viewModel);
        }
    }
}
