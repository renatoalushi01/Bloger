using Bloger.DAL.Entities;
using Bloger.DAL.Persistence;
using System;

namespace Bloger.DAL
{
    public class UnitOfWork : IDisposable
    {
        
        private readonly BlogerDbContext _context = new BlogerDbContext();

        private bool _disposed;

        #region Categories Repository

        private BaseRepository<Category> _categoriesRepository;

        public BaseRepository<Category> CategoryRepository =>
            _categoriesRepository ?? (_categoriesRepository = RepositoryFactory.CreateRepository<Category>(_context));

        #endregion
        #region Posts Repository
        private BaseRepository<Posts> _postsRepository;
        public BaseRepository<Posts> PostsRespository =>
            _postsRepository ?? (_postsRepository = RepositoryFactory.CreateRepository<Posts>(_context));
        #endregion

        private BaseRepository<Post_Category> _postCategoryRespository;
        public BaseRepository<Post_Category> PostCategoryRespozitory =>
            _postCategoryRespository ?? (_postCategoryRespository = RepositoryFactory.CreateRepository<Post_Category>(_context));

        private BaseRepository<Coments> _comentsRespository;
        public BaseRepository<Coments> ComentsRespository =>
        _comentsRespository ?? (_comentsRespository = RepositoryFactory.CreateRepository<Coments>(_context));
        private BaseRepository<AspNetUsers> _userbaseRepository;
        public BaseRepository<AspNetUsers> UserRepository =>
            _userbaseRepository ?? (_userbaseRepository = RepositoryFactory.CreateRepository<AspNetUsers>(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
