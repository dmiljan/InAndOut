﻿using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses; 
            return View(objList);
        }

        //GET-Create
        public IActionResult Create()//prikaz stranice forme za unos
        {
            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)//submit forme 
        {
            if(ModelState.IsValid) 
            {
                _db.Expenses.Add(obj); //Entity framework
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);//i bez prosledjivanja objekta isto radi???ako nisu podaci ispravni onda idi na view opet
        }

        //GET-Delete
        public IActionResult Delete(int? id) //otvori se forma
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)//submit forme 
        {
            var obj = _db.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(obj); 
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET-Update
        public IActionResult Update(int? id) //otvori se forma
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)//submit forme 
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj); 
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);//i bez prosledjivanja objekta isto radi vjerovatno zato sto je validacija na strani klijenta i ne poniste se podaci uopste u formi???ako nisu podaci ispravni onda idi na view opet
        }
    }
}
