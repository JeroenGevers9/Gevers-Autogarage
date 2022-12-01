using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public interface IUserStorage
    {
        bool CheckExist(string userName, string passWord);
    }
}
