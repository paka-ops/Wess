using FlotteApplication.Models;

namespace FlotteApplication.Repositories.Interface
{
    public interface IEngin
    {
        public  Task<Boolean> createEngin(Engin engin);
        public Task<bool> deleteEngin(int EnginId);
        public Engin updateEngin(Engin engin);
        public List<Engin> getAllEngin();
        public Task<Engin> getEngineById(int EnginId);
    }
}
