namespace RefactoringSingletonDemo
{
    public class Singleton<T> where T : new()
    {
        private static object lockObject = new object();
        protected static T instance;

        public static T GetInstance()
        {
            lock (lockObject)
            {
                if (instance == null )
                {
                    instance = new T();
                }
                return instance;
            }
        }
    }
}