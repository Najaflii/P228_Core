using Core.Entities;
using Core.Helpers;
using DataAccess.Impelementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter admin login:");
            string userName = Console.ReadLine();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter admin password:");
            string password = Console.ReadLine();

            var admin = _adminRepositories.Get(a => a.Login.ToLower() == userName.ToLower()
                                             && PasswordHasher.Decrypt(a.Password) == password);
            return admin;
        
        }
    }
}
