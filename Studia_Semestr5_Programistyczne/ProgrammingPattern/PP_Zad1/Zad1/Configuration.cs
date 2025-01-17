namespace Zad1;

public class Configuration
{
    private static Configuration _instance = null;
    private static object obj = new object();
    public string StringProperty { get; set; }
    public int IntProperty { get; set; }

    private Configuration()
    {
    }

    //Lazy<T>
    public static Configuration GetInstance()
    {
        if (_instance == null)
        {
            lock (obj)
            {
                if (_instance == null)
                {
                    _instance = new Configuration();
                }
            }
        }
        return _instance;
    }
}