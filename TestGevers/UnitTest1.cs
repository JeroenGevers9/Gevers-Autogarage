using GeversLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGevers
{
    [TestClass]
    public class UnitTest1
    {
        private ICompanyStorage companyStorage;
        private Company company;
        [TestMethod]
        public void TestMethod1()
        {
            this.company = new Company(companyStorage);
        }
    }
}
