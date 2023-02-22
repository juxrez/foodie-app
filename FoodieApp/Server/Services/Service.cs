namespace FoodieApp.Server.Services
{
    public class Service : IService
    {
        private readonly IDependency _dependency;

        public Service(IDependency dependency)
        {
            _dependency = dependency;
        }
        public string GetNumberOfRetries(bool shouldSuccess)
        {
            int retries = _dependency.NumberOfRetries();
            return shouldSuccess ? $"Hello there are {retries} and counting" : throw new Exception("Something went wrong");
        }
    }
}

    public interface IService
    {
        string GetNumberOfRetries(bool shouldSuccess);
    }

public class Dependency : IDependency
{
    public Dependency()
    {
            
    }
    public int NumberOfRetries() => 3;
}

public interface IDependency
{
    int NumberOfRetries();
}

