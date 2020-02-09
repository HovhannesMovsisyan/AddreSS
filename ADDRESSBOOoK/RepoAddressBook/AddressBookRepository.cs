using ADDRESSBOOoK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADDRESSBOOoK.RepoAddressBook
{
    public class AddressBookRepository:IAddressBook
    {
        private readonly AddressEntities addressEntities;

        public AddressBookRepository(AddressEntities addressEntities)
        {
            this.addressEntities = addressEntities;
        }
        public IEnumerable<User> GetUsers()
        {
            return addressEntities.Users.ToList();
        }

        public void Delete(int userId)
        {
            var deletedItem = addressEntities.Users.Find(userId);
            addressEntities.Users.Remove(deletedItem);
            addressEntities.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return addressEntities.Users.Find(id);
        }

        public void InsertUser(User user)
        {
            addressEntities.Users.Add(user);
            addressEntities.SaveChanges();
        }
        
        public void UpdateUser(User user)
        {
            addressEntities.Entry(user).State = System.Data.Entity.EntityState.Modified;
            addressEntities.SaveChanges();
        }

       
    }
}