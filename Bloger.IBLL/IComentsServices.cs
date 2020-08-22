using System.Collections.Generic;
using Bloger.DAL.Entities;
using Bloger.Models;

namespace Bloger.IBLL
{
    public interface IComentsServices
    {
        void AddComents(ComentsViewModel coments);
        List<ComentsViewModel> GetComents(int id);
        void Delete(int? id);

    }
}
