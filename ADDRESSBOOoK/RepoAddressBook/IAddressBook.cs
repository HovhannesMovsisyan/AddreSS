using ADDRESSBOOoK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDRESSBOOoK.RepoAddressBook
{
    interface IAddressBook
    {
        /// <summary>
        /// Inserts or Create new User
        /// </summary>
        /// <param name="user"></param>
        void InsertUser(User user);
        /// <summary>
        /// Gets from DataBase Users List 
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetUsers();
        /// <summary>
        /// Update Users 
        /// </summary>
        /// <param name="user">Updates Users</param>
        void UpdateUser(User user);
        /// <summary>
        /// Removes Users
        /// </summary>
        /// <param name="userId"></param>
        void Delete(int userId);
        /// <summary>
        /// Gets Users from DataBase by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserById(int id);
    }
}
