﻿using Core.Entities;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public static class DbContext
    {
        static DbContext()
        {
            Admins = new List<Admin>();
            string password1 = "12345678";
            var hashedPassword1 = PasswordHasher.Encrypt(password1);
            Admin admin1 = new Admin("admin1", hashedPassword1);
            Admins.Add(admin1);

            string password2 = "87654321";
            var hashedPassword2 = PasswordHasher.Encrypt(password2);
            Admin admin2 = new Admin("admin2", hashedPassword2);
            Admins.Add(admin2);
        }

        public static List<Admin> Admins { get; set; }
        public static List<Owner> Owners { get; set; }
        public static List<Drug> Drugs { get; set; }
        public static List<Druggist> Druggists { get; set; }
        public static List<DrugStore> DrugStores { get; set; }


    }
}