using FlotteApplication.Models;

namespace FlotteApplication.Repositories.Interface
{
    public interface IEngin
    {
        public  Task<String> createEngin(Engin engin);
        public Engin deleteEngin(int EnginId);
        public Engin updateEngin(int EnginId);
        public Engin getAllEngin();
        public Task<Engin> getEngineById(int EnginId);
    }
}
