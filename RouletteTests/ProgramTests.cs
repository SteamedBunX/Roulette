using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roulette;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Tests
{


    [TestClass()]
    public class ProgramTests
    {
        Program program = new Program();
        [TestInitialize]
        public void Ini()
        {
            
        }

        [TestMethod()]
        public void Is_blackTest()
        {
            Assert.Fail();
        }
    }
}