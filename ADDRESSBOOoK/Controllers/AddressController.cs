using ADDRESSBOOoK.Models;
using ADDRESSBOOoK.RepoAddressBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADDRESSBOOoK.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressBook address;
        public AddressController()
        {
            this.address = new AddressBookRepository(new AddressEntities());
        }
        // GET: Address
        public ActionResult Index()
        {
            var users = address.GetUsers().ToList();
            return View(users);
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            var user = address.GetUserById(id);
            var display = new User();
            display.Id = user.Id;
            display.Name= user.Name;
            display.Surname = user.Surname;
            display.Email = user.Email;
            display.Phone = user.Phone;
            return View(display);
        }

        // GET: Address/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new User());
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, User user)
        {
            try
            {
                var addUser = new User();
                addUser.Name = user.Name;
                addUser.Surname = user.Surname;
                addUser.Email = user.Email;
                addUser.Phone = user.Phone;
                address.InsertUser(addUser);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            var edit = address.GetUserById(id);
            var display = new User();
            display.Id = edit.Id;
            display.Name = edit.Name;
            display.Surname = edit.Surname;
            display.Email = edit.Email;
            display.Phone = edit.Phone;
            return View(display);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(User user, FormCollection collection)
        {
            try
            {
                address.UpdateUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            var delete = address.GetUserById(id);
            return View(delete);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                address.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}