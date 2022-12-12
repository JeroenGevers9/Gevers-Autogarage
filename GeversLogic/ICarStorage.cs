using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public interface ICarStorage
    {
        Car Read(string brand, string model, string constructionYear);
        bool Create(string brand, string model, decimal price, string constructionYear);
        bool Delete(int id);
        bool Update(string brand, string model, decimal price, string constructionYear);
        List<Accessoire> GetAccessoires();
    }
}
