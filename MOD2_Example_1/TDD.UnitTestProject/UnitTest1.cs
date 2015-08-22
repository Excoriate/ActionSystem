using System;
using System.Linq;
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
           
        }


        [TestMethod]
        public void GetAllPersonsBusinessTest()
        {
            var testInstance = new PersonManager();
            var test1 = testInstance.GetAllPersons();

            Assert.IsNotNull(test1);
            Assert.IsTrue(test1.Any());

        }


    }
}
