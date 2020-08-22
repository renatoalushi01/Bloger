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
    public class ComentsServices : IComentsServices
    {
        private readonly UnitOfWork _internalUnitOfWork;


        public ComentsServices(UnitOfWork unitOfWork)
        {
            _internalUnitOfWork = unitOfWork;
        }

        public void AddComents(ComentsViewModel coments)
        {
            Coments c = new Coments();
            c.Description = coments.Description;
            c.PostsID = coments.PostsID;
            c.AspNetUsersId = coments.AspNetUsersId;
            _internalUnitOfWork.ComentsRespository.Insert(c);
            _internalUnitOfWork.Save();
        }

        public List<ComentsViewModel> GetComents(int id)
        {
            var coment = _internalUnitOfWork.ComentsRespository.Get(s=>s.Posts.ID == id);
            
            var user = _internalUnitOfWork.UserRepository.Get();
            var user_coment = from com in coment
                              join u in user on com.AspNetUsersId equals u.Id
                              select new { desc = com.Description,username = u.Email};
            List<ComentsViewModel> coments = new List<ComentsViewModel>();
            foreach(var c in user_coment.ToList())
            {
                coments.Add(new ComentsViewModel { Description = c.desc, UserName = c.username, PostsID = id });
            }
            return coments;
        }

        public void Delete( int? id)
        {
            Coments coments = new Coments();
            if (id == coments.ID)
            {
                _internalUnitOfWork.ComentsRespository.Delete(coments);
                _internalUnitOfWork.Save();
            }
        }
        //public List<PostViewModel> GetPostID(int id)
        //{
        //    var post = _internalUnitOfWork.PostsRespository.Get();
        //    List<PostViewModel> posts = new List<PostViewModel>();

        //    foreach (var p in post)
        //    {
        //        if (p.ID == id)
        //        {
        //            posts.Add(new PostViewModel {ID = p.ID});
        //        }
        //    }
        //    return posts;
        //}

    }
}
