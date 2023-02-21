using NavigationExample11B1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavigationExample11B1.Controller
{
    internal class LoginController
    {
        //Create
        internal void AddUser(User user)
        {
            using (NavigationDBEntities db = new NavigationDBEntities())
            {
                var lastUser = db.User.ToList().LastOrDefault();
                if(lastUser == null)
                {
                    user.Id = 1;
                }
                else
                {
                    user.Id = lastUser.Id + 1;
                }
                
                db.User.Add(user);
                db.SaveChanges();
            }
        }

        //Read
        internal List<User> GetAll()
        {
            using (NavigationDBEntities db = new NavigationDBEntities())
            {
                return db.User.ToList();
            }
        }

        //Update
        public void UpdateUser(int id, User user)
        {
            using (NavigationDBEntities db = new NavigationDBEntities())
            {
                var userToUpdate = db.User.Where(u => u.Id == id).FirstOrDefault();
                if (userToUpdate != null)
                {
                    userToUpdate.Id = id;
                    userToUpdate.Username = user.Username;
                    userToUpdate.Password = user.Password;
                    db.SaveChanges();
                }
            }
        }

        //Delete
        public void DeleteUser(int id)
        {
            using (NavigationDBEntities db = new NavigationDBEntities())
            {
                var userToDelete = db.User.Where(u => u.Id == id).FirstOrDefault();
                if (userToDelete != null)
                {
                    db.User.Remove(userToDelete);
                    db.SaveChanges();
                }
            }
        }
    }
}
