using Dlp.WhereIsMyChange.Core.Log;
using Dlp.WhereIsMyChange.Core.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Test.UnitTest {

    [TestClass]
    public class LogUnitTest {

        [TestMethod]
        public void TestFileLog() {

            IConfigurationUtility configurationUtility = new Mock.ConfigurationUtility();

            AbstractLog log = FileLog.GetInstance(configurationUtility);

            log.Log("aaaaaaaaaaaaaaaaaaaaa", Core.Enums.LogTypeEnum.Information);

        }
    }
}
