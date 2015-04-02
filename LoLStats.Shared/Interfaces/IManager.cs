#region References

using System.Collections.Generic;
using LoLStats.Shared.Models.Entities;

#endregion

namespace LoLStats.Shared.Interfaces
{
    public interface IManager<T> where T : Entity
    {
        #region Methods

        T Add(T item);
        T DeleteById(int id);
        T EditById(T item, int id);
        List<T> GetAll();
        T GetOneById(int id);

        #endregion
    }
}