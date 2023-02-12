using System;
using System.Collections;
using Models;
namespace BusinessLogic
{
    public interface ICrud<T, T1>
    {
        public IList GetAll(int id);


        public bool Add(int id, T obj);


        public bool Delete(int id);


        public bool Update(int id, T1 t1);
    }
}

