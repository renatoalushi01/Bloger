using System.Collections.Generic;
using Bloger.DAL.Entities;
using Bloger.Models;

namespace Bloger.IBLL
{
    public interface IComentsServices
    {
        void AddComents(ComentsViewModel coments);
        List<ComentsViewModel> GetComents();
        void Delete(int? id);

    }
}
