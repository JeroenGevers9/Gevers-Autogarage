using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public interface ICarStorage
    {
        bool Create(string brand, string model, decimal price, string constructionYear);
        bool Delete(int id);
        bool Update(string brand, string model, decimal price, string constructionYear);
        List<Accessoire> GetAccessoires();
    }
}
