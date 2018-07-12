namespace DDDInPractice.Logic
{
    public static class Inniter
    {
        public static void Init(string connectionString)
        {
            SessionFactory.Init(connectionString);
        }
    }
}