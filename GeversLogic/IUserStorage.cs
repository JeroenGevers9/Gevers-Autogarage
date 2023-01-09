using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public interface IUserStorage
    {
        User CheckExist(string userName, string passWord);
    }
}
