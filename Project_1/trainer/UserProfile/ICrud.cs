using System;
namespace UserProfile
{
    public interface ICrud
    {
        public void Add(int id);
        public void Update(int id);
        public void Delete(int id);
        public void View();
    }
}

