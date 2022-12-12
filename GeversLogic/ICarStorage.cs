using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public interface ICarStorage
    {
        Car Read(string brand, string model, string constructionYear);
        bool Create(Car car);
        bool Delete(Car car);
        bool Update(Car car);
        List<Accessoire> GetAccessoires();
    }
}
