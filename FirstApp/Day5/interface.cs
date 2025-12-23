
// Accessing via interface references (commented out to prevent auto-execution)
// IDisposable resource = new ResourceHandler();
// resource.Dispose();  // Works

// INotifier notifier = new ResourceHandler();
// notifier.Log();     // Works

// ResourceHandler obj = new ResourceHandler();
// obj.Dispose();      // ERROR: not accessible directly
// obj.Log();          // ERROR: not accessible directly

interface ILogger
{
    void Log();
}
interface INotifier
{
    void Log();
}
class FileLogger : ILogger, INotifier
{
    void ILogger.Log()
    {
        Console.WriteLine("Logging to file via ILogger");
    }
    void INotifier.Log()
    {
        Console.WriteLine("Logging to notification via INotifier");
    }
}

// another example 
class ResourceHandler : IDisposable, INotifier
{
    void IDisposable.Dispose()
    {
        Console.WriteLine("Resource disposed");
    }
    void INotifier.Log()
    {
        Console.WriteLine("Notification sent");
    }
}