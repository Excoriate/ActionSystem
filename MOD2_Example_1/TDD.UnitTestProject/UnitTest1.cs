using System;
using Backend.Business.RRHH.Module.PersonManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var instancePersonManager = new PersonManager();
            var test = instancePersonManager.GetAllPersons();
        }
    }
}
