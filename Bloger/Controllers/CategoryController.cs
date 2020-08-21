﻿//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Bloger.DAL.Entities;
//using Bloger.IBLL;
//using Bloger.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Bloger.Controllers
//{
//    public class CategoryController : Controller
//    {
//        private readonly IPostService _categoriesService;

//        public CategoryController(IPostService categoriesService)
//        {
//            _categoriesService = categoriesService;
//        }

//        // GET: Category
//        public ActionResult Index()
//        {
//      var categories = _categoriesService.GetCategories();
//            return View(categories);
//        }

//        // GET: Category/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: Category/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Category/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(CategoryViewModel collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here

//                _categoriesService.AddCategories(collection);
//                return RedirectToAction(nameof(Index));
//            }
//            catch(Exception e)
//            {
//                Debug.WriteLine(e);
//                return View();
//            }
//        }

//        // GET: Category/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: Category/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Category/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Category/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}