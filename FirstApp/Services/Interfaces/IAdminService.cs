using FirstApp.Models;

namespace FirstApp.Services.Interfaces
{
    public interface IAdminService
    {
        Admin Get(string id);
        Admin GetByUsername(string username);
        Admin Create(Admin admin);
        Admin Signin(Admin user);
    }
}
