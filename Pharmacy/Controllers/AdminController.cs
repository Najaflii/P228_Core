using Core.Entities;
using Core.Helpers;

namespace Pharmacy.Controllers
{
    public class AdminController
    {
        private AdminRepository _adminRepositories;
        public AdminController()
        {
            _adminRepositories = new AdminRepository();
        }

        public Admin Authenticate()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter admin login");
            string userName = Console.ReadLine();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter admin password");
            string password = Console.ReadLine();

            var admin = _adminRepositories.Get(a => a.Login.ToLower() == userName.ToLower()
                                   && PasswordHasher.Decrypt(a.Password) == password);
            return admin;
        }
    }
}
