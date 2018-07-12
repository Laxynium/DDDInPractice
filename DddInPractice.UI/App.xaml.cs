using DDDInPractice.Logic;

namespace DddInPractice.UI
{
    public partial class App
    {
        public App()
        {
            Inniter.Init(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DDDInPractice;Integrated Security=True");
        }
    }
}
