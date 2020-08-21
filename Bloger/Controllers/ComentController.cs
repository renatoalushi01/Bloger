using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bloger.IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Bloger.Models;
using System.Diagnostics;

namespace Bloger.Controllers
{
    public class ComentController : Controller
    {
        private readonly IComentsServices _comentsServices;

        public ComentController(IComentsServices comentsServices)
        {
            _comentsServices = comentsServices;
        }


        // GET: Coment
        public ActionResult Index()
        {
            var coments = _comentsServices.GetComents();
            
            return View( coments);
        }

        // GET: Coment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Coment/Create
        public ActionResult Create()
        {
            ComentsViewModel comentsM = new ComentsViewModel();
            
            return View(comentsM);
        }

        // POST: Coment/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComentsViewModel comentsM)
        {
            try
            {
                // TODO: Add insert logic here
                
                comentsM.AspNetUsersId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Debug.WriteLine(comentsM.AspNetUsersId);
                

                _comentsServices.AddComents(comentsM); 

                return RedirectToAction("Index", "Posts");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return View();
            }
        }

        // GET: Coment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Coment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Coment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Coment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _comentsServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}