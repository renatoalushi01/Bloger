using System.Collections.Generic;
using Bloger.DAL.Entities;
using Bloger.Models;

namespace Bloger.IBLL
{
    public interface IPostService
    {
        //List<PostViewModel> GetCategories();
        void AddPosts(PostViewModel post);
        List<PostViewModel> GetPosts();
        void AddPostCategory(Post_CategoryViewModel postCategory);
        List<CategoryViewModel> GetCategories();
    }
}
