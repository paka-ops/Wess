using FlotteApplication.Models;

namespace FlotteApplication.Repositories.Interface
{
    public interface IAdmin
    {
        public Task<String> addAdmin(Admin admin);
        public Boolean LoginAdmin(Admin admin);

    }
}
