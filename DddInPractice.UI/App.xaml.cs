using DDDInPractice.Logic.Utils;

namespace DddInPractice.UI
{
    public partial class App
    {
        public App()
        {
            Initer.Init(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DDDInPractice;Integrated Security=True");
        }
    }
}
