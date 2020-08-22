using Bloger.DAL;
using Bloger.DAL.Entities;
using Bloger.IBLL;
using System;
using System.Collections;
using System.Collections.Generic;
using Bloger.Models;
using System.Linq;

namespace Bloger.BLL
{
    public class PostService : IPostService
    {
        private readonly UnitOfWork _internalUnitOfWork;

        public PostService(UnitOfWork unitOfWork)
        {
            _internalUnitOfWork = unitOfWork;
        }

        public void AddPosts(PostViewModel post)
        {
            Posts p = new Posts();
            p.Title = post.Title;
            p.Description = post.Description;
            p.Photo = post.Photo;
            p.AspNetUsersId = post.AspNetUsersId;
            _internalUnitOfWork.PostsRespository.Insert(p);
            _internalUnitOfWork.Save();
            // get inserted poost id

            // foreach categoriesw per te marr id e seciles

            //brenda foreach nje instanc e enteys Post_cCat 
            //jep parametra dhe ben save change per 
            var postId = p.ID;
            Post_Category post_Category = new Post_Category();
            post_Category.PostsID = postId;
            var CatId = post.Categories;
            foreach(var c in CatId)
            {
                post_Category.PostsID = postId;
                post_Category.CategoryID = Convert.ToInt32(c);
            }
            _internalUnitOfWork.PostCategoryRespozitory.Insert(post_Category);
            _internalUnitOfWork.Save();
        }

        public List<PostViewModel> GetPosts()
        {
            var post = _internalUnitOfWork.PostsRespository.Get();
            var post_category = _internalUnitOfWork.PostCategoryRespozitory.Get();
            var category = _internalUnitOfWork.CategoryRepository.Get();
            var join_result = from p in post
                              from p_c in post_category
                              from c in category
                              where p.ID == p_c.PostsID
                              where p_c.CategoryID == c.ID
                              select new {p.ID ,p.Title, p.Description, p.Photo, p.AspNetUsersId, p.Coments, p_c.CategoryID , c.TitleC};
            List<PostViewModel> posts = new List<PostViewModel>();
            foreach ( var p in join_result)
            {
                posts.Add(new PostViewModel {ID= p.ID , Title = p.Title ,Description=p.Description ,Photo=p.Photo,AspNetUsersId=p.AspNetUsersId ,CTitle=p.TitleC});
            }
            return posts;
        }
        public void AddPostCategory(Post_CategoryViewModel postCategory)
        {
            Post_Category post_Cat = new Post_Category();
            post_Cat.CategoryID = postCategory.CategoryID;
            post_Cat.PostsID = postCategory.PostsID;
               _internalUnitOfWork.PostCategoryRespozitory.Insert(post_Cat);
               _internalUnitOfWork.Save();
        }

        
        //public void AddCategories(CategoryViewModel category)
        //{
        //    Category c = new Category();
        //    c.Title = category.Title;
        //    _internalUnitOfWork.CategoriesRepository.Insert(c);
        //    _internalUnitOfWork.Save();

        //}

        public List<CategoryViewModel> GetCategories()
        {
            var cat = _internalUnitOfWork.CategoryRepository.Get();
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            foreach (var c in cat)
            {
                categories.Add(new CategoryViewModel { ID = c.ID ,Title = c.TitleC });
            }
            return categories;
        }



        //public List<CategoryViewModel> GetCategories()
        //{
        //    List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
        //    List<category> allCategories = _internalUnitOfWork.CategoriesRepository.Get().ToList();
        //    foreach (var c in allCategories)
        //    {
        //        var parentName = allCategories.Where(s => s.cat_id == c.cat_parent_id).Select(s => s.cat_name).FirstOrDefault();
        //        categoryViewModels.Add(new CategoryViewModel()
        //        {
        //            cat_id = c.cat_id,
        //            cat_name = c.cat_name,
        //            cat_desc = c.cat_desc,
        //            cat_parent_id = c.cat_parent_id,
        //            cat_parent_name = parentName
        //        });
        //    }
        //    return categoryViewModels;
        //}
    }
}
