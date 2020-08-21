using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bloger.IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.IO;
using Bloger.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Bloger.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bloger.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postsService;
        private IHostingEnvironment _hosting;
        
       

        public PostsController(IPostService postsService, IHostingEnvironment hosting)
        {
             _postsService = postsService;
             _hosting = hosting;
             SizePage = 2;
        }

        public int maxPage { get; set; }
        public int SizePage { get; set; }
        public int CurrentPageUser { get; set; }
        // GET: Posts
        public ActionResult Index(BadImageFormatException PhotoFile, string SearchName, int? currentPage ,int? category )
        {
            var posts = _postsService.GetPosts();
            if (!String.IsNullOrEmpty(SearchName))
            {
                posts = posts.Where(t => t.Title.Contains(SearchName)).ToList(); 
            }
            //var id = Convert.ToInt32(category);
            //if (id > -1)
            //{
            //    posts = posts.Where(t => t.ID == id);
            //}

            List<SelectListItem> categories = new List<SelectListItem>();
            foreach (var c in posts)
            {
                categories.Add(new SelectListItem(c.CTitle ,c.ID.ToString()));
            }
            
            ViewBag.categories = categories;

            CurrentPageUser = currentPage ?? 1;
            CurrentPageUser = CurrentPageUser < 1 ? 1 : CurrentPageUser;
            ViewBag.SearchN = SearchName;
            ViewBag.maxPage = maxPage;
            ViewBag.CurrentPageUser = CurrentPageUser;
            ViewBag.HasPreviousDisabled = HasPreviousDisabled();
            ViewBag.HasNextDisabled = HasNextDisabled();
            maxPage = MaxPageNumber(posts.Count());
            currentPage = Math.Min(CurrentPageUser, maxPage);
            posts = posts.Skip((CurrentPageUser - 1) * SizePage).Take(SizePage).ToList(); //posts.Skip((CurrentPageUser - 1) * PageSize).Take(PageSize);
            return View(posts.ToList());
        }

        public int MaxPageNumber(int total)
        {
            return (int)Math.Ceiling((decimal)total / SizePage);
        }
        public string HasPreviousDisabled()
        {
            return CurrentPageUser < 2 ? "disabled" : "";
        }

        public string HasNextDisabled()
        {
            return CurrentPageUser >= maxPage ? "disabled" : "";
        }

        // GET: Posts/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Posts/Create
        [Authorize]
        public ActionResult Create()
        {
            var cat = _postsService.GetCategories();
            var selectList = new List<SelectListItem>();
            foreach(var item in cat)
            {
                selectList.Add(new SelectListItem(item.Title, item.ID.ToString()));
            }
            var vm = new PostViewModel()
            {
                Category = selectList
            };

            return View(vm);
        }

        // POST: Posts/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel vm)
        {
            try
            {
                // TODO: Add insert logic here
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                //Save image to Root/image
                string wwwRoot = _hosting.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(vm.ImageFile.FileName);
                string extension = Path.GetExtension(vm.ImageFile.FileName);
                vm.AspNetUsersId = userId;
                vm.Photo = fileName+extension;
                string path = Path.Combine(wwwRoot + "\\images\\", fileName+extension);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    vm.ImageFile.CopyTo(fileStream);
                }

                //File.Move(sourceFile, destFile);

                _postsService.AddPosts(vm);
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Posts/Edit/5
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

        // GET: Posts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Posts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}