using System;
using System.Collections.Generic;
using System.Text;

namespace SF.EFPractices_25_7
{
    public class UserRepository
    {
        public static void AddUser(string nm, string eml)
        {
            using (var db = new AppContext())
            {
                
                var user4 = new User { Name = nm, Email = eml };

                db.Users.Add(user4);

                db.SaveChanges();

            }
        }
    }
}
