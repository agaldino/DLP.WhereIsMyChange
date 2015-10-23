using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dlp.WhereIsMyChange.Core.Processors;

namespace Dlp.WhereIsMyChange.Test.UnitTest {
    /// <summary>
    /// Unit tests for processors
    /// </summary>
    [TestClass]
    public class BillProcessorTest {

        [TestMethod]
        public void TestGetAvailableChange() {
            BillProcessor billProcessor = new BillProcessor();
            PrivateObject privateObject = new PrivateObject(billProcessor);
            object availableChange = privateObject.Invoke("GetAvailableChange");

            List<int> availableChangeList = availableChange as List<int>;

            Assert.IsNotNull(availableChangeList);
        }


    }
}
