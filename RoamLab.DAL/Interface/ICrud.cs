using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.DAL.Interface
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
