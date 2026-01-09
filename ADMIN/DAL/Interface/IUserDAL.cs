using QLY_LMS.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN.DAL.Interface
{
    internal interface IUserDAL
    {
        public List<User_table> GetAllUsers();
        public bool CreateUser(User_table model);
        public User_table GetUserById(int id);
        public bool UpdateUser(User_table model);
        public bool DeleteUser(int id);

    }
}
