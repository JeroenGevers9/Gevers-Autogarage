using GeversLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversData
{
    public class RepositoryFactory
    {
        public RepositoryFactory(string server, string database, string userId, string password)
        {
            Server = server;
            Database = database;
            UserId = userId;
            Password = password;
        }

        private string Server { get; }
        private string Database { get; }
        private string UserId { get; }
        private string Password { get; }

        public ICarStorage GetCarStorage()
        {
            return new CarRepository(Server, Database,UserId,Password);
        }

        public IUserStorage GetUserStorage()
        {
            return new UserRepository(Server, Database, UserId, Password);
        }
        public ICompanyStorage GetCompanyStorage()
        {
            return new CompanyRepository(Server, Database, UserId, Password, this.GetCarStorage());
        }
    }
}
